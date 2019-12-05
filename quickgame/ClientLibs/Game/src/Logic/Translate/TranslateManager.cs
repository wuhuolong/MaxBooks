using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    public class TranslateManager : xc.Singleton<TranslateManager>
    {
        Dictionary<string, string> post_data = new Dictionary<string, string>();
        Dictionary<string, KeyValuePair<string, byte[]>> post_stream = new Dictionary<string, KeyValuePair<string, byte[]>>();
        const string translate_url =
                @"https://translation.googleapis.com/language/translate/v2/?q={0}&target={1}&key=AIzaSyC_KO1zX_dAAEXGnh6KxG3HrvtLdSfX5NY";

        object[] translated_res = new object[2];
        public TranslateManager()
        {

        }

        public void Reset()
        {

        }

        public void GetTranslation(string original_content, Action<object[]> cb)
        {
            GetTranslation(original_content, Const.Language, cb);
        }

        public void GetTranslation(string original_content, LanguageType to_lang, Action<object[]> cb)
        {
            string to_lang_str = ConvertToGoogleLangStr(to_lang);
            MainGame.HttpRequest.POST(string.Format(translate_url, original_content, to_lang_str), post_data, post_stream,
                (s, data, errorStr, reply, userData) =>
                {
                    //GameDebug.LogError("原始文本：" + original_content);
                    if (string.IsNullOrEmpty(errorStr))
                    {
                        Hashtable reply_decode = MiniJSON.JsonDecode(reply) as Hashtable;
                        if (reply_decode != null && reply_decode["data"] != null)
                        {
                            var reply_data = reply_decode["data"] as Hashtable;
                            if (reply_data != null && reply_data["translations"] != null)
                            {
                                var reply_translations = reply_data["translations"] as ArrayList;
                                if (reply_translations.Count > 0)
                                {
                                    var reply_translation = reply_translations[0] as Hashtable;
                                    var reply_translatedText = reply_translation["translatedText"] as string;
                                    var reply_detectedSourceLanguage =
                                        reply_translation["detectedSourceLanguage"] as string;
                                    //GameDebug.LogError("已翻译文本：" + reply_translatedText);
                                    //GameDebug.LogError("文本翻译自：" + reply_detectedSourceLanguage);
                                    translated_res[0] = reply_translatedText;
                                    translated_res[1] = ConvertToLanguageName(reply_detectedSourceLanguage);
                                    if (cb != null)
                                        cb(translated_res);
                                }
                            }
                        }
                    }
                    else
                    {
                        GameDebug.LogError("翻译错误：" + errorStr);
                    }
                },
                null);
        }

        /// <summary>
        /// 将游戏内的语言类型转换成谷歌云翻译的语言字符串
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public string ConvertToGoogleLangStr(LanguageType lang)
        {
            string convert_lang = "";
            switch (lang)
            {
                case LanguageType.SIMPLE_CHINESE:
                    convert_lang = "zh-CN";
                    break;
                case LanguageType.TRADITIONAL_CHINESE:
                    convert_lang = "zh-TW";
                    break;
                case LanguageType.KOREAN:
                    convert_lang = "ko";
                    break;
                case LanguageType.ASIAN_ENGLISH:
                    convert_lang = "en";
                    break;
                case LanguageType.VIETNAMESE:
                    convert_lang = "vi";
                    break;
                case LanguageType.THAI:
                    convert_lang = "th";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lang), lang, null);
            }

            return convert_lang;
        }

        /// <summary>
        /// 将语言简写转换成语言名称
        /// </summary>
        /// <param name="lang_abbr"></param>
        /// <returns></returns>
        public string ConvertToLanguageName(string lang_abbr)
        {
            string convert_lang_id = string.Format("LANG_NAME_{0}", lang_abbr.ToUpper());
            string convert_lang = TextHelper.GetConstText(convert_lang_id);
            return convert_lang;
        }

        /// <summary>
        /// 将语言类型转换成服务端用语言编号
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public uint ConvertToServerLang(LanguageType lang)
        {
            uint convert_lang = GameConst.LANG_DEFAULT;
            switch (lang)
            {
                case LanguageType.SIMPLE_CHINESE:
                    convert_lang = GameConst.LANG_DEFAULT;
                    break;
                case LanguageType.TRADITIONAL_CHINESE:
                    convert_lang = GameConst.LANG_CHT;
                    break;
                case LanguageType.KOREAN:
                    convert_lang = GameConst.LANG_KOREAN;
                    break;
                case LanguageType.ASIAN_ENGLISH:
                    convert_lang = GameConst.LANG_ENGLISH;
                    break;
                case LanguageType.VIETNAMESE:
                    convert_lang = GameConst.LANG_VIETNAMESE;
                    break;
                case LanguageType.THAI:
                    convert_lang = GameConst.LANG_THAI;
                    break;
                default:
                    convert_lang = GameConst.LANG_DEFAULT;
                    break;
            }

            return convert_lang;
        }
    }
}
