//------------------------------------------------------------------------------
// Desc   :  Npc数据类
// Author :  ljy
// Date   :  2017.6.1
//------------------------------------------------------------------------------
using System.Collections.Generic;
using xc;

namespace xc
{
    public class NpcDefine
    {
        // 光照类型
        public enum ELightMode
        {
            ROLE = 0,       // 使用角色光照
            SCENE = 1,      // 使用场景光照
        }

        public enum EFunction
        {
            EMPTY = 0,
            TRANSFER = 1,
            EXCHANGE = 2,
            DIALOG = 3,
            EVENT = 4,
            INTERACTION = 5,
            ESCORT = 6,
        }

        public uint NpcId;
        public uint ActorId;
        public string IdleAni;
        public ELightMode LightMode;
        public float Radius;
        public string ConstTitle = string.Empty;
        public string ConstText = string.Empty;
        public string ConstBtnText = string.Empty;
        public string ConstBtnPic = string.Empty;
        public EFunction Function;
        public List<string> FunctionParams = new List<string>();
        public List<uint> VoiceIds = null; 
    }
}