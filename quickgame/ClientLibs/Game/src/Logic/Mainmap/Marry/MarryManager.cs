//------------------------------------------------------------------------------
// Desc   :  结婚管理类
// Author :  ljy
// Date   :  2018.11.8
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class MarryManager : xc.Singleton<MarryManager>
    {
        /// <summary>
        /// 婚宴副本食物采集数量
        /// </summary>
        public uint WeddingInstanceFoodsCount { get; set; }

        uint mWeddingInstanceMaxFoodsCount = 0;

        /// <summary>
        /// 婚宴副本宝箱采集数量
        /// </summary>
        public uint WeddingInstanceBoxCount { get; set; }

        uint mWeddingInstanceMaxBoxCount = 0;

        public void RegisterAllMessage()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_WEDDING_FOODS, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_WEDDING_BOX, HandleServerData);
        }

        public void Reset()
        {
            WeddingInstanceFoodsCount = 0;
            mWeddingInstanceMaxFoodsCount = GameConstHelper.GetUint("GAME_DUNGEON_WEDDING_PERSON_MAX_FOODS");

            WeddingInstanceBoxCount = 0;
            mWeddingInstanceMaxBoxCount = GameConstHelper.GetUint("GAME_DUNGEON_WEDDING_PERSON_MAX_BOX");
        }

        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_DUNGEON_WEDDING_FOODS:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CDungeonWeddingFoods>(data);

                        WeddingInstanceFoodsCount = pack.count;

                        break;
                    }
                case NetMsg.MSG_DUNGEON_WEDDING_BOX:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CDungeonWeddingBox>(data);

                        WeddingInstanceBoxCount = pack.coll_box;

                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// 婚宴场景的食物能否被采集
        /// </summary>
        public bool WeddingFoodsCanBeCollected
        {
            get
            {
                return WeddingInstanceFoodsCount < mWeddingInstanceMaxFoodsCount;
            }
        }

        /// <summary>
        /// 婚宴场景的食物能否被采集
        /// </summary>
        public bool WeddingBoxCanBeCollected
        {
            get
            {
                return WeddingInstanceBoxCount < mWeddingInstanceMaxBoxCount;
            }
        }
    }
}
