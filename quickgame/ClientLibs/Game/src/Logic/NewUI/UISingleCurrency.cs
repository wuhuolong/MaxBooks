using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UISingleCurrency : MonoBehaviour
    {
        public CanvasInfo mCanvasInfo;
        public Button mAddBtn;
        public Image mIconImage;
        public Text mValueText;
        public int mMoneyType = 0;
        public uint mDecimalPlaces = 1;

        public int MoneyType
        {
            set
            {
                if (mMoneyType != value)
                {
                    mMoneyType = value;
                    UpdateUI();
                }
            }
            get
            {
                return mMoneyType;
            }
        }

        void Awake()
        {
            if (mAddBtn != null)
            {
                mAddBtn.onClick.AddListener(OnClickAddBtn);
            }
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_MONEY_UPDATE, OnMoneyUpdate);
        }

        void Start()
        {
            UpdateUI();
        }

        void OnDestroy()
        {
            if (mAddBtn != null)
            {
                mAddBtn.onClick.RemoveAllListeners();
            }
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_MONEY_UPDATE, OnMoneyUpdate);
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

        public void UpdateUI()
        {
            CommonTool.SetActive(gameObject, mMoneyType > 0);
            if (mMoneyType > 0)
            {
                if (mValueText != null)
                {
                    uint money = LocalPlayerManager.Instance.GetMoneyByConst((ushort)mMoneyType);
                    mValueText.text = UIWidgetHelp.GetLargeNumberString3(money, mDecimalPlaces);
                }
                if (mIconImage != null && mCanvasInfo != null)
                {
                    var name = LocalPlayerManager.GetMoneySpriteName(mMoneyType);
                    mIconImage.sprite = mCanvasInfo.LoadSprite(name);
                }
            }
        }

        void OnMoneyUpdate(CEventBaseArgs args)
        {
            UpdateUI();
        }
    }
}