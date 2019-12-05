/*----------------------------------------------------------------
// 文件名： DBGuildDuty.cs
// 文件功能描述： 宠物表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGuildDuty : DBSqliteTableResource
    {

        public const uint GuildDutyLimit_EnterCheck = 1; //入会审核
        public const uint GuildDutyLimit_DutyAppoint = 1 << 1; //职务任免
        public const uint GuildDutyLimit_AlterNotice = 1 << 2; //修改公告
        public const uint GuildDutyLimit_CleanWare = 1 << 3;   //清理仓库
        public const uint GuildDutyLimit_MemberDismiss = 1 << 4;   //请离工会
        public const uint GuildDutyLimit_Boss = 1 << 5;   //帮派BOSS
        public const uint GuildDutyLimit_ApplySetting = 1 << 6;   //修改入帮申请设置
        public class DBGuildDutyItem
        {
            public uint Id;         // 职位ID
            public uint num;        //成员数
            public uint LimitTypeArray;  //权限管理
            public string Name;     //职位名字
            /// <summary>
            /// 是否有权限
            /// </summary>
            /// <param name="guild_duty_limit"></param>
            /// <returns></returns>
            public bool HasLimit(uint guild_duty_limit)
            {
                if ((LimitTypeArray & guild_duty_limit) > 0)
                    return true;
                return false;
            }
        }
        Dictionary<uint, DBGuildDutyItem> mInfos = new Dictionary<uint, DBGuildDutyItem>();

        public DBGuildDuty(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
        }

        public DBGuildDutyItem GetOneItem(uint id)
        {
            DBGuildDutyItem info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInfos[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new DBGuildDutyItem();

            info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
            info.num = DBTextResource.ParseUI_s(GetReaderString(reader, "num"), 0);
            info.Name = GetReaderString(reader, "name");
            info.LimitTypeArray = 0;
            if (DBTextResource.ParseUI_s(GetReaderString(reader, "enter_check"), 0) == 1)
                info.LimitTypeArray = info.LimitTypeArray | GuildDutyLimit_EnterCheck;
            if (DBTextResource.ParseUI_s(GetReaderString(reader, "duty_appoint"), 0) == 1)
                info.LimitTypeArray = info.LimitTypeArray | GuildDutyLimit_DutyAppoint;
            if (DBTextResource.ParseUI_s(GetReaderString(reader, "alter_notice"), 0) == 1)
                info.LimitTypeArray = info.LimitTypeArray | GuildDutyLimit_AlterNotice;
            if (DBTextResource.ParseUI_s(GetReaderString(reader, "clean_ware"), 0) == 1)
                info.LimitTypeArray = info.LimitTypeArray | GuildDutyLimit_CleanWare;
            if (DBTextResource.ParseUI_s(GetReaderString(reader, "member_dismiss"), 0) == 1)
                info.LimitTypeArray = info.LimitTypeArray | GuildDutyLimit_MemberDismiss;
            if (DBTextResource.ParseUI_s(GetReaderString(reader, "open_boss"), 0) == 1)
                info.LimitTypeArray = info.LimitTypeArray | GuildDutyLimit_Boss;
            if (DBTextResource.ParseUI_s(GetReaderString(reader, "apply_setting"), 0) == 1)
                info.LimitTypeArray = info.LimitTypeArray | GuildDutyLimit_ApplySetting;
            mInfos.Add(info.Id, info);

            reader.Close();
            reader.Dispose();
            return info;
        }
    }
}
