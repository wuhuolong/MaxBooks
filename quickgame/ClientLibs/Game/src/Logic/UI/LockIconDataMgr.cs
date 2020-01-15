//-----------------------------------
// File: LockIconDataMgr.cs
// Desc: 
// Author: luozhuocheng
// Date: 2019/2/13 20:03:31
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Utils;
using xc.ui;

namespace xc
{
    [wxb.Hotfix]
    public class LockIconDataMgr : xc.Singleton<LockIconDataMgr>
    {
        private Dictionary<uint, List<xc.ui.LockIcon>> mData = new Dictionary<uint, List<ui.LockIcon>>();

        public LockIconDataMgr()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_LOCK_ICON_BIND, OnBind);
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_LOCK_ICON_UNBIND, OnUnBind);
            //ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_SYS_OPEN, Update);
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_SYS_OPEN_NOTIFY, OnSystemOpen);
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_SYS_CLOSE, Update);
            
        }
        public void Reset()
        {
            if (mData != null)
                mData.Clear();
        }

        public void OnBind(CEventBaseArgs eventParam)
        {
            if (eventParam == null || eventParam.arg == null)
                return;
            ui.LockIcon lockIcon = eventParam.arg as ui.LockIcon;
            if (lockIcon == null)
                return;
            if (lockIcon.SystemId == 0)
                return;

            BindLockIcon(lockIcon.SystemId, lockIcon);
            FreshLockIcon(lockIcon);
        }

        public void OnUnBind(CEventBaseArgs eventParam)
        {
            if (eventParam == null || eventParam.arg == null)
                return;
            ui.LockIcon lockIcon = eventParam.arg as ui.LockIcon;
            if (lockIcon == null)
                return;
            if (lockIcon.SystemId == 0)
                return;
            UnBindLockIcon(lockIcon.SystemId, lockIcon);
        }

        public void Update(CEventBaseArgs eventParam)
        {
            if (eventParam == null || eventParam.arg == null)
                return;
            DBSysConfig.SysConfig config = eventParam.arg as DBSysConfig.SysConfig;
            FreshBySystemId(config.Id);
        }

        public void OnSystemOpen(CEventBaseArgs eventParam)
        {
            if (eventParam == null || eventParam.arg == null)
                return;
            FreshBySystemId((uint)eventParam.arg);
        }

        public void FreshBySystemId(uint systemId)
        {
            if (mData.ContainsKey(systemId))
            {
                List<LockIcon> lockList = mData[systemId];
                for (int i = 0; i < lockList.Count; i++)
                {
                    LockIcon lockIcon = lockList[i];
                    if (lockIcon != null)
                    {
                        FreshLockIcon(lockIcon);
                    }
                }
            }
        }

        public void FreshLockIcon(LockIcon lockIcon)
        {
            if (lockIcon == null)
                return;
            if (lockIcon.SystemId == 0)
                return;
            bool isOpenSystem = SysConfigManager.GetInstance().CheckSysHasOpened(lockIcon.SystemId);
            if (lockIcon.RealObj != null)
            {
                lockIcon.RealObj.gameObject.SetActive(isOpenSystem == false);
            }
            if (lockIcon.TargetImage != null)
            {
                if (lockIcon.Model == LockIcon.State.USE_COLOR)
                {
                    if (isOpenSystem)
                        lockIcon.TargetImage.color = Color.white;
                    else
                        lockIcon.TargetImage.color = lockIcon.ExpectColor;
                }
                else
                {
                    GreyMaterialComponent greyComponent = lockIcon.GreyComponent as GreyMaterialComponent;
                    if (greyComponent == null)
                    {
                        greyComponent = lockIcon.TargetImage.gameObject.AddComponent<GreyMaterialComponent>();
                        lockIcon.GreyComponent = greyComponent;
                    }
                    greyComponent.IsGrey = isOpenSystem == false;
                }
            }

        }


        public void BindLockIcon(uint systemId, LockIcon icon)
        {
            if (mData.ContainsKey(systemId) == false)
            {
                mData.Add(systemId, new List<LockIcon>());
            }
            List<LockIcon> lockList = mData[systemId];
            if (lockList.Contains(icon) == false)
            {
                lockList.Add(icon);
            }
        }
        public void UnBindLockIcon(uint systemId, LockIcon icon)
        {
            if (mData.ContainsKey(systemId) == false)
            {
                mData.Add(systemId, new List<LockIcon>());
            }
            List<LockIcon> lockList = mData[systemId];
            if (lockList.Contains(icon))
            {
                lockList.Remove(icon);
            }
        }

        public void HandleLockIcon(uint systemId)
        {
            //
            SysConfigManager.GetInstance().CheckSysHasOpened(systemId, true);
        }

    }
}
