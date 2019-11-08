
using LitJson;
using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
[Serializable]
public class GameConfig
{
    private static string FileName = "GameConfig";
    public class GameConfigData
    {
        public bool IsDebug = true;
        public int SignInDay = 43775;
    }
    private static GameConfigData _ins;

    public static bool IsDebug
    {
        get
        {
            return _ins.IsDebug;
        }
    }
    public static int SignInDay
    {
        get
        {
            return _ins.SignInDay;
        }
    }
    public static LangType Language
    {
        get
        {
            return (LangType)XPlayerPrefs.GetInt(FileName+LanguageMgr.Tag);
        }
        set
        {
            XPlayerPrefs.SetInt(FileName + LanguageMgr.Tag,(int) value);
        }
    }

    public static void Init()
    {
        string path = XGamePath.GetLevelDataJsonPath(FileName);
        if (File.Exists(path))
        {
            try
            {
                StreamReader fs = File.OpenText(path);
                string json = fs.ReadToEnd();
                fs.Close();
                _ins = JsonMapper.ToObject<GameConfigData>(json);
            }
            catch (Exception e)
            {
                Debuger.Log("GameConfig","load",e + "==>" + e.Data);
            }
        }
        else
        {
            Debuger.Log("GameConfig", "load", "file not exist");
        }
    }

#if UNITY_EDITOR
    [MenuItem("Tools/SaveGameConfig")]
    public static void Save()
    {
        string path = XGamePath.GetLevelDataJsonPath(FileName);

        if (_ins == null)
        {
            _ins = new GameConfigData();
        }
        string json = JsonMapper.ToJson(_ins);
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
            FileStream fs = File.Open(path,FileMode.CreateNew,FileAccess.Write);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
            Debuger.Log("GameConfig", "Save",string.Format("保存成功 路径={0}，json={1}",path,json));
        }
        catch (Exception e)
        {
            Debuger.Log("GameConfig", "Save", e + "==>" + e.Data);
        }
    }
#endif

}

