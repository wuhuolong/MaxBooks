
using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float StartTime;
    public float ShakeLength;
    public float ShakeStrength;

    private float currentTime;

    private bool isShaked = false;
    private SimpleShake simpleShake;

    /// <summary>
    /// 最大距离限制，当距离玩家超过此值时取消振动
    /// </summary>
    private float MAX_DISTANCE_LIMIT = 20.0f;

 #if HANDHELD_VIBRATE
    public bool Vibrate = false;
    public float VibrateStartTime;
    public float VibrateLength;
    private bool isVibrated = false;
    private float lastVibrateTime = 0.0f;
#endif

    public void Init()
    {
        currentTime = 0.0f;
        isShaked = false;
        simpleShake = null;

#if HANDHELD_VIBRATE
        isVibrated = false;
        lastVibrateTime = 0.0f;
#endif
    }

    void Awake()
    {
        Init();
    }
    void OnEnable()
    {
        Init();
    }

    void OnDisable()
    {
        currentTime = 0.0f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (Camera.main == null)
        {
            return;
        }

        if(currentTime > StartTime && currentTime <= (StartTime + ShakeLength))
        {
            if (isShaked == false)
            {
                if(xc.Game.Instance.CameraControl != null)
                {
                    xc.Game.Instance.CameraControl.SimpleShake(ShakeStrength, ShakeLength);
                }
                else
                {
                    simpleShake = new SimpleShake();
                    simpleShake.ShakeStrength = ShakeStrength;
                    simpleShake.Length = ShakeLength;
                    simpleShake.TargetTrans = Camera.main.transform;

                    simpleShake.Shake();
                }
                    
                isShaked = true;
            }
        }

        if(simpleShake != null)
        {
            simpleShake.Update();
        }

#if HANDHELD_VIBRATE
        if (Vibrate == false)
        {
            return;
        }

        // 使用Handheld.Vibrate();接口震动手机，只能固定0.5s，使用这些设定来延长震动
        if (isVibrated && (VibrateStartTime + VibrateLength) - currentTime >= 0.5f)
        {
            if (lastVibrateTime == 0.0f || (currentTime - lastVibrateTime) >= 0.5f)
            {
                lastVibrateTime = currentTime;
#if UNITY_ANDROID || UNITY_IPHONE
                Handheld.Vibrate();
#endif
            }
        }

        if (currentTime > VibrateStartTime && isVibrated == false)
        {
            lastVibrateTime = currentTime;
#if UNITY_ANDROID || UNITY_IPHONE
            Handheld.Vibrate();
#endif
            isVibrated = true;
        }
#endif
    }
}