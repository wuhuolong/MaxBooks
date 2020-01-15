/*----------------------------------------------------------------
// 文件名： ActorModelCullManager.cs
// 文件功能描述： 角色同屏内自动加载卸载模型的管理类
//----------------------------------------------------------------*/
using Net;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using xc.protocol;
using xc.Maths;
using xc.ui;
using xc;

namespace xc
{
    public class ActorModelCullManager : xc.Singleton<ActorModelCullManager>
    {
        bool mIsEnabled = true;
        bool mIsEnableNpcModelCull = false;

        Rect mNeatRect;

        float mNpcMaxVisibleDistanceSquare = 2000f;

        public ActorModelCullManager()
        {
            mNpcMaxVisibleDistanceSquare = GameConstHelper.GetFloat("GAME_MWAR_NPC_MAX_VISIBLE_DISTANCE_SQUARE");
        }

        public void Reset()
        {
            mIsEnableNpcModelCull = DBSystemToggle.IsOpen("ENABLE_NPC_MODEL_CULL");
        }

        public void Enable(bool enable)
        {
            mIsEnabled = enable;
        }

        public void Update()
        {
            if (mIsEnabled == false)
                return;

            Camera cam  = Game.Instance.MainCamera;
            if (cam != null)
            {
                mNeatRect = cam.pixelRect;
                mNeatRect.xMin -= 65f;
                mNeatRect.xMax += 65f;
                mNeatRect.yMin -= 65f;
                mNeatRect.yMax += 65f;

                //目前只处理NPC
                if (mIsEnableNpcModelCull == true)
                {
                    using(var enumerator = NpcManager.Instance.AllNpc.GetEnumerator())
                    {
                        while(enumerator.MoveNext())
                        {
                            var actorMono = enumerator.Current.Value;
                            NpcPlayer npcPlayer = actorMono.BindActor as NpcPlayer;
                            if (npcPlayer != null)
                            {
                                Vector3 pos = cam.WorldToScreenPoint(actorMono.transform.position);
                                // 在屏幕范围内
                                if (mNeatRect.Contains(pos))
                                {
                                    // 离主角一定距离外需要隐藏，主角骑上坐骑的一瞬间位置是0，所以要排除主角位置是0的情况
                                    Actor localPlayer = Game.Instance.GetLocalPlayer();
                                    if (localPlayer != null && localPlayer.ActorTrans.position.Equals(Vector3.zero) == false && (npcPlayer.ActorTrans.position - localPlayer.ActorTrans.position).sqrMagnitude >= mNpcMaxVisibleDistanceSquare)
                                    {
                                        npcPlayer.mAvatarCtrl.UnloadModel();
                                        npcPlayer.GetBehavior<ShadowBehavior>().HideFakeShadow = true;
                                        npcPlayer.ShowTextName(false);
                                    }
                                    else
                                    {
                                        npcPlayer.mAvatarCtrl.ReloadModel();
                                        npcPlayer.GetBehavior<ShadowBehavior>().HideFakeShadow = false;
                                        npcPlayer.ShowTextName(true);
                                    }

                                }
                                else
                                {
                                    npcPlayer.mAvatarCtrl.UnloadModel();
                                    npcPlayer.ShowTextName(false);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
