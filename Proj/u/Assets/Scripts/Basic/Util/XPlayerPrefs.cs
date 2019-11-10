using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public static class XPlayerPrefs
{
    [System.Serializable]
    public class XPlayerPrefsData
    {
        public Dictionary<string, int> Dic_Int = new Dictionary<string, int>();
        public Dictionary<string, float> Dic_Float = new Dictionary<string, float>();
        public Dictionary<string, string> Dic_Str = new Dictionary<string, string>();
        public Dictionary<string, Recorder> Dic_LevelRec = new Dictionary<string, Recorder>();
        public List<byte> List_Day = new List<byte>();
    }
    private static string tag = "/save.d";
    private static Dictionary<string, int> Dic_Int
    {
        get
        {
            return data.Dic_Int;
        }
    }
    private static Dictionary<string, float> Dic_Float
    {
        get
        {
            return data.Dic_Float;
        }
    }
    private static Dictionary<string, string> Dic_Str
    {
        get
        {
            return data.Dic_Str;
        }
    }
    private static XPlayerPrefsData m_data;
    private static XPlayerPrefsData data
    {
        get
        {
            if (m_data == null)
            {
                m_data = Load();
            }
            return m_data;
        }
        set
        {
            m_data = value;
        }
    }
    private static XPlayerPrefsData Load()
    {
        try
        {
            string path = XGamePath.SavePath(tag);
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                return new XPlayerPrefsData();
            }
            StreamReader sr = File.OpenText(path);
            string json = sr.ReadToEnd();
            if (string.IsNullOrEmpty(json))
            {
                return new XPlayerPrefsData();
            }
            XPlayerPrefsData data = JsonMapper.ToObject<XPlayerPrefsData>(json);
            return data;
        }
        catch (System.Exception e)
        {
            Debug.LogError("==>" + e.Message + "\n" + e.StackTrace);
            return null;
        }
    }
    private static bool issaving = false;
    public static void Save()
    {
        lock (data)
        {
            if (issaving)
                return;
            Loom.QueueOnMainThread(() =>
            {
                try
                {
                    issaving = true;
                    string json = JsonMapper.ToJson(data);
                    string path = XGamePath.SavePath(tag);
                    FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write);
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
                    fs.SetLength(0);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();
                    fs.Close();
                    issaving = false;
                }
                catch (System.Exception e)
                {
                    issaving = true;
                    Debug.LogError("==>" + e.Message + "\n" + e.StackTrace);
                }
            });
        }
    }
    public static void DeleteAll()
    {
        try
        {
            XPlayerPrefsData data = new XPlayerPrefsData();
            string json = JsonMapper.ToJson(data);
            string path = XGamePath.SavePath(tag);
            FileStream fs = File.Open(path, FileMode.OpenOrCreate);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
            XPlayerPrefs.data = data;
        }
        catch (System.Exception e)
        {
            Debug.LogError("==>" + e.Message + "\n" + e.StackTrace);
        }
    }
    public static void DeleteKey(string key)
    {
        //int hash = key.GetHashCode();
        if (Dic_Float.ContainsKey(key))
        {
            Dic_Float.Remove(key);
        }
        if (Dic_Int.ContainsKey(key))
        {
            Dic_Int.Remove(key);
        }
        if (Dic_Str.ContainsKey(key))
        {
            Dic_Str.Remove(key);
        }
    }
    public static float GetFloat(string key, float defaultValue = 0)
    {
        int hash = key.GetHashCode();
        Dic_Float.TryGetValue(key, out defaultValue);
        return defaultValue;
    }
    public static float GetFloat(string key)
    {
        int hash = key.GetHashCode();
        float defaultValue = 0;
        Dic_Float.TryGetValue(key, out defaultValue);
        return defaultValue;
    }
    public static int GetInt(string key, int defaultValue = 0)
    {
        int hash = key.GetHashCode();
        Dic_Int.TryGetValue(key, out defaultValue);
        return defaultValue;
    }
    public static int GetInt(string key)
    {
        int hash = key.GetHashCode();
        int defaultValue = 0;
        Dic_Int.TryGetValue(key, out defaultValue);
        return defaultValue;
    }
    public static string GetString(string key, string defaultValue)
    {
        int hash = key.GetHashCode();
        Dic_Str.TryGetValue(key, out defaultValue);
        return defaultValue;
    }
    public static string GetString(string key)
    {
        //int hash = key.GetHashCode();
        string defaultValue;
        Dic_Str.TryGetValue(key, out defaultValue);
        return defaultValue;
    }
    public static bool HasKey(string key)
    {
        //int hash = key.GetHashCode();
        if (Dic_Float.ContainsKey(key) ||
            Dic_Int.ContainsKey(key) ||
            Dic_Str.ContainsKey(key))
        {
            return true;
        }
        return false;
    }
    public static void SetFloat(string key, float value)
    {
        //int hash = key.GetHashCode();
        if (Dic_Float.ContainsKey(key))
        {
            Dic_Float[key] = value;
        }
        else
        {
            Dic_Float.Add(key, value);
        }
    }
    public static void SetInt(string key, int value)
    {
        //int hash = key.GetHashCode();
        if (Dic_Int.ContainsKey(key))
        {
            Dic_Int[key] = value;
        }
        else
        {
            Dic_Int.Add(key, value);
        }
    }
    public static void SetString(string key, string value)
    {
        //int hash = key.GetHashCode();
        if (Dic_Str.ContainsKey(key))
        {
            Dic_Str[key] = value;
        }
        else
        {
            Dic_Str.Add(key, value);
        }
    }

    public static void SetRec(Recorder rec)
    {
        string levelid = rec.LevelId.ToString();
        Debug.Log("记录关卡保存==>" + levelid);
        if (data.Dic_LevelRec.ContainsKey(levelid))
        {
            data.Dic_LevelRec[levelid] = rec;
        }
        else
        {
            data.Dic_LevelRec.Add(levelid, rec);
        }
        Save();
    }
    public static Recorder GetRec(uint levelid)
    {
        string level = levelid.ToString();
        if (data.Dic_LevelRec.ContainsKey(level))
        {
            return data.Dic_LevelRec[level];
        }
        return null;
    }
    public static void DelRec(uint levelid)
    {
        string level = levelid.ToString();
        if (data.Dic_LevelRec.ContainsKey(level))
        {
            data.Dic_LevelRec.Remove(level);
        }
    }
    public static void SetSign(int index, int offset, byte value)
    {
        if (data.List_Day.Count <= index)
        {
            Debug.Log(data.List_Day.Count + "///" + index);
            int temp = index - data.List_Day.Count+1;
            data.List_Day.AddRange(new List<byte>(temp){new byte()});
        }
        byte tempb = data.List_Day[index];
        SetByte(ref tempb, value, offset);
        data.List_Day[index] = tempb;
    }

    private static void SetByte(ref byte src, byte value, int index)
    {
        byte des = (byte)(value << index);
        int temp = src;
        temp = temp | des;
        src = (byte)temp;
    }

    public static bool GetSign(int index, int offset)
    {
        if (offset > 7)
        {
            Debuger.LogError("Debuger", "GetSign", "每日签到 数据越界了");
        }
        if (data.List_Day.Count <= index)
        {
            int temp = index - data.List_Day.Count;
            data.List_Day.AddRange(new List<byte>(temp));
            return false;
        }
        byte tempb = data.List_Day[index];
        return ((tempb >> offset) & 1) == 1;
    }
}
