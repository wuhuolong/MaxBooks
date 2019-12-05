using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

using xc.protocol;
using xc.ui;
using Net;
namespace xc
{
    public class DBActor : DBSqliteTableResource
	{
		public const float ANGLE_TO_RADIAN = (float)(System.Math.PI / 180.0);
		public const float RADIAN_TO_ANGLE = 1.0f / ANGLE_TO_RADIAN;
		public const uint UF_NONE = 0x00000000;
		public const uint UF_ALL = 0xffffffff;
		public const uint UF_ACTION = 0x00000001;       //控制角色状态机的更新
		public const uint UF_ANIMATION = 0x00000002;    //控制动画的更新
		public const uint UF_MOVE = 0x00000004;         //控制移动的更新
		public const uint UF_ATTACK = 0x00000008;       //控制AttackCtrl的更新
        public const uint UF_BEATTACK = 0x00000010;     //控制BeattackedCtrl的更新
        public const uint UF_SKILL = 0x00000020;        //控制Skill的更新
        public const uint UF_AI = 0x00000040;           //控制AI的更新
        public const uint UF_BUFF = 0x00000080;         //控制BUFF的更新
        public const uint UF_BATTLESTATE = 0x00000100;  //控制战斗状态的更新

		public static float SpeedUpMinDis = 0.5f;  //跟目的位置的当前距离与实际距离之差在闭区间[SpeedUpMaxDis, SpeedUpMinDis]时则加速行走或跑步
		public static float SpeedUpMaxDis = 15.0f; //小于SpeedUpMinDis时则不加速，大于SpeedUpMaxDis时则直接瞬间转移。 单位为米
		public static ushort Gravity = 50;
		public static float MinimumAngle = 2.0f;
		public static float MinimumDistance = 0.05f;
		public static float MinDisToGround = 0.0001f;

        public class ActorData
        {
            public string name;
            public byte vocation;
            public uint level;
            public Monster.QualityColor color;
            public byte type;
            public byte war_tag;
            public uint race_id;
            public byte skill_count;
            public uint[] skill_idx;
            public byte[] cast_rate;
            public uint model_id;
            public ushort runspeed; // 厘米/秒
            public byte motion_radius;
            public string behaviour_tree;
            public string summon_behaviour_tree;
            public byte attack_rotaion;
            public byte hp_bar_count;
            public ushort gravity = 50; // 击飞后的角色重力参数
            public byte[] dead_notify;
            public uint spawn_timeline;
            public uint dead_timeline;
            public bool is_hide_shadow;
            public bool is_hide_select_effect;
            public uint attr_param; //属性系数
            public uint default_actor_id;   //资源不存在的时候，可以默认加载的资源
        }

        Dictionary<uint, ActorData> data = new Dictionary<uint, ActorData>();

		public DBActor(string strName, string strPath) : base(strName, strPath)
		{

		}

        public ActorData GetData(string id)
        {
            uint idInt;
            uint.TryParse(id, out idInt);
            return GetData(idInt);
        }

        public ActorData GetData(uint id)
        {
            ActorData ad = null;
            if(!data.TryGetValue(id, out ad))
            {
                ad = GetActorInfo(id);
            }
            return ad;
        }

        public bool ContainsKey(uint id)
        {
            var data = GetData(id);
            return data != null;
        }

        ActorData GetActorInfo(uint id)
        {
            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id" , id.ToString());

            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (table_reader == null)
            {
                return null;
            }

            if (!table_reader.HasRows)
            {
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            if (!table_reader.Read())
            {
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            ActorData ad = new ActorData();
            ad.name = GetReaderString(table_reader, "name");
            ad.vocation = DBTextResource.ParseBT(GetReaderString(table_reader, "vocation"));
            ad.level = DBTextResource.ParseUI(GetReaderString(table_reader, "level"));
            ad.color = (Monster.QualityColor)DBTextResource.ParseBT_s(GetReaderString(table_reader, "color"), 0); ;
            ad.type = DBTextResource.ParseBT(GetReaderString(table_reader, "type"));
            ad.war_tag = DBTextResource.ParseBT(GetReaderString(table_reader, "war_tag"));
            ad.race_id = DBTextResource.ParseUI(GetReaderString(table_reader, "race_id"));
            ad.skill_count = DBTextResource.ParseBT(GetReaderString(table_reader, "skill_count"));
            if (ad.skill_count > 0)
            {
                ad.skill_idx = new uint[ad.skill_count];
                ad.cast_rate = new byte[ad.skill_count];
                for (int k = 0; k < ad.skill_count; ++k)
                {
                    ad.skill_idx[k] = DBTextResource.ParseUI_s(GetReaderString(table_reader, string.Format("skill_idx_{0}", k)), 0);
                    ad.cast_rate[k] = DBTextResource.ParseBT(GetReaderString(table_reader, string.Format("cast_rate_{0}", k)));
                }
            }

            ad.model_id = DBTextResource.ParseUI(GetReaderString(table_reader, "model_id"));
            ad.runspeed = (ushort)GetReaderFloat(table_reader, "runspeed");
            ad.motion_radius = DBTextResource.ParseBT(GetReaderString(table_reader, "motion_radius"));
            ad.behaviour_tree = GetReaderString(table_reader, "behaviour_tree");
            ad.summon_behaviour_tree = GetReaderString(table_reader, "summon_behaviour_tree");
            ad.attack_rotaion = DBTextResource.ParseBT(GetReaderString(table_reader, "attack_rotaion"));
            ad.hp_bar_count = DBTextResource.ParseBT(GetReaderString(table_reader, "hp_bar_count"));
            ad.gravity = DBTextResource.ParseUS_s(GetReaderString(table_reader, "gravity"), DBActor.Gravity);
            ad.dead_notify = DBTextResource.ParseByteArray(GetReaderString(table_reader, "dead_notify"));
            ad.spawn_timeline = DBTextResource.ParseUI(GetReaderString(table_reader, "spawn_timeline"));
            ad.dead_timeline = DBTextResource.ParseUI(GetReaderString(table_reader, "dead_timeline"));
            string isHideShadow = GetReaderString(table_reader, "is_hide_shadow");
            if (isHideShadow == string.Empty || isHideShadow == "0")
            {
                ad.is_hide_shadow = false;
            }
            else
            {
                ad.is_hide_shadow = true;
            }
            string isHideSelectEffect = GetReaderString(table_reader, "is_hide_select_effect");
            if (isHideSelectEffect == string.Empty || isHideSelectEffect == "0")
            {
                ad.is_hide_select_effect = false;
            }
            else
            {
                ad.is_hide_select_effect = true;
            }
            ad.attr_param = DBTextResource.ParseUI_s(GetReaderString(table_reader, "attr_param"), 0);
            ad.default_actor_id = DBTextResource.ParseUI_s(GetReaderString(table_reader, "default_actor_id"), 0);
            data[id] = ad;

            table_reader.Close();
            table_reader.Dispose();

            return ad;
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
		{
            data.Clear();
		}
	}
}


