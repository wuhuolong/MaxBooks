using gcloud_voice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class VoiceManager : xc.Singleton<VoiceManager>
    {
        private string mAuthkey; /*this key should get from your game svr*/
        private byte[] mShareFileID = null;
        private IGCloudVoice mVoiceEngine;
        private string mRecordPath;
        private string mDownloadPath;
        private uint mStartUploadingTime; // 开始上传时间戳
        private string mUploadReccordFileId;

        private static bool mIsStart = false;

        public bool mIsGCloudVoiceAuthKey = false;

        public bool IsUnloading { set; get; }

        /// <summary>
        /// 上传是否超时
        /// </summary>        
        public bool IsUploadingOverTime
        {
            get
            {
                // 最长等待时间
                var longest = GameConstHelper.GetUint("GAME_CHAT_VOICE_WAIT_LONGEST");

                var curServerTime = Game.Instance.ServerTime;

                return (curServerTime - mStartUploadingTime) > longest;
            }
        }

        public bool IsCanSendByGameLogic { set; get; }

        private List<string> mPlayingFileQueue = new List<string>();

        public Dictionary<string, string> FilePathToFileId = new Dictionary<string, string>();

        private string mSaveDir = Const.persistentDataPath + "/voice";

        public IGCloudVoice VoiceEngine
        {
            get
            {
                return mVoiceEngine;
            }
        }

        public VoiceManager()
        {
        }

        public void Init()
        {
            if (!mIsStart)
            {
                mIsStart = true;

                try
                {
                    mVoiceEngine = GCloudVoice.GetEngine();
                }
                catch(Exception e)
                {
                    GameDebug.Log(e.Message);
                    return;
                }

                System.TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                string strTime = System.Convert.ToInt64(ts.TotalSeconds).ToString();
#if !TEST_HOST && !CMPT_RELEASE
                if (Const.Region == RegionType.CHINA)
                {
                    mVoiceEngine.SetAppInfo("1075242022", "b24dbcfef34b73475b81f47df5edc172", strTime);
                    mVoiceEngine.SetServerInfo("udp://cn.voice.gcloudcs.com:10001");
                }
                else if (Const.Region == RegionType.HKTW)
                {
                    mVoiceEngine.SetAppInfo("1529889908", "f4655f1fb599ef6b9ac2fe52e49c9ef2", strTime);
                    mVoiceEngine.SetServerInfo("udp://hk.voice.gcloudcs.com:10013");
                }
                else if (Const.Region == RegionType.KOREA)
                {
                    mVoiceEngine.SetAppInfo("1614396342", "3fc91371164d69fdb3c9bfc911aec845", strTime);
                    mVoiceEngine.SetServerInfo("udp://kr.voice.gcloudcs.com:8700");
                }
                else if (Const.Region == RegionType.SEASIA)
                {
                    mVoiceEngine.SetAppInfo("1338975937", "e293bba813c9d4782b67695da54c75af", strTime);
                    mVoiceEngine.SetServerInfo("udp://sg.voice.gcloudcs.com:8700");
                }
#else
                mVoiceEngine.SetAppInfo("gcloud.test", "test_key", strTime);
#endif
                mVoiceEngine.Init();
                int setModedRet = mVoiceEngine.SetMode(GCloudVoiceMode.Translation);
                GameDebug.Log("setModedRet ="+ setModedRet);
                mVoiceEngine.EnableLog(true);
                mVoiceEngine.OnApplyMessageKeyComplete += (IGCloudVoice.GCloudVoiceCompleteCode code) =>
                {
                    //Debug.LogError("OnApplyMessageKeyComplete c# callback code = " + code);
                    if (code == IGCloudVoice.GCloudVoiceCompleteCode.GV_ON_MESSAGE_KEY_APPLIED_SUCC)
                    {
                        //GameDebug.Log("OnApplyMessageKeyComplete succ");
                    }
                    else
                    {
                        //GameDebug.Log("OnApplyMessageKeyComplete error");
                        VoiceManager.Instance.ReqAuthKey();
                    }
                };
                mVoiceEngine.OnUploadReccordFileComplete += (IGCloudVoice.GCloudVoiceCompleteCode code, string filepath, string fileid) =>
                {
                    //Debug.LogError("OnUploadReccordFileComplete c# callback");
                    if (code == IGCloudVoice.GCloudVoiceCompleteCode.GV_ON_UPLOAD_RECORD_DONE)
                    {
                        //Debug.LogError("OnUploadReccordFileComplete succ, filepath:" + filepath + " fileid len=" + fileid.Length + " fileid:" + fileid + " fileid len=" + fileid.Length);

                        FileInfo file_info = new FileInfo(filepath);
                        var path = GenFilePathByFileId(fileid);
                        if (!File.Exists(path))
                            file_info.CopyTo(path);

                        mUploadReccordFileId = fileid;
                        if (Const.Region == RegionType.CHINA)
                        {
                            VoiceManager.Instance.SpeechToText(fileid);
                        }
                        else
                        {
                            uint second = VoiceManager.Instance.GetRecFileSecond(fileid);
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GVOICE_SPEECH_TO_TEXT_COMPLETE, new CEventGVoiceArgs(fileid, "", second));
                            IsUnloading = false;
                        }
                    }
                    else
                    {
                        IsUnloading = false;
                        Debug.LogError("OnUploadReccordFileComplete error");
                    }
                };
                mVoiceEngine.OnDownloadRecordFileComplete += (IGCloudVoice.GCloudVoiceCompleteCode code, string filepath, string fileid) =>
                {
                    //Debug.LogError("OnDownloadRecordFileComplete c# callback");
                    if (code == IGCloudVoice.GCloudVoiceCompleteCode.GV_ON_DOWNLOAD_RECORD_DONE)
                    {
                        //Debug.LogError("OnDownloadRecordFileComplete succ, filepath:" + filepath + " fileid:" + fileid);

                        FileInfo file_info = new FileInfo(filepath);
                        var path = GenFilePathByFileId(fileid);
                        if (!File.Exists(path))
                            file_info.CopyTo(path);

                        OnlyPlayRecordFile(fileid);
                    }
                    else
                    {
                        Debug.LogError("OnDownloadRecordFileComplete error");
                    }
                };
                mVoiceEngine.OnPlayRecordFilComplete += (IGCloudVoice.GCloudVoiceCompleteCode code, string filepath) =>
                {
                    //Debug.LogError("OnPlayRecordFilComplete c# callback");
                    string file_id;
                    if (code == IGCloudVoice.GCloudVoiceCompleteCode.GV_ON_PLAYFILE_DONE && VoiceManager.Instance.FilePathToFileId.TryGetValue(filepath, out file_id))
                    {
                       
                    }
                    else
                    {
                        Debug.LogError("OnPlayRecordFilComplete error");
                    }

                    if (mPlayingFileQueue.Count > 0)
                    {
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GVOICE_RECORD_PLAY_DONE, new CEventGVoiceArgs(mPlayingFileQueue[0], "", 0));
                        mPlayingFileQueue.RemoveAt(0);
                    }

                    if (mPlayingFileQueue.Count == 0) // 最后一个播放完毕才重新播放背景音乐
                    {
                        AudioManager.Instance.SetMusicVolume(GlobalSettings.Instance.MusicVolume);
                        AudioManager.Instance.SetSFXVolume(GlobalSettings.Instance.SFXVolume);
                    }
                    else
                    {
                        PlayOrDownload(mPlayingFileQueue[0]);
                    }
                };
                mVoiceEngine.OnSpeechToText += (IGCloudVoice.GCloudVoiceCompleteCode code, string fileID, string result) =>
                {
                    //Debug.LogError("OnSpeechToText c# callback");
                    if (code == IGCloudVoice.GCloudVoiceCompleteCode.GV_ON_STT_SUCC)
                    {
                        //Debug.LogError("OnSpeechToText succ, result:" + result);
                        uint second = VoiceManager.Instance.GetRecFileSecond(fileID);
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GVOICE_SPEECH_TO_TEXT_COMPLETE, new CEventGVoiceArgs(fileID, result, second));
                    }
                    else if (code == IGCloudVoice.GCloudVoiceCompleteCode.GV_ON_STT_TIMEOUT)
                    {
                        Debug.LogError("OnSpeechToText error," + code);

                        if (mUploadReccordFileId.Length > 0)
                        {
                            uint second = VoiceManager.Instance.GetRecFileSecond(mUploadReccordFileId);
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GVOICE_SPEECH_TO_TEXT_COMPLETE, new CEventGVoiceArgs(mUploadReccordFileId, result, second));
                        }
                    }
                    else
                    {
                        Debug.LogError("OnSpeechToText error," + code);

                        Init();//重现初始化，尝试清除上一次翻译失败
                    }
                    IsUnloading = false;
                };
                if(Directory.Exists(mSaveDir)){
                    Directory.Delete(mSaveDir, true);
                }
                
                Directory.CreateDirectory(mSaveDir);

                mRecordPath = mSaveDir + "/recording.dat";
                mDownloadPath = mSaveDir + "/download.dat";

            }

            IsUnloading = false;
            IsCanSendByGameLogic = false;
            mStartUploadingTime = 0;
            mUploadReccordFileId = "";
            mPlayingFileQueue.Clear();

            VoiceManager.Instance.ReqAuthKey();
        }

        public string GenFileNameByFileId(string file_id)
        {
            return CommonTool.GetMD5(file_id);
        }

        public string GenFilePathByFileId(string file_id)
        {
            var new_file_name = GenFileNameByFileId(file_id);
            var new_file_path = mSaveDir + "/" + new_file_name + ".dat";
            if (!FilePathToFileId.ContainsKey(new_file_path))
                FilePathToFileId.Add(new_file_path, file_id);
            return new_file_path;
        }

        public void ReqAuthKey()
        {
            //Debug.LogError("ReqAuthKey");
            mVoiceEngine.ApplyMessageKey(6000);
        }

        // Update is called once per frame
        public void Update()
        {
            //Debug.Log("update...");
            if (mVoiceEngine == null)
            {
#if !UNITY_MOBILE_LOCAL
                Debug.Log("m_voiceengine is null");
#endif
            }
            else
            {
                mVoiceEngine.Poll();
            }
        }

        public bool isGCloudVoiceReady()
        {
            bool isReady = false;
            isReady = mVoiceEngine != null && mIsGCloudVoiceAuthKey;
            if (!mIsGCloudVoiceAuthKey)
            {
               // Debug.LogError("OnApplyMessageKeyComplete error");
            }
            return isReady;
        }

        public void StartRecord()
        {
            if (!IsUnloading)
            {
                int ret = mVoiceEngine.StartRecording(mRecordPath);
                if (ret > 0)
                    Debug.LogError("StartRecord = " + ret);
                //SpeechToText("3051020100044a3048020100040a3135303930373036383202037a1db902044afd03b7020459f2c58c042033323036343631653531396535633433383861366635373365613836323231390201000201000400");
            }
        }

        public void StopRecord()
        {
            int ret = mVoiceEngine.StopRecording();
            if (ret > 0)
                Debug.LogError("StopRecord = " + ret);
        }

        public void UploadFile()
        {
            if (!IsCanSendByGameLogic)
                return;

            //Debug.LogError("UnloadFile ->" + mRecordPath);
            uint size = GetRecFileSize(mRecordPath);
            if (size > 0)
            {
                int ret = mVoiceEngine.UploadRecordedFile(mRecordPath, 6000);
                if (ret == 0)
                {
                    mStartUploadingTime = Game.Instance.ServerTime;
                    IsUnloading = true;
                }
                else
                    Init();//尝试处理12299 错误码，重新初始化
            }
        }

        public void DownloadFile(string file_id)
        {
            mVoiceEngine.DownloadRecordedFile(file_id, mDownloadPath, 6000);
        }

        public void PlayReocrdFile(string file_id)
        {
            if (file_id == null)
                return;

            if (mPlayingFileQueue.Count == 0)
            {
                PlayOrDownload(file_id);
            }
            mPlayingFileQueue.Add(file_id);
        }

        public void PlayOrDownload(string file_id)
        {
            var path = GenFilePathByFileId(file_id);
            if (File.Exists(path))
            {
                mVoiceEngine.PlayRecordedFile(path);
            }
            else
            {
                DownloadFile(file_id);
            }
        }

        public void OnlyPlayRecordFile(string file_id)
        {
            var path = GenFilePathByFileId(file_id);
            if (File.Exists(path))
            {
                mVoiceEngine.PlayRecordedFile(path);
            }
        }

        public void StopPlayRecordFile()
        {
            if (mPlayingFileQueue.Count > 0)
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GVOICE_RECORD_PLAY_DONE, new CEventGVoiceArgs(mPlayingFileQueue[0], "", 0));       

            if(mVoiceEngine != null)
                mVoiceEngine.StopPlayFile();
        }

        public void StopAllPlayingRecordFiles()
        {
            //             if (mPlayingFileQueue.Count > 1)
            //             {
            //                 for (int i = 1; i < mPlayingFileQueue.Count; i++)
            //                     mPlayingFileQueue.RemoveAt(i);
            //             }

            if (mPlayingFileQueue.Count > 0)
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GVOICE_RECORD_PLAY_DONE, new CEventGVoiceArgs(mPlayingFileQueue[0], "", 0));

            mPlayingFileQueue.Clear();

            if(mVoiceEngine != null)
                mVoiceEngine.StopPlayFile();
        }

        public void SpeechToText(string fileid)
        {
            //Debug.LogError("do Speech to Text and fileid is "+ fileid);
            if (fileid != null)
            {
                if(mVoiceEngine != null)
                    mVoiceEngine.SpeechToText(fileid);

            }
            else {
                Debug.LogError("Speech to Text but fileid is null");
            }
            
        }

        public uint GetRecFileSecond(string fileid)
        {
            int[] bytes = new int[1];
            bytes[0] = 0;
            float[] seconds = new float[1];
            seconds[0] = 0;
            string record_path = GenFilePathByFileId(fileid);
            mVoiceEngine.GetFileParam(record_path, bytes, seconds);
            uint ret = 1;
            if (seconds.Length > 0)
            {
                ret = (uint)seconds[0];
                if (ret == 0)
                    ret = 1;
            }
            return ret;
        }

        public uint GetRecFileSize(string path)
        {
            int[] bytes = new int[1];
            bytes[0] = 0;
            float[] seconds = new float[1];
            seconds[0] = 0;
            mVoiceEngine.GetFileParam(path, bytes, seconds);
            uint ret = 0;
            if (bytes.Length > 0)
            {
                ret = (uint)bytes[0];
            }
            return ret;
        }

        public bool IsPlaying()
        {
            if (mPlayingFileQueue.Count > 0)
                return true;

            return false;
        }

        public string GetQueueHeadFileId()
        {
            if (mPlayingFileQueue.Count > 0)
                return mPlayingFileQueue[0];
            return "";
        }
    }
}
