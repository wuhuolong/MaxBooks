//------------------------------------------
// File: UIMinimapWindowBehaviour.cs
// Desc: 小地图上的组件
// Authro: caoxingcai
// Date: 2017.12.12
//------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using xc.protocol;
using System.Collections;
using System.Collections.Generic;
using Net;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIMinimapWindowBehaviour : IUIBehaviour
    {
        /// <summary>
        /// 本地玩家标识的UI物体
        /// </summary>
        GameObject m_localPlayerPoint;

        /// <summary>
        /// 队员标识的UI物体
        /// </summary>
        GameObject m_teamPoint;

        /// <summary>
        /// 地图图片
        /// </summary>
        RawImage m_minimapRawImage;

        /// <summary>
        /// 加载的地图图片资源
        /// </summary>
        SGameEngine.AssetResource m_assetRes;
        float m_uiScalex = 0;
        float m_uiScaley = 0;
        float m_minX = 0;
        float m_minY = 0;

        /// <summary>
        /// 网络消息应答，用来判断发送MSG_TEAM_MEMBER_POS后，服务端是否有消息返回
        /// </summary>
        bool m_bNetAnswer = false; 

        List<GameObject> m_teamListPointObjs = new List<GameObject>();
        Utils.Timer m_updateTeamPosCd;
        ScrollRect m_minimapScroll;

        public override void InitBehaviour()
        {
            m_localPlayerPoint = Window.FindChild("LocalPlayerPoint");
            m_teamPoint = Window.FindChild("MinimapTeamPlayerPoint");
            m_minimapScroll = Window.FindChild<ScrollRect>("MinimapScrollView");

            m_minimapRawImage = Window.FindChild<RawImage>("MinimapTexture");
            m_minimapRawImage.enabled = false;

            UIResourceManager.Instance.InitPool(m_teamPoint, 2);

            // event
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, OnTeamInfoChange);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_MEMBER_POS, OnTeamMemberPos);

            base.InitBehaviour();
        }

        public override void UpdateBehaviour()
        {
            base.UpdateBehaviour();

            RefreshPosition();
        }

        public override void DestroyBehaviour()
        {
            m_bNetAnswer = false;

            ClearPoint();
            UIResourceManager.Instance.DestroyPool(m_teamPoint);

            if (m_assetRes != null)
            {
                m_assetRes.destroy();
                m_assetRes = null;
            }

            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, OnTeamInfoChange);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_TEAM_MEMBER_POS, OnTeamMemberPos);

            base.DestroyBehaviour();
        }

        public override void EnableBehaviour(bool isEnable)
        {
            base.EnableBehaviour(isEnable);

            m_bNetAnswer = false;
            ClearPoint();

            if (!isEnable)
            {
                return;
            }

            DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(SceneHelp.Instance.CurSceneID);
            if (instanceInfo != null)
            {
                m_minX = instanceInfo.mMinPos.x;
                m_minY = instanceInfo.mMinPos.y;
                m_uiScalex = instanceInfo.mMiniMapWidth / m_minimapRawImage.rectTransform.rect.width;
                m_uiScaley = instanceInfo.mMiniMapHeight / m_minimapRawImage.rectTransform.rect.height;
                LoadMiniMapTexture(instanceInfo.mMiniMapName);
            }

            RefreshPosition();
            OnTeamInfoChange(null);

            m_localPlayerPoint.transform.SetAsLastSibling();
        }

        /// <summary>
        /// 监听队伍信息的变化
        /// </summary>
        /// <param name="args"></param>
        void OnTeamInfoChange(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;

            if (TeamManager.Instance.HaveTeam)
            {
                if (m_updateTeamPosCd != null)
                    return;

                m_updateTeamPosCd = new Utils.Timer(2000, true, 3000,
                    (dt) =>
                    {
                        if (!m_bNetAnswer)
                            ClearTeamPoint();

                        if (TeamManager.Instance.TeamMembers.Count <= 1)
                            return;

                        // 有的场景没有地图
                        if (m_uiScalex <= 0 || m_uiScaley <= 0)
                            return;

                        //隐藏组队
                        if (DBInstanceTypeControl.Instance.HideTeam(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType))
                            return;

                        m_bNetAnswer = false;
                        var data = new C2STeamMemberPos();
                        // 请求队伍位置信息
                        NetClient.GetBaseClient().SendData<C2STeamMemberPos>(NetMsg.MSG_TEAM_MEMBER_POS, data);
                    });
            }
            else {
                ClearPoint();
            }
        }

        /// <summary>
        /// 队伍成员位置信息
        /// </summary>
        /// <param name="args"></param>
        void OnTeamMemberPos(ushort protocol, byte[] data)
        {
            if (IsEnable == false || protocol != NetMsg.MSG_TEAM_MEMBER_POS)
                return;

            // 有的场景没有地图
            if (m_uiScalex <= 0 || m_uiScaley <= 0)
                return;

            m_bNetAnswer = true;

            var msg = S2CPackBase.DeserializePack<S2CTeamMemberPos>(data);
            if (m_teamListPointObjs.Count != msg.list.Count)
            {
                for (int i = 0; i < m_teamListPointObjs.Count; i++)
                {
                    UIResourceManager.Instance.ReturnObjectToPool(m_teamListPointObjs[i]);
                }

                m_teamListPointObjs.Clear();

                for (int i = 0; i < msg.list.Count; i++)
                {
                    var rect = GetItem(m_teamPoint);
                    if (null != rect)
                    {
                        m_teamListPointObjs.Add(rect.gameObject);
                    }
                }
            }



            for (int i = 0; i < m_teamListPointObjs.Count; i++)
            {
                if (msg.list.Count > i)
                {
                    var pos = msg.list[i];
                    float x = (pos.pos.px * GlobalConst.UnitScale - m_minX) / m_uiScalex;
                    float y = (pos.pos.py * GlobalConst.UnitScale - m_minY) / m_uiScaley;

                    m_teamListPointObjs[i].transform.localPosition = new Vector3(x, y);
                }
            }
        }

        void LoadMiniMapTexture(string minimapName)
        {
            if (m_minimapRawImage.texture == null || m_minimapRawImage.texture.name.CompareTo(minimapName.ToString()) != 0)
            {
                UIManager.Instance.MainCtrl.StartCoroutine(ShowAsync(minimapName));
            }
            else if (m_minimapRawImage.texture.name.CompareTo(minimapName.ToString()) == 0)
            {
                m_minimapRawImage.enabled = true;
            }
        }

        IEnumerator ShowAsync(string minimapName)
        {
            if (m_assetRes != null)
            {
                m_assetRes.destroy();
                m_assetRes = null;
            }

            if (0 == minimapName.Length) {
                m_minimapRawImage.enabled = false;
                yield break;
            }

            if (m_minimapRawImage.texture != null)
            {
                if (m_minimapRawImage.texture.name.CompareTo(minimapName.ToString()) == 0)
                {
                    yield break;
                }
            }

            m_assetRes = new SGameEngine.AssetResource();
            string assetPath = string.Format("Assets/Res/UI/Textures/MiniMap/{0}.png", minimapName);
            yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(
                SGameEngine.ResourceLoader.Instance.load_asset(assetPath, typeof(Texture), m_assetRes));

            if (m_assetRes == null || m_assetRes.asset_ == null)
            {
                if (null != m_minimapRawImage)
                    m_minimapRawImage.enabled = false;

                yield break;
            }

            if (null != m_minimapRawImage)
            {
                m_minimapRawImage.texture = m_assetRes.asset_ as Texture;
                m_minimapRawImage.enabled = true;
            }
        }

        void RefreshPosition()
        {
            var localPlayer = Game.Instance.GetLocalPlayer();
            if (null != localPlayer && null != m_minimapRawImage && m_localPlayerPoint != null)
            {
                // 本地玩家朝向
                float eulerAnglesZ = 360 - localPlayer.transform.localEulerAngles.y;
                m_localPlayerPoint.transform.localEulerAngles = new Vector3(0.0f, 0.0f, eulerAnglesZ);

                if (!m_minimapRawImage.enabled)
                    return;

                // 地图位置
                float x = (localPlayer.transform.localPosition.x - m_minX) / m_uiScalex;
                float y = (localPlayer.transform.localPosition.z - m_minY) / m_uiScaley;
                x -= (m_minimapScroll.viewport.rect.width / 2);
                y -= (m_minimapScroll.viewport.rect.height / 2);

                m_minimapRawImage.rectTransform.anchoredPosition = new Vector2(-1 * x, -1 * y);
            }
        }

        RectTransform GetItem(GameObject template)
        {
            GameObject go = UIResourceManager.Instance.GetObjectFromPool(template);
            if (null == go)
            {
                return null;
            }

            RectTransform nextItem = go.GetComponent<RectTransform>();
            nextItem.transform.SetParent(template.transform.parent, false);
            nextItem.gameObject.SetActive(true);
            return nextItem;
        }

        void ClearTeamPoint()
        {
            if (m_teamListPointObjs.Count > 0)
            {
                for (int i = 0; i < m_teamListPointObjs.Count; i++)
                {
                    UIResourceManager.Instance.ReturnObjectToPool(m_teamListPointObjs[i]);
                }
                m_teamListPointObjs.Clear();
            }
        }

        void ClearPoint()
        {
            if (m_updateTeamPosCd != null)
            {
                m_updateTeamPosCd.Destroy();
                m_updateTeamPosCd = null;
            }

            ClearTeamPoint();
        }
    }
}