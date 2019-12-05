using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBAvatarPart: DBSqliteTableResource
    {
        public enum BODY_PART : byte
        {
            BODY = 1,
            WEAPON = 2,
            WING = 3,
            ELFIN = 4,          //小精灵
            MAGICAL_PET = 5,    //神宠
            FOOTPRINT = 6,      //足迹
            BUBBLE = 7,      //聊天气泡
            PHOTO_FRAME = 8,      //头像框
            LIGHT_WEAPON = 9,      //光武
            BACK_ATTACHMENT = 10,  // 背饰
        }

        public class Data
        {
            public string path;// 资源的路径
            public string low_path; // 低配资源的路径
            
            public BODY_PART part;
            public Actor.EVocationType vocation;
            public bool isFashion;
            public bool isShowWin;  // 是否打开更换展示界面

            public Data Clone()
            {
                Data newData = MemberwiseClone() as Data;
                return newData;
            }

            /// <summary>
            /// 获取合适的资源路径
            /// </summary>
            /// <returns></returns>
            public string SuitablePath(bool is_local_player)
            {
                if(is_local_player)// 本地玩家根据画面设置使用不同的资源
                {
                    if (QualitySetting.GraphicLevel == 2) // 低配
                    {
                        if (string.IsNullOrEmpty(low_path) == false)
                        {
                            return low_path;
                        }
                        else
                            return path;
                    }
                    else // 高、中配
                        return path;
                }
                else // 其他人使用低配的资源
                {
                    if (string.IsNullOrEmpty(low_path) == false)
                    {
                        return low_path;
                    }
                    else
                        return path;
                }
            }
        }

        public Dictionary<uint, Data> mData = new Dictionary<uint, Data>();

        public DBAvatarPart(string strName, string strPath)
            :base(strName, strPath)
        {
        }

        public static Data GetAvatarPartData(uint avatarId)
        {
            DBAvatarPart dbAvatarPart = DBManager.GetInstance().GetDB<DBAvatarPart>();
            Data data = null;
            if(dbAvatarPart.mData.TryGetValue(avatarId , out data))
                return data;
            return null;
        }

        /// <summary>
        /// 换装部件是否属于时装
        /// </summary>
        /// <param name="avatarId"></param>
        /// <returns></returns>
        public bool IsFashion(uint avatarId)
        {
            DBAvatarPart dbAvatarPart = DBManager.GetInstance().GetDB<DBAvatarPart>();
            Data data = null;
            if (dbAvatarPart.mData.TryGetValue(avatarId, out data))
                return data.isFashion;
            return false;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if(reader == null || !reader.HasRows)
            {
                return;
            }

            mData.Clear();

            while (reader.Read())
            {
                Data data = new Data();
                data.vocation = (Actor.EVocationType)DBTextResource.ParseUI(GetReaderString(reader, "vocation"));
                data.path = GetReaderString(reader, "path");
                data.low_path = GetReaderString(reader, "low_path");
                data.part = (BODY_PART) DBTextResource.ParseUI(GetReaderString(reader, "part"));
                data.isFashion = DBTextResource.ParseI(GetReaderString(reader, "is_show")) == 0 ? false : true;
                data.isShowWin = DBTextResource.ParseI(GetReaderString(reader, "is_show_win")) == 0 ? false : true;

                uint id = DBTextResource.ParseUI(GetReaderString(reader, "id"));

                // 身体部件模型有高模，程序内部增加一个id来对应高模
                if(data.part == BODY_PART.BODY)
                {
                    Data newData = data.Clone();
                    newData.path += "_high";
                    mData.Add(id*100, newData);
                }
                mData.Add(id, data);
            }
        }

        private void GetSplit( string s, List<string> ouput)
        {
            string[] prices = s.Split('{', ',', '}',' ');
            ouput.Clear();
            foreach(var p in prices)
            {
                if(string.IsNullOrEmpty(p))
                {
                    continue;
                }
                ouput.Add(p);  
            }
        }
    }
}

