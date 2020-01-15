//-------------------------------------------------------------------
// Desc : 限制物体实例化最大数量的辅助类
// Author : Raorui
// Date : 2015.8.27
//-------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace xc
{
    public class InstGameObject
    {
        /// <summary>
        /// 实例化的所有物体
        /// </summary>
        private GameObject[] mInstObjects;

        /// <summary>
        /// 记录当前实例化物体的状态
        /// </summary>
        private bool[] mObjectState;
        
        public InstGameObject(int num)
        {
            mInstObjects = new GameObject[num];
            mObjectState = new bool[num];
            for (int index = 0; index < mObjectState.Length; ++index)
                mObjectState[index] = false;
        }

        /// <summary>
        /// 将实例化的GameObject添加到列表中
        /// </summary>
        /// <param name="obj"></param>
        public void AddAvailableObj(GameObject obj)
        {
            // 寻找一个已经被删除的GameObject的位置,添加到对应的索引上
            for (int index = 0; index < mObjectState.Length; ++index)
            {
                if (mInstObjects[index] == null)
                {
                    mInstObjects[index] = obj;
                    mObjectState[index] = true;
                    return;
                }
            }
        }

        /// <summary>
        /// 是否可以添加新的实例化物体
        /// </summary>
        /// <returns></returns>
        public bool CanAddAvailableObj()
        {
            for (int index = 0; index < mInstObjects.Length; ++index)
            {
                if (mInstObjects[index] == null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取一个可用的实例化物体
        /// </summary>
        /// <returns></returns>
        public GameObject GetOneAvailableObject()
        {
            for(int index = 0; index < mObjectState.Length; ++index)
            {
                if(mInstObjects[index] != null && mObjectState[index])
                {
                    mObjectState[index] = false;
                    return mInstObjects[index];
                }
            }
            return null;
        }
    }

    public class ObjInstHelp : xc.Singleton<ObjInstHelp>
    {
        /// <summary>
        /// 清除保存GameObject的字典
        /// </summary>
        public void ClearInstedObject()
        {
            mInstReuseObjDict.Clear();
            mReuseGameObjDict.Clear();
            mInstLimitedObjDict.Clear();
        }

        Dictionary<int, InstGameObject> mInstReuseObjDict = new Dictionary<int, InstGameObject>();

        /// <summary>
        /// 创建可重复使用并限制最大数量的物体
        /// max_num : 可实例化的最大数量
        /// </summary>
        public GameObject InstantiateReuse(Object inst_object, int max_num)
        {
            if(inst_object == null)
                return null;
            
            // 获取Object的id作为key
            int id = inst_object.GetInstanceID();
            InstGameObject inst_game_object;
            if(!mInstReuseObjDict.TryGetValue(id, out inst_game_object))
            {
                if(max_num < 1)
                    max_num = 1;

                inst_game_object = new InstGameObject(max_num);
                mInstReuseObjDict[id] = inst_game_object;
            }
            
            GameObject new_game_object = inst_game_object.GetOneAvailableObject();
            
            if(new_game_object == null && inst_game_object.CanAddAvailableObj())
            {
                GameObject new_obj = GameObject.Instantiate (inst_object) as GameObject;
                inst_game_object.AddAvailableObj(new_obj);
                new_game_object = inst_game_object.GetOneAvailableObject();
            }

            if(new_game_object == null)
            {
                new_game_object = new GameObject();
                new_game_object.name = "EmptyGameObject";
            }
            new_game_object.SetActive(false);
            new_game_object.SetActive(true);
            return new_game_object;
        }
        
        Dictionary<string, InstGameObject> mReuseGameObjDict = new Dictionary<string, InstGameObject>();
        Dictionary<int, InstGameObject> mInstLimitedObjDict = new Dictionary<int, InstGameObject>();
    }
}

