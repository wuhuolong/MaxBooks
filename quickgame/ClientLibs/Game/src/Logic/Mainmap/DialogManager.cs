/*----------------------------------------------------------------
// 文件名： DialogManager.cs
// 文件功能描述： 剧情对话管理类
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc.ui.ugui;

namespace xc
{
    [wxb.Hotfix]
    public class DialogManager : xc.Singleton<DialogManager>
    {
        DBDialog.DialogInfo mDialogInfo;
        uint mDialogIndex;

        string mCustomName = "";
        Actor mOtherPlayer = null;
        uint mActorId = 0;

        string mCutsceneSequencerName;

        System.Action mFinishedCallback;
        System.Action mSkipedCallback;

        Task mRelatedTask;

        Dictionary<uint, DBDialog.DialogInfo> mBubbleDialogInfos;
        Dictionary<uint, uint> mBubbleDialogIndexs;
        Dictionary<uint, System.Action> mBubbleFinishedCallbacks;
        Dictionary<uint, Utils.Timer> mBubbleTimers;

        uint mPlayingVoiceDialogId = 0;

        public DialogManager()
        {
        }

        public void Reset()
        {
            mDialogInfo = null;
            mDialogIndex = 0;

            mRelatedTask = null;

            mBubbleDialogInfos = new Dictionary<uint, DBDialog.DialogInfo>();
            mBubbleDialogInfos.Clear();
            mBubbleDialogIndexs = new Dictionary<uint, uint>();
            mBubbleDialogIndexs.Clear();
            mBubbleFinishedCallbacks = new Dictionary<uint, System.Action>();
            mBubbleFinishedCallbacks.Clear();
            mBubbleTimers = new Dictionary<uint, Utils.Timer>();
            mBubbleTimers.Clear();

            mPlayingVoiceDialogId = 0;
        }

        /// <summary>
        /// 触发相应的对话框
        /// </summary>
        /// <returns><c>true</c>, if dialog story was triggered, <c>false</c> otherwise.</returns>
        /// <param name="dialogInfo">Dialog info.</param>
        public bool TriggerDialogBox(DBDialog.DialogInfo dialogInfo, string customName, Actor otherPlayer, uint actorId, System.Action finishedCallback, System.Action skipedCallback, Task relatedTask)
        {
            ClearDialog();

            // 是否在系统开放中
            if (SysConfigManager.Instance.IsWaiting() == true)
            {
                GameDebug.LogWarning("DialogManager.TriggerDialogBox SysConfigManager is waiting!!");
                return false;
            }

            if (dialogInfo != null)
            {
                GameDebug.Log("Trigger dialog box: " + dialogInfo.mId);

                mDialogInfo = dialogInfo;
                mDialogIndex = 0;

                mCustomName = customName;
                mOtherPlayer = otherPlayer;
                mActorId = actorId;

                mFinishedCallback = finishedCallback;
                mSkipedCallback = skipedCallback;

                mRelatedTask = relatedTask;

                ShowDialogWindow();

                return true;
            }
            else
            {
                if (finishedCallback != null)
                {
                    finishedCallback();
                }
            }

            return false;
        }

        public bool TriggerDialogBox(DBDialog.DialogInfo dialogInfo)
        {
            return TriggerDialogBox(dialogInfo, "", null, 0, null, null, null);
        }

        public bool TriggerDialogBox(DBDialog.DialogInfo dialogInfo, string customName, Actor otherPlayer, uint actorId = 0)
        {
            return TriggerDialogBox(dialogInfo, customName, otherPlayer, actorId, null, null, null);
        }

        void GoToNextBubble(float remainTime, Utils.Timer timer)
        {
            DBDialog.DialogInfo dialogInfo = timer.UserData as DBDialog.DialogInfo;

            if (dialogInfo == null)
                return;

            uint dialogNum = (uint)dialogInfo.mDialogs.Count;
            uint bubbleDialogIndex = 0;
            if (mBubbleDialogIndexs.TryGetValue(dialogInfo.mId, out bubbleDialogIndex) && bubbleDialogIndex < (dialogNum - 1)) // 对话还没完
            {
                bubbleDialogIndex++;
                mBubbleDialogIndexs[dialogInfo.mId] = bubbleDialogIndex;

                TriggerBubbleImpl(bubbleDialogIndex, dialogInfo);
            }
            else
            {
                if (timer != null)
                {
                    timer.Destroy();
                    timer = null;
                }

                System.Action bubbleFinishedCallback;
                if (mBubbleFinishedCallbacks.TryGetValue(dialogInfo.mId, out bubbleFinishedCallback))
                {
                    if (bubbleFinishedCallback != null)
                    {
                        bubbleFinishedCallback();
                    }
                }

                if (mBubbleDialogInfos.ContainsKey(dialogInfo.mId))
                {
                    mBubbleDialogInfos.Remove(dialogInfo.mId);
                }
                if (mBubbleDialogIndexs.ContainsKey(dialogInfo.mId))
                {
                    mBubbleDialogIndexs.Remove(dialogInfo.mId);
                }
                if (mBubbleFinishedCallbacks.ContainsKey(dialogInfo.mId))
                {
                    mBubbleFinishedCallbacks.Remove(dialogInfo.mId);
                }
                if (mBubbleTimers.ContainsKey(dialogInfo.mId))
                {
                    mBubbleTimers.Remove(dialogInfo.mId);
                }
            }
        }

        bool TriggerBubbleImpl(uint dialogIndex, DBDialog.DialogInfo dialogInfo)
        {
            if (dialogIndex >= dialogInfo.mDialogs.Count)
            {
                return false;
            }

            List<uint> dialogs = dialogInfo.mDialogs;
            DBDialogContent dbDialogContent = DBManager.GetInstance().GetDB<DBDialogContent>();
            DBDialogContent.DialogContentInfo dialogContentInfo = dbDialogContent.GetDialogContentInfo(dialogs[(int)dialogIndex]);

            Actor actor = null;

            if (dialogContentInfo.mObjectType == DBDialogContent.EDialogObjectType.DOT_Player)
            {
                actor = Game.GetInstance().GetLocalPlayer();
            }
            else if (dialogContentInfo.mObjectType == DBDialogContent.EDialogObjectType.DOT_NPC)
            {
                actor = NpcManager.Instance.GetNpcByNpcId(dialogContentInfo.mObjectParam);
            }
            else if (dialogContentInfo.mObjectType == DBDialogContent.EDialogObjectType.DOT_Monster)
            {
                //List<Actor> actors = InstanceHelper.GetMonstersByMonsterGroupId((int)dialogContentInfo.mObjectParam);
                //if (actors != null && actors.Count > 0)
                //{
                //    actor = actors[0];
                //}
            }
            if (actor == null)
            {
                GameDebug.LogError("TriggerBubble error, actor is null!!!");
                return false;
            }
            actor.ShowDialogBubble(dialogContentInfo.mWords, (int)dialogContentInfo.mLength);


            Utils.Timer bubbleTimer;
            if (mBubbleTimers.TryGetValue(dialogInfo.mId, out bubbleTimer))
            {
                if (bubbleTimer != null)
                {
                    bubbleTimer.Destroy();
                    bubbleTimer = null;
                }
                mBubbleTimers.Remove(dialogInfo.mId);
            }
            bubbleTimer = new Utils.Timer(1000 * (int)dialogContentInfo.mLength, false, 1000 * dialogContentInfo.mLength, GoToNextBubble, dialogInfo);
            mBubbleTimers.Add(dialogInfo.mId, bubbleTimer);

            return true;
        }

        public bool TriggerBubble(DBDialog.DialogInfo dialogInfo, System.Action finishedCallback)
        {
            bool ret = false;
            if (dialogInfo != null)
            {
                //GameDebug.Log("Trigger dialog bubble: " + dialogInfo.mId);

                if (mBubbleDialogInfos.ContainsKey(dialogInfo.mId))
                {
                    mBubbleDialogInfos.Remove(dialogInfo.mId);
                }
                if (mBubbleDialogIndexs.ContainsKey(dialogInfo.mId))
                {
                    mBubbleDialogIndexs.Remove(dialogInfo.mId);
                }
                if (mBubbleFinishedCallbacks.ContainsKey(dialogInfo.mId))
                {
                    mBubbleFinishedCallbacks.Remove(dialogInfo.mId);
                }
                if (mBubbleTimers.ContainsKey(dialogInfo.mId))
                {
                    mBubbleTimers.Remove(dialogInfo.mId);
                }

                mBubbleDialogInfos.Add(dialogInfo.mId, dialogInfo);
                mBubbleDialogIndexs.Add(dialogInfo.mId, 0);
                mBubbleFinishedCallbacks.Add(dialogInfo.mId, finishedCallback);

                ret = TriggerBubbleImpl(0, dialogInfo);
            }

            if (ret == false)
            {
                if (finishedCallback != null)
                {
                    finishedCallback();
                }
            }
            return ret;
        }

        public bool TriggerBubble(DBDialog.DialogInfo dialogInfo)
        {
            return TriggerBubble(dialogInfo, null);
        }

        public bool TriggerDialog(uint dialogId, string customName, Actor otherPlayer, uint actorId, System.Action finishedCallback, System.Action skipedCallback, Task relatedTask)
        {
            //dialogId = 1014;

            DBDialog dbDialog = DBManager.GetInstance().GetDB<DBDialog>();
            DBDialog.DialogInfo dialogInfo = dbDialog.GetDialog(dialogId);

            if (dialogInfo == null)
            {
                GameDebug.LogError("Trigger dialog error, can not find dialog " + dialogId);

                if (finishedCallback != null)
                {
                    finishedCallback();
                }
                return false;
            }

            if (dialogInfo.mType == DBDialog.EDialogType.IST_DialogBox)
            {
                return TriggerDialogBox(dialogInfo, customName, otherPlayer, actorId, finishedCallback, skipedCallback, relatedTask);
            }
            else if (dialogInfo.mType == DBDialog.EDialogType.IST_Bubble)
            {
                TriggerBubble(dialogInfo, finishedCallback);
            }

            return false;
        }

        public bool TriggerDialog(uint dialogId, string customName, Actor otherPlayer, uint actorId, System.Action finishedCallback, System.Action skipedCallback)
        {
            return TriggerDialog(dialogId, customName, otherPlayer, actorId, finishedCallback, skipedCallback, null);
        }

        public bool TriggerDialog(uint dialogId, string customName, Actor otherPlayer, uint actorId, System.Action finishedCallback)
        {
            return TriggerDialog(dialogId, customName, otherPlayer, actorId, finishedCallback, null, null);
        }

        public bool TriggerDialog(uint dialogId, string customName, Actor otherPlayer, System.Action finishedCallback)
        {
            return TriggerDialog(dialogId, customName, otherPlayer, 0, finishedCallback, null, null);
        }

        public bool TriggerDialog(uint dialogId, string customName, uint actorId, System.Action finishedCallback)
        {
            return TriggerDialog(dialogId, customName, null, actorId, finishedCallback, null, null);
        }

        public bool TriggerDialog(uint dialogId, uint actorId, System.Action finishedCallback)
        {
            return TriggerDialog(dialogId, string.Empty, null, actorId, finishedCallback, null, null);
        }

        public bool TriggerDialog(uint dialogId, System.Action finishedCallback)
        {
            return TriggerDialog(dialogId, "", null, 0, finishedCallback, null, null);
        }

        public bool TriggerDialog(uint dialogId)
        {
            return TriggerDialog(dialogId, null);
        }

        public bool TriggerDialog(uint dialogId, System.Action finishedCallback, Transform source)
        {
            if (source != null)
            {
                ActorMono actMono = ActorHelper.GetActorMono(source);
                if (actMono != null)
                {
                    NpcPlayer sourceActor = actMono.BindActor as NpcPlayer;
                    if (sourceActor != null)
                    {
                        sourceActor.TurnToLocalPlayer();
                    }
                }


            }

            return TriggerDialog(dialogId, finishedCallback);
        }

        /// <summary>
        /// 去往下一个对话
        /// </summary>
        public void GotoNextDialog()
        {
            if (mDialogInfo == null)
            {
                FinishDialog();
                return;
            }

            uint dialogNum = (uint)mDialogInfo.mDialogs.Count;
            if (mDialogIndex < (dialogNum - 1))	// 对话还没完
            {
                mDialogIndex++;

                //System.Action callback = () =>
                //{
                //    ShowDialogWindow();
                //};
                //HideDialogWindow(callback);
                UpdateDialogWindowInfo();
            }
            else
            {
                FinishDialog();
            }
        }

        void ClearDialog()
        {
            if (mDialogInfo != null)
            {
                GameDebug.Log("Clear dialog box: " + mDialogInfo.mId);
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_DIALOG_END, new CEventBaseArgs(mDialogInfo));
            }

            DestroyDialogWindow();

            Reset();

            mCustomName = "";
            mOtherPlayer = null;
            mActorId = 0;
        }

        /// <summary>
        /// 跳过对话
        /// </summary>
        public void SkipDialog()
        {
            if (mSkipedCallback != null)
            {
                mSkipedCallback();
                mSkipedCallback = null;
            }

            ClearDialog();
        }

        /// <summary>
        /// 完成对话
        /// </summary>
        public void FinishDialog()
        {
            if (mFinishedCallback != null)
            {
                mFinishedCallback();
                mFinishedCallback = null;
            }

            ClearDialog();
        }

        void ShowDialogWindow()
        {
            if (mDialogInfo == null)
            {
                return;
            }

            UIManager uiMgr = UIManager.GetInstance();

            DBDialogContent dbDialogContent = DBManager.GetInstance().GetDB<DBDialogContent>();
            uint dialogContentInfoId = mDialogInfo.mDialogs[(int)mDialogIndex];
            DBDialogContent.DialogContentInfo dialogContentInfo = dbDialogContent.GetDialogContentInfo(dialogContentInfoId);
            if (dialogContentInfo != null)
            {
                uint dialogNum = (uint)mDialogInfo.mDialogs.Count;
                CheckPlayVoice(dialogContentInfo);
                if (mDialogIndex < (dialogNum - 1)) // 对话还没完
                {
                    uiMgr.ShowSysWindow("UIDialogWindow", mDialogInfo.mAutoRunTime, dialogContentInfo, mCustomName, mOtherPlayer, mActorId, mRelatedTask, false);
                }
                else
                {
                    uiMgr.ShowSysWindow("UIDialogWindow", mDialogInfo.mAutoRunTime, dialogContentInfo, mCustomName, mOtherPlayer, mActorId, mRelatedTask, true);
                }
            }
            else
            {
                GameDebug.LogError("Can not find dialog content info by id " + dialogContentInfoId);
            }
        }

        void HideDialogWindow(System.Action finishedCallback)
        {
            UIManager.Instance.CloseSysWindow("UIDialogWindow");
            finishedCallback();
        }

        void UpdateDialogWindowInfo()
        {
            if (mDialogInfo == null)
            {
                return;
            }

            DBDialogContent dbDialogContent = DBManager.GetInstance().GetDB<DBDialogContent>();
            uint dialogContentInfoId = mDialogInfo.mDialogs[(int)mDialogIndex];
            DBDialogContent.DialogContentInfo dialogContentInfo = dbDialogContent.GetDialogContentInfo(dialogContentInfoId);
            if (dialogContentInfo != null)
            {
                uint dialogNum = (uint)mDialogInfo.mDialogs.Count;
                CheckPlayVoice(dialogContentInfo);
                if (mDialogIndex < (dialogNum - 1)) // 对话还没完
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_UPDATE_DIALOG_WINDOW_INFO,
                        new CEventObjectArgs(mDialogInfo.mAutoRunTime, dialogContentInfo, mCustomName, mOtherPlayer, mActorId, mRelatedTask, false));
                }
                else
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_UPDATE_DIALOG_WINDOW_INFO,
                        new CEventObjectArgs(mDialogInfo.mAutoRunTime, dialogContentInfo, mCustomName, mOtherPlayer, mActorId, mRelatedTask, true));
                }
            }
            else
            {
                GameDebug.LogError("Can not find dialog content info by id " + dialogContentInfoId);
            }
        }

        void DestroyDialogWindow()
        {
            UIManager.Instance.CloseSysWindow("UIDialogWindow");
        }

        public string CutsceneSequencerName
        {
            get { return mCutsceneSequencerName; }
            set { mCutsceneSequencerName = value; }
        }


        private void CheckPlayVoice(DBDialogContent.DialogContentInfo dialogContentInfo)
        {
            if (mDialogInfo == null || mDialogInfo.mType != DBDialog.EDialogType.IST_DialogBox)
                return;

            if (dialogContentInfo == null || dialogContentInfo.mObjectType != DBDialogContent.EDialogObjectType.DOT_Other)
                return;

            if (mDialogInfo.mId == mPlayingVoiceDialogId)
                return;

            if (mOtherPlayer == null || !mOtherPlayer.IsNpc())
                return;

            NpcPlayer npc = (NpcPlayer)mOtherPlayer;
            if(npc != null)
            {
                mPlayingVoiceDialogId = mDialogInfo.mId;
                npc.PlayRandomVoice();
            }

        }

    }
}
