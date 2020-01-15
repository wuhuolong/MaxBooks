using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using SGameEngine;

namespace Uranus.Runtime
{ 
    public class UranusManager : xc.Singleton<UranusManager>
    {
        /// <summary>
        /// Ura文件前缀
        /// </summary>
        private readonly string FILE_PATH_PREFIX = Application.dataPath + "/Res/DB/Ura/data_ura_";

        /// <summary>
        /// 结点组们
        /// </summary>
        public Dictionary<string, NodeGroup> NodeGroups {  get { return nodeGroups; } }
        private Dictionary<string, NodeGroup> nodeGroups;

        /// <summary>
        /// Condition创建器
        /// </summary>
        private IConditionCreator conditionCreator;
        /// <summary>
        /// action创建器
        /// </summary>
        private IActionCreator actionCreator;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UranusManager()
        {
            nodeGroups = new Dictionary<string, NodeGroup>();
        }

        public string GetRunningNepKey()
        {
            return "nep" + Neptune.DataManager.Instance.Data.BaseInfo.LevelId;       
        }

        protected void InitNodeGroup(NodeGroup group)
        {
            var startNodes = group.StartNodes;
            List<uint> keys = new List<uint>(startNodes.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                StartNode startNode = startNodes[keys[i]];
                startNode.Init();
            }
        }

        public void Update()
        {
            using (var iter = nodeGroups.Values.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var nodeGroup = iter.Current;
                    var keys = Pool<uint>.List.New();

                    var startNodes = nodeGroup.StartNodes;
                    using(var siter = startNodes.GetEnumerator())
                    {
                        while(siter.MoveNext())
                        {
                            keys.Add(siter.Current.Key);
                        }
                    }

                    //List<uint> keys = new List<uint>(startNodes.Keys);
                    for (int i = 0; i < keys.Count; i++)
                    {
                        StartNode startNode = startNodes[keys[i]];
                        // 先递归重置一下trigger所有孩子的状态（为了控制编辑器结点由高亮状态还原）
                        if (Application.isEditor)
                            startNode.SetChildrenStatus(NodeStatus.NONE);

                        NodeStatus result = startNode.Update();
                        if (startNode.NodeMode == StartNodeMode.ONCE)
                        {
                            if (result == NodeStatus.SUCCESS)
                                nodeGroup.RemoveStartNode(startNode);
                            else
                                startNode.Active = false;
                        }
                        else
                        {
                            startNode.Active = false;
                        }
                    }

                    Pool<uint>.List.Free(keys);
                }
            }

                //foreach (var nodeGroup in nodeGroups.Values)
                //{
                    
                //}
        }

        public void RegistConditionCreator(IConditionCreator creator)
        {
            conditionCreator = creator;
        }

        public IConditionCreator GetConditionCreator()
        {
            return conditionCreator;
        }

        public void RegistActionCreator(IActionCreator creator)
        {
            actionCreator = creator;
        }

        public IActionCreator GetActionCreator()
        {
            return actionCreator;
        }

        /// <summary>
        /// 加载结点组
        /// </summary>
        /// <param name="key"></param>
        public NodeGroup LoadNodeGroup(string key)
        {
            string path = FILE_PATH_PREFIX + key + ".json";
            return LoadNodeGroupByJson(path);
        }

        public NodeGroup LoadNodeGroupByJson(string path)
        {
            string content = "";
#if UNITY_EDITOR
            if (File.Exists(path))
                content = File.ReadAllText(path);
#else
            content = xc.DBManager.Instance.LoadDBFile(path.Replace("Assets/Res/", ""));
#endif
            if (string.IsNullOrEmpty(content) == true)
            {
                return null;
            }
            NodeGroup temp = null;
            FullSerializer.fsData fsdata = FullSerializer.fsJsonParser.Parse(content);
            var serializer = new FullSerializer.fsSerializer();
            var processor = new FileSerializerProcessor();
            serializer.AddProcessor(processor);
            serializer.TryDeserialize(fsdata, ref temp);
            if (temp != null)
            {
                RemoveNodeGroup(temp.Id);
                InitNodeGroup(temp);
                nodeGroups.Add(temp.Id, temp);
                return temp;
            }
            return null;
        }

        /// <summary>
        /// 添加结点组
        /// </summary>
        /// <param name="key"></param>
        /// <param name="group"></param>
        public void AddNodeGroup(string key, NodeGroup group)
        {
            nodeGroups.Add(key, group);
        }

        /// <summary>
        /// 获取结点组
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public NodeGroup GetNodeGroup(string key)
        {
            NodeGroup group = null;
            if (nodeGroups.TryGetValue(key, out group))
            {
                return group;
            }
            return null;
        }

        /// <summary>
        /// 移除结点组
        /// </summary>
        /// <param name="key"></param>
        public void RemoveNodeGroup(string key)
        {
            NodeGroup group = GetNodeGroup(key);
            if (group != null)
                group.Destroy();

            nodeGroups.Remove(key);
        }

        /// <summary>
        /// 移除结点组
        /// </summary>
        /// <param name="group"></param>
        public void RemoveNodeGroup(NodeGroup group)
        {
            group.Destroy();
            nodeGroups.Remove(group.Id);
        }

        /// <summary>
        /// 清除所有结点组
        /// </summary>
        public void ClearAllNodeGroups()
        {
            foreach (var group in nodeGroups.Values)
                group.Destroy();

            nodeGroups.Clear();
        }

        /// <summary>
        /// 激活结点
        /// </summary>
        /// <param name="key"></param>
        /// <param name="id"></param>
        public void ActiveNode(string key, uint id)
        {
            NodeGroup group = null;
            if (nodeGroups.TryGetValue(key, out group) == false)
            {
                GameDebug.LogError("Cannot find node group " + key);
                return;
            }

            StartNode node = group.GetStartNode(id);
            if (node != null)
            {
                node.Active = true;
            }
        }

        /// <summary>
        /// 激活关卡相关结点
        /// </summary>
        /// <param name="id"></param>
        public void ActiveLevelNode(uint id)
        {
            int levelId = Neptune.DataManager.Instance.Data.BaseInfo.LevelId;
            if (levelId > 0)
            {
                string key = "nep" + levelId;
                ActiveNode(key, id);
            }
        }
    }
}

