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
    [wxb.Hotfix]
    public class MailManager2 :xc.Singleton<MailManager2>
    {
        public Dictionary<ulong, MailInfo> mMails;

        public List<MailInfo> GetMailsBySorted()
        {
            List<MailInfo> mailList = new List<MailInfo>();
            foreach(var item in mMails)
            {
                mailList.Add(item.Value);
            }
            mailList.Sort(CompareMailInfo);

            return  mailList ;
        }
        public List<MailInfo> GetMails()
        {
            List<MailInfo> mailList = new List<MailInfo>();
            foreach (var item in mMails)
            {
                mailList.Add(item.Value);
            }

            return mailList;
        }
        public void SetMailNotNew(ulong mailId)
        {
            MailInfo mail = null;
            if(mMails.TryGetValue(mailId , out mail))
                mail.IsNew = false;
        }
        int CompareMailInfo(MailInfo info1, MailInfo info2)
        {
            uint state1 = info1.netEmailInfo.state;
            uint state2 = info2.netEmailInfo.state;
            if (info1.IsHaveAccessoriesToGet() == true  && info2.IsHaveAccessoriesToGet() == false)
            {
                return -1;
            }
            else if(info2.IsHaveAccessoriesToGet() == true  && info1.IsHaveAccessoriesToGet() == false)
            {
                return 1;
            }
            else
            {
                if (state1 == (uint)1 && state2 > (uint)1)
                {
                    return -1;
                }
                else if (state1 > (uint)1 && state2 == (uint)1)
                {
                    return 1;
                }
                else
                {
                    if (info1.netEmailInfo.createtime > info2.netEmailInfo.createtime)
                    {
                        return -1;
                    }
                    else if (info1.netEmailInfo.createtime < info2.netEmailInfo.createtime)
                    {
                        return 1;
                    }
                    return 0;
                }
            }
        }
        
        public MailManager2()
        {
            mMails = new Dictionary<ulong, MailInfo>();
            mMails.Clear();

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SYS_CONFIG_INIT, OnSysConfigInit);
        }
        
        public void Reset()
        {
            mMails.Clear();
        }

        void OnSysConfigInit(CEventBaseArgs args)
        {
            UpdateRedPoint();
        }

        public int GetMailsCount()
        {
            return mMails.Count;
        }
        public void ChangeMailState(uint state, ulong mailId )
        {
            MailInfo info = null;
            
            mMails.TryGetValue(mailId, out info);
            if (info != null)
            {
                info.netEmailInfo.state = state;
            }
            
        }
        public MailInfo GetMailByIndex(int index)
        {
            if(mMails.Count <= index)
            {
                return null;
            }
            
            int i = 0;
            foreach(var itr in mMails)
            {
                if(i == index)
                {
                    return itr.Value;
                }
                
                ++i;
            }
            
            return null;
        }
        
        public void ShowAttachmentsTipsDialog(string tips)
        {
            if (SceneHelp.Instance.IsInInstance/* || InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_MULTI*/)
            {
                UINotice.Instance.ShowMessage(tips);
                return;
            }

            xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate confirmDelegate = (param) =>
            {
                //RouterManager.Instance.GoToMailWnd();
            };
            
            UIWidgetHelp.Instance.ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.SH_OKBtn, tips, confirmDelegate, null);
        }
        
        public void Delete(ulong mailId)
        {
            MailInfo willDeleteMail = GetMail(mailId);
            
            if(willDeleteMail == null)
            {
                return;
            }
            
            if(willDeleteMail.IsHaveAccessories() && willDeleteMail.IsGet == false)
            {
                //ShowAttachmentsTipsDialog(DBConstText.GetText("MAIL_ATTACHMENTS_DELETE"));
            }
            
            if(mMails.ContainsKey(mailId))
            {
                mMails.Remove(mailId);
            }
        }
        
        public MailInfo GetMail(ulong mailId)
        {
            MailInfo info = null;
            
            mMails.TryGetValue(mailId, out info);
            
            return info;
        }
        
        public int GetUnReadMailCount()
        {
            GameDebug.Log("getUnReadMailCount");
            int count = 0; 
            foreach (var itr in mMails)
            {
                if(itr.Value.netEmailInfo.state == 1||(itr.Value.IsHaveAccessories() && itr.Value.netEmailInfo.state != 3)){
                    count ++ ; 
                }
            }
            return count;
            
        }
        public void ClearAllMail()
        {
            mMails.Clear();
        }
        
        public void AddMail(MailInfo info)
        {
            GameDebug.Log("AddMail");
            if(info == null)
            {
                return;
            }
            
            if(mMails.ContainsKey(info.MailId))
            {
                GameDebug.Log("MailManager2::AddMail error, the same mail key " + info.MailId +" is already exist.");
                GameDebug.Log("The added failed mail message is:" + info.Content);
                return;
            }
            
            mMails.Add(info.MailId, info);
//            xc.ClientEventManager<ClientEvent.FriendEvent>.Instance.FireEvent(ClientEvent.FriendEvent.RECEIVE_NEW_EMAIL_REQUEST, null);
            xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.NEW_MAIL_RECEIVED, null);
            
            GameDebug.Log("AddMail add successed");
        }
        
        public bool IsHaveWithAccessoriesMail()
        {
            foreach(var itr in mMails)
            {
                if(itr.Value.IsHaveAccessories() == true && itr.Value.IsGet == false)
                {
                    return true;
                }
            }
            
            return false;
        }

        public bool IsHaveCanDeleteMail()
        {
            foreach (var item in mMails)
            {
                if(item.Value.IsHaveAccessories())
                {
                    if(item.Value.IsGet)
                    {
                        return true;
                    }
                    
                }
                else
                {
                    if(item.Value.IsRead)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        public uint GetUnCollectMailCount()
        {
            if(mMails == null)
            {
                return 0;
            }
            
            uint result = 0;
            foreach (var item in mMails)
            {
                if(item.Value.IsHaveAccessories() && item.Value.IsGet == false)
                {
                    ++result;
                }
            }
            
            return result;
        }

        /// <summary>
        /// 是否有未读邮件
        /// </summary>
        /// <returns></returns>
        public bool HaveUnReadMails()
        {
            foreach (MailInfo mailInfo in mMails.Values)
            {
                if (mailInfo.IsRead == false && mailInfo.IsGet == false)
                {
                    return true;
                }
            }

            return false;
        }

        public void UpdateRedPoint()
        {
            bool haveRedPoint = false;

            if (SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_MAIL) == false)
            {
                haveRedPoint = false;
            }
            else
            {
                haveRedPoint = HaveUnReadMails();
            }

            if (haveRedPoint == true)
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NEW_REDPOINT_SHOW, new CEventBaseArgs("20202"));
            }
            else
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NEW_REDPOINT_DISAPPEAR, new CEventBaseArgs("20202"));
            }
        }
    }
}