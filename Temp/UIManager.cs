using ClientEventType.ugui;
using SGameEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Utils;
using wxb;
using XLua;
using xpatch;

namespace xc.ui.ugui
{
	[wxb.Hotfix]
	public class UIManager : Singleton<UIManager>
	{
		private class ReopenInfo
		{
			public string Name;

			public bool IsSystemWindow;

			public bool IsMainmapSwitch;

			public object SubSystemInfo;
		}

		public enum RefreshOrder
		{
			All,
			Normal,
			Pop
		}

		public const string MainPanelName = "UIMainmapWindow";

		public static bool IsPopBackWin = false;

		private UICacheManager cache;

		private string mCurUIName;

		private Dictionary<string, UIBaseWindow> mWindows;

		private Dictionary<string, bool> mOpenedSysWindow = new Dictionary<string, bool>();

		private List<string> mOpeningSysWin = new List<string>();

		public const string DynamicPath = "Assets/Res/UI/Widget/Dynamic/";

		public const string PresetPath = "Assets/Res/UI/Widget/Preset/";

		private readonly float mRealDestroyWinTime = 5f;

		private Dictionary<UIType, UILayerInfo> LayerInfos;

		public readonly int MaxDepth = 200;

		public UIBaseWindow ModalWindow = null;

		public UILoadingWindow LoadingWindow = null;

		public string IsBackMainMapShowWin = "";

		private Timer mTimer;

		private Dictionary<string, bool> loadingWindows;

		private List<string> needCloseWindowsAfterResLoad;

		private List<UIManager.ReopenInfo> mReopenWindows = new List<UIManager.ReopenInfo>();

		private List<string> tempRemoveList = new List<string>();

		private const int MIN_LAYER = 0;

		private const int MAX_LAYER = 5000;

		private const float MIN_DIS = 10f;

		private const float MAX_DIS = 3000f;

		public UICacheManager UICache
		{
			get
			{
				bool flag = this.cache == null;
				if (flag)
				{
					this.cache = new UICacheManager("UITemplateRoot");
				}
				return this.cache;
			}
		}

		public UIMainCtrl MainCtrl
		{
			get;
			set;
		}

		public bool LoadingBKIsShow
		{
			get
			{
				bool flag = this.LoadingWindow != null;
				return flag && this.LoadingWindow.LoadingBKIsShow;
			}
		}

		public Dictionary<string, UIBaseWindow> AllWindow
		{
			get
			{
				return this.mWindows;
			}
		}

		public UILayerInfo GetLayerInfo(UIType type)
		{
			return this.LayerInfos[type];
		}

		public UIManager()
		{
			this.LayerInfos = new Dictionary<UIType, UILayerInfo>();
			this.LayerInfos.Add(UIType.Hud, new UILayerInfo(1, UIType.Hud, 11f));
			this.LayerInfos.Add(UIType.Normal, new UILayerInfo(2, UIType.Normal, 10f));
			this.LayerInfos.Add(UIType.Loading, new UILayerInfo(3, UIType.Loading, 9f));
			this.LayerInfos.Add(UIType.Pop, new UILayerInfo(4, UIType.Pop, 8f));
			this.loadingWindows = new Dictionary<string, bool>();
			this.needCloseWindowsAfterResLoad = new List<string>();
			this.mWindows = new Dictionary<string, UIBaseWindow>();
			this.MainCtrl = null;
			Singleton<ClientEventManager<UICoreEvent>>.Instance.SubscribeClientEvent(UICoreEvent.UILOADDONE, new ClientEventManager<UICoreEvent>.ClientEventFunc(this.OnResourceLoadDone));
			Singleton<ClientEventManager<UICoreEvent>>.Instance.SubscribeClientEvent(UICoreEvent.LEVEL_CHANGE, new ClientEventManager<UICoreEvent>.ClientEventFunc(this.OnLevelChange));
			Singleton<ClientEventMgr>.Instance.SubscribeClientEvent(81, new ClientEventMgr.ClientEventFunc(this.OnFinishSwitchScene));
		}

		public void Reset()
		{
			bool flag = this.mTimer != null;
			if (flag)
			{
				this.mTimer.Destroy();
				this.mTimer = null;
			}
			bool flag2 = this.UICache != null;
			if (flag2)
			{
				this.UICache.Reset();
			}
			this.mTimer = new Timer((float)((int)(this.mRealDestroyWinTime * 1000f)), true, float.PositiveInfinity, new Timer.DetalCallback(this.RealTimerRemove));
			this.IsBackMainMapShowWin = "";
		}

		public IEnumerator SwitchUI(string uiName, bool hideLoadingBk = true)
		{
			bool flag = uiName == "" || this.mCurUIName == uiName;
			if (flag)
			{
				yield break;
			}
			this.mCurUIName = uiName;
			this.ClearUI();
			this.ShowLoadingBK(true);
			this.ShowWindow(uiName, new object[0]);
			if (hideLoadingBk)
			{
				this.ShowLoadingBK(false);
			}
			yield break;
		}

		private void OnLevelChange(ClientEventBaseArgs args)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, UIBaseWindow> current in this.mWindows)
			{
				bool flag = current.Value.WindowType != UIType.Loading;
				if (flag)
				{
					bool flag2 = !current.Value.IsGlobal;
					if (flag2)
					{
						bool flag3 = current.Value.mUIObject != null;
						if (flag3)
						{
							current.Value.Destroy();
							this.DestroyWindowGameObject(current.Value.mUIObject);
							list.Add(current.Key);
						}
					}
					else
					{
						current.Value.Show();
					}
				}
			}
			int num;
			for (int i = 0; i < list.Count; i = num + 1)
			{
				bool flag4 = this.mWindows.ContainsKey(list[i]);
				if (flag4)
				{
					this.mWindows.Remove(list[i]);
				}
				num = i;
			}
		}

		private void OnFinishSwitchScene(CEventBaseArgs arg)
		{
			bool flag = Singleton<SceneHelp>.Instance.IsInNormalWild(Singleton<SceneHelp>.Instance.CurSceneID);
			if (flag)
			{
				foreach (UIManager.ReopenInfo current in this.mReopenWindows)
				{
					bool isSystemWindow = current.IsSystemWindow;
					if (isSystemWindow)
					{
						bool flag2 = current.SubSystemInfo != null;
						if (flag2)
						{
							this.ShowSysWindowEx(current.Name, current.IsMainmapSwitch, new object[]
							{
								current.SubSystemInfo
							});
						}
						else
						{
							this.ShowSysWindowEx(current.Name, current.IsMainmapSwitch, new object[0]);
						}
					}
					else
					{
						this.ShowWindow(current.Name, new object[0]);
					}
				}
			}
			this.mReopenWindows.Clear();
		}

		public bool IsLuaScriptExist(string lua_script)
		{
			bool flag = LuaScriptMgr.Instance == null;
			return !flag && LuaScriptMgr.Instance.IsLuaScriptExist(lua_script);
		}

		public void SetLoadingTip(string text)
		{
			bool flag = this.LoadingWindow != null;
			if (flag)
			{
				this.LoadingWindow.SetLoadingTip(text);
			}
		}

		public void ShowLoadingBK(bool isShow)
		{
			bool flag = this.LoadingWindow != null;
			if (flag)
			{
				this.LoadingWindow.ShowLoadingBK(isShow);
			}
		}

		public void ShowWaitScreen(bool isShow, float wait_time = 10f)
		{
			bool flag = this.LoadingWindow != null;
			if (flag)
			{
				this.LoadingWindow.ShowWaitScreen(isShow, wait_time);
			}
		}

		public void UpdateLoadingBar(double process)
		{
			bool flag = this.LoadingWindow != null;
			if (flag)
			{
				bool flag2 = process > 1.0;
				if (flag2)
				{
					process = 1.0;
				}
				this.LoadingWindow.UpdateLoadingBar(process);
			}
		}

		private void OnResourceLoadDone(ClientEventBaseArgs args)
		{
			bool flag = args.Arg == null;
			if (!flag)
			{
				UIBaseWindow uIBaseWindow = (UIBaseWindow)args.Arg;
				this.loadingWindows.Remove(uIBaseWindow.mWndName);
				bool flag2 = !this.mWindows.ContainsValue(uIBaseWindow);
				if (flag2)
				{
					this.DestroyWindowGameObject(uIBaseWindow.mUIObject);
				}
				else
				{
					bool flag3 = Singleton<NetReconnect>.Instance.IsReconnect && uIBaseWindow.mWndName != "UIAutoConnectWindow";
					if (flag3)
					{
						this.DestroyWindowGameObject(uIBaseWindow.mUIObject);
						bool flag4 = this.needCloseWindowsAfterResLoad.Contains(uIBaseWindow.mWndName);
						if (flag4)
						{
							this.needCloseWindowsAfterResLoad.Remove(uIBaseWindow.mWndName);
						}
						bool flag5 = this.mWindows.ContainsKey(uIBaseWindow.mWndName);
						if (flag5)
						{
							this.mWindows.Remove(uIBaseWindow.mWndName);
						}
					}
					else
					{
						uIBaseWindow.InitData();
						bool flag6 = this.ModalWindow != null && this.ModalWindow.mWndName != uIBaseWindow.mWndName;
						if (!flag6)
						{
							bool isModal = uIBaseWindow.IsModal;
							if (isModal)
							{
								this.ModalWindow = uIBaseWindow;
							}
							uIBaseWindow.Show();
							int num;
							for (int i = 0; i < this.needCloseWindowsAfterResLoad.Count; i = num + 1)
							{
								bool flag7 = uIBaseWindow.mWndName == this.needCloseWindowsAfterResLoad[i];
								if (flag7)
								{
									this.needCloseWindowsAfterResLoad.RemoveAt(i);
									this.CloseWindow(uIBaseWindow.mWndName);
									break;
								}
								num = i;
							}
						}
					}
				}
			}
		}

		public void Update()
		{
			using (Dictionary<string, UIBaseWindow>.ValueCollection.Enumerator enumerator = this.mWindows.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					bool flag = enumerator.Current.IsShow && enumerator.Current.Behaviours.Count > 0;
					if (flag)
					{
						foreach (KeyValuePair<string, IUIBehaviour> current in enumerator.Current.Behaviours)
						{
							bool flag2 = current.Value is UILuaBehaviour;
							if (!flag2)
							{
								current.Value.UpdateBehaviour();
							}
						}
					}
				}
			}
			this.UICache.Update();
		}

		private void DestroyWindowGameObject(GameObject obj)
		{
			bool flag = obj != null;
			if (flag)
			{
				Object.DestroyImmediate(obj);
			}
		}

		[BlackList]
		public void RealTimerRemove(float delta)
		{
			bool flag = delta > 0f;
			if (!flag)
			{
				this.tempRemoveList.Clear();
				foreach (KeyValuePair<string, UIBaseWindow> current in this.mWindows)
				{
					bool flag2 = current.Value.mUIObject == null && current.Value.IsLoadDone;
					if (flag2)
					{
						GameObject mUIObject = current.Value.mUIObject;
						current.Value.Destroy();
						this.DestroyWindowGameObject(mUIObject);
						this.tempRemoveList.Add(current.Key);
					}
					else
					{
						bool flag3 = !current.Value.IsGlobal && !current.Value.IsShow;
						if (flag3)
						{
							UIBaseWindow value = current.Value;
							bool flag4 = value.WindowCloseTime != -1f && value.WindowCloseTime + value.DestroyDelayTime < Time.get_realtimeSinceStartup();
							if (flag4)
							{
								current.Value.Destroy();
								GameObject mUIObject2 = current.Value.mUIObject;
								this.DestroyWindowGameObject(mUIObject2);
								this.tempRemoveList.Add(current.Key);
							}
						}
					}
				}
				int num;
				for (int i = 0; i < this.tempRemoveList.Count; i = num + 1)
				{
					this.mWindows.Remove(this.tempRemoveList[i]);
					num = i;
				}
			}
		}

		public UIBaseWindow GetWindow(string name)
		{
			UIBaseWindow uIBaseWindow;
			this.mWindows.TryGetValue(name, out uIBaseWindow);
			bool flag = uIBaseWindow != null && uIBaseWindow.IsShow;
			UIBaseWindow result;
			if (flag)
			{
				result = uIBaseWindow;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public UIBaseWindow GetExistingWindow(string name)
		{
			UIBaseWindow uIBaseWindow;
			this.mWindows.TryGetValue(name, out uIBaseWindow);
			bool flag = uIBaseWindow != null;
			UIBaseWindow result;
			if (flag)
			{
				result = uIBaseWindow;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public List<UIBaseWindow> GetNeedCloseSystemWindowsByType(UIType uiType)
		{
			List<UIBaseWindow> list = new List<UIBaseWindow>();
			foreach (KeyValuePair<string, UIBaseWindow> current in this.mWindows)
			{
				bool flag = current.Value.WindowType == uiType && (current.Value.IsShow || !current.Value.IsLoadDone);
				if (flag)
				{
					list.Add(current.Value);
				}
			}
			return list;
		}

		protected bool CheckWindowDownloaded(string winName)
		{
			int patch_id = UIHelper.GetWindowPatchId(winName);
			bool flag = patch_id >= 0;
			bool result;
			if (flag)
			{
				bool flag2 = XPatchManager.get_Instance().IsPatchDownloaded(patch_id);
				bool flag3 = flag2;
				if (flag3)
				{
					result = true;
				}
				else
				{
					string text = DBConstText.GetText("DOWNLOAD_PATCH_TIPS");
					Singleton<UIWidgetHelp>.Instance.ShowNoticeDlg(UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, text, delegate(object param)
					{
						Singleton<UIManager>.Instance.ShowSysWindow("UIPatchWindow", new object[]
						{
							patch_id
						});
					}, null);
					result = false;
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		public void ShowWindowLayer(string winName, int layer, params object[] param)
		{
			this.ShowWindow(winName, param);
			UIBaseWindow uIBaseWindow = null;
			this.mWindows.TryGetValue(winName, out uIBaseWindow);
			bool flag = uIBaseWindow != null && layer != 0;
			if (flag)
			{
				uIBaseWindow.SetLayerDirectIndex(layer);
			}
		}

		public void ShowWindow(string winName, params object[] param)
		{
			bool flag = this.MainCtrl == null;
			if (!flag)
			{
				bool flag2 = !this.CheckWindowDownloaded(winName);
				if (!flag2)
				{
					bool flag3 = this.ModalWindow != null && this.ModalWindow.IsShow;
					if (flag3)
					{
						GameDebug.LogWarning(string.Format("当前有模态窗口{0}打开，所以{1}无法打开", this.ModalWindow.mWndName, winName));
					}
					bool flag4 = this.loadingWindows.ContainsKey(winName);
					if (flag4)
					{
						GameDebug.Log("当前窗口正在加载中:" + winName);
						bool flag5 = this.needCloseWindowsAfterResLoad.Contains(winName);
						if (flag5)
						{
							this.needCloseWindowsAfterResLoad.Remove(winName);
							this.SetWindowDynOrder(this.GetExistingWindow(winName));
						}
					}
					else
					{
						string text = string.Format("show window: {0}", winName);
						BuglyAgent.PrintLog(2, text, new object[0]);
						UIBaseWindow uIBaseWindow = null;
						bool flag6 = this.mWindows.TryGetValue(winName, out uIBaseWindow);
						if (flag6)
						{
							bool flag7 = uIBaseWindow.WinState == WinowState.ResLoadDone;
							if (flag7)
							{
								uIBaseWindow.ShowParam = param;
								bool flag8 = this.MainCtrl != null;
								if (flag8)
								{
									this.MainCtrl.CreateAndCheckMoneyBar(uIBaseWindow, uIBaseWindow.mUIObject, winName, uIBaseWindow.CurrencyScale, false);
									this.MainCtrl.CreateAndCheckProbabilityBtn(uIBaseWindow, uIBaseWindow.mUIObject, winName, uIBaseWindow.CurrencyScale, false);
									this.MainCtrl.CreateAndCheckRefundBtn(uIBaseWindow, uIBaseWindow.mUIObject, winName, uIBaseWindow.CurrencyScale, false);
								}
								uIBaseWindow.Show();
							}
						}
						else
						{
							string luaWindowPath = UIHelper.GetLuaWindowPath(winName);
							bool flag9 = luaWindowPath.CompareTo(string.Empty) == 0;
							string lua_script;
							if (flag9)
							{
								lua_script = string.Format("newUI.{0}", winName);
							}
							else
							{
								lua_script = string.Format("newUI.{0}.{1}", luaWindowPath, winName);
							}
							bool flag10 = this.IsLuaScriptExist(lua_script);
							if (flag10)
							{
								uIBaseWindow = new UILuaBaseWindow(winName, lua_script);
							}
							else
							{
								Type type = Type.GetType("xc.ui.ugui." + winName);
								bool flag11 = type != null;
								if (flag11)
								{
									bool flag12 = type.IsSubclassOf(typeof(UIBaseWindow));
									if (flag12)
									{
										uIBaseWindow = (UIBaseWindow)Activator.CreateInstance(type);
									}
									else
									{
										GameDebug.Log("use reflection create ugui panel :" + winName);
										FieldInfo field = type.GetField("mWndName", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
										bool flag13 = field == null;
										if (flag13)
										{
											Debug.LogError(string.Format("the type {0} should cantains a static string field named mPrefabName", type));
											return;
										}
										string winName2 = field.GetValue(null) as string;
										uIBaseWindow = new UIBaseWindow(winName2);
									}
								}
							}
							bool flag14 = uIBaseWindow == null;
							if (flag14)
							{
								Debug.LogError("UIManager.CreateWindow error:" + winName);
								return;
							}
							bool flag15 = uIBaseWindow.WinState == WinowState.ResNoLoad;
							if (flag15)
							{
								this.SetWindowDynOrder(uIBaseWindow);
								uIBaseWindow.ShowParam = param;
								this.mWindows.Add(winName, uIBaseWindow);
								uIBaseWindow.WinState = WinowState.ResLoading;
								this.loadingWindows.Add(winName, true);
								this.MainCtrl.StartCoroutine(this.MainCtrl.CreateWindowFromPrefab(uIBaseWindow.mWndName, uIBaseWindow));
							}
						}
						bool flag16 = uIBaseWindow != null;
						if (flag16)
						{
							uIBaseWindow.IsSystemWindow = false;
						}
						bool flag17 = !this.mOpenedSysWindow.ContainsKey(winName);
						if (flag17)
						{
							this.mOpenedSysWindow[winName] = false;
						}
					}
				}
			}
		}

		public void SetWindowDynOrder(UIBaseWindow baseWin)
		{
			bool flag = baseWin.staticLayerIndex != -1;
			if (!flag)
			{
				UILayerInfo layerInfo = this.GetLayerInfo(baseWin.WindowType);
				int newDynamicLayerIndex = layerInfo.GetNewDynamicLayerIndex(baseWin);
				baseWin.SetDynamicLayerIndex(newDynamicLayerIndex);
			}
		}

		public void RemoveWindowDynOrder(UIBaseWindow win)
		{
			bool flag = win.staticLayerIndex != -1;
			if (!flag)
			{
				UILayerInfo layerInfo = this.GetLayerInfo(win.WindowType);
				layerInfo.RemoveDynamicLayerIndex(win);
			}
		}

		public void DestroyWindow(string name)
		{
			UIBaseWindow uIBaseWindow;
			bool flag = this.mWindows.TryGetValue(name, out uIBaseWindow);
			if (flag)
			{
				bool flag2 = uIBaseWindow.mUIObject != null;
				if (flag2)
				{
					uIBaseWindow.Destroy();
					this.DestroyWindowGameObject(uIBaseWindow.mUIObject);
					this.mWindows.Remove(name);
				}
			}
			else
			{
				GameDebug.LogWarning(string.Format("DestroyWindow {0} is null", name));
			}
		}

		public void CloseWindow(string name)
		{
			string text = string.Format("close window: {0}", name);
			BuglyAgent.PrintLog(2, text, new object[0]);
			UIBaseWindow uIBaseWindow;
			bool flag = this.mWindows.TryGetValue(name, out uIBaseWindow);
			if (flag)
			{
				int num;
				for (int i = 0; i < uIBaseWindow.SubWindow.Count; i = num + 1)
				{
					string text2 = uIBaseWindow.SubWindow[i];
					bool flag2 = this.loadingWindows.ContainsKey(text2) && !this.needCloseWindowsAfterResLoad.Contains(text2);
					if (flag2)
					{
						this.needCloseWindowsAfterResLoad.Add(text2);
					}
					num = i;
				}
				bool flag3 = this.loadingWindows.ContainsKey(name) && !this.needCloseWindowsAfterResLoad.Contains(name);
				if (flag3)
				{
					this.needCloseWindowsAfterResLoad.Add(name);
					this.RemoveWindowDynOrder(uIBaseWindow);
				}
				else
				{
					bool flag4 = !uIBaseWindow.IsShow;
					if (!flag4)
					{
						uIBaseWindow.Close();
						bool isModal = uIBaseWindow.IsModal;
						if (isModal)
						{
							this.ModalWindow = null;
						}
						uIBaseWindow.BackupOpenSubWindows.Clear();
						for (int j = 0; j < uIBaseWindow.SubWindow.Count; j = num + 1)
						{
							string text3 = uIBaseWindow.SubWindow[j];
							UIBaseWindow uIBaseWindow2 = null;
							this.mWindows.TryGetValue(text3, out uIBaseWindow2);
							bool flag5 = uIBaseWindow2 != null;
							if (flag5)
							{
								bool flag6 = uIBaseWindow2.IsShow && text3 != "UIGoodsTipsWindow" && text3 != "UIEquipmentTipsWindow";
								if (flag6)
								{
									UIBaseWindow.BackupWin backupWin = new UIBaseWindow.BackupWin();
									backupWin.WinName = text3;
									backupWin.ShowParam = uIBaseWindow2.ShowParam;
									uIBaseWindow.BackupOpenSubWindows.Add(backupWin);
								}
								uIBaseWindow2.Close();
							}
							num = j;
						}
						Singleton<ClientEventMgr>.GetInstance().FireEvent(355, new CEventBaseArgs(name));
					}
				}
			}
		}

		public void CloseAllWindow()
		{
			UIMainCtrl.MainCam.set_enabled(false);
			this.mOpeningSysWin.Clear();
			this.UpdateSysUIMaskBg();
		}

		public void CloseAllWindowExcept(bool record = false)
		{
			Singleton<UINavgationCtrl>.Instance.Clear();
			string b = "UIGuideWindow";
			List<string> list = Pool<string>.List.New(this.mWindows.Keys.Count);
			foreach (string current in this.mWindows.Keys)
			{
				list.Add(current);
			}
			foreach (string current2 in list)
			{
				bool flag = current2 == b;
				if (!flag)
				{
					UIBaseWindow uIBaseWindow = this.mWindows[current2];
					bool flag2 = uIBaseWindow == null;
					if (!flag2)
					{
						if (record)
						{
							DBUIManager.UIInfo data = DBUIManager.Instance.GetData(uIBaseWindow.mWndName);
							bool flag3 = uIBaseWindow.IsShow && data != null && data.reopen;
							if (flag3)
							{
								UIManager.ReopenInfo reopenInfo = new UIManager.ReopenInfo();
								reopenInfo.Name = uIBaseWindow.mWndName;
								reopenInfo.IsSystemWindow = uIBaseWindow.IsSystemWindow;
								reopenInfo.IsMainmapSwitch = uIBaseWindow.IsMainmapSwitch;
								reopenInfo.SubSystemInfo = uIBaseWindow.SubSystemInfo;
								this.mReopenWindows.Add(reopenInfo);
							}
						}
						bool flag4 = uIBaseWindow.ReconnectHandle == 0u;
						if (!flag4)
						{
							bool flag5 = uIBaseWindow.ReconnectHandle == 1u;
							if (flag5)
							{
								bool isSystemWindow = uIBaseWindow.IsSystemWindow;
								if (isSystemWindow)
								{
									this.CloseSysWindow(current2, true);
								}
								else
								{
									this.CloseWindow(current2);
								}
							}
							else
							{
								bool flag6 = !uIBaseWindow.IsShow;
								if (flag6)
								{
									Singleton<UIManager>.Instance.ShowSysWindow(current2, new object[0]);
								}
							}
						}
					}
				}
			}
			Pool<string>.List.Free(list);
			Singleton<UINavgationCtrl>.Instance.Clear();
			Singleton<ClientEventMgr>.GetInstance().FireEvent(101, new CEventBaseArgs(true));
		}

		public void CloseWindowsWhenSwitchPlaneInstance()
		{
			List<string> list = Pool<string>.List.New(this.mWindows.Keys.Count);
			foreach (string current in this.mWindows.Keys)
			{
				list.Add(current);
			}
			Singleton<UINavgationCtrl>.Instance.Clear();
			string b = "UIGuideWindow";
			foreach (string current2 in list)
			{
				bool flag = current2 == b;
				if (!flag)
				{
					UIBaseWindow uIBaseWindow = this.mWindows[current2];
					bool flag2 = uIBaseWindow == null;
					if (!flag2)
					{
						bool flag3 = !uIBaseWindow.StayWhenSwitchPlaneInstance;
						if (flag3)
						{
							bool isSystemWindow = uIBaseWindow.IsSystemWindow;
							if (isSystemWindow)
							{
								this.CloseSysWindow(current2, false);
							}
							else
							{
								this.CloseWindow(current2);
							}
						}
					}
				}
			}
			Pool<string>.List.Free(list);
			Singleton<UINavgationCtrl>.Instance.Clear();
		}

		public void ShowAllWindow()
		{
			UIMainCtrl.MainCam.set_enabled(true);
			this.UpdateSysUIMaskBg();
		}

		public void ClearUI()
		{
			List<UIBaseWindow> list = new List<UIBaseWindow>();
			Dictionary<string, UIBaseWindow> dictionary = new Dictionary<string, UIBaseWindow>();
			foreach (KeyValuePair<string, UIBaseWindow> current in this.mWindows)
			{
				bool flag = current.Value.WindowType != UIType.Loading;
				if (flag)
				{
					bool flag2 = current.Value.mUIObject != null;
					if (flag2)
					{
						list.Add(current.Value);
					}
				}
				else
				{
					bool flag3 = !dictionary.ContainsKey(current.Key);
					if (flag3)
					{
						dictionary.Add(current.Key, current.Value);
					}
				}
			}
			int num;
			for (int i = 0; i < list.Count; i = num + 1)
			{
				list[i].Destroy();
				this.DestroyWindowGameObject(list[i].mUIObject);
				num = i;
			}
			list.Clear();
			list = null;
			this.mWindows.Clear();
			this.loadingWindows.Clear();
			bool flag4 = this.MainCtrl != null;
			if (flag4)
			{
				this.MainCtrl.ClearAllChildWindow();
			}
			foreach (KeyValuePair<string, UIBaseWindow> current2 in dictionary)
			{
				this.mWindows.Add(current2.Key, current2.Value);
			}
			this.mCurUIName = "";
			Singleton<UINavgationCtrl>.Instance.Clear();
			this.mOpenedSysWindow.Clear();
			this.mOpeningSysWin.Clear();
			this.UpdateSysUIMaskBg();
		}

		public void Dispose()
		{
			this.ClearUI();
			this.UICache.Dispose();
			this.cache = null;
		}

		public void ShowSysWindowEx(string winName, bool mainmap_switch, params object[] param)
		{
			bool flag = !this.CheckWindowDownloaded(winName);
			if (!flag)
			{
				bool flag2 = this.ModalWindow != null && this.ModalWindow.IsShow;
				if (flag2)
				{
					GameDebug.LogWarning(string.Format("当前有模态窗口{0}打开，所以{1}无法打开", this.ModalWindow.mWndName, winName));
				}
				UIBaseWindow uIBaseWindow = null;
				this.mWindows.TryGetValue(winName, out uIBaseWindow);
				bool flag3 = winName.CompareTo("UIMainmapWindow") != 0 && (uIBaseWindow == null || (uIBaseWindow != null && !uIBaseWindow.IsShow));
				if (flag3)
				{
					if (mainmap_switch)
					{
						bool flag4 = !this.IsOpeningSysWinExceptMainmapWin();
						if (flag4)
						{
							Singleton<ClientEventMgr>.GetInstance().FireEvent(101, new CEventBaseArgs(false));
						}
					}
				}
				else
				{
					bool flag5 = winName.CompareTo("UIMainmapWindow") == 0 && this.IsBackMainMapShowWin.CompareTo("") != 0 && !Singleton<SceneHelp>.Instance.IsInInstance;
					if (flag5)
					{
						this.ShowSysWindow(this.IsBackMainMapShowWin, new object[0]);
					}
				}
				Singleton<ClientEventMgr>.GetInstance().FireEvent(352, new CEventBaseArgs(winName));
				Singleton<UINavgationCtrl>.Instance.Push(winName, param);
				this.mWindows.TryGetValue(winName, out uIBaseWindow);
				bool flag6 = uIBaseWindow != null;
				if (flag6)
				{
					uIBaseWindow.IsSystemWindow = true;
					uIBaseWindow.IsMainmapSwitch = mainmap_switch;
				}
				bool flag7 = winName != "UIChatWindow";
				if (flag7)
				{
					this.mOpenedSysWindow[winName] = true;
				}
				bool flag8 = !this.mOpeningSysWin.Contains(winName);
				if (flag8)
				{
					this.mOpeningSysWin.Add(winName);
				}
				this.UpdateSysUIMaskBg();
			}
		}

		public void ShowSysWindow(string winName, params object[] param)
		{
			this.ShowSysWindowEx(winName, true, param);
		}

		public void CloseSysWindow(string winName, bool isPlayMainMapAni = true)
		{
			UIBaseWindow window = this.GetWindow(winName);
			bool flag = this.mOpeningSysWin.Contains(winName);
			if (flag)
			{
				this.mOpeningSysWin.Remove(winName);
			}
			bool flag2 = window == null;
			if (!flag2)
			{
				Singleton<ClientEventMgr>.GetInstance().FireEvent(353, new CEventBaseArgs(winName));
				bool flag3 = Singleton<UINavgationCtrl>.Instance.Pop(winName);
				bool flag4 = (!flag3 & isPlayMainMapAni) && winName.CompareTo("UIMainmapWindow") != 0 && Singleton<UINavgationCtrl>.Instance.GetStackLen() == 0;
				if (flag4)
				{
					bool flag5 = !this.IsOpeningSysWinExceptMainmapWin();
					if (flag5)
					{
						Singleton<ClientEventMgr>.GetInstance().FireEvent(101, new CEventBaseArgs(true));
					}
				}
				this.UpdateSysUIMaskBg();
				Singleton<ClientEventMgr>.GetInstance().FireEvent(355, new CEventBaseArgs(winName));
			}
		}

		public bool IsOpenedSysWindow(string wnd_name)
		{
			bool result = false;
			this.mOpenedSysWindow.TryGetValue(wnd_name, out result);
			return result;
		}

		public bool IsOpeningSysWinExceptMainmapWin()
		{
			bool result;
			foreach (string current in this.mOpeningSysWin)
			{
				bool flag = !current.Equals("UIChatWindow") && !current.Equals("UIMainmapWindow") && this.GetWindow(current) != null;
				if (flag)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public List<UIBaseWindow> GetStateIsShowWindowByWindowType(UIType uiType, bool isShow)
		{
			List<UIBaseWindow> list = new List<UIBaseWindow>();
			foreach (KeyValuePair<string, UIBaseWindow> current in this.mWindows)
			{
				bool flag = current.Value.WindowType == uiType && current.Value.IsShow == isShow;
				if (flag)
				{
					list.Add(current.Value);
				}
			}
			return list;
		}

		public float GetPlaneDistance(int orderInLayer)
		{
			orderInLayer = Mathf.Clamp(orderInLayer, 0, 5000);
			return 3000f - (10f + 0.598f * (float)orderInLayer);
		}

		private void UpdateSysUIMaskBg()
		{
		}

		public bool TryCloseAllWindow()
		{
			bool result = false;
			Singleton<UINavgationCtrl>.Instance.Clear();
			List<string> list = Pool<string>.List.New(this.mWindows.Keys.Count);
			foreach (string current in this.mWindows.Keys)
			{
				list.Add(current);
			}
			foreach (string current2 in list)
			{
				UIBaseWindow uIBaseWindow = this.mWindows[current2];
				bool flag = uIBaseWindow == null;
				if (!flag)
				{
					bool flag2 = !uIBaseWindow.IsShow;
					if (!flag2)
					{
						bool flag3 = uIBaseWindow.ReturnHandle == 0u;
						if (!flag3)
						{
							bool flag4 = uIBaseWindow.ReturnHandle == 1u;
							if (flag4)
							{
								result = true;
								bool isSystemWindow = uIBaseWindow.IsSystemWindow;
								if (isSystemWindow)
								{
									this.CloseSysWindow(current2, true);
								}
								else
								{
									this.CloseWindow(current2);
								}
							}
							else
							{
								bool flag5 = !uIBaseWindow.IsShow;
								if (flag5)
								{
									Singleton<UIManager>.Instance.ShowSysWindow(current2, new object[0]);
								}
							}
						}
					}
				}
			}
			Pool<string>.List.Free(list);
			Singleton<UINavgationCtrl>.Instance.Clear();
			Singleton<ClientEventMgr>.GetInstance().FireEvent(101, new CEventBaseArgs(true));
			return result;
		}
	}
}
