

/*----------------------------------------------------------------
// 文件名： DBSkillSlot.cs
// 文件功能描述： 技能槽
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSkillSlot : DBSqliteTableResource
    {
        public enum SlotSetType
        {
            None = 0,   //不能被设定
            OnlyBasicSkill = 1, //基础技能
            OnlyFurySkill = 2,  //怒气技能
        }
        public class SkillSlotInfo
        {
            public uint VocationId;
            public uint SlotPos;    //槽位置
            public SlotSetType SetType; //设定类型
            public string NotOpenNotice; // 技能槽未开启时候的提示文本对应的文本表Key
            public List<uint> DefaultAllSkillIds; //默认的技能ID(总表技能ID)
        }

        public class VocationSkillSlotInfo
        {
            public uint VocationId;
            public Dictionary<uint, SkillSlotInfo> mSlotInfos;
            
            public VocationSkillSlotInfo()
            {
                mSlotInfos = new Dictionary<uint, SkillSlotInfo>();
            }
            public SkillSlotInfo GetSlotInfo(uint slot_pos)
            {
                if (mSlotInfos == null)
                    return null;
                if (mSlotInfos.ContainsKey(slot_pos) == false)
                    return null;
                return mSlotInfos[slot_pos];
            }
        }
        Dictionary<uint, VocationSkillSlotInfo> mInfos = new Dictionary<uint, VocationSkillSlotInfo>();
        public DBSkillSlot(string strName, string strPath)
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
            
            SkillSlotInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new SkillSlotInfo();

                        info.VocationId = DBTextResource.ParseUI_s(GetReaderString(reader, "vocation"), 0);
                        info.SlotPos = DBTextResource.ParseUI(GetReaderString(reader, "slot_pos"));
                        info.SetType = (SlotSetType)DBTextResource.ParseUI(GetReaderString(reader, "slot_set_type"));
                        info.NotOpenNotice = GetReaderString(reader, "not_open_notice");

                        if (mInfos.ContainsKey(info.VocationId) == false)
                            mInfos.Add(info.VocationId, new VocationSkillSlotInfo());

                        mInfos[info.VocationId].mSlotInfos[info.SlotPos] = info;
                    }
                }
            }
        }

        public VocationSkillSlotInfo GetOneSkillSlotInfo(uint vocation_id)
        {
            VocationSkillSlotInfo info;
            if (mInfos.TryGetValue(vocation_id, out info))
            {
                return info;
            }
            return null;
        }

        /// <summary>
        /// 获取指定技能槽未开启时候的提示文本
        /// </summary>
        /// <param name="vocationId"></param>
        /// <param name="slotPos"></param>
        /// <returns></returns>
        public string GetSkillSlotNotice(uint vocationId, uint slotPos)
        {
            VocationSkillSlotInfo info;
            mInfos.TryGetValue(vocationId, out info);
            if(info != null)
            {
                var slotInfo = info.GetSlotInfo(slotPos);
                if(slotInfo != null)
                {
                    var textKey = slotInfo.NotOpenNotice;
                    if(!string.IsNullOrEmpty(textKey))
                    {
                        var notice = DBConstText.GetText(textKey);
                        return notice;
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// 新增一个技能槽默认技能ID
        /// </summary>
        /// <param name="require_race">职业ID，参照 DBDataAllSkill.Require_race 取值</param>
        /// <param name="slot_pos"></param>
        /// <param name="active_skill_id"></param>
        public void AddSlotDefaultSkillId(uint require_race, uint slot_pos, uint all_skill_id)
        {
            foreach(var item in mInfos)
            {
                if((item.Key == require_race) || (require_race == DBDataAllSkill.CommonVocationType))
                {
                    SkillSlotInfo slot_info = item.Value.GetSlotInfo(slot_pos);
                    if (slot_info != null)
                    {
                        if (slot_info.DefaultAllSkillIds == null)
                            slot_info.DefaultAllSkillIds = new List<uint>();
                        slot_info.DefaultAllSkillIds.Add(all_skill_id);
                    }
                }
            }
        }
    }
}
