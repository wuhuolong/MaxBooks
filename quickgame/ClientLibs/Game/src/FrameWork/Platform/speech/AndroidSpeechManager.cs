using UnityEngine;
using System.Collections;
using System;

#if !UNITY_IPHONE
public class AndroidSpeechManager : ISpeechManager
{
    private static AndroidSpeechManager manager = null;
    private  string JAVA_CLASS_NAME = "cn.uc.db.speech.SpeechEngine" ;
    private AndroidJavaClass javaClass;
    AndroidSpeechManager()
    {
        GameDebug.Log("AndroidSpeechManager init");
        try
        {
            javaClass = new AndroidJavaClass(JAVA_CLASS_NAME);
        }
        catch (Exception e ) {
            if(!Application.isEditor)
                GameDebug.LogError("AndroidSpeechManager is  no enable!");
        }
    }
    
    public static AndroidSpeechManager getInstance()
    {
        if (manager == null)
        {
            manager = new AndroidSpeechManager();  
        }
        return manager; 
    }
    /* @brief 开始录音
        @param filePath 文件路径
        @return 1 标示成功  -1 没权权限等 异常 失败 0 标示 上次录音还没有结束 
    */
    public int startRecord(string filePath){
        var ret = javaClass.CallStatic<int>("startRecord");
        return ret; 
    }
    
    /*
        @brief 结束录音
        @return 文件名
    */  
    public string stopRecord(){
        var ret = javaClass.CallStatic<string>("stopRecord");
        return ret; 
    }
    
    /*  @brief 获取实时音量
        @return 音量
    */
    public int getRecordingVoiceVolume(){
        var ret = javaClass.CallStatic<int>("getRecordingVoiceVolume");
        return ret; 
    }
    
    /*
        @brief 判断路径写入操作是否结束
        @return 1表示成功
    */
    
    public int getWriteOver(){
        var ret = javaClass.CallStatic<int>("getWriteOver");
        return ret; 
        
    }
}

#endif
