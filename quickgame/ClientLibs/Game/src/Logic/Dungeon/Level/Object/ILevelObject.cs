using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc.Dungeon
{
    /// <summary>
    /// 关卡基础对象
    /// </summary>
    public abstract class ILevelObject
    {
        /// <summary>
        /// 原始数据
        /// </summary>
        protected Neptune.BaseGenericNode rawData;

        /// <summary>
        /// 对象Id
        /// </summary>
        int mId;
        public int Id
        {
            get {
                return rawData ? rawData.Id : mId;
            }
        }

        /// <summary>
        /// 关联的场景对象
        /// </summary>
        public GameObject BindGameObject { get { return gameObject; } }
        protected GameObject gameObject;
        protected Transform transform;

        /// <summary>
        /// 加载资源的协程
        /// </summary>
        protected Coroutine mLoadPrefabCoroutine = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        public ILevelObject(Neptune.BaseGenericNode data)
        {
            rawData = data;

            gameObject = new GameObject(data.GameObjectName);
            transform = gameObject.transform;
            transform.position = data.Position;
            transform.rotation = data.Rotation;
            transform.localScale = data.Scale;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public ILevelObject(int id, string name, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            rawData = new Neptune.BaseGenericNode();
            rawData.Id = id;
            rawData.GameObjectName = name;
            rawData.Position = position;
            rawData.Rotation = rotation;
            rawData.Scale = scale;

            mId = id;

            gameObject = new GameObject(name);
            transform = gameObject.transform;
            transform.position = position;
            transform.rotation = rotation;
            transform.localScale = scale;
        }

        /// <summary>
        /// 设置坐标
        /// </summary>
        /// <param name="pos"></param>
        public void SetPosition(Vector3 pos)
        {
            if (transform != null)
                transform.position = pos;
        }

        public virtual void CleanUp()
        {
            if (mLoadPrefabCoroutine != null)
            {
                MainGame.HeartBehavior.StopCoroutine(mLoadPrefabCoroutine);
            }

            if (gameObject != null)
                GameObject.Destroy(gameObject);
        }

        protected void DestroyModel()
        {
            List<Transform> childrenToDestroy = new List<Transform>();
            childrenToDestroy.Clear();
            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform child = transform.GetChild(i);
                childrenToDestroy.Add(child);
            }
            foreach (Transform child in childrenToDestroy)
            {
                GameObject.DestroyImmediate(child.gameObject);
            }
        }
    }
}