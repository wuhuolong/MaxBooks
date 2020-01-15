using UnityEngine;
using System.Collections;
using xc;

[wxb.Hotfix]
public class MoneyChangeCom : MonoBehaviour
{
    public UIButton BindDiamondBtn { get; set; }
    public UIButton DiamondBtn { get; set; }
    public UIButton GoldBtn { get; set; }
    public UIButton BloodBtn { get; set; }
    public UIButton CoinBtn { get; set; }
    public UIButton BindCoinBtn { get; set; }
    public UIButton StuffBtn { get; set; }
    public UIButton FashionBtn { get; set; }
    public UILabel mGoldLabel { get; set; }
    public UILabel mCoinLabel { get; set; }
    public UILabel mBindCoinLabel { get; set; }
    public UILabel mBloodLabel { get; set; }
    public UILabel mDiamondLabel { get; set; }
    public UILabel mBindDiamondLabel { get; set; }
    public UILabel mStuffLabel { get; set; }
    public UILabel mFashionLabel { get; set; }
    public UILabel mBagGoodsLabel { get; set; }
    public int mBagGoodsGid;
    public xc.ui.UIBaseWindow Wind;
    public string DestroyWindName = string.Empty;
    // Use this for initialization
    void Start()
    {
    
    }


    void Awake()
    {
        if(DiamondBtn != null)
            EventDelegate.Add(DiamondBtn.onClick , OnClickDiamondBtn);
        if(GoldBtn != null)
            EventDelegate.Add(GoldBtn.onClick , OnClickGoldBtn);
        if(BloodBtn != null)
            EventDelegate.Add(BloodBtn.onClick , OnClickBloodBtn);
        if(CoinBtn != null)
            EventDelegate.Add(CoinBtn.onClick , OnClickCoinBtn);
        if(StuffBtn != null)
            EventDelegate.Add(StuffBtn.onClick , OnClickGotoChangeNpcBtn);
        if(FashionBtn != null)
            EventDelegate.Add(FashionBtn.onClick , OnClickGotoChangeNpcBtn);

        if(BindCoinBtn != null)
            EventDelegate.Add(BindCoinBtn.onClick , OnClickBindCoinBtn);
        if(BindDiamondBtn != null)
            EventDelegate.Add(BindDiamondBtn.onClick , OnClickBindDiamondBtn);
        ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_MONEY_UPDATE, OnMoneyUpdate);
        ClientEventMgr.GetInstance().SubscribeClientEvent((int)xc.ClientEvent.CE_BAG_UPDATE, OnBagUpDate);
        OnMoneyUpdate(null);
        OnBagUpDate(null);
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    void OnDestroy()
    {
        if(DiamondBtn != null)
            EventDelegate.Remove(DiamondBtn.onClick , OnClickDiamondBtn);
        if(GoldBtn != null)
            EventDelegate.Remove(GoldBtn.onClick , OnClickGoldBtn);
        if(BloodBtn != null)
            EventDelegate.Remove(BloodBtn.onClick , OnClickBloodBtn);
        if(CoinBtn != null)
            EventDelegate.Remove(CoinBtn.onClick , OnClickCoinBtn);
        if(StuffBtn != null)
            EventDelegate.Remove(StuffBtn.onClick , OnClickGotoChangeNpcBtn);
        if(FashionBtn != null)
            EventDelegate.Remove(FashionBtn.onClick , OnClickGotoChangeNpcBtn);
        if(BindCoinBtn != null)
            EventDelegate.Remove(BindCoinBtn.onClick , OnClickBindCoinBtn);
        if(BindDiamondBtn != null)
            EventDelegate.Remove(BindDiamondBtn.onClick , OnClickBindDiamondBtn);
        ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_BAG_UPDATE, OnBagUpDate);
        ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)xc.ClientEvent.CE_MONEY_UPDATE, OnMoneyUpdate);
    }

    public void SetBtnClickCallBack(UIButton diamond , UIButton gold , UIButton blood , UIButton coin ,  UIButton stuff , UIButton fashion , xc.ui.UIBaseWindow win)
    {
        DiamondBtn = diamond;
        GoldBtn = gold;
        BloodBtn = blood;
        CoinBtn = coin;
        Wind = win;
        StuffBtn = stuff;
        FashionBtn  = fashion;
        if(DiamondBtn != null)
            EventDelegate.Add(DiamondBtn.onClick , OnClickDiamondBtn);
        if(GoldBtn != null)
            EventDelegate.Add(GoldBtn.onClick , OnClickGoldBtn);
        if(BloodBtn != null)
            EventDelegate.Add(BloodBtn.onClick , OnClickBloodBtn);
        if(CoinBtn != null)
            EventDelegate.Add(CoinBtn.onClick , OnClickCoinBtn);
        if(StuffBtn != null)
            EventDelegate.Add(StuffBtn.onClick , OnClickGotoChangeNpcBtn);
        if(FashionBtn != null)
            EventDelegate.Add(FashionBtn.onClick , OnClickGotoChangeNpcBtn);

        if(BindCoinBtn != null)
            EventDelegate.Add(BindCoinBtn.onClick , OnClickBindCoinBtn);
        if(BindDiamondBtn != null)
            EventDelegate.Add(BindDiamondBtn.onClick , OnClickBindDiamondBtn);
    }

    private void CheckGotoRedeemNpc(System.Object param)
    {
        xc.TargetPathManager.Instance.GoToNpcPos(xc.GameConstHelper.GetUint("GAME_MAP_MAIN_ID"), xc.GameConstHelper.GetUint("GAME_MAP_OPERATION_REDEEM_NPC_ID"), null);

        if (DestroyWindName.CompareTo(string.Empty) != 0)
        {
            Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_DESTROY, new Utils.ClientEventParamArgs(DestroyWindName));
        }

    }

    void OnClickGotoChangeNpcBtn()
    {
        xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK , xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_99"), CheckGotoRedeemNpc, null );     
    }

    void OnClickDiamondBtn()
    {
        xc.RouterManager.Instance.GoToPayWnd();
//        if(Wind != null)
//            Wind.Hide();
        if (DestroyWindName.CompareTo(string.Empty) != 0)
        {
            Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_DESTROY, new Utils.ClientEventParamArgs(DestroyWindName));
        }
        else if (Wind != null)
        {
            Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_DESTROY, new Utils.ClientEventParamArgs(DestroyWindName));
        }
    }

    void OnClickBindDiamondBtn()
    {
        xc.RouterManager.Instance.GoToPayWnd();
        //        if(Wind != null)
        //            Wind.Hide();
        if (DestroyWindName.CompareTo(string.Empty) != 0)
        {
            Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_DESTROY, new Utils.ClientEventParamArgs(DestroyWindName));
        }
        else if (Wind != null)
        {
            Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_DESTROY, new Utils.ClientEventParamArgs(DestroyWindName));
        }
    }

    void OnClickGoldBtn()
    {
        xc.RouterManager.Instance.GoToShopWindow();
        if (DestroyWindName.CompareTo(string.Empty) != 0)
        {
            Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_DESTROY, new Utils.ClientEventParamArgs(DestroyWindName));
        }
        else if (Wind != null)
        {
            Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_DESTROY, new Utils.ClientEventParamArgs(DestroyWindName));
        }
    }

    void OnClickBloodBtn()
    {
        xc.RouterManager.Instance.GoToShopWindow();
        if (DestroyWindName.CompareTo(string.Empty) != 0)
        {
            Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_DESTROY, new Utils.ClientEventParamArgs(DestroyWindName));
        }
        else if (Wind != null)
        {
            Utils.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_DESTROY, new Utils.ClientEventParamArgs(DestroyWindName));
        }
    }

    void OnClickCoinBtn()
    {

    }

    void OnClickBindCoinBtn()
    {

    }

    void OnBagUpDate (CEventBaseArgs args)
    {
        if (mBagGoodsGid == 0)
            return;
        if(mBagGoodsLabel != null)
            mBagGoodsLabel.text = xc.ItemManager.GetInstance().GetGoodsNumForBagByTypeId((uint)mBagGoodsGid).ToString();
    }

    void OnMoneyUpdate(CEventBaseArgs args)
    {
//        if (mGoldLabel != null)
//            mGoldLabel.text = "" + xc.LocalPlayerManager.Instance.Gold;
        if (mCoinLabel != null)
            mCoinLabel.text = "" + xc.LocalPlayerManager.Instance.Coin;
//        if (mBloodLabel != null)
//            mBloodLabel.text = "" + xc.LocalPlayerManager.Instance.BloodStone;
        if (mDiamondLabel != null)
            mDiamondLabel.text = "" + xc.LocalPlayerManager.Instance.Diamond;
//        if (mStuffLabel != null)
//            mStuffLabel.text = "" + xc.LocalPlayerManager.Instance.StuffRedeemVoucher;
//        if (mFashionLabel != null)
//            mFashionLabel.text = "" + xc.LocalPlayerManager.Instance.FashionRedeemVoucher;

        if (mBindCoinLabel != null)
            mBindCoinLabel.text = "" + xc.LocalPlayerManager.Instance.BindCoin;
        if (mBindDiamondLabel != null)
            mBindDiamondLabel.text = "" + xc.LocalPlayerManager.Instance.BindDiamond;
    }
}

