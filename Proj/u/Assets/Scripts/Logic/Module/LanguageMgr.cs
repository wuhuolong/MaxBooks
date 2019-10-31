using System.Collections.Generic;
using System.Collections;
using X.Res;
using System.Text;

public enum LangType
{
    cn = 0,
    en = 1,
}
public class LanguageMgr : CSSingleton<LanguageMgr>
{
    private static StringBuilder sb = new StringBuilder(256);
    public static string Tag = "_Lang";
    LanguageConfig_ARRAY data;
    Dictionary<uint, LanguageConfig> m_LanDic;
    protected override void Init()
    {
        m_LanDic = new Dictionary<uint, LanguageConfig>();
        data = ResBinReader.Read<LanguageConfig_ARRAY>("LanguageConfig");

        LanguageConfig item;
        for (int i = 0; i < data.Items.Count; i++)
        {
            item = data.Items[i];
            m_LanDic.Add(item.TxtId, item);
        }
    }
    public string GetLangStrByID(uint id,params object[] args)
    {
        LanguageConfig config;
        m_LanDic.TryGetValue(id, out config);
        if (config == null)
        {
            this.LogError("language id not exist "+id);
            return string.Empty;
        }
        return SelectType(config, args);
    }
    private string SelectType(LanguageConfig config, params object[] args)
    {
        sb.Clear();
        switch (GameConfig.Language)
        {
            case LangType.cn:
                sb.Append(config.Cn);
                break;
            case LangType.en:
                sb.Append(config.En);
                break;
            default:
                break;
        }
        if (config.Count>0)
        {
            string tempstr;
            try
            {
                tempstr = string.Format(sb.ToString(), args);
            }
            catch (System.Exception e)
            {
                tempstr = string.Empty;
                Debuger.LogError(Tag, "GetLangStrByID", e.Message);
            }
            return tempstr;
        }
        return sb.ToString();
    }
}
