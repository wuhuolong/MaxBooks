using System.Collections.Generic;
using System.Collections;
using X.Res;
using System.Text;
using UnityEngine.UI;

public enum LangType
{
    cn = 0,
    en = 1,
}
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
    public static string Tag = "_Lang";
    LanguageConfig_ARRAY data;
    Dictionary<uint, LanguageConfig> m_LanDic;

    Dictionary<int, ImgWrap> m_Img_Dic;
    Dictionary<int, TextWrap> m_Txt_Dic;

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


    public TextWrap RegisterText(Text txt)
    {
        int hash = txt.GetHashCode();
        if (!m_Txt_Dic.ContainsKey(hash))
        {
            TextWrap txtw = new TextWrap();
            txtw.Txt = txt;
            txtw.Hashcode = hash;
            m_Txt_Dic.Add(hash, txtw);
            return txtw;
        }
        return m_Txt_Dic[hash];
    }

    public void SwitchLanguage(LangType type)
    {
        if (GameConfig.Language == type)
        {
            return;
        }
        var ie = m_Txt_Dic.GetEnumerator();
        TextWrap txtitem;
        while (ie.MoveNext())
        {
            txtitem = ie.Current.Value;
            if (txtitem.Txt == null)
            {
                m_Txt_Dic.Remove(txtitem.Hashcode);
            }
            else
            {
                SetSelectedLang(txtitem);
            }
        }
        ImgWrap imgitem;
    }

    private void GetLangStrByID(uint id,TextWrap txtw, params object[] args)
    {
        LanguageConfig config;
        if (!m_LanDic.TryGetValue(id, out config))
        {
            this.LogError("language id not exist " + id);
            txtw.Txt.text = string.Empty;
            return;
        }
        txtw.ID = id;
        txtw.Config = config;
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
    }

    private void SetSelectedLang(TextWrap txtw)
    {
        sb.Clear();
        LanguageConfig config = txtw.Config;
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
    }

    public void GetLangStrByID(Text txt, uint id, params object[] args)
    {
        TextWrap txtw = RegisterText(txt);
        GetLangStrByID(id, txtw, args);
    }
}
