//-----------------------------------
// File: TranMusicAction.cs
// Desc: 
// Author: luozhuocheng
// Date: 2019/1/16 19:54:46
//-----------------------------------


using System;
using xc;

namespace Uranus.Runtime
{
    /// <summary>
    /// 切换音乐
    /// </summary>
    [Serializable]
    public class TranMusicAction : IAction
    {
        public bool IsTranIn = false;
        public string ResPath;
        public override NodeStatus Execute()
        {
            
            if (IsTranIn)
            {
                if (string.IsNullOrEmpty(ResPath) == false)
                    AudioManager.GetInstance().TransferMusic(ResPath);
            }
            else
            {
                AudioManager.GetInstance().TransferOut();
            }
            return NodeStatus.SUCCESS;
        }
 
    }
}