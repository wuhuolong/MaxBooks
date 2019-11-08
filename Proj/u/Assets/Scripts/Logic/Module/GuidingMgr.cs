using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X.Res;

public class GuidingMGr : CSSingleton<GuidingMGr>
{
    GuidingConfig_ARRAY data;
    Dictionary<uint, GuidingConfig> m_Guid_Dic;
    protected override void Init()
    {
        m_Guid_Dic = new Dictionary<uint, GuidingConfig>();
        data = ResBinReader.Read<GuidingConfig_ARRAY>("GuidingConfig");
        for (int i = 0; i < data.Items.Count; i++)
        {
            m_Guid_Dic.Add(data.Items[i].FuncId, data.Items[i]);
        }
    }
    public GuidingConfig GetConfigByID(uint id)
    {
        GuidingConfig config;
        if (!m_Guid_Dic.TryGetValue(id, out config))
        {
            Debuger.LogError(Tag, string.Empty, "guidingmgr get config error,id==>" + id);
        }
        return config;
    }
}
