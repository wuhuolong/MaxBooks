using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X.Res;

public class FuncMgr : CSSingleton<FuncMgr>
{
    FuncParamConfig_ARRAY data;
    Dictionary<uint, FuncParamConfig> m_Func_Dic;
    protected override void Init()
    {
        m_Func_Dic = new Dictionary<uint, FuncParamConfig>();
        data = ResBinReader.Read<FuncParamConfig_ARRAY>("FuncParamConfig");
        for (int i = 0; i < data.Items.Count; i++)
        {
            m_Func_Dic.Add(data.Items[i].FuncId, data.Items[i]);
        }
    }
    public FuncParamConfig GetConfigByID(uint id)
    {
        FuncParamConfig config;
        if (!m_Func_Dic.TryGetValue(id, out config))
        {
            Debuger.LogError(Tag,string.Empty,"funcmgr get config error,id==>"+id);
        }
        return config;
    }

}
