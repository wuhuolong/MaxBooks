using System;
using System.Collections;
using UnityEngine;
namespace xc.ui
{
    public class UIWildSwitchLineWaiting:MonoBehaviour
    {
        public UILabel labelMsg { get; set; }
        public UIButton buttonExit { get; set; }

        public static UIWildSwitchLineWaiting Instance;
        public static readonly string mPrefabName = "UIWildSwitchLineWaiting";


        private void Awake()
        {
            Instance = this;
        }

        public static void Show(string name,int num)
        {
            UIManager.Instance.UIMain.StartCoroutine(CoShow(name, num));
        }

        static IEnumerator CoShow(string name,int num)
        {
            yield return UIManager.Instance.UIMain.StartCoroutine(UIManager.Instance.ShowWindow("UIWildSwitchLineWaiting"));
            Instance.labelMsg.text = string.Format(xc.DBConstText.GetText("SWITCH_LINE_WAITING_TIP"), name, num);
        }

        public void OnExit()
        {
            UIManager.Instance.HideWindow<UIWildSwitchLineWaiting>();
        }
    }
}

