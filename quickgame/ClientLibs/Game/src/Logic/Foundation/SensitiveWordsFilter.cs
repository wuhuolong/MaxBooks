using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace xc
{
    /// <summary>
    /// 聊天敏感词屏蔽功能，使用Trie算法
    /// </summary>
    [wxb.Hotfix]
    public class SensitiveWordsFilter : xc.Singleton<SensitiveWordsFilter>
    {
        /// <summary>
        /// 敏感词单个字符节点
        /// </summary>
        private class TrieFilterNode
        {
            /// <summary>
            /// 自身是否也是敏感词
            /// </summary>
            public bool IsSelfSensitive = false;

            public Dictionary<Char, TrieFilterNode> Children;
        }

        private static char SensitiveReplaceChar = '*';

        private TrieFilterNode mRootNode = new TrieFilterNode();

        public SensitiveWordsFilter()
        { }

        public string GetFilterString(string raw)
        {
            return Filter(raw);
        }

        public void AddSensitiveWord(string sensitiveWord)
        {
            if (string.IsNullOrEmpty(sensitiveWord))
                return;

            // 初始化Root节点的Children
            if (mRootNode.Children == null)
                mRootNode.Children = new Dictionary<char, TrieFilterNode>();

            TrieFilterNode node = mRootNode;

            for (int i = 0; i < sensitiveWord.Length; i++)
            {
                char key = sensitiveWord[i];

                TrieFilterNode childNode;

                if (node.Children == null)
                    node.Children = new Dictionary<char, TrieFilterNode>();

                if (!node.Children.TryGetValue(key, out childNode))
                {
                    childNode = new TrieFilterNode();
                    node.Children.Add(key, childNode);
                }

                node = childNode;
            }

            node.IsSelfSensitive = true;
        }

        public string ToLowerWord(string word)
        {
            return word.ToLower();
        }

        public string Filter(string raw)
        {
            var oldRaw = raw;
            raw = ToLowerWord(raw);

            char[] resultChars = null;

            for (int i = 0; i < raw.Length; i++)
            {
                TrieFilterNode childNode;

                if (mRootNode.Children.TryGetValue(raw[i], out childNode))
                {
                    if(childNode.Children == null || childNode.IsSelfSensitive)
                    {
                        if(resultChars == null)
                        {
                            resultChars = raw.ToCharArray();
                        }

                        if(resultChars.Length > i)
                        {
                            resultChars[i] = SensitiveReplaceChar;
                        }
                    }

                    for (int j = i + 1; j < raw.Length; j++)
                    {
                        if (childNode.Children != null && childNode.Children.TryGetValue(raw[j], out childNode))
                        {
                            if (childNode.Children == null || childNode.IsSelfSensitive)
                            {
                                if (resultChars == null) 
                                    resultChars = raw.ToCharArray();

                                for (int t = i; t <= j; t++)
                                {
                                    resultChars[t] = SensitiveReplaceChar;
                                }

                                i = j;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return resultChars == null ? oldRaw : new string(resultChars);
           
        }
        /// <summary>
        /// 是否包含敏感词
        /// </summary>
        /// <param name="raw">待检测的原始语句</param>
        /// <returns>是否含有敏感词</returns>
        public bool IsHaveSensitiveWords(string raw)
        {
            raw = ToLowerWord(raw);
            if (mRootNode.Children == null)
                return false;

            for (int i = 0; i < raw.Length; i++)
            {
                TrieFilterNode childNode;

                if (mRootNode.Children.TryGetValue(raw[i], out childNode))
                {
                    if (childNode.Children == null || childNode.IsSelfSensitive)
                    {
                        return true;
                    }

                    for (int j = i + 1; j < raw.Length; j++)
                    {
                        if (childNode.Children != null && childNode.Children.TryGetValue(raw[j], out childNode))
                        {
                            if (childNode.Children == null || childNode.IsSelfSensitive)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return false;
        }

        public bool IsInputUserNameLegal(string input)
        {
            return IsInputUserNameLegal(input, Const.Region);
        }

        public bool IsInputUserNameLegal(string input, RegionType region)
        {
            //默认大陆
            string match_str = "";
            switch (region)
            {
                case RegionType.CHINA:
                    match_str = @"^[\u4e00-\u9fa5_a-zA-Z0-9]+$";
                    break;
                case RegionType.KOREA:
                    match_str = @"^[\uAC00-\uD7A3_a-zA-Z0-9]+$";
                    break;
                case RegionType.HKTW:
                    match_str = @"^[\u4e00-\u9fa5_a-zA-Z0-9]+$";
                    break;
                case RegionType.SEASIA:
                    match_str = @"^[\u0e00-\u0e7f\u0041-\u1ef9\u4e00-\u9fa5_a-zA-Z0-9]+$";
                    break;
                default:
                    match_str = @"^[\u4e00-\u9fa5_a-zA-Z0-9]+$";
                    break;
            }
            Regex regex = new Regex(match_str, RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }

        public bool IsInputUserNameLegal(string input, LanguageType lang)
        {
            //默认简体中文
            string match_str = "";
            switch (lang)
            {
                case LanguageType.SIMPLE_CHINESE:
                    match_str = @"^[\u4e00-\u9fa5_a-zA-Z0-9]+$";
                    break;
                case LanguageType.TRADITIONAL_CHINESE:
                    match_str = @"^[\u4e00-\u9fa5_a-zA-Z0-9]+$";
                    break;
                case LanguageType.KOREAN:
                    match_str = @"^[\uAC00-\uD7A3_a-zA-Z0-9]+$";
                    break;
                case LanguageType.ASIAN_ENGLISH:
                    match_str = @"^[_a-zA-Z0-9]+$";
                    break;
                case LanguageType.VIETNAMESE:
                    match_str = @"^[\u0041-\u1ef9_a-zA-Z0-9]+$";
                    break;
                case LanguageType.THAI:
                    match_str = @"^[\u0e00-\u0e7f_a-zA-Z0-9]+$";
                    break;
                default:
                    match_str = @"^[\u4e00-\u9fa5_a-zA-Z0-9]+$";
                    break;
            }
            Regex regex = new Regex(match_str, RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }

        public string ReplaceEmoji(string input)
        {
            string result = Regex.Replace(input, @"\p{Cs}", "");//屏蔽emoji 
            return result;
        }
    }
}