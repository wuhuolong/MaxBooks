using SafeCoroutine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;
using wxb;

namespace xc.ui.ugui
{
	[Hotfix]
	public class UIMainMapSysOpenBehaviour : IUIBehaviour
	{
		private List<GameObject> mSysBtnRootList = new List<GameObject>();

		private GameObject mSysBtnObj;

		private GameObject mTRSysBtnObj;

		private GameObject mRightSysBtnObj;

		private Vector2 mAnchorMin = new Vector2(0f, 1f);

		private Vector2 mAnchorMax = new Vector2(0f, 1f);

		private GameObject mLBSysBtns;

		private List<DBSysConfig.SysConfig> mLBSysConfigs = new List<DBSysConfig.SysConfig>();

		private Dictionary<uint, UISysConfigBtn> mLBSysBtnsDic = new Dictionary<uint, UISysConfigBtn>();

		private Dictionary<uint, uint> mExpandableSysBtnsDic = new Dictionary<uint, uint>();

		private GameObject mLbSysBtnTotalRed;

		private GameObject mTRSysBtnRoot;

		private List<DBSysConfig.SysConfig> mTRSysConfigs = new List<DBSysConfig.SysConfig>();

		private Dictionary<uint, UISysConfigBtn> mTRSysBtnsDic = new Dictionary<uint, UISysConfigBtn>();

		private GameObject mTRPackUpBtnRedPoint;

		private GameObject mRightSysBtns;

		private GameObject mBagRedPoint;

		private List<DBSysConfig.SysConfig> mRightSysConfigs = new List<DBSysConfig.SysConfig>();

		private Dictionary<uint, UISysConfigBtn> mRightSysBtnsDic = new Dictionary<uint, UISysConfigBtn>();

		public Dictionary<uint, Dictionary<uint, bool>> AllSysRedPoint = new Dictionary<uint, Dictionary<uint, bool>>();

		private Coroutine mPlayOpenSysRoutine = null;

		private float SYS_OPEN_BTN_FLY_DURATION = 1.5f;

		private float SYS_OPEN_BTN_TR_DURATION = 0.3f;

		private float SYS_OPEN_BTN_LB_DURATION = 0.4f;

		private float SYS_OPEN_BTN_RIGHT_DURATION = 0.3f;

		private float SYS_OPEN_BTN_FLY_END_DURATION = 0.5f;

		private float SYS_WAIT_DURATION = 10f;

		private GameObject mLBWaitSysBtnObj;

		private GameObject mTRWaitSysBtnObj;

		private GameObject mRightWaitSysBtnObj;

		private Vector2 mLBWaitSysBtnPos;

		private Vector2 mTRWaitSysBtnPos;

		private Vector2 mRightWaitSysBtnPos;

		private GameObject m_IconpanelObj;

		private GameObject m_WaitBgObj;

		private CameraCurveShake m_Shake;

		private GameObject m_WaitMaskObj;

		private Timer WaitTimer;

		private Button SysPanelButton;

		private Vector3 mOpenScale = new Vector3(0.67f, 0.67f, 1f);

		private bool mStart = false;

		public bool IsSysOpenPlaying
		{
			get
			{
				return this.mStart;
			}
		}

		public override void InitBehaviour()
		{
			base.InitBehaviour();
			this.mSysBtnObj = this.Window.FindChild("SysBtnObj");
			this.mTRSysBtnObj = this.Window.FindChild("TRSysBtnObj");
			this.mRightSysBtnObj = this.Window.FindChild("RightSysBtnObj");
			this.mSysBtnObj.SetActive(false);
			this.mTRSysBtnObj.SetActive(false);
			this.mRightSysBtnObj.SetActive(false);
			this.mLBSysBtns = this.Window.FindChild("LBSysBtns");
			this.mTRSysBtnRoot = this.Window.FindChild("TRSysBtns");
			this.mRightSysBtns = this.Window.FindChild("RightSysBtns");
			this.mBagRedPoint = this.Window.FindChild("BagRedPoint");
			this.mSysBtnRootList.Clear();
			this.mSysBtnRootList.Add(this.mLBSysBtns);
			this.mSysBtnRootList.Add(this.mTRSysBtnRoot);
			this.mSysBtnRootList.Add(this.mRightSysBtns);
			this.mLbSysBtnTotalRed = this.Window.FindChild("BLPackUpBtnRedPoint");
			this.mLbSysBtnTotalRed.SetActive(true);
			this.mTRPackUpBtnRedPoint = this.Window.FindChild("TRPackUpBtnRedPoint");
			this.mTRPackUpBtnRedPoint.SetActive(true);
			this.m_IconpanelObj = this.Window.FindChild("IconPanel");
			this.mLBWaitSysBtnObj = this.m_IconpanelObj.get_transform().Find("LBWaitSysBtn").get_gameObject();
			this.mTRWaitSysBtnObj = this.m_IconpanelObj.get_transform().Find("TRWaitSysBtn").get_gameObject();
			this.mRightWaitSysBtnObj = this.m_IconpanelObj.get_transform().Find("RightWaitSysBtn").get_gameObject();
			this.mLBWaitSysBtnPos = this.mLBWaitSysBtnObj.GetComponent<RectTransform>().get_anchoredPosition();
			this.mTRWaitSysBtnPos = this.mTRWaitSysBtnObj.GetComponent<RectTransform>().get_anchoredPosition();
			this.mRightWaitSysBtnPos = this.mRightWaitSysBtnObj.GetComponent<RectTransform>().get_anchoredPosition();
			this.mLBWaitSysBtnObj.get_transform().Find("SysBtn").Find("Text").GetComponent<Text>().set_text("");
			this.mTRWaitSysBtnObj.get_transform().Find("SysBtn").Find("Text").GetComponent<Text>().set_text("");
			this.mRightWaitSysBtnObj.get_transform().Find("SysBtn").Find("Text").GetComponent<Text>().set_text("");
			this.mLBWaitSysBtnObj.SetActive(false);
			this.mTRWaitSysBtnObj.SetActive(false);
			this.mRightWaitSysBtnObj.SetActive(false);
			this.SysPanelButton = this.Window.FindChild("SysPanel").GetComponent<Button>();
			this.m_WaitBgObj = UIHelper.FindChild(this.SysPanelButton.get_gameObject(), "BgPanel");
			this.m_Shake = UIHelper.FindChild(this.m_WaitBgObj, "EF_UI_gongxihuode_03").GetComponent<CameraCurveShake>();
			this.m_WaitMaskObj = UIHelper.FindChild(this.SysPanelButton.get_gameObject(), "WaitMask");
			this.SysPanelButton.get_gameObject().SetActive(false);
			this.SysPanelButton.get_onClick().AddListener(new UnityAction(this.OnClickSysOpenBtn));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(117, new ClientEventMgr.ClientEventFunc(this.OnNewWaitingSysEvent));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(447, new ClientEventMgr.ClientEventFunc(this.OnNewWaitingSysEvent));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(486, new ClientEventMgr.ClientEventFunc(this.OnNewWaitingSysEvent));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(488, new ClientEventMgr.ClientEventFunc(this.OnNewWaitingSysEvent));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(120, new ClientEventMgr.ClientEventFunc(this.OnSysRealOpen));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(124, new ClientEventMgr.ClientEventFunc(this.OnSysRealClose));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(107, new ClientEventMgr.ClientEventFunc(this.OnClickPackUpBtn));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(102, new ClientEventMgr.ClientEventFunc(this.OnMainmapTRSysBtnChange));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(116, new ClientEventMgr.ClientEventFunc(this.OnSysOpenListUpdate));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(17, new ClientEventMgr.ClientEventFunc(this.OnNetReconnect));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(479, new ClientEventMgr.ClientEventFunc(this.OnActivityStateChange));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(135, new ClientEventMgr.ClientEventFunc(this.OnNewRedpointShow));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(483, new ClientEventMgr.ClientEventFunc(this.OnActivityStateChange));
			List<DBSysConfig.SysConfig> allSysConfig = Singleton<DBManager>.Instance.GetDB<DBSysConfig>().GetAllSysConfig();
			int num;
			for (int i = 0; i < allSysConfig.Count; i = num + 1)
			{
				DBSysConfig.SysConfig sysConfig = allSysConfig[i];
				Dictionary<uint, bool> dictionary;
				bool flag = this.AllSysRedPoint.TryGetValue(sysConfig.MainMapSysBtnId, out dictionary);
				if (flag)
				{
					bool flag2 = !dictionary.ContainsKey(sysConfig.Id);
					if (flag2)
					{
						this.AllSysRedPoint[sysConfig.MainMapSysBtnId].Add(sysConfig.Id, false);
					}
				}
				else
				{
					dictionary = new Dictionary<uint, bool>();
					dictionary.Add(sysConfig.Id, false);
					this.AllSysRedPoint.Add(sysConfig.MainMapSysBtnId, dictionary);
				}
				switch (sysConfig.Pos)
				{
				case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
					this.mLBSysConfigs.Add(sysConfig);
					break;
				case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
					this.mTRSysConfigs.Add(sysConfig);
					break;
				case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
					this.mRightSysConfigs.Add(sysConfig);
					break;
				}
				bool flag3 = Const.Region == 1;
				if (flag3)
				{
					bool flag4 = sysConfig.DropDown.Count > 0 && sysConfig.DropDownType == 1u;
					if (flag4)
					{
						List<uint> parentIds = new List<uint>
						{
							sysConfig.Id
						};
						DBRedPoint dB = Singleton<DBManager>.Instance.GetDB<DBRedPoint>();
						foreach (uint current in sysConfig.DropDown)
						{
							bool flag5 = this.mExpandableSysBtnsDic.ContainsKey(current);
							if (!flag5)
							{
								this.mExpandableSysBtnsDic.Add(current, sysConfig.Id);
								dB.AddRedPointData(current, parentIds);
							}
						}
					}
				}
				num = i;
			}
			RectTransform component = this.mLBSysBtns.GetComponent<RectTransform>();
			float num2 = 112f;
			GridLayoutGroup component2 = component.GetComponent<GridLayoutGroup>();
			bool flag6 = component2 != null;
			if (flag6)
			{
				num2 = component2.get_cellSize().x;
			}
			CanvasScaler component3 = this.Window.mUIObject.GetComponent<CanvasScaler>();
			float num3 = component3.get_referenceResolution().x;
			bool flag7 = component3.get_matchWidthOrHeight() == 1f;
			if (flag7)
			{
				num3 = (float)Screen.get_width() * component3.get_referenceResolution().y / (float)Screen.get_height();
			}
			Vector2 sizeDelta = component.get_sizeDelta();
			sizeDelta.x = num3 - num2;
			component.set_sizeDelta(sizeDelta);
			this.InitCreateSysBtn(this.mLBSysConfigs, ref this.mLBSysBtnsDic, this.mLBSysBtns, 0);
			this.InitCreateSysBtn(this.mTRSysConfigs, ref this.mTRSysBtnsDic, this.mTRSysBtnRoot, 1);
			this.InitCreateSysBtn(this.mRightSysConfigs, ref this.mRightSysBtnsDic, this.mRightSysBtns, 2);
		}

		public override void DestroyBehaviour()
		{
			base.DestroyBehaviour();
			this.mSysBtnRootList.Clear();
			this.mLBSysBtnsDic.Clear();
			this.mLBSysConfigs.Clear();
			this.mTRSysBtnsDic.Clear();
			this.mTRSysConfigs.Clear();
			this.mRightSysBtnsDic.Clear();
			this.mRightSysConfigs.Clear();
			this.mExpandableSysBtnsDic.Clear();
			Singleton<GuideManager>.Instance.ResetEnableRef();
			bool flag = this.mPlayOpenSysRoutine != null;
			if (flag)
			{
				this.mPlayOpenSysRoutine.Stop();
				this.mPlayOpenSysRoutine = null;
			}
			bool flag2 = this.WaitTimer != null;
			if (flag2)
			{
				this.WaitTimer.Destroy();
				this.WaitTimer = null;
			}
			this.mStart = false;
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(117, new ClientEventMgr.ClientEventFunc(this.OnNewWaitingSysEvent));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(447, new ClientEventMgr.ClientEventFunc(this.OnNewWaitingSysEvent));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(486, new ClientEventMgr.ClientEventFunc(this.OnNewWaitingSysEvent));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(120, new ClientEventMgr.ClientEventFunc(this.OnSysRealOpen));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(124, new ClientEventMgr.ClientEventFunc(this.OnSysRealClose));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(107, new ClientEventMgr.ClientEventFunc(this.OnClickPackUpBtn));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(102, new ClientEventMgr.ClientEventFunc(this.OnMainmapTRSysBtnChange));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(116, new ClientEventMgr.ClientEventFunc(this.OnSysOpenListUpdate));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(17, new ClientEventMgr.ClientEventFunc(this.OnNetReconnect));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(479, new ClientEventMgr.ClientEventFunc(this.OnActivityStateChange));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(135, new ClientEventMgr.ClientEventFunc(this.OnNewRedpointShow));
			Singleton<ClientEventMgr>.Instance.UnsubscribeClientEvent(483, new ClientEventMgr.ClientEventFunc(this.OnActivityStateChange));
		}

		public override void EnableBehaviour(bool isEnable)
		{
			base.EnableBehaviour(isEnable);
			this.mStart = false;
			bool isEnable2 = this.IsEnable;
			if (isEnable2)
			{
				bool flag = this.mPlayOpenSysRoutine != null;
				if (flag)
				{
					this.mPlayOpenSysRoutine.Stop();
					this.mPlayOpenSysRoutine = null;
				}
				bool flag2 = this.WaitTimer != null;
				if (flag2)
				{
					this.WaitTimer.Destroy();
					this.WaitTimer = null;
				}
				this.SysPanelButton.get_gameObject().SetActive(false);
				this.InitSysBtnState(this.mLBSysConfigs, this.mLBSysBtnsDic);
				this.InitSysBtnState(this.mTRSysConfigs, this.mTRSysBtnsDic);
				this.InitSysBtnState(this.mRightSysConfigs, this.mRightSysBtnsDic);
				bool flag3 = Singleton<SysConfigManager>.Instance.IsWaiting();
				if (flag3)
				{
					bool flag4 = Singleton<SceneHelp>.Instance.IsInWildInstance(0u);
					if (flag4)
					{
						Singleton<TargetPathManager>.Instance.StopPlayerAndReset(true, true);
						this.OnNewWaitingSysEvent(null);
					}
					else
					{
						Singleton<ClientEventMgr>.GetInstance().PostEvent(117, new CEventBaseArgs());
					}
				}
			}
		}

		private void OnClickPackUpBtn(CEventBaseArgs evt)
		{
			bool flag = !this.IsEnable || evt == null || evt.arg == null;
			if (!flag)
			{
				bool flag2 = (bool)evt.arg;
				bool flag3 = flag2;
				if (flag3)
				{
					this.mLbSysBtnTotalRed.SetActive(false);
				}
				else
				{
					this.mLbSysBtnTotalRed.SetActive(true);
				}
			}
		}

		private void OnMainmapTRSysBtnChange(CEventBaseArgs param)
		{
			bool flag = !this.IsEnable || param == null;
			if (!flag)
			{
				bool flag2 = param.arg == null;
				if (!flag2)
				{
					bool active = (bool)param.arg;
					this.mTRPackUpBtnRedPoint.SetActive(active);
				}
			}
		}

		private void OnSysOpenListUpdate(CEventBaseArgs args)
		{
			bool flag = !this.IsEnable;
			if (!flag)
			{
				this.EnableBehaviour(true);
			}
		}

		private void OnSysRealOpen(CEventBaseArgs args)
		{
			bool flag = !this.IsEnable;
			if (!flag)
			{
				bool flag2 = args.arg != null;
				if (flag2)
				{
					DBSysConfig.SysConfig sysConfig = args.arg as DBSysConfig.SysConfig;
					bool flag3 = true;
					bool hideBtnWhenActNotOpen = sysConfig.HideBtnWhenActNotOpen;
					if (hideBtnWhenActNotOpen)
					{
						bool flag4 = !ActivityHelper.GetActivityInfo<bool>(sysConfig.Id, "IsOpen");
						if (flag4)
						{
							flag3 = false;
						}
					}
					bool flag5 = flag3;
					if (flag5)
					{
						UISysConfigBtn confingBtn = this.GetConfingBtn(sysConfig);
						bool flag6 = confingBtn != null;
						if (flag6)
						{
							confingBtn.set_IsDynamicShow(true);
							confingBtn.SetSysBtnState(3);
							RectTransform btnRoot = this.GetBtnRoot(sysConfig);
							bool flag7 = btnRoot != null;
							if (flag7)
							{
								LayoutRebuilder.ForceRebuildLayoutImmediate(btnRoot);
							}
						}
					}
				}
			}
		}

		private void OnSysRealClose(CEventBaseArgs args)
		{
			bool flag = !this.IsEnable;
			if (!flag)
			{
				bool flag2 = args.arg != null;
				if (flag2)
				{
					DBSysConfig.SysConfig config = args.arg as DBSysConfig.SysConfig;
					UISysConfigBtn confingBtn = this.GetConfingBtn(config);
					bool flag3 = confingBtn != null;
					if (flag3)
					{
						confingBtn.SetSysBtnState(0);
						RectTransform btnRoot = this.GetBtnRoot(config);
						bool flag4 = btnRoot != null;
						if (flag4)
						{
							LayoutRebuilder.ForceRebuildLayoutImmediate(btnRoot);
						}
					}
				}
			}
		}

		private void OnNewWaitingSysEvent(CEventBaseArgs args)
		{
			bool flag = !this.IsEnable;
			if (!flag)
			{
				this.TryToStartToPlayWaitingBtn();
			}
		}

		public void OnNetReconnect(CEventBaseArgs args)
		{
			bool flag = !this.IsEnable;
			if (!flag)
			{
				foreach (GameObject current in this.mSysBtnRootList)
				{
					RectTransform component = current.GetComponent<RectTransform>();
					bool flag2 = component != null;
					if (flag2)
					{
						LayoutRebuilder.ForceRebuildLayoutImmediate(component);
					}
				}
				foreach (KeyValuePair<uint, UISysConfigBtn> current2 in this.mTRSysBtnsDic)
				{
					bool flag3 = current2.Value.m_FixedPos == 2 && current2.Value.IsRedPointShow();
					if (flag3)
					{
						TweenAlpha component2 = current2.Value.Btn.GetComponent<TweenAlpha>();
						bool flag4 = component2 != null;
						if (flag4)
						{
							component2.set_value(1f);
						}
						TweenPosition component3 = current2.Value.Btn.GetComponent<TweenPosition>();
						bool flag5 = component3 != null;
						if (flag5)
						{
							component3.set_value(new Vector3(0f, 0f, 0f));
						}
					}
				}
			}
		}

		private void OnActivityStateChange(CEventBaseArgs args)
		{
			bool flag = !this.IsEnable;
			if (!flag)
			{
				bool flag2 = args.arg == null;
				if (!flag2)
				{
					uint sys_id = 0u;
					uint.TryParse(args.arg.ToString(), out sys_id);
					DBSysConfig.SysConfig configById = DBSysConfig.Instance.GetConfigById(sys_id);
					bool flag3 = configById == null;
					if (!flag3)
					{
						bool flag4 = false;
						bool flag5 = Singleton<SysConfigManager>.Instance.CheckSysHasOpenIgnoreActivity(sys_id);
						if (flag5)
						{
							bool activityInfo = ActivityHelper.GetActivityInfo<bool>(configById.Id, "IsOpen");
							flag4 = (activityInfo || !configById.HideBtnWhenActNotOpen);
						}
						UISysConfigBtn confingBtn = this.GetConfingBtn(configById);
						bool flag6 = confingBtn == null;
						if (!flag6)
						{
							bool flag7 = flag4;
							if (flag7)
							{
								confingBtn.set_IsDynamicShow(true);
								confingBtn.SetSysBtnState(3);
							}
							else
							{
								confingBtn.SetSysBtnState(0);
							}
							RectTransform btnRoot = this.GetBtnRoot(configById);
							bool flag8 = btnRoot != null;
							if (flag8)
							{
								LayoutRebuilder.ForceRebuildLayoutImmediate(btnRoot);
							}
						}
					}
				}
			}
		}

		private void OnNewRedpointShow(CEventBaseArgs args)
		{
			bool flag = args == null || args.arg == null;
			if (!flag)
			{
				string s = (string)args.arg;
				uint num = 0u;
				bool flag2 = !uint.TryParse(s, out num);
				if (!flag2)
				{
					foreach (KeyValuePair<uint, UISysConfigBtn> current in this.mTRSysBtnsDic)
					{
						bool flag3 = num == current.Value.UIMainBtnId;
						if (flag3)
						{
							TweenAlpha component = current.Value.Btn.GetComponent<TweenAlpha>();
							bool flag4 = component != null;
							if (flag4)
							{
								component.set_value(1f);
							}
							TweenPosition component2 = current.Value.Btn.GetComponent<TweenPosition>();
							bool flag5 = component2 != null;
							if (flag5)
							{
								component2.set_value(new Vector3(0f, 0f, 0f));
							}
						}
					}
				}
			}
		}

		private void OnClickSysOpenBtn()
		{
			bool flag = this.mPlayOpenSysRoutine != null;
			if (!flag)
			{
				this.mPlayOpenSysRoutine = CoroutineManager.StartCoroutine(this.PlayOpenSysAnimRoutine());
			}
		}

		private void OnClickBtn(params object[] param)
		{
			bool flag = !this.IsEnable;
			if (!flag)
			{
				bool flag2 = param != null && param.Length != 0;
				if (flag2)
				{
					DBSysConfig.SysConfig sysConfig = param[0] as DBSysConfig.SysConfig;
					bool flag3 = sysConfig.DropDown != null && sysConfig.DropDown.Count > 0;
					if (flag3)
					{
						GameObject gameObject = param[1] as GameObject;
						Singleton<RouterManager>.Instance.GenericGoToSysWindow(sysConfig.Id, new object[]
						{
							gameObject
						});
					}
					else
					{
						Singleton<RouterManager>.Instance.GenericGoToSysWindow(sysConfig.Id, new object[0]);
					}
				}
			}
		}

		public void TryToStartToPlayWaitingBtn()
		{
			bool flag = this.mPlayOpenSysRoutine != null;
			if (!flag)
			{
				List<DBSysConfig.SysConfig> allWaitingSysList = Singleton<SysConfigManager>.Instance.GetAllWaitingSysList();
				bool flag2 = allWaitingSysList.Count <= 0;
				if (!flag2)
				{
					bool flag3 = Singleton<TimelineManager>.Instance.IsPlaying();
					if (!flag3)
					{
						allWaitingSysList.Sort();
						DBSysConfig.SysConfig sysConfig = allWaitingSysList[0];
						bool flag4 = sysConfig.NeedAnim && sysConfig.MainMapSysBtnId != 24u;
						if (flag4)
						{
							bool flag5 = !sysConfig.IsWaitingSystem || sysConfig.IsWaitFinished;
							if (flag5)
							{
								Singleton<ClientEventMgr>.GetInstance().FireEvent(125, new CEventBaseArgs(sysConfig.Id));
								this.SysPanelButton.get_gameObject().SetActive(true);
								this.SetWaitSysBtn(sysConfig);
								GameObject gameObject = null;
								switch (sysConfig.Pos)
								{
								case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
									gameObject = this.mLBWaitSysBtnObj;
									break;
								case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
									gameObject = this.mTRWaitSysBtnObj;
									break;
								case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
									gameObject = this.mRightWaitSysBtnObj;
									break;
								}
								gameObject.get_transform().Find("SysBtn").Find("Text").get_gameObject().SetActive(false);
								this.mStart = true;
								bool flag6 = this.WaitTimer != null;
								if (flag6)
								{
									this.WaitTimer.Destroy();
									this.WaitTimer = null;
								}
								float num = this.SYS_WAIT_DURATION * 1000f;
								this.WaitTimer = new Timer(num, false, num, delegate(float dt)
								{
									bool flag8 = this.mPlayOpenSysRoutine == null;
									if (flag8)
									{
										this.OnClickSysOpenBtn();
									}
								});
							}
						}
						else
						{
							Singleton<SysConfigManager>.GetInstance().OpenSys(sysConfig, true);
							GameDebug.LogRed("waiting_sys_list.count:" + allWaitingSysList.Count);
							bool flag7 = allWaitingSysList.Count > 0;
							if (flag7)
							{
								this.OnClickSysOpenBtn();
							}
						}
					}
				}
			}
		}

		private void SetWaitSysBtn(DBSysConfig.SysConfig config)
		{
			this.SysPanelButton.get_gameObject().SetActive(true);
			GameObject gameObject = null;
			switch (config.Pos)
			{
			case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
				gameObject = this.mLBWaitSysBtnObj;
				break;
			case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
				gameObject = this.mTRWaitSysBtnObj;
				break;
			case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
				gameObject = this.mRightWaitSysBtnObj;
				break;
			}
			gameObject.SetActive(true);
			Image component = gameObject.get_transform().Find("SysBtn").Find("SysIcon").GetComponent<Image>();
			Text component2 = UIHelper.FindChild(this.m_WaitBgObj, "BgTitleText").GetComponent<Text>();
			component2.set_text(config.BtnText);
			Text component3 = UIHelper.FindChild(this.m_WaitBgObj, "WaitSysText").GetComponent<Text>();
			component3.set_text(config.Desc);
			this.m_Shake.set_enabled(true);
			bool flag = this.Window != null;
			if (flag)
			{
				component.set_sprite(this.Window.LoadSprite(config.BtnSprite));
			}
		}

		private IEnumerator PlayOpenSysAnimRoutine()
		{
			yield return new SafeWaitForSeconds(0f);
			Singleton<GuideManager>.Instance.Pause();
			while (true)
			{
				bool flag = Singleton<TimelineManager>.Instance.IsPlaying();
				if (flag)
				{
					break;
				}
				List<DBSysConfig.SysConfig> list = Singleton<SysConfigManager>.Instance.GetAllWaitingSysList();
				GameDebug.LogRed("waiting_sys_list.count:" + list.Count);
				bool flag2 = list == null || list.Count <= 0;
				if (flag2)
				{
					goto Block_4;
				}
				DBSysConfig.SysConfig sysConfig = list[0];
				bool flag3 = !sysConfig.NeedAnim || Singleton<SysConfigManager>.Instance.SkipSysOpen;
				if (flag3)
				{
					this.ResetWaitSysBtn(sysConfig.Pos);
					this.m_WaitBgObj.SetActive(true);
					this.m_WaitMaskObj.GetComponent<Image>().set_color(Color.get_white());
					this.SysPanelButton.get_gameObject().SetActive(false);
					Singleton<SysConfigManager>.GetInstance().OpenSys(sysConfig, true);
				}
				else
				{
					UISysConfigBtn uISysConfigBtn = this.GetConfingBtn(sysConfig);
					GameObject gameObject = null;
					switch (sysConfig.Pos)
					{
					case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
						gameObject = this.mLBWaitSysBtnObj;
						break;
					case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
						gameObject = this.mTRWaitSysBtnObj;
						break;
					case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
						gameObject = this.mRightWaitSysBtnObj;
						break;
					}
					bool flag4 = uISysConfigBtn == null;
					if (flag4)
					{
						gameObject.SetActive(true);
						this.m_WaitBgObj.SetActive(true);
						this.m_WaitMaskObj.GetComponent<Image>().set_color(Color.get_white());
						gameObject.get_transform().set_localPosition(Vector3.get_zero());
						gameObject.get_transform().set_localScale(Vector3.get_one());
						this.SysPanelButton.get_gameObject().SetActive(false);
						Singleton<SysConfigManager>.GetInstance().OpenSys(sysConfig, true);
					}
					else
					{
						this.SetWaitSysBtn(sysConfig);
						this.mStart = true;
						switch (sysConfig.Pos)
						{
						case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
							Singleton<ClientEventMgr>.GetInstance().FireEvent(128, new CEventBaseArgs("LBRect"));
							yield return new SafeWaitForSeconds(this.SYS_OPEN_BTN_LB_DURATION);
							break;
						case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
							Singleton<ClientEventMgr>.GetInstance().FireEvent(128, new CEventBaseArgs("TRRect"));
							yield return new SafeWaitForSeconds(this.SYS_OPEN_BTN_TR_DURATION);
							break;
						case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
							yield return new SafeWaitForSeconds(this.SYS_OPEN_BTN_RIGHT_DURATION);
							break;
						}
						Vector3 vector = this.GetWillOpenPosition(uISysConfigBtn);
						uISysConfigBtn.GetComponent<RectTransform>().set_anchoredPosition(vector);
						Vector3 vector2 = uISysConfigBtn.get_transform().get_position();
						this.ResetWaitSysBtn(sysConfig.Pos);
						this.m_WaitBgObj.SetActive(false);
						this.m_WaitMaskObj.GetComponent<Image>().set_color(Color.get_clear());
						gameObject.SetActive(true);
						GameObject gameObject2 = gameObject.get_transform().Find("SysBtn").Find("Text").get_gameObject();
						gameObject2.SetActive(true);
						gameObject2.GetComponent<Text>().set_text(sysConfig.BtnText);
						TweenPosition.Begin(gameObject, this.SYS_OPEN_BTN_FLY_DURATION, vector2, true);
						GameDebug.LogRed("[PlayOpenSysAnimRoutine]SYS_OPEN_BTN_FLY_DURATION");
						yield return new SafeWaitForSeconds(this.SYS_OPEN_BTN_FLY_DURATION * 0.85f);
						bool flag5 = uISysConfigBtn.CurrentState == null && !sysConfig.InitNeedShow;
						if (flag5)
						{
							uISysConfigBtn.SetSysBtnState(2);
						}
						RectTransform rectTransform = this.GetBtnRoot(sysConfig);
						bool flag6 = rectTransform != null;
						if (flag6)
						{
							LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
						}
						yield return new SafeWaitForSeconds(this.SYS_OPEN_BTN_FLY_DURATION * 0.15f);
						Singleton<SysConfigManager>.GetInstance().OpenSys(sysConfig, true);
						gameObject2.SetActive(false);
						this.ResetWaitSysBtn(sysConfig.Pos);
						this.m_Shake.set_enabled(false);
						this.m_WaitBgObj.SetActive(true);
						this.m_WaitMaskObj.GetComponent<Image>().set_color(Color.get_white());
						this.SysPanelButton.get_gameObject().SetActive(false);
						uISysConfigBtn.set_IsDynamicShow(true);
						uISysConfigBtn.SetSysBtnState(3);
						yield return new SafeWaitForSeconds(this.SYS_OPEN_BTN_FLY_END_DURATION);
						list = null;
						sysConfig = null;
						uISysConfigBtn = null;
						gameObject = null;
						vector = default(Vector3);
						vector2 = default(Vector3);
						gameObject2 = null;
						rectTransform = null;
					}
				}
			}
			this.ResetAllWaitSysBtns();
			this.m_WaitBgObj.SetActive(true);
			this.m_WaitMaskObj.GetComponent<Image>().set_color(Color.get_white());
			this.SysPanelButton.get_gameObject().SetActive(false);
			this.mPlayOpenSysRoutine = null;
			this.mStart = false;
			bool flag7 = this.WaitTimer != null;
			if (flag7)
			{
				this.WaitTimer.Destroy();
				this.WaitTimer = null;
			}
			Singleton<GuideManager>.Instance.Resume();
			yield break;
			Block_4:
			this.ResetAllWaitSysBtns();
			this.m_WaitBgObj.SetActive(true);
			this.m_WaitMaskObj.GetComponent<Image>().set_color(Color.get_white());
			this.SysPanelButton.get_gameObject().SetActive(false);
			Singleton<GuideManager>.Instance.Resume();
			this.mPlayOpenSysRoutine = null;
			this.mStart = false;
			Singleton<ClientEventMgr>.GetInstance().FireEvent(126, null);
			yield break;
		}

		private void ResetAllWaitSysBtns()
		{
			this.ResetWaitSysBtn(DBSysConfig.ESysBtnPos.SYS_LBBTN_POS);
			this.ResetWaitSysBtn(DBSysConfig.ESysBtnPos.SYS_TRBTN_POS);
			this.ResetWaitSysBtn(DBSysConfig.ESysBtnPos.SYS_RIGHT_POS);
		}

		private void ResetWaitSysBtn(DBSysConfig.ESysBtnPos btnPos)
		{
			GameObject gameObject = null;
			switch (btnPos)
			{
			case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
				gameObject = this.mLBWaitSysBtnObj;
				break;
			case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
				gameObject = this.mTRWaitSysBtnObj;
				break;
			case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
				gameObject = this.mRightWaitSysBtnObj;
				break;
			}
			gameObject.get_transform().SetParent(this.m_IconpanelObj.get_transform());
			switch (btnPos)
			{
			case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
				gameObject.GetComponent<RectTransform>().set_anchoredPosition(this.mLBWaitSysBtnPos);
				break;
			case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
				gameObject.GetComponent<RectTransform>().set_anchoredPosition(this.mTRWaitSysBtnPos);
				break;
			case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
				gameObject.GetComponent<RectTransform>().set_anchoredPosition(this.mRightWaitSysBtnPos);
				break;
			}
			gameObject.SetActive(false);
			gameObject.get_transform().set_localScale(Vector3.get_one());
		}

		private RectTransform GetBtnRoot(DBSysConfig.SysConfig config)
		{
			RectTransform result = null;
			switch (config.Pos)
			{
			case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
				result = this.mLBSysBtns.GetComponent<RectTransform>();
				break;
			case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
			{
				Transform transform = this.mTRSysBtnRoot.get_transform().Find(config.SubPos.ToString());
				bool flag = transform != null;
				if (flag)
				{
					result = transform.GetComponent<RectTransform>();
				}
				else
				{
					GameDebug.LogError(string.Format("GetBtnRoot获取子节点为空, id: {0}, sub_pos: {1}", config.Id, config.SubPos));
				}
				break;
			}
			case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
				result = this.mRightSysBtns.GetComponent<RectTransform>();
				break;
			}
			return result;
		}

		public Vector3 GetWillOpenPosition(UISysConfigBtn config_btn)
		{
			bool flag = config_btn.Param != null && config_btn.Param.Length != 0;
			Vector3 result;
			if (flag)
			{
				DBSysConfig.SysConfig sysConfig = config_btn.Param[0] as DBSysConfig.SysConfig;
				bool flag2 = sysConfig != null;
				if (flag2)
				{
					RectTransform btnRoot = this.GetBtnRoot(sysConfig);
					bool flag3 = btnRoot != null;
					if (flag3)
					{
						float num = 112f;
						float num2 = 112f;
						float num3 = 0f;
						float num4 = 0f;
						GridLayoutGroup component = btnRoot.GetComponent<GridLayoutGroup>();
						uint num5 = 0u;
						bool flag4 = component != null;
						if (flag4)
						{
							num = component.get_cellSize().x;
							num2 = component.get_cellSize().y;
							num3 = component.get_spacing().x;
							num4 = component.get_spacing().y;
							bool flag5 = num + num3 > 0f;
							if (flag5)
							{
								num5 = (uint)(btnRoot.get_sizeDelta().x / (num + num3));
							}
						}
						Vector3 zero = Vector3.get_zero();
						switch (sysConfig.Pos)
						{
						case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
						{
							uint num6 = 0u;
							foreach (UISysConfigBtn current in this.mLBSysBtnsDic.Values)
							{
								bool flag6 = current.CurrentState == 0;
								if (!flag6)
								{
									bool flag7 = current.m_SortIndex < config_btn.m_SortIndex;
									if (flag7)
									{
										uint num7 = num6;
										num6 = num7 + 1u;
									}
								}
							}
							uint num8 = num6 % num5;
							uint num9 = num6 / num5;
							zero.y = (-0.5f + num9) * num2 + num4 * num9;
							bool flag8 = num9 > 0u;
							if (flag8)
							{
								zero.x = (-0.5f + num5 - num8) * num + num3 * (num5 - num8);
							}
							else
							{
								zero.x = (0.5f + num8) * num + num3 * num8;
							}
							break;
						}
						case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
						{
							uint num10 = 0u;
							foreach (UISysConfigBtn current2 in this.mTRSysBtnsDic.Values)
							{
								bool flag9 = current2.CurrentState == 0;
								if (!flag9)
								{
									bool flag10 = current2.m_SubPos != sysConfig.SubPos;
									if (!flag10)
									{
										bool flag11 = current2.m_SortIndex < config_btn.m_SortIndex;
										if (flag11)
										{
											uint num7 = num10;
											num10 = num7 + 1u;
										}
									}
								}
							}
							uint num11 = num10 % num5;
							uint num12 = num10 / num5;
							zero.x = (0.5f + num11) * num + num3 * num11;
							zero.x = btnRoot.get_rect().get_width() - zero.x;
							zero.y = (-0.5f - num12) * num2 - num4 * num12;
							break;
						}
						case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
						{
							uint num13 = 0u;
							foreach (UISysConfigBtn current3 in this.mRightSysBtnsDic.Values)
							{
								bool flag12 = current3.CurrentState == 0;
								if (!flag12)
								{
									bool flag13 = current3.m_SortIndex < config_btn.m_SortIndex;
									if (flag13)
									{
										uint num7 = num13;
										num13 = num7 + 1u;
									}
								}
							}
							zero.x = (0.5f + num13) * num + num3 * num13;
							zero.x = btnRoot.get_rect().get_width() - zero.x;
							zero.y = -num2 * 0.5f;
							break;
						}
						}
						GameDebug.LogRed("[GetOpenPosition]btn_pos: " + zero.ToString());
						result = zero;
						return result;
					}
				}
			}
			GameDebug.LogError("[GetOpenPosition]Position is invaild");
			result = Vector3.get_zero();
			return result;
		}

		public void InitSysBtnState(List<DBSysConfig.SysConfig> configs, Dictionary<uint, UISysConfigBtn> dic)
		{
			using (Dictionary<uint, UISysConfigBtn>.Enumerator enumerator = dic.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<uint, UISysConfigBtn> kv = enumerator.Current;
					bool flag = AuditManager.get_Instance().ContainShieldSId(kv.Key);
					if (flag)
					{
						kv.Value.SetSysBtnState(0);
					}
					else
					{
						List<DBSysConfig.SysConfig> list = configs.FindAll((DBSysConfig.SysConfig config) => config.MainMapSysBtnId == kv.Key);
						bool flag2 = false;
						bool flag3 = list != null;
						if (flag3)
						{
							int num;
							for (int i = 0; i < list.Count; i = num + 1)
							{
								DBSysConfig.SysConfig sysConfig = list[i];
								uint sysIdClosePresent = sysConfig.SysIdClosePresent;
								bool flag4 = Singleton<SysConfigManager>.GetInstance().CheckSysHasOpened(sysConfig.Id);
								if (flag4)
								{
									bool hideBtnWhenActNotOpen = sysConfig.HideBtnWhenActNotOpen;
									if (hideBtnWhenActNotOpen)
									{
										bool activityInfo = ActivityHelper.GetActivityInfo<bool>(sysConfig.Id, "IsOpen");
										if (activityInfo)
										{
											bool flag5 = sysIdClosePresent == 0u || !Singleton<SysConfigManager>.GetInstance().CheckSysHasOpened(sysIdClosePresent);
											if (flag5)
											{
												flag2 = true;
												break;
											}
										}
									}
									else
									{
										bool flag6 = sysIdClosePresent == 0u || !Singleton<SysConfigManager>.GetInstance().CheckSysHasOpened(sysIdClosePresent);
										if (flag6)
										{
											flag2 = true;
											break;
										}
									}
								}
								num = i;
							}
						}
						DBSysConfig.SysConfig firstMainId = Singleton<DBManager>.Instance.GetDB<DBSysConfig>().GetFirstMainId(kv.Key);
						bool flag7 = firstMainId != null && (firstMainId.Id == 70u || firstMainId.Id == 71u || firstMainId.Id == 72u);
						if (flag7)
						{
							bool flag8 = flag2;
							if (flag8)
							{
								bool flag9 = ActivityHelper.IsActivityOpen(232u, false);
								if (flag9)
								{
									flag2 = false;
								}
							}
						}
						bool flag10 = !flag2;
						if (flag10)
						{
							bool flag11 = firstMainId == null;
							if (flag11)
							{
								kv.Value.SetSysBtnState(0);
							}
							else
							{
								bool flag12 = firstMainId.InitNeedShow && !firstMainId.HideBtnWhenActNotOpen;
								if (flag12)
								{
									kv.Value.SetSysBtnState(1);
								}
								else
								{
									kv.Value.SetSysBtnState(0);
								}
							}
						}
						else
						{
							kv.Value.set_IsDynamicShow(true);
							kv.Value.SetSysBtnState(3);
						}
					}
				}
			}
		}

		public UISysConfigBtn CreateConfigBtn(DBSysConfig.SysConfig config, Transform parent_trans, uint sort_index)
		{
			bool flag = config == null;
			UISysConfigBtn result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = config.MainMapSysBtnId == 24u;
				if (flag2)
				{
					result = null;
				}
				else
				{
					Vector3 one = Vector3.get_one();
					GameObject gameObject;
					byte b;
					switch (config.Pos)
					{
					case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
						gameObject = Object.Instantiate<GameObject>(this.mSysBtnObj);
						b = 0;
						break;
					case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
						gameObject = Object.Instantiate<GameObject>(this.mTRSysBtnObj);
						b = 1;
						break;
					case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
						gameObject = Object.Instantiate<GameObject>(this.mRightSysBtnObj);
						b = 2;
						break;
					default:
						gameObject = Object.Instantiate<GameObject>(this.mTRSysBtnObj);
						b = 1;
						break;
					}
					RectTransform component = gameObject.GetComponent<RectTransform>();
					component.set_anchorMin(this.mAnchorMin);
					component.set_anchorMax(this.mAnchorMax);
					gameObject.get_transform().SetParent(parent_trans);
					gameObject.get_transform().set_localScale(one);
					gameObject.get_transform().set_localPosition(Vector3.get_zero());
					UISysConfigBtn uISysConfigBtn = gameObject.GetComponent<UISysConfigBtn>();
					bool flag3 = uISysConfigBtn == null;
					if (flag3)
					{
						uISysConfigBtn = gameObject.AddComponent<UISysConfigBtn>();
					}
					uISysConfigBtn.Init(config.MainMapSysBtnId, sort_index, config.SubPos, (uint)config.FixedPos, config.ShowBg, config.BtnText, this.Window.LoadSprite(config.BtnSprite), new UISysConfigBtn.ClickSysBtnCallBack(this.OnClickBtn), new object[]
					{
						config,
						gameObject
					});
					gameObject.set_name(config.MainMapSysBtnId.ToString());
					gameObject.SetActive(true);
					Transform transform = gameObject.get_transform().Find("SysBtn");
					RedPoint redPoint = transform.get_gameObject().GetComponent<RedPoint>();
					bool flag4 = redPoint == null;
					if (flag4)
					{
						redPoint = transform.get_gameObject().AddComponent<RedPoint>();
						bool flag5 = b == 0;
						if (flag5)
						{
							redPoint.DeltaX = 59f;
							redPoint.DeltaY = -21f;
						}
						else
						{
							redPoint.DeltaX = 59f;
							redPoint.DeltaY = -21f;
						}
						redPoint.Scale = 1f;
						redPoint.RefreshPosAndScale();
					}
					redPoint.mPointKey = config.MainMapSysBtnId;
					bool flag6 = config.MainMapSysBtnId == 37u;
					if (flag6)
					{
						redPoint.set_AssignRedPointObj(this.mBagRedPoint);
						RectTransform component2 = this.mBagRedPoint.GetComponent<RectTransform>();
						component2.SetParent(transform, false);
						component2.set_localEulerAngles(Vector3.get_zero());
						component2.set_localScale(Vector3.get_one());
						component2.set_anchoredPosition3D(new Vector3(-21.68f, -16.15f, 0f));
					}
					bool flag7 = config.Id == 70u || config.Id == 71u || config.Id == 72u;
					if (flag7)
					{
						UIGuildLeagueSysBtn uIGuildLeagueSysBtn = gameObject.AddComponent<UIGuildLeagueSysBtn>();
						uIGuildLeagueSysBtn.Init();
					}
					bool flag8 = config.UIBehavior.Count > 0;
					if (flag8)
					{
						int num;
						for (int i = 0; i < config.UIBehavior.Count; i = num + 1)
						{
							string text = config.UIBehavior[i];
							bool flag9 = string.IsNullOrEmpty(text);
							if (!flag9)
							{
								bool flag10 = false;
								bool flag11 = text.StartsWith("#");
								if (flag11)
								{
									flag10 = true;
									text = text.Substring(1);
								}
								bool flag12 = LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(text);
								if (flag12)
								{
									bool flag13 = flag10;
									if (flag13)
									{
										LuaClassBehaviour luaClassBehaviour = gameObject.AddComponent<LuaClassBehaviour>();
										luaClassBehaviour.Init(text);
									}
									else
									{
										LuaMonoBehaviour luaMonoBehaviour = gameObject.AddComponent<LuaMonoBehaviour>();
										luaMonoBehaviour.Init(text);
									}
								}
								else
								{
									Type type = Type.GetType(text);
									bool flag14 = type != null;
									if (flag14)
									{
										gameObject.AddComponent(type);
									}
								}
							}
							num = i;
						}
					}
					result = uISysConfigBtn;
				}
			}
			return result;
		}

		public void InitCreateSysBtn(List<DBSysConfig.SysConfig> configs, ref Dictionary<uint, UISysConfigBtn> dic, GameObject root, byte pos)
		{
			uint num = 1u;
			int num2;
			for (int i = 0; i < configs.Count; i = num2 + 1)
			{
				DBSysConfig.SysConfig sysConfig = configs[i];
				bool flag = sysConfig.MainMapSysBtnId == 24u;
				if (!flag)
				{
					bool flag2 = dic.ContainsKey(sysConfig.MainMapSysBtnId);
					if (!flag2)
					{
						bool flag3 = sysConfig.MainMapSysBtnId != sysConfig.Id;
						if (!flag3)
						{
							bool flag4 = Const.Region == 1;
							if (flag4)
							{
								bool flag5 = this.mExpandableSysBtnsDic.ContainsKey(sysConfig.Id);
								if (flag5)
								{
									goto IL_479;
								}
							}
							GameObject gameObject = null;
							Vector3 one = Vector3.get_one();
							bool flag6 = pos == 0;
							if (flag6)
							{
								gameObject = Object.Instantiate<GameObject>(this.mSysBtnObj);
							}
							else
							{
								bool flag7 = pos == 1;
								if (flag7)
								{
									gameObject = Object.Instantiate<GameObject>(this.mTRSysBtnObj);
								}
								else
								{
									bool flag8 = pos == 2;
									if (flag8)
									{
										gameObject = Object.Instantiate<GameObject>(this.mRightSysBtnObj);
									}
								}
							}
							RectTransform component = gameObject.GetComponent<RectTransform>();
							component.set_anchorMin(this.mAnchorMin);
							component.set_anchorMax(this.mAnchorMax);
							Transform transform = root.get_transform();
							bool flag9 = pos == 1;
							if (flag9)
							{
								Transform transform2 = transform.Find(sysConfig.SubPos.ToString());
								bool flag10 = transform2 != null;
								if (flag10)
								{
									transform = transform2;
								}
								else
								{
									GameDebug.LogError("[InitCreateSysBtn] cannot find trans root, sub_pos: " + sysConfig.SubPos);
								}
							}
							gameObject.get_transform().SetParent(transform);
							gameObject.get_transform().set_localScale(one);
							gameObject.get_transform().set_localPosition(Vector3.get_zero());
							UISysConfigBtn uISysConfigBtn = gameObject.GetComponent<UISysConfigBtn>();
							bool flag11 = uISysConfigBtn == null;
							if (flag11)
							{
								uISysConfigBtn = gameObject.AddComponent<UISysConfigBtn>();
							}
							uISysConfigBtn.Init(sysConfig.MainMapSysBtnId, num, sysConfig.SubPos, (uint)sysConfig.FixedPos, sysConfig.ShowBg, sysConfig.BtnText, this.Window.LoadSprite(sysConfig.BtnSprite), new UISysConfigBtn.ClickSysBtnCallBack(this.OnClickBtn), new object[]
							{
								sysConfig,
								gameObject
							});
							gameObject.set_name(sysConfig.MainMapSysBtnId.ToString());
							gameObject.SetActive(true);
							dic.Add(sysConfig.MainMapSysBtnId, uISysConfigBtn);
							Transform transform3 = gameObject.get_transform().Find("SysBtn");
							RedPoint redPoint = transform3.get_gameObject().GetComponent<RedPoint>();
							bool flag12 = redPoint == null;
							if (flag12)
							{
								redPoint = transform3.get_gameObject().AddComponent<RedPoint>();
								bool flag13 = pos == 0;
								if (flag13)
								{
									redPoint.DeltaX = 59f;
									redPoint.DeltaY = -21f;
								}
								else
								{
									redPoint.DeltaX = 59f;
									redPoint.DeltaY = -21f;
								}
								redPoint.Scale = 1f;
								redPoint.RefreshPosAndScale();
							}
							redPoint.mPointKey = sysConfig.MainMapSysBtnId;
							bool flag14 = sysConfig.MainMapSysBtnId == 37u;
							if (flag14)
							{
								redPoint.set_AssignRedPointObj(this.mBagRedPoint);
								RectTransform component2 = this.mBagRedPoint.GetComponent<RectTransform>();
								component2.SetParent(transform3, false);
								component2.set_localEulerAngles(Vector3.get_zero());
								component2.set_localScale(Vector3.get_one());
								component2.set_anchoredPosition3D(new Vector3(-21.68f, -16.15f, 0f));
							}
							bool flag15 = sysConfig.Id == 70u || sysConfig.Id == 71u || sysConfig.Id == 72u;
							if (flag15)
							{
								UIGuildLeagueSysBtn uIGuildLeagueSysBtn = gameObject.AddComponent<UIGuildLeagueSysBtn>();
								uIGuildLeagueSysBtn.Init();
							}
							bool flag16 = sysConfig.UIBehavior.Count > 0;
							if (flag16)
							{
								for (int j = 0; j < sysConfig.UIBehavior.Count; j = num2 + 1)
								{
									string text = sysConfig.UIBehavior[j];
									bool flag17 = string.IsNullOrEmpty(text);
									if (!flag17)
									{
										bool flag18 = false;
										bool flag19 = text.StartsWith("#");
										if (flag19)
										{
											flag18 = true;
											text = text.Substring(1);
										}
										bool flag20 = LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(text);
										if (flag20)
										{
											bool flag21 = flag18;
											if (flag21)
											{
												LuaClassBehaviour luaClassBehaviour = gameObject.AddComponent<LuaClassBehaviour>();
												luaClassBehaviour.Init(text);
											}
											else
											{
												LuaMonoBehaviour luaMonoBehaviour = gameObject.AddComponent<LuaMonoBehaviour>();
												luaMonoBehaviour.Init(text);
											}
										}
										else
										{
											Type type = Type.GetType(text);
											bool flag22 = type != null;
											if (flag22)
											{
												gameObject.AddComponent(type);
											}
										}
									}
									num2 = j;
								}
							}
							uint num3 = num;
							num = num3 + 1u;
						}
					}
				}
				IL_479:
				num2 = i;
			}
		}

		public UISysConfigBtn GetConfingBtn(DBSysConfig.SysConfig config)
		{
			UISysConfigBtn result = null;
			switch (config.Pos)
			{
			case DBSysConfig.ESysBtnPos.SYS_LBBTN_POS:
				this.mLBSysBtnsDic.TryGetValue(config.MainMapSysBtnId, out result);
				break;
			case DBSysConfig.ESysBtnPos.SYS_TRBTN_POS:
				this.mTRSysBtnsDic.TryGetValue(config.MainMapSysBtnId, out result);
				break;
			case DBSysConfig.ESysBtnPos.SYS_RIGHT_POS:
				this.mRightSysBtnsDic.TryGetValue(config.MainMapSysBtnId, out result);
				break;
			}
			return result;
		}
	}
}
