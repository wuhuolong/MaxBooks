//------------------------------------------------------------------------------
// 解析文本的辅助工具类
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class TextHelper
    {
        static string[] trip = new string[]{","};
        public static string[] GetTupleFromString(string text)
        {
            if(text == null || text.Length <= 2)
                return null;

            if(text[0] == '[' && text[text.Length-1] == ']')
            {
                string content = text.Substring(1,text.Length-2);
                string[] tuple = content.Split(trip, StringSplitOptions.RemoveEmptyEntries);
                return tuple;
            }
            else
                return new string[1]{text};
        }

        public static string[] GetListFromString(string text)
        {
            if(text == null || text.Length <= 2)
                return null;
            
            if(text[0] == '{' && text[text.Length-1] == '}')
            {
                string content = text.Substring(1,text.Length-2);
                string[] tuple = content.Split(trip, StringSplitOptions.RemoveEmptyEntries);
                return tuple;
            }
            else
                return new string[1]{text};
        }

        public static string GetConstText(string key)
        {
            DBConstText dbText = DBManager.Instance.GetDB<DBConstText>();

            if(dbText != null)
            {
                var res = dbText.Text(key);
                res = res.Replace("\\n", "\n");
                return res;
            }

            return string.Empty;
        }

        public static string GetTranslateText(string tableName, string col_name, string text)
        {
            var hasChinese = DBCharIndex.Instance.HasChineseChars(tableName, col_name);
            if (hasChinese)
                return xc.DBTranslate.Instance.GetTranslateText(tableName, text);
            return text;
        }

        public static string GetTranslateText(string text)
        {
            return xc.DBTranslate.Instance.GetTranslateText("", text);
        }

        /// <summary>
        /// 解析字符串中{}括号中的内容(替换@"\{(\d+),(\d+)\}" 正则表达式的功能)
        /// </summary>
        /// <returns>The array string string.</returns>
        /// <param name="str">String.</param>
        public static List<List<string>> ParseBraceContent(string str, bool usePool = false)
        {
            var ret = usePool ? SGameEngine.Pool<List<string>>.List.New() : new List<List<string>>();

            if (string.IsNullOrEmpty(str))
                return ret;

            bool brace_start = false;
            List<string> brace_content = null;
            StringBuilder char_content = null;
            int len = str.Length;
            for (int i = 0; i < len; ++i)
            {
                char c = str[i];

                if (c == ' ')
                    continue;

                if (c == '{')
                {
                    if (brace_start)
                    {
                        GameDebug.LogError("ParseBraceContent error, duplication brace.");
                        break;
                    }
                    else
                    {
                        brace_start = true;
                        brace_content = new List<string>();
                        char_content = new StringBuilder(10);

                        ret.Add(brace_content);
                    }
                }
                else if (c == '}')
                {
                    if (brace_start)
                    {
                        brace_start = false;

                        if (brace_content != null)
                        {
                            if (char_content != null)
                            {
                                var content_str = char_content.ToString();
                                char_content = null;
                                brace_content.Add(content_str);
                                brace_content = null;
                            }
                            else
                            {
                                GameDebug.LogError("ParseBraceContent error, char_content is null.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        GameDebug.LogError("ParseBraceContent error, brace_start state is invalid.");
                        break;
                    }
                }
                else if (c == ',')
                {
                    if (brace_content != null)
                    {
                        if (char_content != null)
                        {
                            var content_str = char_content.ToString();
                            brace_content.Add(content_str);
                            char_content = new StringBuilder(10);
                        }
                        else
                        {
                            GameDebug.LogError("ParseBraceContent error, char_content is null.");
                            break;
                        }
                    }
                }
                else
                {
                    if (brace_start)
                    {
                        if (char_content != null)
                            char_content.Append(c);
                        else
                        {
                            GameDebug.LogError("ParseBraceContent error, char_content is null.");
                            break;
                        }
                    }
                }
            }

            return ret;
        }

        #region 无法读取数据库的游戏初始化相关本地化字符串

        // 游戏初始化相关
        public static string LoadingNotice
        {
            get { return LocalizeManager.Instance.Localize.LoadingNotice; }
        }

        public static string InitDataNotice
        {
            get { return LocalizeManager.Instance.Localize.InitDataNotice; }
        }

        public static string DBInitFailed
        {
            get { return LocalizeManager.Instance.Localize.DBInitFailed; }
        }

        public static string BtnConfirm
        {
            get { return LocalizeManager.Instance.Localize.BtnConfirm; }
        }

        public static string BtnCancel
        {
            get { return LocalizeManager.Instance.Localize.BtnCancel; }
        }

        public static string DBDownloading
        {
            get { return LocalizeManager.Instance.Localize.DBDownloading; }
        }

        public static string InitSceneFailed
        {
            get { return LocalizeManager.Instance.Localize.InitSceneFailed; }
        }

        public static string InitSceneNewVersion
        {
            get { return LocalizeManager.Instance.Localize.InitSceneNewVersion; }
        }

        public static string BtnDownload
        {
            get { return LocalizeManager.Instance.Localize.BtnDownload; }
        }

        public static string StartUpgrade
        {
            get { return LocalizeManager.Instance.Localize.StartUpgrade; }
        }

        public static string InitSceneFirstRunTips
        {
            get { return LocalizeManager.Instance.Localize.InitSceneFirstRunTips; }
        }

        public static string InitSceneLackStorage
        {
            get { return LocalizeManager.Instance.Localize.InitSceneLackStorage; }
        }

        public static string InitSceneGetUpgradeInfoFailed
        {
            get { return LocalizeManager.Instance.Localize.InitSceneGetUpgradeInfoFailed; }
        }

        public static string BtnRetry
        {
            get { return LocalizeManager.Instance.Localize.BtnRetry; }
        }

        public static string UpgradeNoWifiTips
        {
            get { return LocalizeManager.Instance.Localize.UpgradeNoWifiTips; }
        }

        public static string NoWifiContinue
        {
            get { return LocalizeManager.Instance.Localize.NoWifiContinue; }
        }

        public static string ContinueDownload
        {
            get { return LocalizeManager.Instance.Localize.ContinueDownload; }
        }

        public static string DownloadException
        {
            get { return LocalizeManager.Instance.Localize.DownloadException; }
        }

        public static string DownloadProcess
        {
            get { return LocalizeManager.Instance.Localize.DownloadProcess; }
        }

        public static string DownloadSizeKb
        {
            get { return LocalizeManager.Instance.Localize.DownloadSizeKb; }
        }

        public static string DownloadSizeMb
        {
            get { return LocalizeManager.Instance.Localize.DownloadSizeMb; }
        }

        public static string UpgradeSuccess
        {
            get { return LocalizeManager.Instance.Localize.UpgradeSuccess; }
        }

        public static string SDKLoginCancel
        {
            get { return LocalizeManager.Instance.Localize.SDKLoginCancel; }
        }

        // 登录相关
        public static string SDKLogingFail
        {
            get { return LocalizeManager.Instance.Localize.SDKLogingFail; }
        }

        #endregion

        /// <summary>
        /// 复制文本到剪贴板
        /// </summary>
        public static void CopyTextToClipboard(string text)
        {
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            bridge.copyTextToClipboard(text);
        }
    }
}

