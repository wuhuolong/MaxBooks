//-----------------------------------------
// File: ResNameMapping.cs
// Author: raorui
// Date: 2018.4.28
// Desc: 获取资源名字的映射表
//-----------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

namespace xc
{
    public class ResNameMapping
    {
        static ResNameMapping sInstance;
        public static ResNameMapping Instance
        {
            get
            {
                if (sInstance == null)
                    sInstance = new ResNameMapping();

                return sInstance;
            }
        }

        /// <summary>
        /// 资源名字映射表
        /// </summary>
        Dictionary<string, string> mNameMapping = new Dictionary<string, string>();

        /// <summary>
        /// 初始化映射表
        /// </summary>
        public void Init(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.LogError("ResNameMapping init fail,file is not exist: " + filePath);
                return;
            }

            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                var bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);

                var mappingText = Encoding.UTF8.GetString(bytes);
                if (!string.IsNullOrEmpty(mappingText))
                {
                    var nameTable = MiniJSON.JsonDecode(mappingText) as Hashtable;

                    if (nameTable != null)
                    {
                        foreach (DictionaryEntry nameMap in nameTable)
                        {
                            string key = nameMap.Key.ToString();
                            string value = nameMap.Value.ToString();
                            mNameMapping[key] = value;
                        }
                    }
                }
                else
                    GameDebug.LogError("ResNameMapping init error: hashtable is null");
            }
            catch (Exception e)
            {
                GameDebug.LogError("ResNameMapping init error: " + e.Message);

                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream = null;
                }
            }

            if (fileStream != null)
            {
                fileStream.Close();
                fileStream = null;
            }
        }

        /// <summary>
        /// 获取映射后的文件名字(适用于没有在DynamicResBundle文件夹的文件)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetMappingName(string fileName)
        {
#if UNITY_IPHONE
            string mapFileName = "";
            if (!mNameMapping.TryGetValue(fileName, out mapFileName))
            {
                mapFileName = fileName;
            }
            else
            {
                if (string.IsNullOrEmpty(mapFileName))
                {
                    mapFileName = fileName;
                }
            }

            return mapFileName;
#else
            return fileName;
#endif
        }

        /// <summary>
        /// 获取映射后的文件路径(适用于在DynamicResBundle文件夹的文件)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetMappingPath(string fileFullPath, string fileFolder, string fileName)
        {
#if UNITY_IPHONE
            string fileRelativePath = string.Format("{0}/{1}", fileFolder, fileName);
            string mapRelativePath = "";
            if (mNameMapping.TryGetValue(fileRelativePath, out mapRelativePath))
            {
                if (!string.IsNullOrEmpty(mapRelativePath))
                    fileFullPath = fileFullPath.Replace(fileRelativePath, mapRelativePath);
            }

            return fileFullPath;
#else
            return fileFullPath;
#endif
        }

        /// <summary>
        /// 获取所有后缀为.bin的文件路径("DynamicResBundles/1.bin")
        /// </summary>
        /// <returns></returns>
        public List<string> GetBinFiles()
        {
            List<string> binFiles = new List<string>();
            foreach (var kv in mNameMapping)
            {
                var file = kv.Key;
                if (string.IsNullOrEmpty(file))
                    continue;

                // 获取后缀为.bin的文件
                if (Path.GetExtension(file).ToLower() == ".bin")
                {
                    // map路径为空是返回原始路径
                    var mapFile = kv.Value;
                    if (!string.IsNullOrEmpty(mapFile))
                    {
                        binFiles.Add(mapFile);
                    }
                    else
                        binFiles.Add(file);
                }
            }

            return binFiles;
        }

        /// <summary>
        /// 获取所有后缀为.patch的文件路径("DynamicResBundles/Patch/1.patch")
        /// </summary>
        /// <returns></returns>
        public List<string> GetPatchFiles()
        {
            List<string> patchFiles = new List<string>();
            foreach (var kv in mNameMapping)
            {
                var file = kv.Key;
                if (string.IsNullOrEmpty(file))
                    continue;

                // 获取后缀为.patch的文件
                if (Path.GetExtension(file).ToLower() == ".patch")
                {
                    // map路径为空是返回原始路径
                    var mapFile = kv.Value;
                    if (!string.IsNullOrEmpty(mapFile))
                    {
                        patchFiles.Add(mapFile);
                    }
                    else
                        patchFiles.Add(file);
                }
            }

            return patchFiles;
        }

        string mExVersionName = "";

        /// <summary>
        /// 获取记录配表版本信息的文件名
        /// </summary>
        /// <returns></returns>
        public string GetExVersionName(bool original = false)
        {
#if UNITY_IPHONE
            if(original)
            {
                return "ExVersion.json";
            }
            else
            {
                if (string.IsNullOrEmpty(mExVersionName))
                {
                    var mapName = "";
                    mNameMapping.TryGetValue("ExVersion.json", out mapName);
                    if (!string.IsNullOrEmpty(mapName))
                        mExVersionName = mapName;
                    else
                        mExVersionName = "ExVersion.json";
                }

                return mExVersionName;
            }
#else
            return "ExVersion.json";
#endif
        }


        string mTableFileName = "";

        /// <summary>
        /// 获取配表的文件名
        /// </summary>
        /// <returns></returns>
        public string GetTableFileName(bool original = false)
        {
#if UNITY_IPHONE
            if(original)
            {
                return "x_cf.uass";
            }
            else
            {
                if (string.IsNullOrEmpty(mTableFileName))
                {
                    var mapName = "";
                    mNameMapping.TryGetValue("x_cf.uass", out mapName);
                    if (!string.IsNullOrEmpty(mapName))
                        mTableFileName = mapName;
                    else
                        mTableFileName = "x_cf.uass";
                }

                return mTableFileName;
            }
#else
            return "x_cf.uass";
#endif
        }
    }
}