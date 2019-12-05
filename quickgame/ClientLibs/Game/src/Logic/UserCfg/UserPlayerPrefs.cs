/*******************************************************************/
//   Desc : 保存客户端本地设置，因为unity的PlayerPrefs在一些小米机器上获取不到写入权限
//   Author : raorui
//   Date   : 2016.1.23
/*******************************************************************/
#define HZB
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
#if HZB
    public sealed class UserPlayerPrefs
    {
        private static Dictionary<string, UserPlayerPrefs> instanceMap = new Dictionary<string, UserPlayerPrefs>();
        private static Dictionary<string, Hashtable> playerPrefsMap = new Dictionary<string, Hashtable>();
        private readonly static string DEFAULT_FILE = "playerprefs";
        private string filePath = "";

        //TODO 去掉单例化
        private static UserPlayerPrefs mInstance = null;

        public static UserPlayerPrefs Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new UserPlayerPrefs();
                }
                return mInstance;
            }
        }


        public static UserPlayerPrefs GetInstance()
        {
            return Instance;
        }

        private Hashtable playerPrefs
        {
            get { return playerPrefsMap[filePath]; }
        }

        public bool Init(string filename)
        {
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            string targetPath = bridge.getGameResPath();
            filePath = targetPath + filename + ".json";

            instanceMap[filePath] = this;

            if (File.Exists(filePath))
            {
                string str = File.ReadAllText(filePath);
                Hashtable table = MiniJSON.JsonDecode(str) as Hashtable;
                if (table != null)
                {
                    playerPrefsMap[filePath] = table;
                    return true;
                }
                else
                {
                    playerPrefsMap[filePath] = new Hashtable();
                    GameDebug.LogError("Get PlayerPrefs error!!! filePath: " + filePath);
                }
            }
            else
            {
                playerPrefsMap[filePath] = new Hashtable();

                //GameDebug.LogError("Get PlayerPrefs error, file not exists!!! filePath: " + filePath);
                return true;
            }

            return false;
        }

        [System.Obsolete("use Init(string filename) instead")]
        public bool Init()
        {
            return Init(DEFAULT_FILE);
        }


#else
    public class UserPlayerPrefs : xc.Singleton<UserPlayerPrefs>
    {
        public static string filePath = "";
        public static Hashtable playerPrefs = new Hashtable();

        public bool Init()
        {
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            string targetPath = bridge.getGameResPath();
            filePath = targetPath + "playerprefs.json";

            if (File.Exists(filePath))
            {
                string str = File.ReadAllText(filePath);
                Hashtable table = MiniJSON.JsonDecode(str) as Hashtable;
                if (table != null)
                {
                    playerPrefs = table;
                    return true;
                }
                else
                    GameDebug.LogError("Get PlayerPrefs error!!!");
            }

            return false;
        }


#endif

        public UserPlayerPrefs()
        {

        }



#if HZB
        public float GetFloat(string key, float default_val)
#else
        public static float GetFloat(string key, float default_val)
#endif
        {
            if(playerPrefs.Contains(key))
            {
                string val = playerPrefs[key] as string;
                float fVal = default_val;
                float.TryParse(val, out fVal);
                return fVal;
            }
            else
                return default_val;
        }

#if HZB
        public int GetInt(string key, int default_val)
#else
        public static int GetInt(string key, int default_val)
#endif
        {
            if(playerPrefs.Contains(key))
            {
                string val = playerPrefs[key] as string;
                int iVal = default_val;
                int.TryParse(val, out iVal);
                return iVal;
            }
            else
                return default_val;
        }


#if HZB
        public string GetString(string key, string default_val)
#else
        public static string GetString(string key, string default_val)
#endif
        {
            if(playerPrefs.Contains(key))
            {
                string val = playerPrefs[key] as string;
                return val;
            }
            else
                return default_val;
        }

#if HZB
        public void SetFloat(string key, float val)
#else
        public static void SetFloat(string key, float val)
#endif
        {
            playerPrefs[key] = val.ToString();
        }

#if HZB
        public void SetInt(string key, float val)
#else
        public static void SetInt(string key, float val)
#endif
        {
            playerPrefs[key] = val.ToString();
        }

#if HZB
        public void SetString(string key, string val)
#else
        public static void SetString(string key, string val)
#endif
        {
            playerPrefs[key] = val;
        }

#if HZB
        public void Save()
#else
        public static void Save()
#endif
        {
            string str = MiniJSON.JsonEncode(playerPrefs);
            File.WriteAllText(filePath,str);
        }

        public bool Contain(string key)
        {
            return playerPrefs.Contains(key);
        }
    }
}

