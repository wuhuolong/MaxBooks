using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuglyMgr : CSSingleton<BuglyMgr>
{
    public void setUserId()
    {
        LitJson.JsonData data = new LitJson.JsonData();
        data["buglyid"] = 1024;
    }


}
