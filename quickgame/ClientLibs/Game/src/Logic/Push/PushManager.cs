using System;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class PushManager : MonoBehaviour
    {
        public static PushManager Instance;
        public void Awake()
        {
            Instance = this;
        }

        public void RegistPushService(string token)
        {
            GameDebug.Log(string.Format("PushManager:RegistPushService token = {0}", token));

            if (string.IsNullOrEmpty(token))
                return;

            if (token.Length > 16) // 欢老板说，大于16位就是token，不然就是错误码
            {
                GlobalConfig globalConfig = GlobalConfig.GetInstance();
                DBOSManager.getOSBridge().registerPush(globalConfig.LoginInfo.AccName);

                globalConfig.XgDeviceId = token;

                // 接收到信鸽sdk的设备id之后，发一次RoleInfo给控制服
                ControlServerLogHelper.Instance.PostRoleInfo();
            }
            else
            {
                GameDebug.LogError("RegistPushService error, msg: " + token);
            }
        }
    }
}
