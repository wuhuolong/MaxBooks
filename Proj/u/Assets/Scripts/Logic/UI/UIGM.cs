using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using X.Res;

public class UIGM : UIWindows
{
    //private string btnPath = "Prefabs/UI/GMbtn.Prefab";
    public GameObject m_BtnGo;
    public RectTransform content;
    private List<GMItem> _gmlist = new List<GMItem>() {
        new GMItem(GMController.ClearAcount,5,"清空账号数据"),
        new GMItem(GMController.PassAllStage,4,"通关所有关卡"),
    };
    private GMItem curItem;
    private List<UIGMBtnItem> m_btns;
    public InputField[] inputs;
    //private static int maxinputs = 7;
    protected override void InitComp()
    {
        //初始化UI组件
        //inputs = new InputField[maxinputs];
        m_btns = new List<UIGMBtnItem>();
        for (int i =0;i<_gmlist.Count;i++)
        {
            GameObject btn = GameObject.Instantiate(m_BtnGo, content);//ResMgr.LoadGameObject(btnPath);
            btn.SetActive(true);
            UIGMBtnItem item = new UIGMBtnItem();
            item.Btn_Obj = btn;
            item.Item_Data = _gmlist[i];
            item.Init();
            item.Show();
            m_btns.Add(item);
            //GMbtn btnCS = btn.GetComponent<GMbtn>();
            //btn.transform.SetParent(content,false);
            //btnCS.InitGM();
            //btnCS.SetItem(_gmlist[i]);
        }
    }

    protected override void InitData()
    {
        //把数据填充到组件中
    }


    private void OnEnable()
    {
        UIEvent.RegEvent(UIEvent.UI_GM_SELECTED, SetCurItem);
    }
    private void OnDisable()
    {
        UIEvent.UnRegEvent(UIEvent.UI_GM_SELECTED, SetCurItem);
    }

    public void OnClickClose()
    {
        UIMgr.GetInstance().Pop();
    }

    public void OnBtnClick()
    {
        for (int i = 0; i < curItem.ParamCount; i++)
        {
            curItem.ParamObjs[i] = inputs[i].text;
        }
        GMController.ReceiveGM(curItem);
    }
    public void SetCurItem(params object[] param)
    {
        curItem = param[0] as GMItem;
        InitInputField();
    }
    public void InitInputField()
    {
        for(int i=0;i< inputs.Length;i++)
        {
            if (i< curItem.ParamCount)
            {
                inputs[i].gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
                inputs[i].gameObject.GetComponent<CanvasGroup>().interactable = true;
            }
            else
            {
                inputs[i].gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
                inputs[i].gameObject.GetComponent<CanvasGroup>().interactable = false;
            }
        }
    }
}
public class UIGMBtnItem
{
    public GameObject Btn_Obj;
    public GMItem Item_Data;

    private Text m_text;
    public void Init()
    {
        m_text = Btn_Obj.transform.Find("Text").GetComponent<Text>();
        Btn_Obj.transform.GetComponent<Button>().onClick.AddListener(BtnFunc);
    }
    public void Show()
    {
        m_text.text = Item_Data.FuncName;

    }
    private void BtnFunc()
    {
        UIEvent.Broadcast(UIEvent.UI_GM_SELECTED, Item_Data);
    }
}
public class GMItem
{
    public GMItem(int func, int count,string funcname)
    {
        ParamCount = count;
        Func = func;
        ParamObjs = new object[ParamCount];
        FuncName = funcname;
    }
    public int ParamCount;
    public int Func;
    public string FuncName;
    public object[] ParamObjs;
}
public static class GMController
{
    public static int ClearAcount = 0;
    public static int PassAllStage = 1;

    public static void ReceiveGM(GMItem item)
    {
        switch (item.Func)
        {
            case 0:
                ClearAcount_Func(item.ParamObjs);
                break;
            case 1:
                PassAllStage_Func(item.ParamObjs);
                break;
            default:
                break;
        }
    }
    private static void ClearAcount_Func(object[] objs)
    {
        Debug.Log("clear");
        XPlayerPrefs.DeleteAll();
        XPlayerPrefs.Save();
    }

    private static void PassAllStage_Func(object[] objs)
    {
        Debug.Log("pass");
        //string numAllStar = "numAllStar";
        string isUnlock = "isUnlock";
        string isCompleted = "isCompleted";
        //string numStar = "numStar";
        LevelConfig_ARRAY m_config = LevelMgr.GetInstance().GetLevelConfigArray();
        for(int i=0;i<m_config.Items.Count;i++)
        {
            string id = m_config.Items[i].LevelId.ToString();

            //设置关卡解锁状态
            XPlayerPrefs.SetInt(id + isUnlock, -1);
            XPlayerPrefs.SetInt(id + isCompleted, 1);

            ////设置当前关卡星星
            //int preStar = XPlayerPrefs.GetInt(id + numStar);
            //XPlayerPrefs.SetInt(id + numStar, 3);

            ////设置总星星数量
            //int curNum = XPlayerPrefs.GetInt(numAllStar);
            //XPlayerPrefs.SetInt(numAllStar, curNum + 3 - preStar);

        }
        //保存
        XPlayerPrefs.Save();
    }
}
