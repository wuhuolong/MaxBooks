using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Utils;
using SGameFirstPass;
using SGameEngine;
using xc;
using xc.ui;
using xc.ui.ugui;
using Net;
using xc.protocol;

namespace xc
{
	public class GameInitState : xc.Machine.State
	{
		public GameInitState(xc.Machine machine) : base((uint)GameState.GS_INIT, machine)
		{
			Init();
		}
		
		public GameInitState(xc.Machine machine, xc.Machine.State owner) : base((uint)GameState.GS_INIT, machine, owner)
		{
			Init();
		}
		
		void Init()
		{
			// 创建子状态
            // 检查版本信息
			xc.Machine.State stateCheckingVersion = new xc.Machine.State((uint)GameState.GS_CHECKING_VERSION, mMachine, this);
            // 加载登陆场景
			xc.Machine.State stateLoadingScene = new xc.Machine.State((uint)GameState.GS_LOADING_LEVEL, mMachine, this);
            // 登陆sdk
			xc.Machine.State stateLoginPlatform = new xc.Machine.State((uint)GameState.GS_LOGIN_PLATFORM, mMachine, this);
            // 完成状态
			xc.Machine.State stateInitDone = new xc.Machine.State((uint)GameState.GS_INIT_DONE, mMachine, this);
            // 更换角色状态
            xc.Machine.State stateChangeRole = new xc.Machine.State((uint)GameState.GS_CHANGE_ROLE, mMachine, this);

            stateCheckingVersion.SetEnterFunction(StateEnter_CheckingVersion);
			stateCheckingVersion.SetUpdateFunction(StateUpdate_CheckingVersion);

			stateLoadingScene.SetEnterFunction(StateEnter_LoadingLevel);
			stateLoadingScene.SetUpdateFunction(StateUpdate_LoadingLevel);
			
			stateLoginPlatform.SetEnterFunction(StateEnter_LoginPlatform);
			stateLoginPlatform.SetUpdateFunction(StateUpdate_LoginPlatform);

            stateInitDone.SetEnterFunction(StateEnter_InitDone);

            stateChangeRole.SetEnterFunction(StateEnter_ChangeRole);
            stateChangeRole.SetUpdateFunction(StateUpdate_ChangeRole);

            // 状态图 -- begin
            stateCheckingVersion.AddTransition((uint)GameEvent.GE_VERSION_CHECKED, stateLoadingScene);
			stateLoadingScene.AddTransition((uint)GameEvent.GE_LEVEL_LOADED, stateLoginPlatform);
			stateLoginPlatform.AddTransition((uint)GameEvent.GE_LOGINED_PLATFORM, stateInitDone);
            stateChangeRole.AddTransition((uint)GameEvent.GE_CHANGE_ROLE_FINISH, stateInitDone);
            stateInitDone.AddTransition((uint)GameEvent.GE_CHANGE_ROLE, stateChangeRole);

            stateLoadingScene.AddTransition((uint)GameEvent.GE_RESET, stateCheckingVersion);
            stateLoginPlatform.AddTransition((uint)GameEvent.GE_RESET, stateCheckingVersion);
            stateInitDone.AddTransition((uint)GameEvent.GE_RESET, stateCheckingVersion);
            stateChangeRole.AddTransition((uint)GameEvent.GE_RESET, stateCheckingVersion);

            // 状态图 -- end

            // 设置默认子状态
            this.SetChild(stateCheckingVersion);
			
#if UNITY_IPHONE
            //断线手动点击取消按钮返回选服界面时，不清登录信息
            if(Game.Instance.ManualCancelReconnect == false)
                GlobalConfig.GetInstance().ResetLoginInfo();
#endif
		}
		
        public override void Enter( params object[] param  )
		{
            base.Enter(param);

            Game.Instance.IsEnterGame = false;
            if (ChangeRoleManager.Instance.IsChangeRole)
            {
                mMachine.React((uint)GameEvent.GE_CHANGE_ROLE);
            }
            else
            {
                mMachine.React((uint)GameEvent.GE_RESET);

                GameDebug.Log("Enter GameInit state. Loaded Level: " + SceneHelp.loadedLevelName);
            }
        }
		
		public override void Exit()
		{
            base.Exit();
		}
		
        /// <summary>
        /// 是否已经清除了所有的UI
        /// </summary>
		bool mClearUI = false;

        /// <summary>
        /// 设置提审信息
        /// </summary>
        void SetAuditInfo()
        {
            // 提审信息的读取(ios已经在初始化的时候读取)
#if UNITY_ANDROID
            string json = DBManager.Instance.LoadDBFile("DB/Common/android_audit_info.json");

            if (string.IsNullOrEmpty(json))
            {
                AuditManager.Instance.Open = false;
                AuditManager.Instance.ServerUrl = "";
                return;
            }

            Hashtable jsonObj = MiniJSON.JsonDecode(json) as Hashtable;
            AuditManager.Instance.Open = int.Parse(jsonObj["open"].ToString()) == 1;
            AuditManager.Instance.ServerUrl = jsonObj["server_url"].ToString();
#endif

            if (AuditManager.Instance.Open)
                xpatch.XPatchManager.Instance.OverrideServerUrl(AuditManager.Instance.ServerUrl);
        }

        // ----------------- 检查版本信息状态 -------------------------
        float mStartTime = 0;
		void StateEnter_CheckingVersion(xc.Machine.State s)
		{			
			mClearUI = false;
            mStartTime = Time.time;
		}
		
		void StateUpdate_CheckingVersion(xc.Machine.State s)
		{
			// 进入UI界面
            UIManager ui_manager = UIManager.GetInstance();
            if (ui_manager.MainCtrl == null)
                return;
            
            if (!mClearUI)
            {
                mClearUI = true;
                ui_manager.ClearUI();
                ui_manager.ShowLoadingBK(true);
                ui_manager.SetLoadingTip(xc.TextHelper.LoadingNotice);
            }

            mMachine.React((uint)GameEvent.GE_VERSION_CHECKED);
		}

		
        // ----------------- 加载登陆场景状态 -------------------------
		void StateEnter_LoadingLevel(xc.Machine.State s)
		{
            // 重置游戏
            Game.Instance.Reset();

#if UNITY_IPHONE || UNITY_ANDROID
            // 提审信息
            SetAuditInfo();
#endif

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_GAME_INITED, null);

            // 切换到快速登录场景
            if(Game.Instance.IsSkillEditorScene)
                SceneHelp.Instance.SwitchPreposeScene(GlobalConst.DefaultTestScene, false);
            else
                SceneHelp.Instance.SwitchPreposeScene(GlobalConst.LoginScene, false);
		}
		
		void StateUpdate_LoadingLevel(xc.Machine.State s)
		{
			if (Game.GetInstance().GetLoadAsyncOp() == null || !Game.GetInstance().GetLoadAsyncOp().isDone)
				return;
			
			mMachine.React((uint)GameEvent.GE_LEVEL_LOADED);
		}

        // ----------------- 登陆sdk状态 -------------------------
        string login_wnd = "";
		void StateEnter_LoginPlatform(xc.Machine.State s)
		{
            ControlServerLogHelper.GetInstance().PostStartClientLog();

            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            if (globalConfig.IsEnterSDK)
            {
                login_wnd = "UIQuickLoginWindow";
                UIManager.Instance.ShowWindow(login_wnd);
            }
            else
            {
                if (Game.Instance.IsSkillEditorScene == false)
                {
                    if (string.IsNullOrEmpty(globalConfig.LoginInfo.AccName) == true)
                    {
                        login_wnd = "UIAccountWindow";
                        UIManager.Instance.ShowWindow(login_wnd);
                    }
                    else
                    {
                        login_wnd = "UILoginWindow";
                        UIManager.Instance.ShowWindow(login_wnd);
                    }
                }
            }
        }
		
		void StateUpdate_LoginPlatform(xc.Machine.State s)
		{
            if(string.IsNullOrEmpty(login_wnd))
            {
                UIManager.Instance.ShowLoadingBK(false);
                mMachine.React((uint)GameEvent.GE_LOGINED_PLATFORM);
            }

            var wnd = UIManager.Instance.GetWindow(login_wnd);
            if (wnd == null)
                return;

            UIManager.Instance.ShowLoadingBK(false);
            mMachine.React((uint)GameEvent.GE_LOGINED_PLATFORM);
        }

        void StateEnter_InitDone(xc.Machine.State s)
        {

        }

        // ----------------- 更换角色状态 -------------------------
        void StateEnter_ChangeRole(xc.Machine.State s)
        {
            if (ChangeRoleManager.Instance.IsChangeRole)
            {
                ChangeRoleManager.Instance.ChangeRole();
            }
        }

        void StateUpdate_ChangeRole(xc.Machine.State s)
        {
            if (!ChangeRoleManager.Instance.IsChangeRole)
            {
                mMachine.React((uint)GameEvent.GE_CHANGE_ROLE_FINISH);
            }
        }

        public static Vector3 PreviewPlayerPos = new Vector3(-0.2f, -0.8f, 18.0f);//-2.72 -0.6 21.86 //2.69
        public static Quaternion PieviewPlayerRot = Quaternion.Euler(0.0f, 90.0f, 0f);
	}
}

