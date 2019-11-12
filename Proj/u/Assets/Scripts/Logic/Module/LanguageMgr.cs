using System.Collections.Generic;
using System.Collections;
using X.Res;
using System.Text;
using UnityEngine.UI;

public enum LangType
{
    /// <summary>
    /// 中文简体
    /// </summary>
    zh_Hans = 0,
    /// <summary>
    /// 中文繁体
    /// </summary>
    zh_Hant = 1,
    /// <summary>
    /// 英语
    /// </summary>
    en = 2,
}
/*
    en,"zh-Hans",fr,de,ja,nl,it,es,pt,"pt-PT",da,fi,nb,sv,ko,"zh-Hant",ru,pl,tr,uk,ar,hr,
    cs,el,he,ro,sk,th,id,ms,"en-GB",ca,hu,vi*/
public class LanguageMgr : CSSingleton<LanguageMgr>
{
    public class TextWrap
    {
        public Text Txt;
        public int Hashcode;
        public uint ID;
        public LanguageConfig Config;
        public object[] args;
    }

    public class ImgWrap
    {
        public Image Img;
        public int Hashcode;
        public uint ID;
    }
    private static StringBuilder sb = new StringBuilder(256);
    LanguageConfig_ARRAY data;
    Dictionary<uint, LanguageConfig> m_LanDic;

    Dictionary<int, ImgWrap> m_Img_Dic;
    Dictionary<int, TextWrap> m_Txt_Dic;

    public void SetUp()
    {
        GameConfig.Language = SDKMgr.GetInstance().GetSystemLang();
    }

    protected override void Init()
    {
        m_LanDic = new Dictionary<uint, LanguageConfig>();
        m_Img_Dic = new Dictionary<int, ImgWrap>();
        m_Txt_Dic = new Dictionary<int, TextWrap>();
        data = ResBinReader.Read<LanguageConfig_ARRAY>("LanguageConfig");

        LanguageConfig item;
        for (int i = 0; i < data.Items.Count; i++)
        {
            item = data.Items[i];
            m_LanDic.Add(item.TxtId, item);
        }
    }

    //todo 
    public ImgWrap RegisterImage(Image img)
    {
        int hash = img.GetHashCode();
        if (!m_Img_Dic.ContainsKey(hash))
        {
            ImgWrap imgw = new ImgWrap();
            imgw.Img = img;
            m_Img_Dic.Add(hash, imgw);
            return imgw;
        }
        return null;
    }


    private TextWrap RegisterText(Text txt)
    {
        int hash = txt.GetHashCode();
        if (!m_Txt_Dic.ContainsKey(hash))
        {
            TextWrap txtw = new TextWrap();
            txtw.Txt = txt;
            txtw.Hashcode = hash;
            m_Txt_Dic.Add(hash, txtw);
            return txtw;
        }else if (m_Txt_Dic[hash].Txt == null)
        {
            m_Txt_Dic[hash].Txt = txt;
        }
        return m_Txt_Dic[hash];
    }

    public void SwitchLanguage(LangType type)
    {
        if (GameConfig.Language == type)
        {
            return;
        }
        GameConfig.Language = type;
        var ie = m_Txt_Dic.GetEnumerator();
        TextWrap txtitem;
        while (ie.MoveNext())
        {
            txtitem = ie.Current.Value;
            if (txtitem.Txt != null)
            {
                SetSelectedLang(txtitem);
            }
        }
        //TODO
        //ImgWrap imgitem;
    }

    private void GetLangStrByID(uint id,TextWrap txtw, params object[] args)
    {
        LanguageConfig config;
        if (!m_LanDic.TryGetValue(id, out config))
        {
            Debuger.LogError(Tag,string.Empty,"language id not exist " + id);
            txtw.Txt.text = string.Empty;
            return;
        }
        txtw.ID = id;
        txtw.Config = config;
        sb.Clear();
        switch (GameConfig.Language)
        {
            case LangType.zh_Hans:
                sb.Append(config.Cn);
                break;
            case LangType.en:
                sb.Append(config.En);
                break;
            default:
                break;
        }
        if (config.Count > 0)
        {
            string tempstr;
            try
            {
                tempstr = string.Format(sb.ToString(), args);
                txtw.args = args;
            }
            catch (System.Exception e)
            {
                tempstr = string.Empty;
                Debuger.LogError(Tag, "GetLangStrByID", e.Message);
            }
            txtw.Txt.text = tempstr;
        }
        txtw.Txt.text = sb.ToString();
        txtw.Txt.fontSize = (int)txtw.Config.Fontsize[(int)GameConfig.Language];
        txtw.Txt.font = FontUtil.GetFont(txtw.Config.Fonttype[(int)GameConfig.Language]);
    }

    private string GetLangStrByIDv1(uint id,params object[] args)
    {
        LanguageConfig config;
        if (!m_LanDic.TryGetValue(id, out config))
        {
            Debuger.LogError(Tag, string.Empty, "language id not exist " + id);
            return string.Empty;
        }
        sb.Clear();
        switch (GameConfig.Language)
        {
            case LangType.zh_Hans:
                sb.Append(config.Cn);
                break;
            case LangType.en:
                sb.Append(config.En);
                break;
            default:
                break;
        }
        if (config.Count > 0)
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

    private void SetSelectedLang(TextWrap txtw)
    {
        sb.Clear();
        LanguageConfig config = txtw.Config;
        switch (GameConfig.Language)
        {
            case LangType.zh_Hans:
                sb.Append(config.Cn);
                break;
            case LangType.en:
                sb.Append(config.En);
                break;
            default:
                break;
        }
        if (txtw.args!= null)
        {
            string tempstr;
            try
            {
                tempstr = string.Format(sb.ToString(), txtw.args);
            }
            catch (System.Exception e)
            {
                tempstr = string.Empty;
                Debuger.LogError(Tag, "GetLangStrByID", e.Message);
            }
            txtw.Txt.text = tempstr;
        }
        txtw.Txt.text = sb.ToString();
        txtw.Txt.fontSize = (int)txtw.Config.Fontsize[(int)GameConfig.Language];
        txtw.Txt.font = FontUtil.GetFont(txtw.Config.Fonttype[(int)GameConfig.Language]);
    }

    public void GetLangStrByID(Text txt, uint id,bool isregister = true, params object[] args)
    {
        TextWrap txtw;
        if (isregister)
        {
            txtw = RegisterText(txt);
        }
        else
        {
            txtw = new TextWrap()
            {
                Txt = txt,
            };
        }
        GetLangStrByID(id, txtw, args);
    }

    public string GetLangStrByID(uint id, params object[] args)
    {
        return GetLangStrByIDv1(id,args);
    }
}
