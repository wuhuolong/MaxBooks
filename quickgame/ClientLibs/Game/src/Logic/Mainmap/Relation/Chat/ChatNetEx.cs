using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class ChatNetEx : xc.Singleton<ChatNetEx>
    {
        public void RegisterMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TALK_GOODS, HandleServerData);
        }

        public void CheckGoodsInfo(uint senderId, ulong goodsId)
        {
            C2STalkGoods data = new C2STalkGoods();
            data.uuid = senderId;
            data.oid = goodsId;

            NetClient.GetBaseClient().SendData<C2STalkGoods>(NetMsg.MSG_TALK_GOODS, data);
        }

        public static void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_TALK_GOODS:
                    {
                        var msg = Net.S2CPackBase.DeserializePack<Net.S2CTalkGoods>(data);
                        var goods = GoodsFactory.Create(msg.goods.gid, msg.goods);
                        if (goods == null)
                        {
                            return;
                        }

                        string luaScript = GoodsHelper.GetGoodsLuaScriptByGoodsId(goods.type_idx);
                        if (!string.IsNullOrEmpty(luaScript))
                        {
                            return;
                        }

                        goods.id = msg.goods.oid;
                        goods.num = msg.goods.num;
                        goods.bind = msg.goods.bind;
                        goods.expire_time = msg.goods.expire_time;

                        Net.PkgStrengthInfo pkgStrengthInfo = null;
                        if (msg.strengths != null && msg.strengths.Count > 0)
                        {
                            pkgStrengthInfo = msg.strengths[0];
                        }

                        Net.PkgBaptizeInfo pkgBaptizeInfo = null;
                        if (msg.baptizes != null && msg.baptizes.Count > 0)
                        {
                            pkgBaptizeInfo = msg.baptizes[0];
                        }

                        GoodsHelper.ShowGoodsTips(goods, pkgStrengthInfo, pkgBaptizeInfo);

                        break; ;
                    }
            }
        }
    }
}


