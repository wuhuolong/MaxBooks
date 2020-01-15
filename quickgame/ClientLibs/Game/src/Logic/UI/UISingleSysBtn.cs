
/*----------------------------------------------------------------
// 文件名： UISingleSysBtn.cs
// 文件功能描述： 单个系统按钮，左下角和右上角以外的单独按钮可用
//----------------------------------------------------------------*/
using System;
using UnityEngine;
using UnityEngine.UI;
using xc;
using xc.ui.ugui;

[wxb.Hotfix]
public class UISingleSysBtn : MonoBehaviour
{
    public uint mSysId;
    public Button mButton;
    public Image mIcon;
    public Text mName;
    public GameObject mLock;

    void Awake()
    {
    }

    void Start()
    {
        DBSysConfig.SysConfig sysConfig = DBSysConfig.Instance.GetConfigById(mSysId);
        if (sysConfig == null)
        {
            return;
        }

        if (mIcon != null)
        {
            UIBaseWindow mainmapWindow = UIManager.Instance.GetWindow("UIMainmapWindow");
            if (mainmapWindow != null)
            {
                mIcon.sprite = mainmapWindow.LoadSprite(sysConfig.BtnSprite);
            }
        }
        if (mName != null)
        {
            mName.text = sysConfig.BtnText;
        }
        UpdateState();

        if (mButton != null)
        {
            mButton.onClick.AddListener(OnClickButton);
        }
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SYS_CONFIG_INIT, OnSysConfigInit);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SYS_OPEN, OnSysOpen);
    }

    void OnDestroy()
    {
        if (mButton != null)
        {
            mButton.onClick.RemoveAllListeners();
        }
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SYS_CONFIG_INIT, OnSysConfigInit);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SYS_OPEN, OnSysOpen);
    }

    void OnClickButton()
    {
        RouterManager.Instance.GenericGoToSysWindow(mSysId);
    }

    void UpdateState()
    {
        if (mLock != null)
        {
            CommonTool.SetActive(mLock, !SysConfigManager.Instance.CheckSysHasOpened(mSysId));
        }
    }

    void OnSysConfigInit(CEventBaseArgs args)
    {
        UpdateState();
    }

    void OnSysOpen(CEventBaseArgs args)
    {
        UpdateState();
    }
}
