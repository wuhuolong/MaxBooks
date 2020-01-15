using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using xc.Dungeon;


using Net;
using xc.ui;

namespace xc
{
	public class PlayingTestState : xc.Machine.State
	{
        bool mUILoaded = false;

		public PlayingTestState (xc.Machine machine) : base((uint)GameState.GS_PLAYING_TEST, machine)
		{
			Init();
		}
		
		void Init()
		{
			// 创建子状态
			xc.Machine.State stateLoadLevel = new xc.Machine.State((uint)GameState.GS_LOADING_LEVEL, mMachine, this);
			xc.Machine.State stateInPlay = new xc.Machine.State((uint)GameState.GS_IN_PLAY, mMachine, this);
			
			stateLoadLevel.SetEnterFunction(StateEnter_Loadlevel);
			stateLoadLevel.SetUpdateFunction(StateUpdate_Loadlevel);
			
			stateInPlay.SetEnterFunction(StateEnter_InPlay);
			stateInPlay.SetUpdateFunction(StateUpdate_InPlay);
			
			// 状态图 -- begin
			stateLoadLevel.AddTransition((uint)GameEvent.GE_LEVEL_LOADED, stateInPlay);
			stateInPlay.AddTransition((uint)GameEvent.GE_RESET, stateLoadLevel);
			// 状态图 -- end
			
			// 设置默认子状态
			this.SetChild(stateLoadLevel);
		}
		
        public override void Enter( params object[] param  )
		{
            mUILoaded = false;
            mExit = false;
            mMachine.React((uint)GameEvent.GE_RESET);

            //MainGame.HeartBehavior.StartCoroutine(LoadUI());

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_MONSTERDEAD, OnMonsterDead);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_EXITINSTANCE, OnExitInstance);
            xc.ClientEventManager<ClientEventType.ugui.UICoreEvent>.Instance.SubscribeClientEvent(ClientEventType.ugui.UICoreEvent.UILOADDONE, OnResoueLoadDone);

           
            xc.ui.ugui.UIManager.Instance.ShowWindow("UIMainmapWindow");

            base.Enter( param );
		}

        private IEnumerator LoadUI()
        {
            mUILoaded = false;
            yield return MainGame.HeartBehavior.StartCoroutine(ui.ugui.UIManager.Instance.SwitchUI("UIInstanceWindow"));
            mUILoaded = true;
        }
		
		public override void Exit ()
		{
            xc.ClientEventManager<ClientEventType.ugui.UICoreEvent>.Instance.UnsubscribeClientEvent(ClientEventType.ugui.UICoreEvent.UILOADDONE, OnResoueLoadDone);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_MONSTERDEAD, OnMonsterDead);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_EXITINSTANCE, OnExitInstance);

			base.Exit ();
		}
        void OnResoueLoadDone(xc.ClientEventBaseArgs args)
        {
            mUILoaded = true;
        }

            bool PlayerPosInited = false;

		public override void Update()
		{
			// 处理AOI的缓存信息
            if (Game.Instance.CameraControl != null)
            {
				ActorManager.Instance.UpdateUnitCache(false);

                if(PlayerPosInited == false)
                {
                    Actor act = Game.GetInstance().GetLocalPlayer();
                    if(act != null)
                    {
                        CameraControl camCtrl = Game.Instance.CameraControl;
                        act.transform.position = camCtrl.transform.position;
                        PlayerPosInited = true;
                    }
                }
            }
			
			base.Update();
		}
		
		void StateEnter_Loadlevel(xc.Machine.State s)
		{}
		
		void StateUpdate_Loadlevel(xc.Machine.State s)
		{
			if (Game.GetInstance().GetLoadAsyncOp() == null)
				return;
			
			if (Game.GetInstance().GetLoadAsyncOp().isDone && mUILoaded)
			{
				mMachine.React((uint)xc.GameEvent.GE_LEVEL_LOADED);
			}
		}
		
		// 开始游戏状态
		void StateEnter_InPlay(xc.Machine.State s)
		{
            DebugUI.Command cmd = new DebugUI.Command();
            cmd.main = "localplayer";
            cmd.paramArray = new List<string>();
            cmd.paramArray.Add("101"); //619.2289 155.3159 576.4397
            cmd.paramArray.Add("60"); //x
            cmd.paramArray.Add("12.5"); //y
            cmd.paramArray.Add("70"); //z
            DebugCommand.OnProcessCmd(cmd);

            //测试关卡
            LevelManager.Instance.LoadLevelFile(6000, false);
        }
		
		void StateUpdate_InPlay(xc.Machine.State s)
		{
			if(mExit)
            {
                Game.GetInstance().GetFSM().React((uint)GameEvent.GE_DISCONNECT);
            }

            LocalPlayer localPlayer = Game.GetInstance().GetLocalPlayer() as LocalPlayer;
            if(localPlayer != null)
            {
                localPlayer.CurMp = 10000;
            }
		}

        bool mExit = false;

        /// <summary>
        /// 响应玩家主动退出副本事件
        /// </summary>
        void OnExitInstance(CEventBaseArgs data)
        {
            mExit = true;
        }

        public void OnMonsterDead(CEventBaseArgs data)
        {
            UnitID uid = (UnitID)data.arg;
            Actor act = ActorManager.Instance.GetActor(uid);
            if (act != null)
            {
                act.SetAI(null);
                ActorManager.Instance.DestroyActor(uid, 5);
            }
        }
	}
}

