//--------------------------------------------------
// File: UIVersionWindow.cs
// Desc: 显示版本号的窗口
// Author: raorui
// Date: 2018.10.23
//--------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace xc.ui.ugui
{
    class UIVersionWindow : UIBaseWindow
    {
        /// <summary>
        /// 显示版本的文本
        /// </summary>
        Text mVersionText;

        /// <summary>
        /// 显示资源版本的文本
        /// </summary>
        Text mResVersionText;


        GameObject mHoriLayout;

        /// <summary>
        /// 健康提示
        /// </summary>
        GameObject mHealthTips;


        //--------------------------------------------------------
        //  构造函数
        //--------------------------------------------------------
        public UIVersionWindow()
        {
            mWndName = "UIVersionWindow";
        }

        //--------------------------------------------------------
        //  虚函数
        //--------------------------------------------------------
        protected override void InitUI()
        {
            base.InitUI();

            mVersionText = FindChild<Text>("VersionText");
            mResVersionText = FindChild<Text>("ResVersionText");

            mHoriLayout = FindChild("HoriLayout");

            mHealthTips = FindChild("HealthTips");

            mHealthTips.SetActive(false);
        }

        protected override void UnInitUI()
        {
            base.UnInitUI();

        }

        protected override void ResetUI()
        {
            base.ResetUI();

            mVersionText.text = "2.0.0";

            string json = DBManager.Instance.LoadDBFile("DB/Common/version.json");
            if (!string.IsNullOrEmpty(json))
            {
                var jsonObj = MiniJSON.JsonDecode(json) as Hashtable;
                if(jsonObj != null)
                {
                    var ver = jsonObj["version"];
                    if(ver != null)
                        mVersionText.text = ver.ToString();
                }
            }
            
            mResVersionText.text = VersionInfoManager.Instance.RemoteVersion;

            if (AuditManager.Instance.AuditAndIOS())
            {
                if (mHoriLayout != null)
                    mHoriLayout.gameObject.SetActive(false);
            }

            if (xc.Const.Region == xc.RegionType.SEASIA) {
                if(xc.Const.Language == xc.LanguageType.VIETNAMESE) {
                    mHealthTips.SetActive(true);
                }
            }

        }

        protected override void HideUI()
        {
            base.HideUI();


        }

        //--------------------------------------------------------
        //  控件消息
        //--------------------------------------------------------
    }
}
