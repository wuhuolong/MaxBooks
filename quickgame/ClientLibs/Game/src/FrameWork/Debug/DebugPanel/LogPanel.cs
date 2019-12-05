using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace xc.debug
{
    public class LogPanel : DebugBasePanel
    {

        private class LogPool
        {
            private List<LogMetaInfo> list = new List<LogMetaInfo>();

            public void Free(LogMetaInfo info)
            {
                info.obj = null;
            }

            public LogMetaInfo Get()
            {
                if (list.Count > 0)
                {
                    var info = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    return info;
                } else
                {
                    return new LogMetaInfo();
                }
            }
        }

        private class LogMetaInfo
        {
            public string info;
            public GameObject obj;
            public LogType type;
        }

        private const int MAX_COUNT = 100;
        private LogPool pool;
        private List<LogMetaInfo> logList;

        private int scrollFrameCount = 0;
        private bool needScrollToBottom = false;

        private Button btnCopy;

        private GameObject logTemplate;
        private GameObject btnClear;

        private ScrollRect scrollRect;

        private const string TEMPLATE_ITEM_STR = "DEBUG_LOG_PANEL_LOG_TEMPLATE";


        public LogPanel(GameObject panel, DebugWindow debug) : base(panel, debug)
        {

        }

        private void ScrollToBottom()
        {
            needScrollToBottom = true;
            scrollFrameCount = 0;
        }

        private void OnLog(string condition, string stackTrace, LogType type)
        {
            if (type == LogType.Log)
            {
                PushLog(System.String.Format("{0}", condition), type);
            }
            
            if (type == LogType.Assert || type == LogType.Error || type == LogType.Exception)
            {
                PushLog(System.String.Format("[{0}] {1}", type.ToString(), condition), type);
                PushLog("-------------------Call Stack:------------------", type);
                string[] lines = stackTrace.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                foreach (string l in lines)
                {
                    PushLog(l, type);
                }
                PushLog("------------------------------------------------", type);
            }
        }

        public void PushLog(string v, LogType type = LogType.Log)
        {
            FreeLogList();

            LogMetaInfo info = pool.Get();
            info.info = v;
            info.type = type;

            logList.Add(info);

            if (isShow)
            {
                AddTemplate(info, logList.Count - 1);
            }
        }


        private void AddTemplate(LogMetaInfo info, int index)
        {
            if (info.obj != null) return;

            var gameobj = cache.GetTemplate(TEMPLATE_ITEM_STR, logTemplate.transform.parent, true);

            var text = gameobj.GetComponent<Text>();
            text.text = info.info;
            if (info.type == LogType.Log)
            {
                text.color = Color.green;
            }
            else
            {
                text.color = Color.yellow;
            }

            gameobj.transform.SetSiblingIndex(index);

            info.obj = gameobj;

            if (scrollRect.verticalNormalizedPosition < 0.1f)
            {
                ScrollToBottom();
            }
        }

        public override void Update()
        {
            base.Update();

            if (needScrollToBottom)
            {
                scrollFrameCount++;
                if (scrollFrameCount > 5)
                {
                    needScrollToBottom = false;

                    scrollRect.verticalNormalizedPosition = 0f;

                }
            }
        }


        private void FreeLogList()
        {
            if (logList.Count < MAX_COUNT) return;

            var info = logList[0];

            if (info.obj != null)
            {
                cache.FreeTemplate(TEMPLATE_ITEM_STR, info.obj);
            }

            pool.Free(info);

            logList.RemoveAt(0);
        }

        protected override void OnDestroy()
        {
            Application.logMessageReceived -= OnLog;
            base.OnDestroy();
        }

        protected override void OnHidePanel()
        {
            base.OnHidePanel();
        }


        protected override void OnLoadFinish()
        {
            pool = new LogPool();
            logList = new List<LogMetaInfo>();
            logTemplate = panel.transform.Find("ScrollView/Viewport/Content/ItemTemplate").gameObject;

            scrollRect = panel.transform.Find("ScrollView").GetComponent<ScrollRect>();


            logTemplate.SetActive(false);

            btnClear = panel.transform.Find("BtnClear").gameObject;

            btnClear.GetComponent<Button>().onClick.AddListener(() =>
            {
                ClearAllLogs();
            });

            btnCopy = panel.transform.Find("BtnCopy").GetComponent<Button>();
            btnCopy.onClick.AddListener(() =>
            {
                StringBuilder builder = new StringBuilder();
                foreach (var info in logList)
                {
                    builder.AppendLine(info.info);
                }

                EditorInterface.CopyToClipboard(builder.ToString());
            });

            this.cache.AddTemplate(TEMPLATE_ITEM_STR, logTemplate);


            Application.logMessageReceived += OnLog;
        }

        private void ClearAllLogs()
        {
            foreach (var info in logList)
            {
                if (info.obj != null)
                {
                    cache.FreeTemplate(TEMPLATE_ITEM_STR, info.obj);
                }
                info.obj = null;
            }

            for (int i = logList.Count - 1; i >= 0; i--)
            {
                var info = logList[i];
                pool.Free(info);
            }

            logList.Clear();
        }

        protected override void OnShowPanel()
        {
            base.OnShowPanel();

            this.ScrollToBottom();

            for (int i = 0; i < logList.Count; i++)
            {
                var info = logList[i];

                if (info.obj == null)
                {
                    this.AddTemplate(info, i);
                }
                else
                {
                    info.obj.transform.SetSiblingIndex(i);
                }
            }

            

        }

    }
}

