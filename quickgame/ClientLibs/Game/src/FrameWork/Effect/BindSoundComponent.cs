using UnityEngine;
using System.Collections;
using xc;

public class BindSoundComponent : MonoBehaviour
{
    /// <summary>
    /// 声音的资源路径
    /// </summary>
    string m_AudioPath;

    /// <summary>
    /// 声音是否循环播放
    /// </summary>
    bool m_IsLoop;

    /// <summary>
    /// 是否进行了初始化
    /// </summary>
    bool m_Inited = false;

    /// <summary>
    /// 初始化声音资源路径等参数
    /// </summary>
    /// <param name="audio_path"></param>
    /// <param name="is_loop"></param>
    public void Init(string audio_path, bool is_loop)
	{
        m_AudioPath = audio_path;
        m_IsLoop = is_loop;

        m_Inited = true;
    }
	
	void OnEnable()
	{		
		if (m_Inited)
			AudioManager.Instance.BindAudio(gameObject, m_AudioPath, m_IsLoop);
	}
}

