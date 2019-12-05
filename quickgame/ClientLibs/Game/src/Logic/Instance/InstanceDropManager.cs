using Net;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using xc.protocol;
using xc.Maths;
using xc.ui;
using xc;

namespace xc
{
    [wxb.Hotfix]
    public class InstanceDropManager : xc.Singleton<InstanceDropManager>
    {
        public static readonly uint UPDATE_DURATION_IN_MS = 2000;

        List<DropComponent> mDrops;
        Vector2 mDropFrameSize = new Vector2(200f, 40f);

        int mMaxDropNum = 100;

        private GameObject mDropObjectTemplate = null;
        public GameObject DropObjectTemplate
        {
            get
            {
                if (mDropObjectTemplate == null)
                {
                    mDropObjectTemplate = SGameEngine.ResourceLoader.Instance.try_load_cached_asset("Assets/" + ResPath.path12) as GameObject;
                    if (mDropObjectTemplate != null)
                    {
                        mDropObjectTemplate.SetActive(false);
                    }
                }
                return mDropObjectTemplate;
            }
        }

        public InstanceDropManager()
        {
            mMaxDropNum = GameConstHelper.GetInt("GAME_DROP_MAX_NUM");
        }

        public void Reset()
        {
            DestroyAllDrops();
        }

        public void RegisterAllMessages()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SWITCHINSTANCE, OnSwitchScene);
        }

        public List<DropComponent> Drops
        {
            get
            {
                return mDrops;
            }
        }

        public void DestroyAllDrops()
        {
            if (mDrops != null)
            {
                List<uint> listToDestroy = SGameEngine.Pool<uint>.List.New(mDrops.Count);
                foreach (DropComponent drop in mDrops)
                {
                    if (drop.DropInfo != null)
                    {
                        listToDestroy.Add(drop.DropInfo.oid);
                    }
                }
                foreach (uint oid in listToDestroy)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_DESTROY_DROP, new CEventBaseArgs(oid));
                }
                SGameEngine.Pool<uint>.List.Free(listToDestroy);
                mDrops.Clear();
            }
        }

        void OnSwitchScene(CEventBaseArgs evt)
        {
            Reset();
        }

        public void AddDrop(DropComponent drop)
        {
            if (drop == null)
            {
                return;
            }

            // 如果掉落已经存在，不要处理
            var oldDrop = GetDrop(drop.Id);
            if (oldDrop != null)
            {
                GameDebug.LogError("重复的掉落，id为" + drop.Id);
                return;
            }

            if (mDrops == null)
            {
                mDrops = new List<DropComponent>();
                mDrops.Clear();
            }

            mDrops.Add(drop);

            // 如果当前正在任务导航，则先拾取掉落，重新导航就可以了
            // 自动战斗的ai会自动拾取掉落的，所以这里要屏蔽
            if (TargetPathManager.Instance.IsNavigating == true && InstanceManager.Instance.IsAutoFighting == false && TaskManager.Instance.NavigatingTask != null && SceneHelp.Instance.IsInWildInstance() == true)
            {
                TaskHelper.TaskGuide(TaskManager.Instance.NavigatingTask);
            }
        }

        public void RemoveDrop(DropComponent drop)
        {
            if (drop == null)
            {
                GameDebug.LogError("Error in remove drop, drop is null!!!");
                return;
            }
            if (mDrops != null)
            {
                mDrops.Remove(drop);
            }
            //mDropsScreenRect.Remove(drop.DropInfo.oid);
        }

        public DropComponent GetDrop(ulong dropId)
        {
            if (mDrops != null)
            {
                foreach (var drop in mDrops)
                {
                    if (drop.Id == dropId)
                        return drop;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取指定范围内最靠近的掉落
        /// </summary>
        /// <param name="range">范围值</param>
        /// <returns></returns>
        public DropComponent GetNearestDrop(float range = float.MaxValue)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            float minDistance = float.MaxValue;
            DropComponent nearestDrop = null;
            if (localPlayer != null)
            {
                if (mDrops != null)
                {
                    Vector3 localPlayerPosition = localPlayer.Trans.position;
                    foreach (var drop in mDrops)
                    {
                        if (drop.CanPick == true && drop.IsInCD == false && drop.IsBossChip == false)
                        {
                            float distance = Vector3.Distance(drop.transform.position, localPlayerPosition);
                            if (distance <= range && distance < minDistance)
                            {
                                minDistance = distance;
                                nearestDrop = drop;
                            }
                        }
                    }
                }
            }

            return nearestDrop;
        }

        public int MaxDropNum
        {
            get { return mMaxDropNum; }
        }

        public int DropNum
        {
            get
            {
                if (mDrops != null)
                {
                    return mDrops.Count;
                }
                return 0;
            }
        }

        /// <summary>
        /// 返回一个最合理的拾取位置
        /// </summary>
        public Vector3 GenerateDropPosition(Vector3 pos, int count)
        {
            //if(count > 3)
            //    return pos;

            Vector3 retPos = Vector3.zero;

            // 先对位置进行简单随机
            //            const float dropPosMaxOffset = 2f;
            //            float offsetX = Maths.Random_.Range(-dropPosMaxOffset, dropPosMaxOffset);
            //            float offsetZ = Maths.Random_.Range(-dropPosMaxOffset, dropPosMaxOffset);
            //            retPos.x =  pos.x + offsetX;
            //            retPos.y =  pos.y;
            //            retPos.x =  pos.z + offsetZ;

            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (pos.Equals(Vector3.zero) == true && localPlayer != null)
            {
                pos = localPlayer.transform.position;
            }

            int dropCnt = DropNum + 10;
            float r = dropCnt * 0.1f;
            float degrees = dropCnt * 1f;
            retPos.x = pos.x + r * (float)Math.Cos(degrees);
            retPos.z = pos.z + r * (float)Math.Sin(degrees);

            if (localPlayer != null)
            {
                retPos.y = localPlayer.transform.position.y;
            }

            //GameDebug.LogWarning("Drop pos: " + retPos);

            // 限制在副本场景内
            retPos = InstanceHelper.ClampInWalkableRange(retPos);
            // 获取地形高度
            retPos.y = PhysicsHelp.GetHeight(retPos.x, retPos.z);
            // 如果地形太低、则取本地玩家的高度
            if (retPos.y <= -19f)
            {
                var local_player = Game.GetInstance().GetLocalPlayer();
                if (local_player != null)
                    retPos.y = local_player.transform.position.y;
            }

            /*foreach (DropColliderComponent drop in mDrops)
            {
                if (drop != null && (retPos - drop.transform.position).sqrMagnitude < 3f)
                {
                    return GenerateDropPosition(retPos, count+1);
                }
            }*/

            return retPos;
        }

        //public bool CanPick(PkgGoodsGive dropInfo)
        //{
        //    DBPickDropSetting dbPickDropSetting = DBManager.GetInstance().GetDB<DBPickDropSetting>();
        //    GlobalSettings globalSettings = GlobalSettings.GetInstance();
        //    foreach (DBPickDropSetting.PickDropSettingInfo settingInfo in dbPickDropSetting.PickDropSettingList.Values)
        //    {
        //        if (dropInfo.type == GameConst.GIVE_TYPE_GOODS)
        //        {
        //            if (settingInfo.mDropType == DBPickDropSetting.EDropType.OneItem)
        //            {
        //                uint gid = DBTextResource.ParseUI_s(settingInfo.mParam, 0);
        //                if (gid == dropInfo.gid)
        //                {
        //                    return CanPickBySettingType(settingInfo.mId);
        //                }
        //            }
        //            else if (settingInfo.mDropType == DBPickDropSetting.EDropType.MultipleItems)
        //            {
        //                List<uint> gids = DBTextResource.ParseArrayUint(settingInfo.mParam, ",");
        //                foreach (uint gid in gids)
        //                {
        //                    if (gid == dropInfo.gid)
        //                    {
        //                        return CanPickBySettingType(settingInfo.mId);
        //                    }
        //                }
        //            }
        //            else if (settingInfo.mDropType == DBPickDropSetting.EDropType.OneTypeItem)
        //            {
        //                if (GoodsHelper.GetGoodsType(dropInfo.gid) == DBTextResource.ParseUI(settingInfo.mParam))
        //                {
        //                    return CanPickBySettingType(settingInfo.mId);
        //                }
        //            }
        //        }
        //        else if (dropInfo.type == GameConst.GIVE_TYPE_EQUIP)
        //        {
        //            if (settingInfo.mDropType == DBPickDropSetting.EDropType.OneColorEquip)
        //            {
        //                DBEquipColor dbEquipColor = DBManager.GetInstance().GetDB<DBEquipColor>();
        //                if (dropInfo.eq != null)
        //                {
        //                    if (dropInfo.eq.color == DBTextResource.ParseUI_s(settingInfo.mParam, 0))
        //                    {
        //                        return CanPickBySettingType(settingInfo.mId);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return true;
        //}
    }
}
