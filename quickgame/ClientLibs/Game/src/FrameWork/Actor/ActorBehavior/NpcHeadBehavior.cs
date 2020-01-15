using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;

namespace xc
{
    [wxb.Hotfix]
    public class NpcHeadBehavior : IActorBehavior
    {
        public const string TASK_STATE = "TaskState";
        public const string FUNCTION_NAME = "FunctionName";
        public const string FUNCTION_ICON = "FunctionIcon";

        private bool mDirty = true;

        private const string TASK_ACCEPT_STATE_ICON_PREFAB = "Assets/" + ResPath.path11;
        private const string TASK_DOING_STATE_ICON_PREFAB = "Assets/" + ResPath.path9;
        private const string TASK_DONE_STATE_ICON_PREFAB = "Assets/" + ResPath.path10;

        public NpcHeadBehavior(NpcPlayer owner)
        {
            mOwner = owner;
        }

        public override void InitBehaviors()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.TASK_CHANGED, OnTaskUpdate);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);
        }

        public override void Update()
        {
            BuildIcons();
        }

        public override void LateUpdate()
        {
           
        }

        public override void UnInitBehaviors()
        {
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);

            base.UnInitBehaviors();

            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.TASK_CHANGED, OnTaskUpdate);
        }

        public override void EnableBehaviors(bool enable)
        {
            
        }

        public void BuildIcons()
        {
            NpcPlayer mNpc = (NpcPlayer)mOwner;
            if(mNpc == null || mNpc.Define == null)
            {
                return;
            }

            if (!mDirty)
            {
                return;
            }

            if (!mOwner.IsResLoaded)
            {
                return;
            }

            float nextHeightOffset = mOwner.Height;

            // 名称
            TextNameBehavior textName = mNpc.GetBehavior<TextNameBehavior>();
            if(textName != null)
            {
                textName.HeadOffset = new Vector3(0.0f, nextHeightOffset, 0.0f);
                nextHeightOffset += 0.2f;
            }

            BuildTaskStateIcon(null);

            // Npc任务
            List<Task> tasks = TaskManager.Instance.GetNpcRelateCurrentStepTasks((uint)mNpc.NpcData.Id);
            if (tasks.Count > 0)
            {
                Task task = null;

                // 显示顺序：可提交>可接>进行中
                foreach (var item in tasks)
                {
                    if(item.State == GameConst.QUEST_STATE_DONE)
                    {
                        task = item;
                    }
                }
                if (task == null)
                {
                    foreach (var item in tasks)
                    {
                        if (item.State == GameConst.QUEST_STATE_ACCEPT || item.State == GameConst.QUEST_STATE_FAIL)
                        {
                            task = item;
                        }
                    }
                }
                if (task == null)
                {
                    foreach (var item in tasks)
                    {
                        if (item.State == GameConst.QUEST_STATE_DOING)
                        {
                            task = item;
                        }
                    }
                }
                if (task == null)
                {
                    task = tasks[0];
                }

                BuildTaskStateIcon(task);

                nextHeightOffset += 2.3f;
            }

            mDirty = false;
        }

        void BuildTaskStateIcon(Task task)
        {
            string iconPrefabPath = "";

            NpcPlayer mNpc = (NpcPlayer)mOwner;
            if (mNpc != null)
            {
                if (NpcHelper.NpcCanAcceptBountyTask((uint)mNpc.NpcData.Id) == true)
                {
                    iconPrefabPath = TASK_ACCEPT_STATE_ICON_PREFAB;
                }
                else if (NpcHelper.NpcCanAcceptGuildTask((uint)mNpc.NpcData.Id) == true)
                {
                    iconPrefabPath = TASK_ACCEPT_STATE_ICON_PREFAB;
                }
                else if (NpcHelper.NpcCanAcceptEscortTask((uint)mNpc.NpcData.Id) == true)
                {
                    iconPrefabPath = TASK_ACCEPT_STATE_ICON_PREFAB;
                }
            }

            if (string.IsNullOrEmpty(iconPrefabPath) == true && task != null)
            {
                if (task.State == GameConst.QUEST_STATE_ACCEPT)
                {
                    iconPrefabPath = TASK_ACCEPT_STATE_ICON_PREFAB;
                }
                else if (task.State == GameConst.QUEST_STATE_DOING)
                {
                    iconPrefabPath = TASK_DOING_STATE_ICON_PREFAB;
                }
                else if (task.State == GameConst.QUEST_STATE_DONE)
                {
                    iconPrefabPath = TASK_DONE_STATE_ICON_PREFAB;
                }
            }
            
            if (string.IsNullOrEmpty(iconPrefabPath) == false)
            {
                UI3DGameObject component = mOwner.GetModelParent().GetComponent<UI3DGameObject>();
                if (component != null)
                {
                    UnityEngine.Object.DestroyImmediate(component);
                }
                component = mOwner.GetModelParent().AddComponent<UI3DGameObject>();

                UI3DGameObject.StyleInfo styleInfo = new UI3DGameObject.StyleInfo();
                styleInfo.Offset = new Vector3(0f, mOwner.Height, 0f);
                styleInfo.ScreenOffset = new Vector3(0f, 60f, 0f);
                styleInfo.Scale = Vector3.one;
                styleInfo.PrefabPath = iconPrefabPath;
                component.ResetStyleInfo(styleInfo);
            }
            else
            {
                UI3DGameObject component = mOwner.GetModelParent().GetComponent<UI3DGameObject>();
                if (component != null)
                {
                    UnityEngine.Object.DestroyImmediate(component);
                }
            }
        }

        private void OnTaskUpdate(CEventBaseArgs args)
        {
            mDirty = true;
        }

        void OnAfterCreate(CEventBaseArgs param)
        {
            //mHeadTrans = mOwner.GetModelParent().transform;
            //HeadOffset = new Vector3(0f, mOwner.Height, 0f);
        }

        void OnModelChange(CEventBaseArgs param)
        {
            //HeadOffset = new Vector3(0f, mOwner.Height, 0f);
        }
    }
}