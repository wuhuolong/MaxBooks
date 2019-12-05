//------------------------------------------------------------------------------
// Desc   :  通用进度条助手
// Author :  ljy
// Date   :  2017.5.25
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System;
using xc;

namespace xc
{
    [wxb.Hotfix]
    public class CommonSliderHelper
    {
        static Utils.Timer mTimer = null;
        static int mSecond = 1;
        static string mText;
        static string mPic;
        static Action mInterruptCallback;
        static Action mFinishCallback;

        static void Clear()
        {
            if (mTimer != null)
            {
                mTimer.Destroy();
                mTimer = null;
            }
            mSecond = 1;
            mText = "";
            mPic = "";
            mInterruptCallback = null;
            mFinishCallback = null;

            var localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
            {
                localPlayer.UnsubscribeActorEvent(Actor.ActorEvent.EXITIDLE, OnLocalPlayerBeInterrupted);
                localPlayer.UnsubscribeActorEvent(Actor.ActorEvent.BEATTACK, OnLocalPlayerBeInterrupted);
                localPlayer.UnsubscribeActorEvent(Actor.ActorEvent.DEAD, OnLocalPlayerBeInterrupted);
            }
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_PLAYERCONTROLED, OnPlayerControlled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, OnPlayerControlled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_CLICKCOLLISION, OnPlayerControlled);

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CONTROL_COMMON_SLIDER, new CEventObjectArgs(false, 0f, "", ""));
        }

        static void UpdateTimer(float remainTime)
        {
            if (remainTime > 0)
            {
                float floatSecond = (float)(mSecond);
                float p = (floatSecond - remainTime / 1000f) / floatSecond;
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CONTROL_COMMON_SLIDER, new CEventObjectArgs(true, p, mText, mPic));
            }
            else
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CONTROL_COMMON_SLIDER, new CEventObjectArgs(false, 0f, "", ""));
                Finish();
            }
        }

        static void OnLocalPlayerBeInterrupted(CEventBaseArgs evt)
        {
            Interrupt();
        }

        static void OnPlayerControlled(CEventBaseArgs args)
        {
            Interrupt();
        }

        public static void Start(int second, string text, string pic, Action interruptCallback, Action finishCallback, bool canBeInterruptedWhenBeAttacked)
        {
            Clear();

            mSecond = second;
            mText = text;
            mPic = pic;
            mInterruptCallback = interruptCallback;
            mFinishCallback = finishCallback;

            mTimer = new Utils.Timer(second * 1000, false, 50, UpdateTimer);

            var localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
            {
                localPlayer.UnsubscribeActorEvent(Actor.ActorEvent.EXITIDLE, OnLocalPlayerBeInterrupted);
                localPlayer.UnsubscribeActorEvent(Actor.ActorEvent.BEATTACK, OnLocalPlayerBeInterrupted);
                localPlayer.UnsubscribeActorEvent(Actor.ActorEvent.DEAD, OnLocalPlayerBeInterrupted);

                if (canBeInterruptedWhenBeAttacked == true)
                {
                    localPlayer.SubscribeActorEvent(Actor.ActorEvent.EXITIDLE, OnLocalPlayerBeInterrupted);
                    localPlayer.SubscribeActorEvent(Actor.ActorEvent.BEATTACK, OnLocalPlayerBeInterrupted);
                }
                localPlayer.SubscribeActorEvent(Actor.ActorEvent.DEAD, OnLocalPlayerBeInterrupted);
            }
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_PLAYERCONTROLED, OnPlayerControlled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, OnPlayerControlled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_CLICKCOLLISION, OnPlayerControlled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_LOCAL_PLAYER_EXIT_INTERACTION, OnPlayerControlled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_PLAYERCONTROLED, OnPlayerControlled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, OnPlayerControlled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_CLICKCOLLISION, OnPlayerControlled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_LOCAL_PLAYER_EXIT_INTERACTION, OnPlayerControlled);

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CONTROL_COMMON_SLIDER, new CEventObjectArgs(true, 0, mText, mPic));
        }

        public static void Start(int second, string text, string pic, Action interruptCallback, Action finishCallback)
        {
            Start(second, text, pic, interruptCallback, finishCallback, true);
        }

        public static void Start(int second, string text, string pic)
        {
            Start(second, text, pic, null, null, true);
        }

        public static void Start(int second)
        {
            Start(second, "", "", null, null);
        }

        public static void Interrupt(bool executeCallback = true)
        {
            if (mInterruptCallback != null && executeCallback == true)
            {
                mInterruptCallback();
            }

            Clear();
        }

        static void Finish()
        {
            if (mFinishCallback != null)
            {
                mFinishCallback();
            }

            Clear();
        }
    }
}