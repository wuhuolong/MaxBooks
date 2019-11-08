using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIAtlasUtil
{
    /// <summary>
    /// key-value 分别是 文件名-对象
    /// </summary>
    private static Dictionary<string, UIAtlas> m_atlas_Cache = new Dictionary<string, UIAtlas>();

    /// <summary>
    /// key-value 分别是 关卡名-对象
    /// </summary>
    //private static Dictionary<string, UIAtlas> m_level_Atlas_Cache = new Dictionary<string, UIAtlas>();
    private static readonly string tag = "AtlasCache";
    //如果，如果有如果的话，就添加一个表，分别是iconname和Atlasname映射的工具表，由打图集工具自动生成
    public static UIAtlas GetAtlas(string name)
    {
        if (m_atlas_Cache.ContainsKey(name))
        {
            if (m_atlas_Cache[name] == null)
            {
                Debuger.Log(tag, "GetAtlas", "this should never happen on getatlas");
                UIAtlas ua = ResMgr.GetAtlas(name);
                m_atlas_Cache[name] =ua;
            }
            return m_atlas_Cache[name];
        }
        else
        {
            UIAtlas ua = ResMgr.GetAtlas(name);
            m_atlas_Cache.Add(name, ua);
            return ua;
        }
    }

    public static void GetAtlasAsync(string name,System.Action<UIAtlas> ac)
    {
        if (m_atlas_Cache.ContainsKey(name))
        {
            if (m_atlas_Cache[name] == null)
            {
                Debuger.Log(tag, "GetAtlas", "this should never happen on getatlas");
                UIAtlas ua = ResMgr.GetAtlas(name);
                m_atlas_Cache[name] = ua;
            }
            if (ac != null)
            {
                ac(m_atlas_Cache[name]);
            }
        }
        else
        {
            ResMgr.GetAtlasAsync(name,(ua)=> {

                m_atlas_Cache.Add(name, ua);
                if (ac != null)
                {
                    ac(ua);
                }
            });
        }
    }
}
