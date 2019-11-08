using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X.Res;

public class AltasMgr : CSSingleton<AltasMgr>
{
    AltasConfig_ARRAY data;
    Dictionary<uint, AltasConfig> m_Guid_Dic;
    protected override void Init()
    {
        m_Guid_Dic = new Dictionary<uint, AltasConfig>();
        data = ResBinReader.Read<AltasConfig_ARRAY>("AltasConfig");
        for (int i = 0; i < data.Items.Count; i++)
        {
            m_Guid_Dic.Add(data.Items[i].LevelId, data.Items[i]);
        }
    }
    public AltasConfig GetConfigByID(uint id)
    {
        AltasConfig config;
        if (!m_Guid_Dic.TryGetValue(id, out config))
        {
            Debuger.LogError(Tag, string.Empty, "altasmgr get config error,id==>" + id);
        }
        return config;
    }
}