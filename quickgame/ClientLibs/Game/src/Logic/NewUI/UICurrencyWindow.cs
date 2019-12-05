using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UICurrencyWindow : MonoBehaviour
    {
        #region UIMoneyItem
        class UIMoneyItem
        {
            CanvasInfo mCanvasInfo;

            Button mAddBtn;
            Image mIconImage;
            Text mValueText;

            int mMoneyType;
            GameObject mGo;

            public void Init(int moneyType, GameObject go, CanvasInfo canvasInfo)
            {
                mGo = go;
                mCanvasInfo = canvasInfo;
                mMoneyType = moneyType;


                mAddBtn = UIHelper.FindChildInHierarchy(go.transform, "AddBtn").GetComponent<Button>();
                mIconImage = UIHelper.FindChildInHierarchy(go.transform, "IconImage").GetComponent<Image>();
                mValueText = UIHelper.FindChildInHierarchy(go.transform, "ValueText").GetComponent<Text>();

                InitEvent();
                Update();
            }

            public void Update()
            {
                uint money = LocalPlayerManager.Instance.GetMoneyByConst((ushort)mMoneyType);
                //if (money <= 99999)
                //{
                //    mValueText.text = string.Format("{0}", money);
                //}
                //else
                //{
                //    money = money / 10000;
                //    mValueText.text = string.Format("{0}万", money);
                //}
                mValueText.text = UIWidgetHelp.GetLargeNumberString3(money);

                var name = LocalPlayerManager.GetMoneySpriteName(mMoneyType);
                mIconImage.sprite = mCanvasInfo.LoadSprite(name);
            }

            void InitEvent()
            {
                mAddBtn.onClick.AddListener(OnClickAddBtn);
            }

            void OnClickAddBtn()
            {
                // 如果是金锭则直接弹出充值界面
                if (mMoneyType == GameConst.MONEY_DIAMOND)
                {
                    RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_CHARGE);
                }
                else
                {
                    UIManager.Instance.ShowWindow("UIGoodsGetWayWindow", mMoneyType);
                }
            }
        }
        #endregion


        Transform mMoneyListPanel;
        Transform mMoneyItemTemplate;
        List<int> mMoneyTypeList = null;
        List<UIMoneyItem> mUIMoneyItemList = new List<UIMoneyItem>();
        CanvasInfo mCanvasInfo;

        public void SetMoneyList(List<int> moneyTypeList)
        {
            mMoneyTypeList = moneyTypeList;
        }


        void Awake()
        {
            mMoneyItemTemplate = UIHelper.FindChildInHierarchy(transform, "MoneyItemTemplate");
            mMoneyItemTemplate.gameObject.SetActive(false);

            mMoneyListPanel = UIHelper.FindChildInHierarchy(transform, "MoneyListPanel");
            mCanvasInfo = gameObject.GetComponent<CanvasInfo>();

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_MONEY_UPDATE, OnMoneyUpdate);
        }

        void OnDestroy()
        {
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_MONEY_UPDATE, OnMoneyUpdate);
        }

        void Start()
        {
            for (int i = 0; i < mMoneyTypeList.Count; i++)
            {
                var moneyType = mMoneyTypeList[i];

                var trans = GameObject.Instantiate(mMoneyItemTemplate);
                trans.SetParent(mMoneyListPanel);
                trans.gameObject.SetActive(true);
                trans.localScale = Vector3.one;
                trans.localPosition = Vector3.zero;
                trans.localRotation = Quaternion.identity;

                var item = new UIMoneyItem();
                item.Init(moneyType, trans.gameObject, mCanvasInfo);
                mUIMoneyItemList.Add(item);
            }

            var layoutGroup = mMoneyListPanel.GetComponent<GridLayoutGroup>();
            layoutGroup.CalculateLayoutInputHorizontal();
        }

        void OnMoneyUpdate(CEventBaseArgs args)
        {
            for (int i = 0; i < mUIMoneyItemList.Count; i++)
            {
                mUIMoneyItemList[i].Update();
            }
        }
    }
}