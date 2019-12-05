using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using xc;
using xc.ui;
using Utils;
using Net;
using xc.protocol;

namespace xc.ui.ugui
{
    public class NoticeScroll : IUIBehaviour
    {
        Text mContent;
        RectTransform mClipRect;
        string contentStr = "";
        float DURATION = 10.0f;///飞
        TweenPosition PosTween;
        public override void InitBehaviour()
        {
            mContent = Window.FindChild("ContentText").GetComponent<Text>();
            mClipRect = Window.FindChild("Clip").GetComponent<RectTransform>();
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CHAT_TRUMPET_CONTENT, ContentUpdate);
            base.InitBehaviour();
        }

        void ContentUpdate(CEventBaseArgs evt)
        {
            if (IsEnable == false)
                return;
            contentStr = (string)evt.arg;
            mContent.text = "";
            LayoutRebuilder.ForceRebuildLayoutImmediate(mContent.rectTransform);
            mContent.text = contentStr;
            LayoutRebuilder.ForceRebuildLayoutImmediate(mContent.rectTransform);
            mContent.transform.localPosition = new Vector3(-mClipRect.rect.width / 2 + 1, 0,0);
            if (PosTween != null)
            {
                PosTween.enabled = false;
            }
            int detal = (int)mContent.rectTransform.rect.width - (int)mClipRect.rect.width;
            if (detal > 0)
            {
                mContent.rectTransform.anchoredPosition = new Vector2(-mClipRect.rect.width / 2 + 1, 0);
                PosTween = TweenPosition.Begin(mContent.gameObject, DURATION, new Vector3(-mContent.rectTransform.rect.width - mClipRect.rect.width / 2, 0, 0));
            }
        }

        public override void DestroyBehaviour()
        {
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_CHAT_TRUMPET_CONTENT, ContentUpdate);
            base.DestroyBehaviour();
        }

        public override void EnableBehaviour(bool isEnable)
        {
            mContent.text = "";
            mContent.rectTransform.anchoredPosition = new Vector2(-mClipRect.rect.width / 2 + 1, 0);
            base.EnableBehaviour(isEnable);
        }
    }
}
