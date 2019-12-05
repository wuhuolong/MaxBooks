using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class ChatHelper
    {
        public static string GetFixedContent(string color, string content, string goodsName)
        {
            int linkStart = -1;

            string urlNameColor = "";

            for (int i = 0; i < content.Length; i++)
            {
                linkStart = content.LastIndexOf("[url=", i);

                if (linkStart >= 0)
                {
                    int testLinkStart = linkStart + 5;
                    int testLinkEnd = content.IndexOf("]", testLinkStart);

                    if (testLinkEnd < 0)
                    {
                        continue;
                    }

                    string url = content.Substring(testLinkStart, testLinkEnd - testLinkStart);

                    if (GetGoodsRawNameFromUrl(url) == string.Empty)
                    {
                        continue;
                    }

                    urlNameColor = GetGoodsNameColor(url);

                    break;
                }
            }

            if (linkStart < 0)
            {
                return content;
            }

            linkStart += 5;
            int linkEnd = content.IndexOf("]", linkStart);

            if (linkEnd < 0)
            {
                return content;
            }

            StringBuilder builder = new StringBuilder(content);
            if (urlNameColor == "")
                urlNameColor = "[296614]";
            builder.Insert(linkEnd + 1, urlNameColor + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_74") + goodsName + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_75") + color);

            return builder.ToString();
        }

        public static string GetGoodsRawNameFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url) == false)
            {
                //试图解析出物体名称
//                 ulong goodsId = 0;
// 
//                 if (ulong.TryParse(url, out goodsId))
//                 {
//                     Equip.EquipInfo equip = Equip.EquipManager.Instance.GetEquipInfoByOid(goodsId);
// 
//                     if (equip != null)
//                     {
//                         return equip.GoodsEquip.raw_name;
//                     }
//                     else
//                     {
//                         Goods goods = ItemManager.GetInstance().GetGoodsForBagByOId(goodsId);
// 
//                         if (goods != null)
//                         {
//                             return goods.raw_name;
//                         }
//                     }
//                 }
            }

            return string.Empty;
        }

        public static string GetGoodsNameColor(string url)
        {
            if (string.IsNullOrEmpty(url) == false)
            {
                //试图解析出物体名称
                ulong goodsId = 0;

//                 if (ulong.TryParse(url, out goodsId))
//                 {
//                     Equip.EquipInfo equip = Equip.EquipManager.Instance.GetEquipInfoByOid(goodsId);
// 
//                     if (equip != null)
//                     {
//                         return GoodsHelper.GetGoodsColor((EGoodsQuality)equip.GoodsEquip.color_type);
//                     }
//                     else
//                     {
//                         Goods goods = ItemManager.GetInstance().GetGoodsForBagByOId(goodsId);
// 
//                         if (goods != null)
//                         {
//                             return GoodsHelper.GetGoodsColor((EGoodsQuality)goods.color_type);
//                         }
//                     }
//                 }
            }

            return "[296614]";
        }

        public static string GetChatStringGoodsUrl(string rawChat)
        {
            int index = 0;
            return GetChatStringGoodsUrl(rawChat, out index, out index);
        }


        public static string GetChatStringGoodsUrl(string rawChat, out int startIndex, out int endIndex)
        {
            startIndex = 0;
            endIndex = 0;

            for (int i = 0; i < rawChat.Length; i++)
            {
                int linkStart = rawChat.IndexOf("[url=", i);

                if (linkStart < 0)
                {
                    continue;
                }

                int testLinkStart = linkStart + 5;
                int linkEnd = rawChat.IndexOf("]", linkStart);

                if (linkEnd < 0)
                {
                    return string.Empty;
                }

                string url = rawChat.Substring(testLinkStart, linkEnd - testLinkStart);

                if (GetGoodsRawNameFromUrl(url) != string.Empty)
                {
                    startIndex = linkStart;
                    endIndex = linkEnd;
                    return url;
                }
            }

            return string.Empty;
        }

        public static string GetFixedGoodsStringFromRawChatString(string rawChat, out string goodsUrl, out string rawUrl, out string replaceGoodsName)
        {
            int urlStartIndex = 0;
            int urlEndIndex = 0;

            replaceGoodsName = string.Empty;
            rawUrl = string.Empty;

            goodsUrl = GetChatStringGoodsUrl(rawChat, out urlStartIndex, out urlEndIndex);

            string goodsName = GetGoodsRawNameFromUrl(goodsUrl);

            if(string.IsNullOrEmpty(goodsName))
            {
                return rawChat;
            }

            rawUrl = rawChat.Substring(urlStartIndex, urlEndIndex - urlStartIndex + 1);
            replaceGoodsName = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_74") + goodsName + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_76");

            rawChat = rawChat.Replace(rawUrl, replaceGoodsName);

            return rawChat;
        }


        public static string GetFixedGoodsStringFromRawChatString2(string rawChat, string goodsUrl, string rawUrl, string replaceGoodsName)
        {
            int urlStartIndex = 0;
            int urlEndIndex = 0;

            replaceGoodsName = string.Empty;
            rawUrl = string.Empty;

            goodsUrl = GetChatStringGoodsUrl(rawChat, out urlStartIndex, out urlEndIndex);

            string goodsName = GetGoodsRawNameFromUrl(goodsUrl);

            if (string.IsNullOrEmpty(goodsName))
            {
                return rawChat;
            }

            rawUrl = rawChat.Substring(urlStartIndex, urlEndIndex - urlStartIndex + 1);
            replaceGoodsName = "[" + goodsName + "]";

            rawChat = rawChat.Replace(rawUrl, replaceGoodsName);

            return rawChat + "," + goodsUrl + "," + rawUrl + "," + replaceGoodsName;
        }

        public static bool IsInWifi()
        {
            return Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
        }
        
        public static string GetPrivateLogFilePath(string extensionName)
        {
            string uid = Game.GetInstance().LocalPlayerID.obj_idx.ToString();
            var path = Const.persistentDataPath + "/" + uid + "PrivateChats" + extensionName;
            byte[] bytes = Encoding.Default.GetBytes(path);
            var myString = Encoding.UTF8.GetString(bytes);
            return myString;
        }

        public static int CSharpStringLength(string str)
        {
            return str.Length;
        }

        public static string GetChatSavePath(string saveName)
        {
            string uid = Game.GetInstance().LocalPlayerID.obj_idx.ToString();
            var path = Const.persistentDataPath + "/" + uid + saveName;

            byte[] bytes = Encoding.Default.GetBytes(path);
            var myString = Encoding.UTF8.GetString(bytes);


            return myString;
        }

        //public static readonly Regex hrefMatcher = new Regex(@"\[click=([^\]]+)\]\(([^\]]+)\)");
        /// <summary>
        /// 除去超链接格式
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetClickStrName(string content)
        {
            string replace = content;
            var match = EmojiText.hrefMatcher.Match(content);
            if (match != null && match.Success)
            {
                replace = content.Substring(0, match.Index) + match.Groups[1].ToString() + content.Substring(match.Index + match.Length);
                return GetClickStrName(replace);
                //replace = "【" + replace + "】";
            }

            replace = replace.Replace("</color>", "");
            MatchCollection matches = Regex.Matches(replace, @"<color=#(\w*)>");
            if (matches.Count == 0)
            {
                return "";
            }
            else
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    replace = replace.Replace(matches[i].Value, "");
                }
            }
            return replace;
        }
        /// <summary>
        /// 获得文本goods的个数
        /// </summary>
        /// <param name="content"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int GetGoodsCount(string content ,int count)
        {
            int _count = count;
            string replace = content;
            var match = EmojiText.hrefMatcher.Match(content);
            if (match != null && match.Success)
            {
                replace = content.Substring(0, match.Index) + match.Groups[1].ToString() + content.Substring(match.Index + match.Length);
                _count += 1;
                return GetGoodsCount(replace , _count);
                //replace = "【" + replace + "】";
            }
            
            return _count;
        }

        public static string FinalFix(string[] Origs, string[] Replaces, string content)
        {
            string finalStr = content;
            int index = 0;

            List<string> strs = new List<string>();
            for (int i = 0; i < Origs.Length; i++)
            {
                var orig = Origs[i];
                var replace = Replaces[i];
                if (finalStr.Contains(replace))
                {
                    index = finalStr.IndexOf(replace);
                    string str1 = finalStr.Substring(0, index);
                    string str2 = finalStr.Substring(index, replace.Length);
                    string str3 = str2.Replace(replace, orig);
                    string _str = str1 + str3;
                    strs.Add(_str);
                    finalStr = finalStr.Substring(index+ replace.Length);

                }
            }
            string end = "";
            if (strs.Count != 0)
            {
                
                if (finalStr.CompareTo("") != 0)
                {
                    end = finalStr;
                }
                finalStr = "";
                for (int i = 0; i < strs.Count; i++)
                {
                    finalStr = finalStr + strs[i];
                }
            }
            return finalStr+ end;
        }

        /// <summary>
        /// 反推物品格式
        /// </summary>
        /// <param name="content"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public static string FixClickStr(string content , string replace , string orig , ref  int startIndex)
        {
            string finalStr = string.Empty;
            string str1 = content.Substring(0, startIndex);
            string str2 = content.Substring(startIndex);

            Regex _hrefMatcher = new Regex(replace);
            var match = _hrefMatcher.Match(str2);
            if (match != null && match.Success)
            {
                //finalStr = match.Value.Replace(match.Value, orig);
                finalStr = str1 + str2.Substring(0, match.Index) + orig + str2.Substring(match.Index + match.Length);
                startIndex = finalStr.Length - (str2.Length -(match.Index + match.Length));
            }

            return finalStr;
        }
        /// <summary>
        /// 气泡物品过滤
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string BubbleFixedContent(string content)
        {
            string replace = content;
            var match = EmojiText.hrefMatcher.Match(replace);
            while (match.Success)
            {
                replace = replace.Substring(0, match.Index) + match.Groups[1].ToString() + replace.Substring(match.Index + match.Length);
                match = EmojiText.hrefMatcher.Match(replace);
            }
            return replace;
        }

        public static string GetChatEmojiConfigFilePath()
        {
            return "Assets/Res/UI/Textures/Emoji/Output/emoji.txt";
        }

        public static void ResponseClickEmojiTextHref(string origText)
        {
            if (origText.Contains("goodsOid"))
            {
                string idStr = origText.Replace("goodsOid=", "");
                var matchs = Regex.Matches(idStr, @"\{(\d+),(\d+)\}");
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        uint sendId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                        ulong goodsOid = DBTextResource.ParseUL_s(_match.Groups[2].Value, 0);
                        Net.C2STalkGoods pack = new Net.C2STalkGoods();
                        pack.uuid = sendId;
                        pack.oid = goodsOid;
                        //GameDebug.LogError("===============  OnClickHref test");
                        Net.NetClient.GetBaseClient().SendData<Net.C2STalkGoods>(xc.protocol.NetMsg.MSG_TALK_GOODS, pack);
                    }
                }

                //兼容3个参数和2个参数
                matchs = Regex.Matches(idStr, @"\{(\d+),(\d+),(\d+)\}");
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        uint sendId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                        ulong goodsOid = DBTextResource.ParseUL_s(_match.Groups[2].Value, 0);
                        ulong goodsGid = DBTextResource.ParseUL_s(_match.Groups[3].Value, 0);
                        Net.C2STalkGoods pack = new Net.C2STalkGoods();
                        pack.uuid = sendId;
                        pack.oid = goodsOid;
                        pack.gid = (uint)goodsGid;
                        Net.NetClient.GetBaseClient().SendData<Net.C2STalkGoods>(xc.protocol.NetMsg.MSG_TALK_GOODS, pack);
                    }
                }

            }
            else if (origText.Contains("teamId"))
            {
                var idStr = origText.Replace("teamId=", "");
                var teamId = uint.Parse(idStr);
                TeamManager.Instance.Apply(teamId);
            }
            else if (origText.Contains("playerId"))
            {//查看玩家
                var idStr = origText.Replace("playerId=", "");
                List<string> param_list = DBTextResource.ParseArrayString(idStr, ";");
                if (param_list.Count >= 5)
                {
                    // 不能查看玩家自己的信息
                    if (param_list[0].Equals(LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx.ToString()) == false)
                    {
                        Dictionary<string, string> playerInfo = new Dictionary<string, string>();
                        playerInfo.Clear();
                        playerInfo.Add("uuid", param_list[0]);
                        xc.ui.ugui.UIManager.Instance.ShowWindow("UIWatchPlayerWindow", playerInfo);
                    }
                }
                else
                {
                    GameDebug.LogError("playerId param is error! idStr = " + idStr);
                }
            }
            else if (origText.Contains("jumpSysId="))
            {//跳转系统ID
                var idStr = origText.Replace("jumpSysId=", "");
                List<string> param_list = DBTextResource.ParseArrayString(idStr, ";");
                if (param_list.Count >= 1)
                {
                    uint sys_id = 0;
                    if (uint.TryParse(param_list[0], out sys_id))
                    {
                        if (LuaScriptMgr.Instance != null)
                        {
                            XLua.LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction(LuaScriptMgr.Instance.Lua.Global, "GotoSysRouter_chatItem");
                            if (func != null)
                            {
                                func.Action(param_list);
                            }
                        }
                    }
                }
                else
                {
                    GameDebug.LogError("jumpSysId param is error! idStr = " + idStr);
                }
            }
            else if (origText.Contains("clientGoodsTips"))
            {//客户端拼凑的物品TIPS
                string idStr = origText;
                //var idStr = origText.Replace("clientGoodsTips=", "");
                var matchs = Regex.Matches(origText, @"clientGoodsTips=\{(.+)\}");
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        idStr = _match.Groups[1].Value;
                    }
                }
                Goods item_info = xc.GoodsHelper.ParseClientGoodsStr(idStr);
                if (item_info != null)
                {
                    GoodsHelper.ShowGoodsTips(item_info, null, null, "GuildWarehouseNormal");
                }
                else
                {
                    GameDebug.LogError("playerId param is error! idStr = " + idStr);
                }
            }
            else if (origText.Contains("enter_guild_manor"))
            {//进入帮派领地
                if (SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_GUILD, true))
                {
                    if (LocalPlayerManager.Instance.GuildID > 0)
                    {
                        InstanceHelper.EnterGuildManor();
                    }
                    else
                    {
                        xc.UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_77"));
                        xc.ui.ugui.UIManager.GetInstance().ShowSysWindow("UIGuildWindow");
                    }
                }
            }
            else if (origText.Contains("goodsTips"))
            {//查看物品
                string idStr = origText.Replace("goodsTips=", "");
                var matchs = Regex.Matches(idStr, @"\{(\d+),(\d+)\}");
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        uint sendId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                        ulong goodsOid = DBTextResource.ParseUL_s(_match.Groups[2].Value, 0);
                        Net.C2STalkGoods pack = new Net.C2STalkGoods();
                        pack.uuid = sendId;
                        pack.oid = goodsOid;
                        //GameDebug.LogError("===============  OnClickHref test");
                        Net.NetClient.GetBaseClient().SendData<Net.C2STalkGoods>(xc.protocol.NetMsg.MSG_TALK_GOODS, pack);
                    }
                }
            }
            else if (origText.Contains("goodsGid"))
            {
                var matchs = Regex.Matches(origText, @"goodsGid=\{(\d+),(\d+)\}");
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        //uint playerId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                        uint goodsGid = DBTextResource.ParseUI(_match.Groups[2].Value);

                        var goods = GoodsHelper.CreateGoodsByTypeId(goodsGid);
                        if (goods != null)
                        {
                            GoodsHelper.ShowGoodsTips(goods);
                        }
                    }
                }
            }
            else if (origText.Contains("position="))
            {
                var matchs = Regex.Matches(origText, @"position=\{(\d+),(\d+),(\d+\.?\d*),(\d+\.?\d*)\}");

                foreach(Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        uint instanceId = DBTextResource.ParseUI(_match.Groups[1].Value);
                        uint line = DBTextResource.ParseUI(_match.Groups[2].Value);
                        float x = DBTextResource.ParseF(_match.Groups[3].Value);
                        float z = DBTextResource.ParseF(_match.Groups[4].Value);

                        ClientEventMgr.GetInstance().FireEvent(
                            (int)ClientEvent.CE_CHAT_JUMP_TO_CONST_POSITION, 
                            new CEventEventParamArgs(instanceId, line, x, z));

                    }

                }
            }
            else if (origText.Contains("marketGoodsTips"))
            {
                var matchs = Regex.Matches(origText, @"marketGoodsTips=\{(\d+)\}");
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        uint goodsOid = DBTextResource.ParseUI(_match.Groups[1].Value);
                        Net.C2SMarketDetail pack = new Net.C2SMarketDetail();
                        pack.oid = goodsOid;

                        Net.NetClient.GetBaseClient().SendData<Net.C2SMarketDetail>(xc.protocol.NetMsg.MSG_MARKET_DETAIL, pack);
                    }
                }
            }
            else {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CHAT_RESPONSE_CLICK_TEXT_HREF, new CEventEventParamArgs(origText));
            }
        }
    }
}
