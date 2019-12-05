using UnityEngine;
using System;
using xc.protocol;
using Net;
namespace xc.ui
{
    public class UIWildSwtichLineItem : MonoBehaviour
    {
        public UILabel labelName { get; set; }
        public UISprite spriteProgress { get; set; }
        public UITexture texHead { get; set; }
        public UILabel lableButton { get; set; }
        public GameObject goButton { get; set; }
        public GameObject goHead { get; set; }
        public uint mId;

        public void Set(uint id, uint num)
        {
            mId = id;
            DBInstance.InstanceInfo info = DBManager.Instance.GetDB<DBInstance>().GetInstanceInfo(id);
            if (id == GameConstHelper.GetUint("GAME_WILD_DUNGEON_PRIMARY_ID"))
            {
                labelName.text = info.mName + string.Format(DBConstText.GetText("PRIMARY_TITLE_SUFFIX"),GameConstHelper.GetUint("GAME_WILD_PRIMARY_BATTLE_POWER"));
            }
            else
            {
                labelName.text = info.mName;
            }
            UIWIldSwitchLine.SetAmount(spriteProgress, num);
            if(WildManager.Instance.mCurrentLineId == id)
            {
                goHead.SetActive(true);
                RoleHelp.GetIconName(Game.GetInstance().LocalPlayerTypeID , texHead);
                goButton.SetActive(false);
            }
            else
            {
                goHead.SetActive(false);
                goButton.SetActive(true);
                if(id == WildManager.Instance.mCurrentWaitingLineId)
                {
                    lableButton.text = xc.DBConstText.GetText("IN_QUEUE");
                }
                else
                {
                    lableButton.text = xc.DBConstText.GetText("GOTO");
                }
            }

        }

        public void OnGoto()
        {
            if (WildManager.Instance.mCurrentWaitingLineId == mId)
            {
                return;
            }
            //goto new
            //var pack = new C2SMwarWideStart();
            //pack.dungeon_id = mId;
            //NetClient.GetBaseClient().SendData<C2SMwarWideStart>(NetMsg.MSG_MWAR_WIDE_START, pack);
        }

        public void EnableGO(bool enable)
        {
            goButton.GetComponent<UIButton>().isEnabled = enable;
        }

    }
}

