using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FontUtil
{
    /// <summary>
    /// key-value 分别是 文件名-对象
    /// </summary>
    private static Dictionary<string, Font> m_atlas_Cache = new Dictionary<string, Font>();

    private static readonly string tag = "FontCache";
    //如果，如果有如果的话，就添加一个表，分别是iconname和Atlasname映射的工具表，由打图集工具自动生成
    public static Font GetFont(string name)
    {
        if (m_atlas_Cache.ContainsKey(name))
        {
            if (m_atlas_Cache[name] == null)
            {
                Debuger.Log(tag, "GetFont", "this should never happen on getfont");
                Font ua = ResMgr.GetFont(name);
                m_atlas_Cache[name] = ua;
            }
            return m_atlas_Cache[name];
        }
        else
        {
            Font ua = ResMgr.GetFont(name);
            m_atlas_Cache.Add(name, ua);
            return ua;
        }
    }
}
public class xxSingleton<T> : MonoBehaviour where T : xxSingleton<T>, new()
{

    private static T _ins = null;
    public static T GetInstance()
    {
        return _ins;
    }
    public virtual void Awake()
    {
        _ins = this as T;
        DontDestroyOnLoad(this);
    }
}
