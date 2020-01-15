using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xc.ui.ugui;

namespace xc.debug
{
    public class DebugBasePanel
    {
        protected DebugWindow debug;
        public bool isShow = false;
        protected GameObject panel;

        public virtual void Update()
        {

        }

        public DebugBasePanel(GameObject panel, DebugWindow debug)
        {
            this.panel = panel;
            this.debug = debug;

            OnLoadFinish();
            panel.SetActive(false);
        }

        public UICacheManager cache
        {
            get {
                return debug.cache;
            }
        }


        protected virtual void OnLoadFinish()
        {
        }

        public void Show()
        {
            if (isShow) return;
            isShow = true;
            panel.SetActive(true);
            OnShowPanel();

            this.panel.GetComponent<RectTransform>().localPosition += new Vector3(0.0001f, 0f);

        }

        protected virtual void OnShowPanel()
        {
        }

        public void Hide()
        {
            if (!isShow) return;
            isShow = false;
            panel.SetActive(false);
            OnHidePanel();
        }

        public void Destroy()
        {
            OnDestroy();
        }

        protected virtual void OnDestroy()
        {
        }

        protected virtual void OnHidePanel()
        {
        }
    }
}
