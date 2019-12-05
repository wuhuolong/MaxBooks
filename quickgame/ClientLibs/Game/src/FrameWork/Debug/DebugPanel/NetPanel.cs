using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using PackData = xc.PackRecorder.PackData;
namespace xc.debug
{
    public class NetPanel : DebugBasePanel
    {

        private class NetPool
        {
            private List<NetMetaInfo> list = new List<NetMetaInfo>();

            public void Free(NetMetaInfo info)
            {
                info.obj = null;
                info.data = null;
            }

            public NetMetaInfo Get()
            {
                if (list.Count > 0)
                {
                    var info = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    return info;
                }
                else
                {
                    return new NetMetaInfo();
                }
            }
        }

        private class NetMetaInfo
        {
            public PackData data;
            public GameObject obj;
        }

        private const int MAX_COUNT = 100;
        private NetPool pool;
        private List<NetMetaInfo> logList;

        private int scrollFrameCount = 0;
        private bool needScrollToBottom = false;

        private Button btnCopy;

        private GameObject logTemplate;
        private GameObject btnClear;
        private GameObject btnStart;
        private GameObject btnStop;
        private Image recording;
        private ScrollRect scrollRect;

        private const string TEMPLATE_ITEM_STR = "DEBUG_NET_PANEL_LOG_TEMPLATE";


        public NetPanel(GameObject panel, DebugWindow debug) : base(panel, debug)
        {

        }

        private void ScrollToBottom()
        {
            needScrollToBottom = true;
            scrollFrameCount = 0;
        }

        public void PushLog(PackData data)
        {
            FreeLogList();

            NetMetaInfo info = pool.Get();
            info.data = data;

            logList.Add(info);

            if (isShow)
            {
                AddTemplate(info, logList.Count - 1);
            }
        }
        private const string HEADER = "---------------------------\n";

        private void AddTemplate(NetMetaInfo info, int index)
        {
            if (info.obj != null) return;

            var gameobj = cache.GetTemplate(TEMPLATE_ITEM_STR, logTemplate.transform.parent, true);

            var text = gameobj.GetComponent<Text>();

            GetPrintStr(info, text);

            gameobj.transform.SetSiblingIndex(index);

            info.obj = gameobj;

            if (scrollRect.verticalNormalizedPosition < 0.1f)
            {
                ScrollToBottom();
            }
        }

        private string GetPrintStr(NetMetaInfo info, Text text = null)
        {
            string str = "";
            if (info.data.PackType == PackData.EPackType.Recv)
            {
                str = String.Format("{0}recv protocol => {1}\n{2}", HEADER, info.data.Protocol, info.data.GetJson());
                if (text)
                {
                    text.color = Color.yellow;
                }
                
            }
            else
            {
                str = String.Format("{0}send protocol => {1}\n{2}", HEADER, info.data.Protocol, info.data.GetJson());
                if (text)
                {
                    text.color = Color.green;
                }
                
            }

            if (text)
            {
                text.text = str;
            }

            return str;

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
            base.OnDestroy();
        }

        protected override void OnHidePanel()
        {
            base.OnHidePanel();
        }


        protected override void OnLoadFinish()
        {
            pool = new NetPool();
            logList = new List<NetMetaInfo>();

            logTemplate = panel.transform.Find("ScrollView/Viewport/Content/ItemTemplate").gameObject;

            scrollRect = panel.transform.Find("ScrollView").GetComponent<ScrollRect>();


            logTemplate.SetActive(false);

            btnClear = panel.transform.Find("BtnClear").gameObject;

            btnClear.GetComponent<Button>().onClick.AddListener(() =>
            {
                ClearAllLogs();
            });

            btnStart = panel.transform.Find("BtnStart").gameObject;
            btnStart.GetComponent<Button>().onClick.AddListener(() =>
            {
                StartLog();
            });

            btnStop = panel.transform.Find("BtnStop").gameObject;
            btnStop.GetComponent<Button>().onClick.AddListener(() =>
            {
                StopLog();
            });


            btnCopy = panel.transform.Find("BtnCopy").GetComponent<Button>();
            btnCopy.onClick.AddListener(() =>
            {
                StringBuilder builder = new StringBuilder();
                foreach (var info in logList)
                {
                    builder.AppendLine(GetPrintStr(info));
                }

                EditorInterface.CopyToClipboard(builder.ToString());
            });

            recording = panel.transform.Find("Recording").GetComponent<Image>();

            this.cache.AddTemplate(TEMPLATE_ITEM_STR, logTemplate);
        }

        private void UpdateRecording()
        {
            
            recording.color = xc.Game.Instance.PackRecorder.Pause ? Color.red : Color.green;
        }

        private void StopLog()
        {
            xc.Game.Instance.PackRecorder.Pause = true;
            UpdateRecording();
        }

        private void StartLog()
        {
            xc.Game.Instance.PackRecorder.Pause = false;
            UpdateRecording();
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
            xc.Game.Instance.PackRecorder.Clear();
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
            UpdateRecording();
        }

    }
}

