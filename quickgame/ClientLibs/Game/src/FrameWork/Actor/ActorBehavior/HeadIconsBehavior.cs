//------------------------------------------------------------------------------
// Desc: 控制角色头顶图片的显示
// Date: 2016.6.30
// Author: raorui
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class HeadIconsBehavior : IActorBehavior
    {
        public HeadIconsBehavior(Actor act)
        {
            mOwner = act;
        }

        public const string ArenaGrade = "ArenaGrade";
        public const string Title = "Title";
        public const string Mine = "Mine";
        public const string Team = "Team";
        public const string PK = "PK";
        public const string PK2 = "PK2";
        public const string BossBg = "BossBg";
        public const string Boss = "Boss";

        public class IconInfo
        {
            public UI3DImage IconComponent;
            public UI3DImage.StyleInfo StyleInfo;

            public IconInfo(UI3DImage c, UI3DImage.StyleInfo info)
            {
                IconComponent = c;
                StyleInfo = info;
            }
        }

        private Dictionary<string,IconInfo> mIconComponents = new Dictionary<string, IconInfo>();

        public override void InitBehaviors()
        {
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, OnModelChange);
        }
        
        public override void Update()
        {
            //Debug.Log("TilteBehavior");
        }
        
        
        public override void LateUpdate()
        {
            
        }
        
        public override void UnInitBehaviors()
        {
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, OnModelChange);
            base.UnInitBehaviors();

            foreach (var icon in mIconComponents.Values)
            {
                if(icon != null)
                {
                    CommonTool.DestroyObjectImmediate(icon.IconComponent);
                    icon.StyleInfo = null;
                }
            }
            mIconComponents.Clear();
        }
        
      
        // leaf
        public override void EnableBehaviors(bool enable)
        {
            foreach(var icon in mIconComponents.Values)
            {
                if(icon != null && icon.IconComponent != null)
                {
                    icon.IconComponent.Visible = enable;
                    icon.IconComponent.enabled = enable;
                }
            }
        }
        

        public UI3DImage GetIconComponent(string name)
        {
            IconInfo info = null;
            if(mIconComponents.TryGetValue(name , out info))
                return info.IconComponent;

            return null;
        }
        
        public bool HasComponent(string name)
        {
            return GetIconComponent(name) != null;
        }
        
        public void SetIconComponent(string name, UI3DImage.StyleInfo styleInfo)
        {
            if (mOwner.IsResLoaded)
            {
                IconInfo info = null;
                if (mIconComponents.TryGetValue(name, out info))
                {
                    info.StyleInfo = styleInfo;
                    UI3DImage iconComponent = null;
                    iconComponent = mOwner.GetModelParent().GetComponent<UI3DImage>();
                    if (iconComponent == null)
                    {
                        iconComponent = mOwner.GetModelParent().AddComponent<UI3DImage>();
                    }
                    iconComponent.ResetStyleInfo(styleInfo);
                    mIconComponents[name] = new IconInfo(iconComponent, styleInfo);
                }
                else
                {
                    UI3DImage iconComponent = mOwner.GetModelParent().AddComponent<UI3DImage>();
                    iconComponent.ResetStyleInfo(styleInfo);
                    mIconComponents[name] = new IconInfo(iconComponent, styleInfo);
                }
            }
            else
            {
                mIconComponents[name] = new IconInfo(null, styleInfo);
            }
        }

        public void RemoveIconComponent(string name)
        {
            IconInfo info = null;
            if (mIconComponents.TryGetValue(name, out info))
            {
                CommonTool.DestroyObjectImmediate(info.IconComponent);
                info.StyleInfo = null;
                mIconComponents.Remove(name);
            }
        }

        void UpdateOwnerTrans(Transform trans)
        {
            foreach(var icon in mIconComponents.Values)
            {
                if(icon.IconComponent == null)
                {
                    icon.IconComponent = mOwner.GetModelParent().AddComponent<UI3DImage>();
                }

                icon.IconComponent.SetOwnerTrans(trans);
                icon.IconComponent.ResetStyleInfo(icon.StyleInfo);
            }
        }

        Vector3 Offset
        {
            set
            {
                foreach (var icon in mIconComponents.Values)
                {
                    if (icon.IconComponent != null)
                    {
                        icon.IconComponent.Offset = value;
                    }
                }
            }
        }

        void OnAfterCreate(CEventBaseArgs param)
        {
            UpdateOwnerTrans(mOwner.GetModelParent().transform);
            Offset = new Vector3(0f, mOwner.Height, 0f);
        }

        void OnModelChange(CEventBaseArgs param)
        {
            Offset = new Vector3(0f, mOwner.Height, 0f);
        }
    }
}

