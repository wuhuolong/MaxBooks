using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class WorshipModelHeadBehavior : IActorBehavior
    {
        UI3DText mTextComponent = null;
        UI3DText mWorshipButtonComponent = null;

        public WorshipModelHeadBehavior(WorshipModel owner)
        {
            mOwner = owner;
        }

        public override void InitBehaviors()
        {
            mOwner.SubscribeActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, OnModelChange);
        }

        public override void Update()
        {
        }

        public override void LateUpdate()
        {
        }

        public override void UnInitBehaviors()
        {
            base.UnInitBehaviors();
        }

        public override void EnableBehaviors(bool enable)
        {
        }

        void OnModelChange(CEventBaseArgs param)
        {
            WorshipModel owner = mOwner as WorshipModel;
            if (owner == null)
            {
                return;
            }

            // 头顶名字
            if (mTextComponent != null)
            {
                UnityEngine.Object.DestroyImmediate(mTextComponent);
            }
            mTextComponent = mOwner.GetModelParent().AddComponent<UI3DText>();
            UI3DText.StyleInfo styleInfo = new UI3DText.StyleInfo();
            float modelScale = GameConstHelper.GetFloat("GAME_DUNGEON_WORSHIP_MODEL_SCALE");
            styleInfo.HeadOffset = new Vector3(0f, mOwner.Height * modelScale, 0f);
            styleInfo.ScreenOffset = UI3DText.NameTextScreenOffset * modelScale;
            mTextComponent.SetHeadTrans(mOwner.GetModelParent().transform);
            mTextComponent.ResetStyleInfo(styleInfo);
            string text = "<color=#ffc319>" + owner.Rank.ToString();
            if (owner.Rank == 1)
            {
                text = text + DBConstText.GetText("ANSWER_WORSHIP_1"); // "st雕像";
            }
            else if (owner.Rank == 2)
            {
                text = text + DBConstText.GetText("ANSWER_WORSHIP_2");  //"nd雕像";
            }
            else if (owner.Rank == 3)
            {
                text = text + DBConstText.GetText("ANSWER_WORSHIP_3");  //"rd雕像";
            }
            else
            {
                text = text + DBConstText.GetText("ANSWER_WORSHIP_4");  //"th雕像";
            }
            text = text + "</color>";
            mTextComponent.RankTextLabel = text;
            mTextComponent.FontSize = 22;
            if (string.IsNullOrEmpty(owner.GuildName) == false)
            {
                mTextComponent.GuildNameTextLabel = "<color=#4ef269><" + owner.GuildName + "></color>";
            }
            mTextComponent.Text = "<color=#5ec4ff>" + owner.UserName + "</color>";

            // 膜拜按钮
            if (mWorshipButtonComponent != null)
            {
                UnityEngine.Object.DestroyImmediate(mWorshipButtonComponent);
            }
            mWorshipButtonComponent = mOwner.GetModelParent().AddComponent<UI3DText>();
            styleInfo = new UI3DText.StyleInfo();
            modelScale = GameConstHelper.GetFloat("GAME_DUNGEON_WORSHIP_MODEL_SCALE");
            styleInfo.HeadOffset = Vector3.zero;
            styleInfo.ScreenOffset = Vector3.zero;
            mWorshipButtonComponent.SetHeadTrans(ModelHelper.FindChildInHierarchy(mOwner.GetModelParent().transform, "root_node"));
            mWorshipButtonComponent.ResetStyleInfo(styleInfo);
            mWorshipButtonComponent.SetButtonStyle("MainWindow_New@Chatting@Praisebtn", DBConstText.GetText("WORSHIP"), 24, new Color(0.2f, 0.2f, 0.2f), new Vector3(0f, -9f, 0f));
            UnityEngine.UI.Image buttonImage = mWorshipButtonComponent.ButtonImage;
            if (buttonImage != null)
            {
                buttonImage.sprite = mWorshipButtonComponent.LoadSprite("MainWindow_New@Chatting@Hands");
                buttonImage.SetNativeSize();
                buttonImage.transform.localPosition = new Vector3(75, 40, 0);
                xc.ui.ugui.TweenPosition tween = xc.ui.ugui.TweenPosition.Begin(buttonImage.gameObject, 0.8f, new Vector3(100, 55, 0));
                tween.style = ui.ugui.UITweener.Style.PingPong;
                buttonImage.gameObject.SetActive(false);
            }
            mWorshipButtonComponent.SetClickCallback(() =>
            {
                mWorshipButtonComponent.ShowButton(false);
                if (buttonImage != null)
                {
                    buttonImage.gameObject.SetActive(false);
                }

                var data = new C2SPlayerWorship();
                data.rank = owner.Rank;
                NetClient.GetBaseClient().SendData<C2SPlayerWorship>(NetMsg.MSG_PLAYER_WORSHIP, data);

                Actor localPlayer = Game.Instance.GetLocalPlayer();
                if (localPlayer != null)
                {
                    localPlayer.AttackCtrl.Attack(GameConstHelper.GetUint("GAME_DUNGEON_WORSHIP_SKILL_ID"));
                }
            });
            mWorshipButtonComponent.ShowButton(false);

            mTextComponent.Honor = mOwner.Honor;
            mTextComponent.Title = mOwner.Title;
        }

        public void ShowWorshipButton(bool isShow)
        {
            if (mWorshipButtonComponent != null)
            {
                mWorshipButtonComponent.ShowButton(isShow);

                if (isShow == true)
                {
                    // 手指动画，第一次膜拜才显示
                    uint worshipedCount = 0;
                    object[] param = { };
                    System.Type[] returnType = { typeof(int) };
                    object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "WorshipMeetingDataManager_GetWorshipedModelUnitIdsCount", param, returnType);
                    if (objs != null && objs.Length > 0)
                    {
                        if (objs[0] != null)
                        {
                            int a = (int)objs[0];
                            worshipedCount = (uint)a;
                        }
                    }
                    UnityEngine.UI.Image buttonImage = mWorshipButtonComponent.ButtonImage;
                    if (buttonImage != null)
                    {
                        if (worshipedCount == 0)
                        {
                            buttonImage.gameObject.SetActive(true);
                        }
                        else
                        {
                            buttonImage.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        public void ResetHeadInfo()
        {
            //WorshipModel owner = mOwner as WorshipModel;
            //if (mTextComponent != null && owner != null)
            //{
            //    mTextComponent.Text = owner.UserName;
            //    mTextComponent.GuildNameTextLabel = owner.GuildName;
            //}
        }

        /// <summary>
        /// 设置头衔
        /// </summary>
        public uint Honor
        {
            set
            {
                if (mTextComponent != null)
                {
                    mTextComponent.Honor = value;
                }
            }
        }

        /// <summary>
        /// 设置称号
        /// </summary>
        public uint Title
        {
            set
            {
                if (mTextComponent != null)
                {
                    mTextComponent.Title = value;
                }
            }
        }
    }
}
