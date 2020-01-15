using UnityEngine;

/// <summary>
/// 伤害飘字的动画组件
/// </summary>
public class UIFightDamageWordAnimComponent : MonoBehaviour
{
    public enum FightWordAnimStep
    {
        None,
        Step1,
        Step2,
        Step3,
        End,
    }

    //public static float m_normal_step2_height = 0.5f;
    //float m_animInterval = 0;
    Vector2 m_screen_abs_offset;    //屏幕坐标绝对偏移值
    Vector3 m_src_screen_pos;
    //Vector3 m_dest_screen_pos;
    public float m_has_anim_time = 0;
    public xc.FightEffectHelp.FightEffectType m_effect_type = xc.FightEffectHelp.FightEffectType.none;
    public FightWordAnimStep m_anim_step = FightWordAnimStep.None;
    //第一步：朝反向上方飘0.3s过程中并缩放比50%-120%（达到配置大小的1.2X），
    public float m_up_fly_anim_interval = 0.3f;
    Vector3 m_up_fly_dest_screen_pos = Vector3.one;
    public float m_up_fly_start_scale = 0.5f;
    public float m_up_fly_end_scale = 1.2f;

    //第二步：然后静帧0.2s，并快速变回1X大小
    public float m_stay_anim_interval = 0.3f;
    public float m_stay_end_scale = 1f;

    //第三步：最背后继续朝反向上方飘0.5s后并渐隐消失
    public float m_step3_anim_interval = 0.5f;
    Vector3 m_step3_dest_screen_pos = Vector3.one;
    CanvasGroup[] m_canvasGroup;
    void Awake()
    {
        m_canvasGroup = transform.GetComponentsInChildren<CanvasGroup>();
    }

    void OnEnable()
    {
        if (m_canvasGroup != null)
        {
            for (int index = 0; index < m_canvasGroup.Length; ++index)
            {
                m_canvasGroup[index].alpha = 1;
            }
        }
    }

    void Update()
    {
        if (m_anim_step == FightWordAnimStep.None || m_anim_step == FightWordAnimStep.End)
            return;
        m_has_anim_time = m_has_anim_time + Time.deltaTime;
        if (m_anim_step == FightWordAnimStep.Step1)
            UpdateStep1();
        if (m_anim_step == FightWordAnimStep.Step2)
            UpdateStep2();
        if (m_anim_step == FightWordAnimStep.Step3)
            UpdateStep3();
    }

    void UpdateStep1()
    {
        float percent = m_has_anim_time / m_up_fly_anim_interval;
        if (m_has_anim_time >= m_up_fly_anim_interval)
        {
            percent = 1;
            m_has_anim_time = 0;
            m_anim_step = FightWordAnimStep.Step2;
        }

        float scale = percent * (m_up_fly_end_scale - m_up_fly_start_scale) + m_up_fly_start_scale;
        transform.localScale = Vector3.one * scale;

        Camera main_camera = xc.ui.ugui.UIMainCtrl.MainCam;
        if (main_camera == null)
            return;
        Vector3 cur_screen_pos = (m_up_fly_dest_screen_pos - m_src_screen_pos) * percent + m_src_screen_pos;
//         cur_screen_pos.x = cur_screen_pos.x + m_screen_abs_offset.x;
//         cur_screen_pos.y = cur_screen_pos.y + m_screen_abs_offset.y;
        Vector3 cur_world_pos = main_camera.ScreenToWorldPoint(cur_screen_pos);
        cur_world_pos.z = 0;
        transform.position = cur_world_pos;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }

    void UpdateStep2()
    {
        float percent = m_has_anim_time / m_stay_anim_interval;
        if (m_has_anim_time >= m_stay_anim_interval)
        {
            percent = 1;
            m_has_anim_time = 0;
            m_anim_step = FightWordAnimStep.Step3;
        }
        float scale = percent * (m_stay_end_scale - m_up_fly_end_scale) + m_up_fly_end_scale;
        transform.localScale = Vector3.one * scale;
    }

    void UpdateStep3()
    {
        float percent = m_has_anim_time / m_step3_anim_interval;
        if (m_has_anim_time >= m_step3_anim_interval)
        {
            percent = 1;
            m_has_anim_time = 0;
            m_anim_step = FightWordAnimStep.End;
        }
        Camera main_camera = xc.ui.ugui.UIMainCtrl.MainCam;
        if (main_camera == null)
            return;
        Vector3 cur_screen_pos = (m_step3_dest_screen_pos - m_up_fly_dest_screen_pos) * percent + m_up_fly_dest_screen_pos;
//         cur_screen_pos.x = cur_screen_pos.x + m_screen_abs_offset.x;
//         cur_screen_pos.y = cur_screen_pos.y + m_screen_abs_offset.y;
        Vector3 cur_world_pos = main_camera.ScreenToWorldPoint(cur_screen_pos);
        cur_world_pos.z = 0;
        transform.position = cur_world_pos;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        if (m_canvasGroup != null)
        {
            for(int index = 0; index < m_canvasGroup.Length; ++index)
            {
                m_canvasGroup[index].alpha = 1 - percent;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="displayTimeScale"></param>
    /// <param name="start_worldPosInScene">首次出现的起始点世界位置</param>
    /// <param name="attacker_world_pos">攻击者位置</param>
    /// <param name="defender_world_pos">防御者位置（飘字的人）</param>
    /// <param name="effect_type"></param>
    /// <param name="screen_abs_offset">屏幕坐标绝对偏移值（所有屏幕位置都受这个绝对值影响）</param>
    public void Show(float displayTimeScale, Vector3 start_worldPosInScene, Vector3 attacker_world_pos, Vector3 defender_world_pos, 
        xc.FightEffectHelp.FightEffectType effect_type, Vector2 screen_abs_offset)
    {
        m_screen_abs_offset = screen_abs_offset;
        //displayTimeScale = displayTimeScale * 10;
        m_has_anim_time = 0;
        m_anim_step = FightWordAnimStep.Step1;
        Camera mainCamera = xc.Game.Instance.MainCamera;
        if (mainCamera == null)
            return;
        switch (effect_type)
        {
            case xc.FightEffectHelp.FightEffectType.CriticEnemyDamage:
            case xc.FightEffectHelp.FightEffectType.CriticAttendantDamage:
                {
                    m_up_fly_anim_interval = 0.2f * displayTimeScale;
                    Vector3 up_fly_dest_world_pos = start_worldPosInScene + (defender_world_pos - attacker_world_pos).normalized * 0.3f + new Vector3(0, 0.5f, 0);
                    m_up_fly_dest_screen_pos = mainCamera.WorldToScreenPoint(up_fly_dest_world_pos);
                    m_up_fly_start_scale = 0.3f;
                    m_up_fly_end_scale = 1.2f;

                    //第二步：然后静帧0.2s，并快速变回1X大小
                    m_stay_anim_interval = 0.2f * displayTimeScale;
                    m_stay_end_scale = 1f;

                    //第三步：最背后继续朝反向上方飘0.5s后并渐隐消失
                    m_step3_anim_interval = 0.5f * displayTimeScale;
                    Vector3 step3_dest_world_pos = start_worldPosInScene + (defender_world_pos - attacker_world_pos).normalized * 1.8f + new Vector3(0, 1f, 0);
                    m_step3_dest_screen_pos = mainCamera.WorldToScreenPoint(step3_dest_world_pos);
                }
                break;
            case xc.FightEffectHelp.FightEffectType.EnemyDamage:
            case xc.FightEffectHelp.FightEffectType.Attendant_damage:
            default:
                {
                    m_up_fly_anim_interval = 0.3f * displayTimeScale;
                    Vector3 up_fly_dest_world_pos = start_worldPosInScene + (defender_world_pos - attacker_world_pos).normalized * 0.3f + new Vector3(0, 0.5f, 0);
                    m_up_fly_dest_screen_pos = mainCamera.WorldToScreenPoint(up_fly_dest_world_pos);
                    m_up_fly_start_scale = 0.5f;
                    m_up_fly_end_scale = 1.2f;

                    //第二步：然后静帧0.1s，并快速变回1X大小
                    m_stay_anim_interval = 0.1f * displayTimeScale;
                    m_stay_end_scale = 1f;

                    //第三步：最背后继续朝反向上方飘0.5s后并渐隐消失
                    m_step3_anim_interval = 0.5f * displayTimeScale;
                    Vector3 step3_dest_world_pos = start_worldPosInScene + (defender_world_pos - attacker_world_pos).normalized * 1.8f + new Vector3(0, 0.8f, 0);
                    m_step3_dest_screen_pos = mainCamera.WorldToScreenPoint(step3_dest_world_pos);
                }
                break;
        }
        m_up_fly_dest_screen_pos.x = m_up_fly_dest_screen_pos.x + m_screen_abs_offset.x;
        m_up_fly_dest_screen_pos.y = m_up_fly_dest_screen_pos.y + m_screen_abs_offset.y;

        m_step3_dest_screen_pos.x = m_step3_dest_screen_pos.x + m_screen_abs_offset.x;
        m_step3_dest_screen_pos.y = m_step3_dest_screen_pos.y + m_screen_abs_offset.y;

        Vector3 src_world_pos_in_MainCam = transform.position;
        m_src_screen_pos = xc.ui.ugui.UIMainCtrl.MainCam.WorldToScreenPoint(src_world_pos_in_MainCam);
        m_effect_type = effect_type;
    }
}
