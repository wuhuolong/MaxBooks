using UnityEngine;
using System.IO;
using LitJson;
using System.Text;
using System.Collections.Generic;
using System;

public static class LevelLoader
{
    private static LevelMapData data;
    private static string LevelMap_FileName = "LevelMapConfig";

    public static LevelMapData Load()
    {
        if (data != null)
        {
            return data;
        }
        string path = XGamePath.GetLevelDataJsonPath(LevelMap_FileName);
        //Debug.Log("LevelMapData.Load==>" + path);
        if (File.Exists(path))
        {
            try
            {
                StreamReader fs = File.OpenText(path);
                string json = fs.ReadToEnd();
                //ResMgr.Log(json);
                fs.Close();
                data = JsonMapper.ToObject<LevelMapData>(json);
                return data;
            }
            catch (Exception e)
            {
                Debug.Log(e + "==>" + e.Data);
            }
        }
        else
        {
            Debug.Log("file not exist");
        }
        return null;
    }
    public static void Save(LevelMapData data)
    {
        string FilePath = XGamePath.GetLevelDataJsonPath(LevelMap_FileName);
        //string FilePath = Path.Combine(Application.dataPath, "FakeResources/Data/LevelConfig/" + data.Name + ".json");
        LevelLoader.data = data;

        //Debug.Log("LevelMapData.Save==>" + FilePath);
        string json = JsonMapper.ToJson(data);
        string path = string.Format(FilePath, data.Name);
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            FileStream fs = File.Create(path);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e+"==>"+e.Data);
        }
    }
    //public static void Test()
    //{
    //     LevelMapArray config = new  LevelMapArray();
    //    config.Id = 1024;
    //    //config.Name = "xx";
    //    config.MapWidth = 4;
    //    config.MapHeight = 3;
    //    config.MapArray = new int[] {
    //        1,2,3,11,
    //        4,5,6,12,
    //        7,8,9,13
    //    };
    //    //config.StarCondition = new int[] {
    //    //    1011,1012,1013
    //    //};

    //     LevelMapArray config2 = new  LevelMapArray();
    //    config2.Id = 1025;
    //    //config2.Name = "xxx";
    //    config2.MapWidth = 4;
    //    config2.MapHeight = 3;
    //    config2.MapArray = new int[] {
    //        11,2,3,11,
    //        41,5,6,12,
    //        71,8,9,13
    //    };
    //    //config2.StarCondition = new int[] {
    //    //    1111,1112,1113
    //    //};
    //    LevelMapData data = new LevelMapData();
    //    data.Name = "xxxx";
    //    data.Configs = new List< LevelMapArray>();
    //    data.Configs.Add(config);
    //    data.Configs.Add(config2);
    //    Debug.Log(data.ToString());
    //    Save(data);
    //    LevelMapData xx = Load();
    //    Debug.Log(xx.ToString());
    //}
}