/*----------------------------------------------------------------
// 文件名： GuildBossFireComponent.cs
// 文件功能描述： 帮派BOSS的火把逻辑组件
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;
using xc.ui;
using Net;
using xc.protocol;

[wxb.Hotfix]
public class GuildBossFireComponent : MonoBehaviour
{
    uint mId = 0;

    static List<PkgKvMin> sFiresState = null;

    GameObject mFireGameObject = null;
    Collider mCollider = null;
    Utils.Timer mTimer = null;

    void Awake()
    {
        if (mTimer != null)
        {
            mTimer.Destroy();
            mTimer = null;
        }
    }

    void Start()
    {
        Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_GUILD_BOSS_FIRE, HandleServerData);
    }

    void OnDestroy()
    {
        if (mTimer != null)
        {
            mTimer.Destroy();
            mTimer = null;
        }
        Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_DUNGEON_GUILD_BOSS_FIRE, HandleServerData);
    }

    public void Init(uint id)
    {
        mId = id;
    }

    void UpdateTimer(float remainTime)
    {
        if (remainTime <= 0)
        {
            if (mTimer != null)
            {
                mTimer.Destroy();
                mTimer = null;
            }
            ShowFire(false);
        }
    }

    void HandleServerData(ushort protocol, byte[] data)
    {
        switch (protocol)
        {
            case NetMsg.MSG_DUNGEON_GUILD_BOSS_FIRE:
                {
                    S2CDungeonGuildBossFire pack = S2CPackBase.DeserializePack<S2CDungeonGuildBossFire>(data);

                    sFiresState = pack.fires;
                    UpdateFireState();

                    break;
                }
            default:
                break;
        }
    }

    void UpdateFireState()
    {
        if (sFiresState != null)
        {
            foreach (PkgKvMin kv in sFiresState)
            {
                if (kv.k == mId)
                {
                    if (mTimer != null)
                    {
                        mTimer.Destroy();
                        mTimer = null;
                    }
                    uint second = 0;
                    if (Game.Instance.ServerTime <= kv.v)
                    {
                        second = kv.v - Game.Instance.ServerTime;
                    }
                    if (second > 0)
                    {
                        ShowFire(true);

                        mTimer = new Utils.Timer(second * 1000, false, 1000, UpdateTimer);
                    }
                    else
                    {
                        ShowFire(false);
                    }
                }
            }
        }
    }

    void ShowFire(bool isShow)
    {
        if (mFireGameObject != null)
        {
            mFireGameObject.SetActive(isShow);
        }
        if (mCollider != null)
        {
            mCollider.enabled = !isShow;
        }
    }

    public void OnResLoaded()
    {
        if (mFireGameObject == null)
        {
            if (this.gameObject.transform.childCount > 0)
            {
                mFireGameObject = this.gameObject.transform.GetChild(0).Find("Fire").gameObject;
            }
        }
        if (mCollider == null)
        {
            mCollider = this.GetComponentInChildren<Collider>();
        }

        UpdateFireState();
    }
}
