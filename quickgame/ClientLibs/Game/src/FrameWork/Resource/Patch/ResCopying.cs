using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

namespace xc
{
    public class ResCopying
    {
        public class UnPacker
        {
            /// <summary>
            /// 解包后的文件存放路径
            /// </summary>
            string mUnPackPath;

            /// <summary>
            /// 文件路径
            /// </summary>
            string mFilePath;

            /// <summary>
            /// 删除自己
            /// </summary>
            bool mDeleteSelf = false;

            BinaryReader mFileReader = null;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="filePath"></param>
            /// <param name="unpackPath"></param>
            public UnPacker(string filePath, string unpackPath, bool deleteSelf)
            {
                mFilePath = filePath;
                mUnPackPath = unpackPath;
                mDeleteSelf = deleteSelf;
            }

            /// <summary>
            /// 初始化
            /// </summary>
            /// <returns></returns>
            public bool Init()
            {
                if (!File.Exists(mFilePath))
                {
                    Debug.Log("Init failed:, unpack file is not exist: " + mFilePath);
                    return false;
                }

                if (!Directory.Exists(mUnPackPath))
                {
                    Directory.CreateDirectory(mUnPackPath);

                    if (!Directory.Exists(mUnPackPath))
                    {
                        Debug.Log("Init failed:, unpack dir is not exist: " + mUnPackPath);
                        return false;
                    }
                }

                try
                {
                    mFileReader = new BinaryReader(File.Open(mFilePath, FileMode.Open, FileAccess.Read));
                }
                catch (Exception e)
                {
                    if (mFileReader != null)
                        mFileReader.Close();

                    Debug.Log("Init failed: " + e.Message);
                    return false;
                }

                return true;
            }

            /// <summary>
            /// 在指定文件夹进行文件的释放
            /// </summary>
            public void UnpackFiles(ResCopying copying)
            {
                var fileBuffer = copying.fileBuffer;
                var fileNameBuffer = copying.fileNameBuffer;

                mFileReader.BaseStream.Seek(0, SeekOrigin.Begin); //将文件指针设置到文件开始
                var fileLen = mFileReader.BaseStream.Length;
                //int i = 0;
                while (mFileReader.BaseStream.Position < fileLen)
                {
                    // 文件名数据
                    var fileNameBytesLen = mFileReader.ReadByte();
                    if (fileNameBuffer == null || fileNameBuffer.Length < fileNameBytesLen)
                        fileNameBuffer = new byte[fileNameBytesLen];

                    mFileReader.Read(fileNameBuffer, 0, fileNameBytesLen);
                    var fileName = Encoding.UTF8.GetString(fileNameBuffer, 0, fileNameBytesLen);

                    // 文件数据
                    var fileBytesLen = mFileReader.ReadInt32();
                    if (fileBuffer == null || fileBuffer.Length < fileBytesLen)
                        fileBuffer = new byte[fileBytesLen];

                    var fileBytes = mFileReader.Read(fileBuffer, 0, fileBytesLen);

                    try
                    {
                        var filePath = string.Format("{0}/{1}", mUnPackPath, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                        {
                            fileStream.Write(fileBuffer, 0, fileBytesLen);
                            CopyProgress.Progress++;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log("UnpackFiles failed: " + e.Message);
                        return;
                    }
                }
                //CopyProgress.Progress += i;
            }

            /// <summary>
            /// 完成文件操作
            /// </summary>
            public void Finish()
            {
                if (mFileReader != null)
                {
                    mFileReader.Close();
                }
            }
        }

        public string SrcFolder;
        public string TargetFolder;
        public List<string> UnPackList;
        public bool DeletePackage = false;

        byte[] fileBuffer = null;
        byte[] fileNameBuffer = null;

        public void CreatBuffer()
        {
            fileBuffer = new byte[12 * 1024 * 1024];
            fileNameBuffer = new byte[128];
        }

        public void ReleaseBuffer()
        {
            fileBuffer = null;
            fileNameBuffer = null;
        }

        public void Start()
        {
            CreatBuffer();
            var srcFolder = SrcFolder;
            var targetFolder = TargetFolder;
            var unPackList = UnPackList;
            for (int i = 0; i < unPackList.Count; ++i)
            {
                var fileName = unPackList[i];
                var filePath = string.Format("{0}/{1}", srcFolder ,fileName);


                var resUnPacker = new UnPacker(filePath, targetFolder, DeletePackage);
                if (!resUnPacker.Init())
                    break;

                resUnPacker.UnpackFiles(this);
                resUnPacker.Finish();
            }
            ReleaseBuffer();
            CopyProgress.Stage += 1;
        }
    }

    public static class CopyProgress
    {
        private static object lockme = new object();

        private static int progress = 0;
        public static int Progress
        {
            get
            {
                return progress;
            }
            set
            {
                lock (lockme)
                {
                    progress = value;
                }
            }
        }

        private static int stage = 0;
        public static int Stage
        {
            get
            {
                return stage;
            }
            set
            {
                lock (lockme)
                {
                    stage = value;
                }
            }
        }
    }
}
