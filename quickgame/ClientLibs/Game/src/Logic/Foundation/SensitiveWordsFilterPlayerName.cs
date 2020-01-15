using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace xc
{
    /// <summary>
    /// 玩家名字敏感词屏蔽功能（韩国版聊天、玩家名字屏蔽字不一样，故韩国版多了这个）
    /// </summary>
    public class SensitiveWordsFilterPlayerName : xc.Singleton<SensitiveWordsFilterPlayerName>
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

        public SensitiveWordsFilterPlayerName()
        { }

        public string GetFilterString(string raw)
        {
            return Filter(ref raw);
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

        public string Filter(ref string raw)
        {
            var oldRaw = raw;
            raw = ToLowerWord(raw);

            char[] resultChars = null;

            for (int i = 0; i < raw.Length; i++)
            {
                TrieFilterNode childNode;

                if (mRootNode.Children.TryGetValue(raw[i], out childNode))
                {
                    if (childNode.Children == null || childNode.IsSelfSensitive)
                    {
                        if (resultChars == null)
                        {
                            resultChars = raw.ToCharArray();
                        }

                        if (resultChars.Length > i)
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
            return resultChars == null ? raw : new string(resultChars);

        }
        /// <summary>
        /// 是否包含敏感词
        /// </summary>
        /// <param name="raw">待检测的原始语句</param>
        /// <returns>是否含有敏感词</returns>
        public bool IsHaveSensitiveWords(string raw)
        {
            if (mRootNode.Children == null)
                return false;
            raw = ToLowerWord(raw);

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
            Regex regex = new Regex(@"^[\uAC00-\uD7A3_a-zA-Z0-9]+$");
            return regex.IsMatch(input);
        }

        public string ReplaceEmoji(string input)
        {
            string result = Regex.Replace(input, @"\p{Cs}", "");//屏蔽emoji 
            return result;
        }
    }
}
