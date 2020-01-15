//------------------------------------------------------------------------------
// File : UIPlayerSelectInfo.cs
// Desc: 控制选中角色目标的信息更新
// Author: raorui
// Ddate: 2017.11.29
//------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using xc;
using xc.ui.ugui;

public class UIPlayerTargetInfo : MonoBehaviour
{
    /// <summary>
    /// 选中的目标物体
    /// </summary>
    GameObject m_Target;

    /// <summary>
    /// 头像上的按钮
    /// </summary>
    Button m_PlayerBtn;

    /// <summary>
    /// 玩家头像的节点
    /// </summary>
    Transform m_IconImage;

    /// <summary>
    /// 显示玩家等级的文本
    /// </summary>
    Text m_LvText;

    void Awake()
    {
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CLICKPLAYER, OnClickPlayer);

        Transform cache_trans = transform;
        m_IconImage = cache_trans.Find("IconImage");
        m_LvText = cache_trans.Find("LvText").GetComponent<Text>();
        m_PlayerBtn = GetComponent<Button>();

        m_PlayerBtn.onClick.AddListener(OnClickPlayerBtn);

        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_CLICKPLAYER, OnClickPlayer);
        m_PlayerBtn.onClick.RemoveAllListeners();
    }

    /// <summary>
    /// 响应点击玩家的消息
    /// </summary>
    /// <param name="data"></param>
    void OnClickPlayer(CEventBaseArgs data)
    {
        if (SceneHelp.Instance.IgnoreClickPlayer)
        {
            return;
        }

        GameObject select_object = (GameObject)data.arg;
        if (select_object != null)
        {
            ActorMono act_mono = ActorHelper.GetActorMono(select_object);
            if (act_mono != null && act_mono.BindActor != null)
            {
                if (act_mono.BindActor.IsDead() || act_mono.BindActor.IsLocalPlayer)
                    return;

                m_LvText.text = act_mono.BindActor.Level.ToString();
                for(int i = 0; i< m_IconImage.childCount; ++i)
                {
                    m_IconImage.GetChild(i).gameObject.SetActive(false);
                }
                int voc_id = (int)act_mono.BindActor.VocationID;
                var voc_image_object = m_IconImage.Find(voc_id.ToString());
                if(voc_image_object != null)
                    voc_image_object.gameObject.SetActive(true);

                m_Target = select_object;
                gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// 点击玩家头像按钮
    /// </summary>
    void OnClickPlayerBtn()
    {
        if (m_Target != null)
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CLICKPLAYER_INFO, new CEventBaseArgs(m_Target));
    }

    /// <summary>
    /// 目标丢失
    /// </summary>
    void OnTargetLost()
    {
        m_Target = null;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (m_Target == null)
        {
            OnTargetLost();
            return;
        }

        var local_player = Game.Instance.GetLocalPlayer();
        if (local_player == null)
            return;

        var local_pos = local_player.transform.position;
        var target_pos = m_Target.transform.position;

        if (Vector3.Distance(local_pos, target_pos) > 12.0f)
        {
            OnTargetLost();
        }
    }
}

