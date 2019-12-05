using Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xc.protocol;

namespace xc
{
    public abstract class WildAoiInfo<T> where T : class, new()
    {
        /// <summary>
        /// id
        /// </summary>
        public uint UUID { get; protected set; }
        
        /// <summary>
        /// 进入视野的aoi信息
        /// </summary>
        public PkgNwarMove AppearInfo { get; protected set; }
        
        /// <summary>
        /// 信息
        /// </summary>
        public T Info { get; protected set; }
        
        /// <summary>
        /// 上一次更新信息的时间
        /// </summary>
        public DateTime LastUpdateTime { get; protected set; }

        /// <summary>
        /// 生成好的actor
        /// </summary>
        protected UnitID mActorUID;
        public virtual Actor Actor
        {
            get
            {
                return ActorManager.Instance.GetActor(mActorUID);
            }
        }
        
        /// <summary>
        /// 是否正在等待角色创建完成(等待角色创建列表更新)
        /// </summary>
        protected bool mIsWaittingCreateActor = false;
        
        public WildAoiInfo(uint uuid)
        {
            UUID = uuid;
        }
        
        public void Reset(uint uuid)
        {
            if (UUID != uuid)
            {
                UUID = uuid;
                AppearInfo = null;
                Info = null;
                mActorUID = null;
                mIsWaittingCreateActor = false;
            }
        }
        
        public static List<uint> WaittingLookList = new List<uint>();
        public static void SendLookImpl()
        {
            if (WaittingLookList.Count > 0)
            {
                var pack = new C2SNwarLook();
                foreach (var uuid in WaittingLookList)
                    pack.uuids.Add(uuid);
                
                NetClient.GetCrossClient().SendData<C2SNwarLook>(NetMsg.MSG_NWAR_LOOK, pack);
                
                WaittingLookList.Clear();
            }
        }
        
        /// <summary>
        /// 发送获取玩家信息
        /// </summary>
        protected virtual void SendUpdateInfo()
        {
            WaittingLookList.Add(UUID);
        }
        
        /// <summary>
        /// 当前的玩家信息是否过期了
        /// </summary>
        protected virtual bool IsInfoOutOfDate
        {
            get { return false; }
        }
        
        /// <summary>
        /// 实际创建Actor
        /// </summary>
        protected virtual void CreateActor()
        {
            mIsWaittingCreateActor = true;
        }
        
        /// <summary>
        /// 处理离开视野
        /// </summary>
        public void HandleDisappear()
        {
            AppearInfo = null;
            
            // 如果还在等待创建，则将其从创建列表中删除
            if (mIsWaittingCreateActor)
            {
                ActorManager.Instance.RemoveUnitCacheData(RemoveUnitCacheData);
                mIsWaittingCreateActor = false;
            }

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LEAVEAOI, new CEventBaseArgs(UUID));
            //if (UUID != null)
            {
                UnitID uid = new UnitID();
                uid.obj_idx = UUID;
                ActorManager.Instance.DestroyActor(uid, 0);
            }
            mActorUID = null;

            // 这里不用清空Info，Info会保存下来，下次再创建同一个玩家时就可以不用获取其信息了
        }
        
        /// <summary>
        /// 处理获取角色详细信息的函数
        /// </summary>
        /// <param name="info"></param>
        public void HandleBriefInfo(T brief_info)
        {
            Info = brief_info;
            LastUpdateTime = Game.GetInstance().GetServerDateTime();
            
            if (Actor != null)
            {
                UpdateAoiInfo(brief_info);
                
                return;
            }
            
            if (AppearInfo == null)
            {
                // Actor还没创建，则等到aoi信息过来再创建，因为其生成坐标是在aoi信息里的
                return;
            }
            
            if (!mIsWaittingCreateActor)
                CreateActor();
        }
        
        /// <summary>
        /// 处理actor创建成功
        /// </summary>
        /// <param name="actor"></param>
        public virtual void HandleActorCreate(Actor actor)
        {
            mIsWaittingCreateActor = false;
        }

        /// <summary>
        /// 处理更新aoi信息的函数
        /// </summary>
        /// <param name="info"></param>
        protected abstract void UpdateAoiInfo(T info);

        /// <summary>
        /// 将UnitCacheInfo从角色列表中删除的函数
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected abstract bool RemoveUnitCacheData(xc.UnitCacheInfo info);

        /// <summary>
        /// 处理角色死亡的函数
        /// </summary>
        public abstract void HandleDead();
    }
}
