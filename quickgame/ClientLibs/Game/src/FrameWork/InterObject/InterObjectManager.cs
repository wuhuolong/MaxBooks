using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using SGameEngine;

namespace xc
{
    [wxb.Hotfix]
    public class InterObjectManager : xc.Singleton<InterObjectManager>
    {
        Dictionary<InterObjectType, uint> m_CurrentIdxs = new Dictionary<InterObjectType, uint>();
        Dictionary<InterObjectUnitID, InterObject> m_InterObjects = new Dictionary<InterObjectUnitID, InterObject>();

        public InterObjectManager()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnSwitchScene);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CLICKINTEROBJECTLAYER, OnClickInterObjectLayer);
        }

        public T CreateObject<T>(InterObjectUnitID uid, string res_path, Vector3 pos, Quaternion rot, Vector3 scale) where T : InterObject
        {
            if (m_InterObjects.ContainsKey(uid))
            {
                Debug.LogError("m_InterObjects's key conflict. uid: " + uid);
                return (m_InterObjects[uid] as T);
            }

            T inter_object = Activator.CreateInstance<T>();
            inter_object.OnCreate();
            m_InterObjects.Add(uid, inter_object);

            inter_object.CreateModel(res_path, pos, rot, scale);
            return inter_object;
        }

        public void DestroyObject(InterObjectUnitID uid)
        {
            InterObject inter_object = null;
            if (m_InterObjects.TryGetValue(uid, out inter_object))
            {
                inter_object.Destroy();
                m_InterObjects.Remove(uid);
            }
        }

        /// <summary>
        /// 获取唯一ID
        /// </summary>
        /// <returns></returns>
        public InterObjectUnitID GetUID(InterObjectType type)
        {
            uint idx = 0;
            m_CurrentIdxs.TryGetValue(type, out idx);

            InterObjectUnitID uid = new InterObjectUnitID();
            uid.m_Type = type;
            uid.m_Idx = idx;

            m_CurrentIdxs[type] = idx + 1;
            return uid;
        }

        public void Reset()
        {

        }

        public void DestroyAll()
        {
            m_CurrentIdxs.Clear();
            foreach (var inter_object in m_InterObjects.Values)
            {
                inter_object.Destroy();
            }

            m_InterObjects.Clear();
        }

        public void DestroyAllAndBoss()
        {
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SCENE_DESTROY_ALL_INTER_OBJECT, null);
            DestroyAll();
        }
        void OnSwitchScene(CEventBaseArgs data)
        {
            DestroyAll();
        }

        public InterObject GetObject(InterObjectUnitID uid)
        {
            InterObject inter_object = null;
            if (m_InterObjects.TryGetValue(uid, out inter_object))
            {
                return inter_object;
            }
            return null;
        }

        void OnClickInterObjectLayer(CEventBaseArgs data)
        {
            GameObject selectedObj = (GameObject)data.arg;
            if (selectedObj != null)
            {
                foreach(var item in m_InterObjects)
                {
                    if((item.Value.ModelParent == selectedObj || item.Value.Model == selectedObj)
                        && xc.SceneHelp.Instance.CurLine != 0       // 当前场景无分线
                        && xc.SceneHelp.Instance.CurLine != 1)
                    {//选中目标,跳转1线
                        xc.SceneHelp.JumpToScene(xc.SceneHelp.Instance.CurSceneID, 1);
                    }
                }
            }
        }
    }
}
