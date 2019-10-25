using System.Collections;
using System.Collections.Generic;
using Google;
using Google.Protobuf;
using System.IO;
using UnityEngine;
using X.Res;

public static class ResBinReader
{
    private static Dictionary<int, IMessage> m_ConfigDic = new Dictionary<int, IMessage>();
    public static T Read<T>(string sheetname) where T :class, IMessage, new()
    {
        int hash = sheetname.GetHashCode();
        if (m_ConfigDic.ContainsKey(hash))
        {
            return m_ConfigDic[hash] as T;
        }
        string path = XGamePath.GetBinPath(sheetname);
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            CodedInputStream cis = new CodedInputStream(bytes);
            T t = new T();
            t.MergeFrom(cis);
            m_ConfigDic.Add(hash, t);
            return t;
        }
        else
        {
            Debug.LogError("配置表读取错误，sheetname==>"+sheetname+",path==>"+ path);
            return default(T);
        }  
    }
#if UNITY_EDITOR
    public static void Demotest()
    {
        string path = Application.dataPath + "/DataConfig/{0}.bin";
        string sheetname = "ThemeConfig";
        string testname = "test";
        string filepath = string.Format(path, sheetname);
        ThemeConfig ai = new ThemeConfig();
        testname = string.Format(path, testname);
        ai.ThemeId = "theemid";
        ai.ThemeName = "xsdTheme";

        //把类序列化到文件里
        {
            //
            int size = ai.CalculateSize();
            byte[] bytes = new byte[size];
            CodedOutputStream cos = new CodedOutputStream(bytes);

            ai.WriteTo(cos);
            FileStream fs = File.Open(testname, FileMode.OpenOrCreate);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
            ThemeConfig ai2 = ThemeConfig.Parser.ParseFrom(bytes);

            cos.Dispose();
        }
        //从上面保存的文件反序列化出来
        if (File.Exists(filepath))
        {
            byte[] bytes = File.ReadAllBytes(filepath);
            CodedInputStream cis = new CodedInputStream(bytes);
            //ThemeConfig_ARRAY ai2 = ThemeConfig_ARRAY.Parser.ParseFrom(cis);
            ThemeConfig_ARRAY ai2 = new ThemeConfig_ARRAY();
            ai2.MergeFrom(cis);
            ThemeConfig ai1;
            for (int i = 0; i < ai2.Items.Count; i++)
            {

                ai1 = ai2.Items[i];
                Debug.Log(ai2.Items[i].ThemeId);
                Debug.Log(ai2.Items[i].ThemeName);
            }
        }
        //从dataconfig文件夹读取
        if (File.Exists(testname))
        {
            byte[] bytes = File.ReadAllBytes(testname);
            CodedInputStream cis = new CodedInputStream(bytes);
            ThemeConfig ai2 = ThemeConfig.Parser.ParseFrom(cis);
            Debug.Log(ai2.ThemeId);
            Debug.Log(ai2.ThemeName);
        }
    }
#endif
}
