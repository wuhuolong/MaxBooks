using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc.Dungeon
{
    public class InteractionObjectManager : xc.Singleton<InteractionObjectManager>
    {
        /// <summary>
        /// 互动物体/机关对象字典
        /// </summary>
        public Dictionary<int, InteractionObject> InteractionObjects;

        public InteractionObjectManager()
        {
            InteractionObjects = new Dictionary<int, InteractionObject>();
            InteractionObjects.Clear();
        }

        public void CreateAllInteractionObjects()
        {
            foreach (Neptune.Interaction interaction in Neptune.DataManager.Instance.Data.GetData<Neptune.Interaction>().Data.Values)
            {
                if (interaction != null)
                {
                    if (interaction.SpawnDirectly == true)
                    {
                        CreateInteractionObject(interaction);
                    }
                }
                else
                {
                    GameDebug.LogError("Create all interaction objects error, interaction is null!!!");
                }
            }
        }

        /// <summary>
        /// 创建互动物体/机关
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public InteractionObject CreateInteractionObject(Neptune.Interaction data)
        {
            InteractionObject o = new InteractionObject(data);
            if (o != null)
            {
                if (InteractionObjects.ContainsKey(o.Id) == false)
                {
                    InteractionObjects.Add(o.Id, o);
                }
                else
                {
                    GameDebug.LogError("Create interaction object error, id " + o.Id + " has already exist!!!");
                }
            }
            return o;
        }

        /// <summary>
        /// 获取互动物体/机关
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InteractionObject GetInteractionObject(int id)
        {
            InteractionObject o = null;
            if (InteractionObjects.TryGetValue(id, out o))
            {
                return o;
            }
            return o;
        }

        /// <summary>
        /// 移除互动物体/机关
        /// </summary>
        /// <param name="id"></param>
        public void RemoveInteractionObject(int id)
        {
            InteractionObject o = GetInteractionObject(id);
            if (o != null)
            {
                o.CleanUp();
            }
            InteractionObjects.Remove(id);
        }
    }
}
