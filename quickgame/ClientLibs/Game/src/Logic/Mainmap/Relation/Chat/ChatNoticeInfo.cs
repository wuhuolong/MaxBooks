using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class ChatNoticeInfo
    {
        public string Content { set; get; }
        public uint PlayCount { set; get; }
        public uint PlayInterval { set; get; }
        public uint Id { set; get; }
        public uint PlayedTimes { set; get; }
        public uint TimeCounter { set; get; }
    }
}