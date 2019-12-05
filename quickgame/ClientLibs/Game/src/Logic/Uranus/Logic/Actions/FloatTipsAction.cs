using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uranus.Runtime
{
    [Serializable]
    public class FloatTipsAction : IAction
    {
        public string Text;

        public override NodeStatus Execute()
        {
            //xc.ui.UIWidgetHelp.Instance.ShowFloatTips(Text);
            xc.UINotice.Instance.ShowMessage(xc.DBConstText.GetText(Text));
            return NodeStatus.SUCCESS;
        }
    }
}
