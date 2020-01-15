/*----------------------------------------------------------------
// 文件名： DBMap.cs
// 文件功能描述： 地图配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMap : DBSqliteTableResource
    {
        public class MapInfo
		{
			public uint Id = 0;            // id
            public string SceneRes = "";    // 场景资源名字
            public bool HasMiddleScene = false;    // 是否有中配场景
            public bool HasLowScene = false; // 是否有低配场景
            public bool IsBornMap = false;  // 是否新手场景
            public bool IsDynamic = false; //是否是动态加载的场景
            //public string SceneName;   // 用于显示的场景名字

            /// <summary>
            /// 根据当前设置和场景是否切割获取实际的场景名字
            /// </summary>
            public string SceneLevelName
            {
                get
                {
                    // 根据画质选择高、中配场景
                    string level_name = SceneRes;
                    var graphicLevel = QualitySetting.GraphicLevel;
                    if (graphicLevel == 1)// 中配
                    {
                        if(HasMiddleScene)
                            level_name = SceneRes + "_middle";
                        else if (IsBornMap == false && Const.HAVE_HIGH_GRAPHIC_LEVEL == false)  // 如果配置不用高配资源且存在低配资源，则使用低配资源
                        {
                            if (HasLowScene)
                                level_name = SceneRes + "_low";
                        }
                    }
                    else if(graphicLevel == 2) // 低配
                    {
                        //只在ios设备上加载低配场景
#if UNITY_IPHONE || UNITY_STANDALONE_WIN
                        if (HasLowScene)
                            level_name = SceneRes + "_low";
                        else if(HasMiddleScene)
                            level_name = SceneRes + "_middle";
#else
                        if (HasMiddleScene)
                            level_name = SceneRes + "_middle";
                        else if (IsBornMap == false && Const.HAVE_HIGH_GRAPHIC_LEVEL == false)  // 如果配置不用高配资源且存在低配资源，则使用低配资源
                        {
                            if (HasLowScene)
                                level_name = SceneRes + "_low";
                        }
#endif
                    }
                    else if (IsBornMap == false && Const.HAVE_HIGH_GRAPHIC_LEVEL == false)  // 如果配置不用高配资源且存在中配资源，则使用中配资源，不存在且存在低配资源，则使用低配资源
                    {
                        if (HasMiddleScene)
                            level_name = SceneRes + "_middle";
                        else if (HasLowScene)
                            level_name = SceneRes + "_low";
                    }

                    // 获取最终的场景名字
                    if (IsDynamic)
                    {
                        level_name = string.Format("{0}_split", level_name);
                    }

                    return level_name;
                }
            }

            /// <summary>
            /// 根据当前设置和场景是否切割获取实际的场景资源路径
            /// </summary>
            public string SceneResPath
            {
                get
                {
                    // 根据画质选择高、中配场景
                    string scene_name = SceneRes;
                    if (QualitySetting.GraphicLevel ==1)// 中配场景
                    {
                        if(HasMiddleScene)
                            scene_name = SceneRes + "_middle";
                        else if (IsBornMap == false && Const.HAVE_HIGH_GRAPHIC_LEVEL == false)  // 如果配置不用高配资源且存在低配资源，则使用低配资源
                        {
                            if (HasLowScene)
                                scene_name = SceneRes + "_low";
                        }
                    }
                    else if(QualitySetting.GraphicLevel == 2)// 低配场景
                    {
                        //只在ios设备上加载低配场景
#if UNITY_IPHONE || UNITY_STANDALONE_WIN
                        if (HasLowScene)
                            scene_name = SceneRes + "_low";
                        else if (HasMiddleScene)
                            scene_name = SceneRes + "_middle";
#else
                        if (HasMiddleScene)
                            scene_name = SceneRes + "_middle";
                        else if (IsBornMap == false && Const.HAVE_HIGH_GRAPHIC_LEVEL == false)  // 如果配置不用高配资源且存在低配资源，则使用低配资源
                        {
                            if (HasLowScene)
                                scene_name = SceneRes + "_low";
                        }
#endif
                    }
                    else if (IsBornMap == false && Const.HAVE_HIGH_GRAPHIC_LEVEL == false)  // 如果配置不用高配资源且存在中配资源，则使用中配资源，不存在且存在低配资源，则使用低配资源
                    {
                        if (HasMiddleScene)
                            scene_name = SceneRes + "_middle";
                        else if (HasLowScene)
                            scene_name = SceneRes + "_low";
                    }

                    // 获取最终的场景资源路径
                    string asset_path = "";
                    if (IsDynamic)
                    {
                        scene_name = string.Format("{0}_split", scene_name);
                        asset_path = string.Format("Assets/Res/Map/Scenes/QuadTree/{0}.unity", scene_name);
                    }
                    else
                    {
                        asset_path = string.Format("Assets/Res/Map/Scenes/{0}.unity", scene_name);
                    }

                    return asset_path;
                }
            }

        }
        Dictionary<uint, MapInfo> mMapInfos = new Dictionary<uint, MapInfo>();

        public DBMap(string strName, string strPath)
            : base(strName, strPath)
		{
		}

		/// <summary>
        /// 获取地图列表
        /// </summary>
        /// <value>The instance map list.</value>
        public Dictionary<uint, MapInfo> MapList
		{
            get { return mMapInfos; }
		}

        /// <summary>
        /// 根据地图ID获取地图名字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MapInfo GetMapInfo(uint id)
        {
            MapInfo info = null;
            if (mMapInfos.TryGetValue(id, out info))
            {
                return info;
            }
            
            return null;
        }

        /// <summary>
        /// 获取当前地图ID对应的场景Level名字
        /// </summary>
        /// <param name="id"></param>
        public string GetSceneName(uint id)
        {
            var map_info = GetMapInfo(id);
            if (map_info != null)
                return map_info.SceneLevelName;
            else
                return GlobalConst.DefaultTestScene;
        }

        public override void Unload()
        {
            base.Unload();
            mMapInfos.Clear();
        }

		protected override void ParseData(SqliteDataReader reader)
        {
            mMapInfos.Clear();
            MapInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new MapInfo();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.SceneRes = GetReaderString(reader, "scene_res");
                        info.HasMiddleScene = DBTextResource.ParseBT_s(GetReaderString(reader, "has_middle_scene"),0) == 1;
                        info.HasLowScene = DBTextResource.ParseBT_s(GetReaderString(reader, "has_low_scene"), 0) == 1;
                        info.IsBornMap = DBTextResource.ParseUI_s(GetReaderString(reader, "is_born_map"), 0) == 1;
                        info.IsDynamic = DBTextResource.ParseUI_s(GetReaderString(reader, "is_dynamic"), 0) == 1;
                        //info.SceneName = GetReaderString(reader, "scene_name");

#if UNITY_EDITOR
                        if (mMapInfos.ContainsKey(info.Id))
                        {
                            GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, info.Id));
                            continue;
                        }
#endif
                        mMapInfos.Add(info.Id, info);
                    }
                }
			}
		}
	}
}
