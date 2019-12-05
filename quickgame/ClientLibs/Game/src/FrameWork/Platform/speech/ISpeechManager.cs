using System;

public interface ISpeechManager
{
    //语音控制接口
    /*
        @brief 开始录音
        @param filePath 文件路径
        @return 1 标示成功  -1 没权权限等 异常 失败 0 标示 上次录音还没有结束 
    */
    int startRecord(string filePath);

    /*
        @brief 结束录音
        @return 文件名
    */  
    string stopRecord();

    /*
        @brief 获取实时音量
        @return 音量
    */
    int getRecordingVoiceVolume();

    /*
        @brief 判断路径写入操作是否结束
        @return 1表示成功
    */

    int getWriteOver();
}


