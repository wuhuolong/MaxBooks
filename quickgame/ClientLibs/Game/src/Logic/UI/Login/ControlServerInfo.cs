//-----------------------------------------
// File: ControlServerInfo.cs
// Author: raorui
// Date: 2018.4.11
// Desc: 获取控制服的地址
//-----------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace xc
{
    class EncryptUtils
    {
        /// <summary>
        /// 加密二进制数据
        /// </summary>
        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            var des = new TripleDESCryptoServiceProvider();
            des.Key = key;
            des.Mode = CipherMode.ECB;

            return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        /// <summary>
        /// 解密二进制数据
        /// </summary>
        public static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            var des = new TripleDESCryptoServiceProvider();
            des.Key = key;
            des.Mode = CipherMode.ECB;

            return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }
    }

    public class ControlServerInfo
    {
        static ControlServerInfo sInstance;
        public static ControlServerInfo Instance
        {
            get
            {
                if (sInstance == null)
                    sInstance = new ControlServerInfo();

                return sInstance;
            }
        }

        public ControlServerInfo()
        {
            string fileName = ResNameMapping.Instance.GetMappingName("info.data");
            mConfigPath = String.Format("{0}/{1}", Application.streamingAssetsPath, fileName);
        }

        string mConfigPath;// = String.Format("{0}/{1}", Application.streamingAssetsPath, fileName);
        string mKey = "olfsjlslgfh58697612lfshq";
        string mConfig = "";
        public string GetConfig()
        {
            if(string.IsNullOrEmpty(mConfig))
            {
                ReadInfo();
            }
            
            return mConfig;
        }

        void ReadInfo()
        {
            FileStream fileStream = null;
            BinaryReader fileReader = null;
            try
            {
                fileStream = new FileStream(mConfigPath, FileMode.Open, FileAccess.Read);
                fileReader = new BinaryReader(fileStream);

                fileReader.BaseStream.Seek(0, SeekOrigin.Begin); //将文件指针设置到文件开始

                // 文件名数据
                var bytesLen = fileReader.ReadInt32();
                var buffer = new byte[bytesLen];

                fileReader.Read(buffer, 0, bytesLen);
                buffer = EncryptUtils.Decrypt(buffer, Encoding.UTF8.GetBytes(mKey));
                mConfig = Encoding.UTF8.GetString(buffer);
            }
            catch (Exception e)
            {
                if(fileStream != null)
                {
                    fileStream.Close();
                    fileStream = null;
                }

                if (fileReader != null)
                {
                    fileReader.Close();
                    fileReader = null;
                } 

                Debug.LogError("ControlServerInfo loadFile failed: " + e.Message);
            }

            if (fileStream != null)
            {
                fileStream.Close();
                fileStream = null;
            }

            if (fileReader != null)
            {
                fileReader.Close();
                fileReader = null;
            }
        }

        public void WriteInfo(string info)
        {
            if (string.IsNullOrEmpty(info))
            {
                Debug.LogError("ControlServerInfo writeInfo is empty");
                return;
            }

            FileStream fileStream = null;
            BinaryWriter fileWriter = null;
            try
            {
                fileStream = new FileStream(mConfigPath, FileMode.Create, FileAccess.ReadWrite);
                fileWriter = new BinaryWriter(fileStream);

                fileWriter.BaseStream.Seek(0, SeekOrigin.Begin); //将文件指针设置到文件开始

                var buffer = Encoding.UTF8.GetBytes(info);
                buffer = EncryptUtils.Encrypt(buffer, Encoding.UTF8.GetBytes(mKey));
                fileWriter.Write(buffer.Length);
                fileWriter.Write(buffer, 0, buffer.Length);
            }
            catch (Exception e)
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream = null;
                }

                if (fileWriter != null)
                {
                    fileWriter.Close();
                    fileWriter = null;
                }

                Debug.LogError("ControlServerInfo writeInfo failed: " + e.Message);
            }

            if (fileStream != null)
            {
                fileStream.Close();
                fileStream = null;
            }

            if (fileWriter != null)
            {
                fileWriter.Close();
                fileWriter = null;
            }
        }
    }
}
