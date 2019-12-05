
using System;

public class WinSpeechManager : ISpeechManager
{
    private static WinSpeechManager manager = null;
    
    // Use this for initialization
    WinSpeechManager()
    {
        GameDebug.Log("WinSpeechManager init");
    }
    
    public static WinSpeechManager getInstance()
    {
        if (manager == null)
        {
            manager = new WinSpeechManager();  
        }
        return manager; 
    }
    /*
        @brief 开始录音
        @param filePath 文件路径
        @return 1 标示成功  -1 没权权限等 异常 失败 0 标示 上次录音还没有结束 
    */
    public int startRecord(string filePath){
        int ret = 1; 
        return ret; 

    }
    
    /*
        @brief 结束录音
        @return 文件名
    */  
    public string stopRecord(){
        string ret = null;
        return ret; 
    }
    
    /*  @brief 获取实时音量
        @return 音量
    */
    public int getRecordingVoiceVolume(){
        int ret = 1; 
        return 1;
    }
    
    /*
        @brief 判断路径写入操作是否结束
        @return 1表示成功
    */
    
    public int getWriteOver(){
        int ret = 1; 
        return 1;

    }
}


