using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using xc;
namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIHudActorWindow : UIBaseWindow
    {
        GameObject mProgressObj;
        GameObject mTextObj;
        Transform mProgressRootTrans;
        Transform mTextRootTrans;

        protected override void InitUI()
        {
            base.InitUI();

            Transform root_trans = mUIObject.transform;
            mProgressRootTrans = root_trans.Find("HeadBar");
            mTextRootTrans = root_trans.Find("HeadText");
            mProgressObj = root_trans.Find("HeadBar/UI3DProgressBar").gameObject;
            mTextObj = root_trans.Find("HeadText/3DText").gameObject;
            mProgressObj.SetActive(false);
            mTextObj.SetActive(false);
        }

        protected override void ResetUI()
        {
            base.ResetUI();
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Destroy()
        {
            base.Destroy();
        }
        
        /// <summary>
        /// 进度条的模版物体
        /// </summary>
        public GameObject ProgressObj
        {
            get
            {
                return mProgressObj;
            }
        }

        /// <summary>
        /// 文本的模版物体
        /// </summary>
        public GameObject TextObj
        {
            get
            {
                return mTextObj;
            }
        }

        /// <summary>
        /// 进度条的跟节点物体
        /// </summary>
        public Transform ProgressRootTrans
        {
            get
            {
                return mProgressRootTrans;
            }
        }

        /// <summary>
        /// 文本的跟节点物体
        /// </summary>
        public Transform TextRootTrans
        {
            get
            {
                return mTextRootTrans;
            }
        }
    }
}
