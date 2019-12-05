using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace xc.ui.ugui
{
    public class LoginNoticeContent
    {
        public bool isMainTitle;//是否使用主标题
        public string title;//标题
        public string content;//内容
    }

    public class LoginNoticeItemInfo
    {
        public GameObject gameobj;
        public int type;//0 没有 1 活动 2 公告
        public bool isNew;//是否是新活动
        public List<LoginNoticeContent> noticeContents = new List<LoginNoticeContent>();//所有活动内容

        public int openType;//打开类型 0 不强制， 1强制
        public int noticeOrder;//排序序号

        public int status;//状态，是否有效0有效 1无效

        public LoginNoticeContent GetMainTitle()
        {
            foreach (var n in noticeContents)
            {
                if (n.isMainTitle)
                {
                    return n;
                }
            }

            return null;
        }

    }

    public class LoginNoticeData
    {
        public List<LoginNoticeItemInfo> allNotice = new List<LoginNoticeItemInfo>();

        public const string LOGIN_ID_KEY = "__loginNoticeIdKey";
        public const int DEFAULT_LOGIN_ID = -1000;

        //public string content = "";
        //public int id = -1;
        public int type = -1;//0普通公告 1强制弹出公告
        public int result = -1;

        private LoginNoticeItemInfo GetItemInfo(int type, bool isNew, List<string> title, List<string> contents, int openType, int status, int noticeOrder)
        {
            var info = new LoginNoticeItemInfo();
            info.type = type;
            info.isNew = isNew;
            info.openType = openType;
            info.status = status;
            info.noticeOrder = noticeOrder;

            for (int i = 0; i < title.Count; i++)
            {
                var content = new LoginNoticeContent();
                var t = title[i];
                var c = contents[i];

                content.content = c;
                content.title = t;
                if (i == 0)
                {
                    content.isMainTitle = true;
                }
                else
                {
                    content.isMainTitle = false;
                }

                info.noticeContents.Add(content);
            }

            return info;
        }


        public bool FromJson(string json)
        {
            GameDebug.LogGreen("解析JSON：" + json);

            Hashtable jsonObj = MiniJSON.JsonDecode(json) as Hashtable;

            if (jsonObj == null || jsonObj["result"] == null)
            {
                result = -1;
                GameDebug.LogError("游戏公告解析失败" + json);
                return false;
            }

            result = int.Parse(jsonObj["result"].ToString());

            if (result != 1)
            {
                result = -1;
                GameDebug.LogError("游戏公告解析失败" + json);
                return false;
            }

            Hashtable args = jsonObj["args"] as Hashtable;

            if (args == null)
            {
                result = -1;
                GameDebug.LogError("游戏公告参数解析失败" + json);
                return false;
            }

            ArrayList notice_list = args["notice_list"] as ArrayList;

            if (notice_list == null)
            {
                GameDebug.LogError("游戏公告解析失败 notice_list  " + json);
                return false;
            }

            this.allNotice.Clear();

            for (int i = 0; i < notice_list.Count; i++)
            {
                var tbl = notice_list[i] as Hashtable;

                int type = 0;

                if (tbl["tag"] != null)
                {
                    type = int.Parse(tbl["tag"].ToString());
                }

                if (type == 0)
                {
                    type = 1;//活动
                }
                else if (type == 1)
                {
                    type = 2;//公告
                }
                else
                {
                    type = 0;
                }


                int openType = 0;

                if (tbl["type"] != null)
                {
                    openType = int.Parse(tbl["type"].ToString());
                }
                
                int status = 1;
                 
                if (tbl["status"] != null)
                {
                    status = int.Parse(tbl["status"].ToString());
                }
                int noticeOrder = 0;
                if (tbl["notice_order"] != null)
                {
                    noticeOrder = int.Parse(tbl["notice_order"].ToString());
                }

                bool isNew = false;
                if (tbl["icon_status"] != null && tbl["icon_status"].ToString() != "null" && (int.Parse(tbl["icon_status"].ToString()) == 1))
                {
                    isNew = true;
                }

                string title = tbl["title"] == null ? "" : tbl["title"].ToString();
                string content = tbl["content"] == null ? "" : tbl["content"].ToString();

                List<string> titles = new List<string>();
                List<string> contents = new List<string>();

                titles.Add(title);
                contents.Add(content);

                if (tbl["sub_content"] != null && tbl["sub_content"] is ArrayList)
                {
                    var subList = tbl["sub_content"] as ArrayList;

                    for (int j = 0; j < subList.Count; j++)
                    {
                        var c = subList[j] as Hashtable;
                        titles.Add(c["title"].ToString());
                        contents.Add(c["content"].ToString());
                    }
                }

                var item = GetItemInfo(type, isNew, titles, contents, openType, status, noticeOrder);

                //无效的不管
                if (item.status != 1)
                {
                    allNotice.Add(item);
                }
            }

            allNotice.Sort(CompareFunc);
            this.type = 0;

            foreach (var notice in allNotice)
            {
                if (notice.openType == 1)
                {
                    this.type = 1;
                }
                else
                {
                    this.type = 0;
                }
            }
            
            return true;
        }

        private int CompareFunc(LoginNoticeItemInfo x, LoginNoticeItemInfo y)
        {

            if (x.noticeOrder < y.noticeOrder)
            {
                return -1;
            }

            return 1;
        }
    }

    [wxb.Hotfix]
    public class UILoginNoticeWindow : UIBaseWindow
    {

        private GameObject itemTemplate;
        private GameObject contentTemplate;

        private Button btnOk;

        private int curIndex = 0;


        private LoginNoticeData data;


        //--------------------------------------------------------
        //  构造函数
        //--------------------------------------------------------
        public UILoginNoticeWindow()
        {
            mWndName = "UILoginNoticeWindow";
        }

        private const string TEMPLATE_NOTICE_ITEM = "TEMPLATE_LOGIN_NOTICE_ITEM";
        private const string TEMPLATE_NOTICE_CONTENT = "TEMPLATE_LOGIN_NOTICE_CONTENT";

        //--------------------------------------------------------
        //  虚函数
        //--------------------------------------------------------
        protected override void InitUI()
        {
            base.InitUI();


            btnOk = FindChild<Transform>("BtnOk").GetComponent<Button>();

            btnOk.onClick.AddListener(OnClickOk);

            itemTemplate = FindChild<Transform>("ItemTemplate").gameObject;
            contentTemplate = FindChild<Transform>("ContentTemplate").gameObject;

            this.AddTemplate(TEMPLATE_NOTICE_CONTENT, contentTemplate);
            this.AddTemplate(TEMPLATE_NOTICE_ITEM, itemTemplate);
            itemTemplate.SetActive(false);
            contentTemplate.SetActive(false);

            //data = new LoginNoticeData();

        }

        private void OnClickOk()
        {

            GameDebug.Log("关闭公告!");

            UIManager.Instance.CloseWindow("UILoginNoticeWindow");

            if (this.fromServerList)
            {
                GameDebug.Log("回调获取服务器列表");
                var window = UIManager.Instance.GetWindow("UIServerListWindow") as UIServerListWindow;
                if (window != null)
                {
                    window.UpdateServerLogic();
                }
            }
        }

        protected override void UnInitUI()
        {
            base.UnInitUI();

            btnOk.onClick.RemoveAllListeners();
        }

        private bool fromServerList = false;

        protected override void ResetUI()
        {
            base.ResetUI();
            UIManager.Instance.ShowWaitScreen(false);

            this.data = this.ShowParam[0] as LoginNoticeData;
            fromServerList = (bool)this.ShowParam[1];
            Debug.Log("from server list " + fromServerList);

            //PlayerPrefs.SetInt(LoginNoticeData.LOGIN_ID_KEY, data.id);


            this.FreeTemplateInstance(TEMPLATE_NOTICE_ITEM);

            if (data.allNotice.Count == 0)
            {
                itemTemplate.transform.parent.gameObject.SetActive(false);
                contentTemplate.transform.parent.gameObject.SetActive(false);
                return;
            }

            itemTemplate.transform.parent.gameObject.SetActive(true);
            contentTemplate.transform.parent.gameObject.SetActive(true);

            for (int i = 0; i < data.allNotice.Count; i++)
            {
                var notice = data.allNotice[i];

                var main = notice.GetMainTitle();

                var gameobj = this.GetTemplateInstance(TEMPLATE_NOTICE_ITEM, this.itemTemplate.transform.parent, true);

                gameobj.transform.Find("Text").GetComponent<Text>().text = main.title;

                gameobj.transform.Find("NewTag").gameObject.SetActive(notice.isNew);

                var tag1 = gameobj.transform.Find("Tag_1");
                var tag2 = gameobj.transform.Find("Tag_2");

                tag1.gameObject.SetActive(false);
                tag2.gameObject.SetActive(false);

                
                if (notice.type == 1)
                {
                    //公告
                    tag1.gameObject.SetActive(true);
                }
                else if (notice.type == 2)
                {
                    //活动
                    tag2.gameObject.SetActive(true);
                }

                notice.gameobj = gameobj;
                gameobj.GetComponent<Button>().onClick.RemoveAllListeners();

                var info = notice;

                var idx = i;

                gameobj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Debug.Log("click info" + idx);
                    this.curIndex = idx;
                    UpdateSelects();
                });
            }

            this.curIndex = 0;

            UpdateSelects();
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(this.itemTemplate.GetComponent<RectTransform>());
        }

        private void UpdateSelects()
        {
            for (int i = 0; i < data.allNotice.Count; i++)
            {
                var gameobj = data.allNotice[i].gameobj;
                gameobj.transform.Find("CheckMark").gameObject.SetActive(i == this.curIndex);
            }

            UpdateContent(data.allNotice[this.curIndex]);
        }

        private void UpdateContent(LoginNoticeItemInfo info)
        {
            this.FreeTemplateInstance(TEMPLATE_NOTICE_CONTENT);

            for (int i = 0; i < info.noticeContents.Count; i++)
            {
                var content = info.noticeContents[i];

                var contentGameObj = this.GetTemplateInstance(TEMPLATE_NOTICE_CONTENT, this.contentTemplate.transform.parent, true);

                var small = contentGameObj.transform.Find("TitleSmall").gameObject;
                var big = contentGameObj.transform.Find("TitleBig").gameObject;

                small.SetActive(false);
                big.SetActive(false);

                if (content.isMainTitle)
                {
                    big.SetActive(true);
                    var bigTxt = big.transform.Find("TxtTitle").GetComponent<Text>();
                    bigTxt.text = UtilHtml.HtmlToText(content.title);
                    LayoutRebuilder.ForceRebuildLayoutImmediate(bigTxt.GetComponent<RectTransform>());
                }
                else
                {
                    small.SetActive(true);
                    var smallTxt = small.transform.Find("Text").GetComponent<Text>();
                    smallTxt.text = UtilHtml.HtmlToText(content.title);
                    LayoutRebuilder.ForceRebuildLayoutImmediate(smallTxt.GetComponent<RectTransform>());
                }

                var contentTxt = contentGameObj.transform.Find("TxtContent").GetComponent<HrefText>();
                contentTxt.text = UtilHtml.HtmlToText(content.content);
                LayoutRebuilder.ForceRebuildLayoutImmediate(contentTxt.GetComponent<RectTransform>());


                contentGameObj.GetComponent<ContentSizeFitterByText>().ResetSize();
                LayoutRebuilder.ForceRebuildLayoutImmediate(contentGameObj.GetComponent<RectTransform>());
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(this.contentTemplate.transform.parent.GetComponent<RectTransform>());

            var rect = this.contentTemplate.transform.parent.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(rect.localPosition.x, 0, rect.localPosition.z);

        }
    }





    //public class UILoginNoticeWindow : UIBaseWindow
    //{
    //    //公告界面
    //    private GameObject mNoticePanel;

    //    private Button mBtnNoticeConfirm;
    //    private Text mTextNoticeContent;
    //    //Button mBtnAnnouncement;

    //    private Button mBtnTestClear;

    //    private bool isGetServerList = false;

    //    //--------------------------------------------------------
    //    //  构造函数
    //    //--------------------------------------------------------
    //    public UILoginNoticeWindow()
    //    {
    //        mWndName = "UILoginNoticeWindow";
    //    }

    //    //--------------------------------------------------------
    //    //  虚函数
    //    //--------------------------------------------------------
    //    protected override void InitUI()
    //    {
    //        base.InitUI();

    //        //公告界面
    //        mNoticePanel = FindChild<Transform>("NoticePanel").gameObject;
    //        mBtnNoticeConfirm = FindChild<Transform>("btnNoticeConfirm").gameObject.GetComponent<Button>();

    //        mBtnNoticeConfirm.onClick.AddListener(onClickNoticeConfirm);

    //        mTextNoticeContent = FindChild<Transform>("txtNoticeContent").gameObject.GetComponent<Text>();

    //        var btnTestGameobj = FindChild<Transform>("btnTestClear");
    //        if (btnTestGameobj != null)
    //        {
    //            mBtnTestClear = btnTestGameobj.gameObject.GetComponent<Button>();

    //            mBtnTestClear.onClick.AddListener(onClickTestClear);
    //        }
    //        mNoticePanel.SetActive(false);
    //    }

    //    //for test
    //    private void onClickTestClear()
    //    {
    //        PlayerPrefs.DeleteKey(LoginNoticeData.LOGIN_ID_KEY);
    //    }

    //    private void onClickNoticeConfirm()
    //    {
    //        GameDebug.Log("关闭公告!");

    //        UIManager.Instance.CloseWindow("UILoginNoticeWindow");

    //        if (this.fromServerList)
    //        {
    //            GameDebug.Log("回调获取服务器列表");
    //            var window = UIManager.Instance.GetWindow("UIServerListWindow") as UIServerListWindow;
    //            if (window != null)
    //            {
    //                window.UpdateServerLogic();
    //            }
    //        }
    //    }

    //    protected override void UnInitUI()
    //    {
    //        base.UnInitUI();

    //        mBtnNoticeConfirm.onClick.RemoveAllListeners();

    //        if (mBtnTestClear != null)
    //        {
    //            mBtnTestClear.onClick.RemoveAllListeners();
    //        }
    //    }

    //    private bool fromServerList = false;

    //    protected override void ResetUI()
    //    {
    //        base.ResetUI();
    //        UIManager.Instance.ShowWaitScreen(false);

    //        LoginNoticeData data = this.ShowParam[0] as LoginNoticeData;
    //        fromServerList = (bool)this.ShowParam[1];
    //        Debug.Log("from server list " + fromServerList);

    //        PlayerPrefs.SetInt(LoginNoticeData.LOGIN_ID_KEY, data.id);

    //        this.mNoticePanel.SetActive(true);

    //        mTextNoticeContent.text = UtilHtml.HtmlToText(data.content);

    //        GameDebug.Log("show uiloginnoticewindow");
    //    }
    //}
}