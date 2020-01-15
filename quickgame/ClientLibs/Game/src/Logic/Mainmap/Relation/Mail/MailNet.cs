using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using xc.ui;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class MailNet : xc.Singleton<MailNet>
    {
        public void RegisterAllMessage()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_MAIL_LIST, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GET_MAIL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_READ_MAIL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NEW_MAIL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_MAIL_GET_ALL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_MAIL_DEL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_MAIL_DETAIL, HandleServerData);
        }

        public void MailDetail(ulong mailId)
        {
            C2SMailDetail pack = new C2SMailDetail();
            pack.mail_id = mailId;
            NetClient.GetBaseClient().SendData<C2SMailDetail>(NetMsg.MSG_MAIL_DETAIL, pack); 
        }

        public void ReadMail(ulong mailId)
        {
            C2SReadMail pack = new C2SReadMail();
            pack.mail_id = mailId;
            NetClient.GetBaseClient().SendData<C2SReadMail>(NetMsg.MSG_READ_MAIL, pack);
        }

        public void GetAllMails()
        {
            C2SMailList mailList = new C2SMailList();

            NetClient.GetBaseClient().SendData<C2SMailList>(NetMsg.MSG_MAIL_LIST, mailList);
        }

        //获取全部附件
        public void GetAllMailPlugs()
        {
            C2SMailGetAll getAllPlugs = new C2SMailGetAll();
            NetClient.GetBaseClient().SendData<C2SMailGetAll>(NetMsg.MSG_MAIL_GET_ALL, getAllPlugs);
        }

        //一键领取所有附件邮件
        public void GetMailPlugs(ulong mailId)
        {
            C2SGetMail mailGet = new C2SGetMail();
            mailGet.mail_id = mailId;
            NetClient.GetBaseClient().SendData<C2SGetMail>(NetMsg.MSG_GET_MAIL, mailGet);
        }

        public void DeleteMail(ulong mailId)
        {
            C2SMailDel pack = new C2SMailDel();
            pack.mail_id = mailId;

            NetClient.GetBaseClient().SendData<C2SMailDel>(NetMsg.MSG_MAIL_DEL, pack);
        }

        private void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                // 领取附件
                case NetMsg.MSG_GET_MAIL:
                {
                    S2CGetMail mailGet = S2CPackBase.DeserializePack<S2CGetMail>(data);
                    MailInfo mailInfo = MailManager2.Instance.GetMail(mailGet.mail_id);
                    if (mailInfo != null)
                    {
                        mailInfo.IsGet = true;
                        mailInfo.IsNew = false;
                    }
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAIL_GET, new CEventBaseArgs(mailGet.mail_id));
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_MAIN_MAP_CHECK_MARK, new CEventBaseArgs((int)SysMarkType.FriendsAndMail));
                    break;
                }
                // 全部的邮件列表
                case NetMsg.MSG_MAIL_LIST:
                {
                    S2CMailList mailList = S2CPackBase.DeserializePack<S2CMailList>(data);
                    if(mailList.mails == null)
                    {
                        return;
                    }

                    foreach(var netMail in mailList.mails)
                    {
                        MailInfo mailInfo = new MailInfo(netMail);
                        if(mailInfo.IsRead == false)
                            mailInfo.IsNew = true;
                        MailManager2.Instance.AddMail(mailInfo);
                    }
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAIL_UPDATE, new CEventBaseArgs());
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_MAIN_MAP_CHECK_MARK, new CEventBaseArgs((int)SysMarkType.FriendsAndMail));

                    MailManager2.Instance.UpdateRedPoint();
                    break;
                }
                // 新邮件推送列表
                case NetMsg.MSG_NEW_MAIL:
                {
                    S2CNewMail mailNew = S2CPackBase.DeserializePack<S2CNewMail>(data);
                    if(mailNew.mails == null)
                    {
                        return;
                    }

                    foreach(var netMail in mailNew.mails)
                    {
                        MailInfo mailInfo = new MailInfo(netMail);
                        mailInfo.IsNew = true;
                        MailManager2.Instance.AddMail(mailInfo);
                    }
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAIL_NEW, new CEventBaseArgs());
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_MAIN_MAP_CHECK_MARK, new CEventBaseArgs((int)SysMarkType.FriendsAndMail));

                    MailManager2.Instance.UpdateRedPoint();
                    break;
                }
                case NetMsg.MSG_READ_MAIL:
                {
                    S2CReadMail mailNew = S2CPackBase.DeserializePack<S2CReadMail>(data);
                    MailInfo mailInfo = MailManager2.Instance.GetMail(mailNew.mail_id);
                    if(mailInfo != null)
                    {
                        mailInfo.IsRead = true;
                        mailInfo.IsNew = false;
                    }
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAIL_READ, new CEventBaseArgs(mailNew.mail_id));
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_MAIN_MAP_CHECK_MARK, new CEventBaseArgs((int)SysMarkType.FriendsAndMail));

                    MailManager2.Instance.UpdateRedPoint();
                    break;
                }
                case NetMsg.MSG_MAIL_DEL:
                {
                    S2CMailDel allMails = S2CPackBase.DeserializePack<S2CMailDel>(data);
                    for(int i = 0 ; i < allMails.mail_ids.Count;i++)
                    {
                        MailManager2.Instance.Delete(allMails.mail_ids[i]);
                    }
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAIL_DEL, new CEventBaseArgs(allMails.mail_ids));
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_MAIN_MAP_CHECK_MARK, new CEventBaseArgs((int)SysMarkType.FriendsAndMail));

                    MailManager2.Instance.UpdateRedPoint();
                    break;
                }

                case NetMsg.MSG_MAIL_GET_ALL:
                {
                    S2CMailGetAll allMails = S2CPackBase.DeserializePack<S2CMailGetAll>(data);
                    for(int i = 0; i < allMails.mail_ids.Count; i++)
                    {
                        MailInfo mailInfo = MailManager2.Instance.GetMail(allMails.mail_ids[i]);
                        if(mailInfo != null)
                        {
                            mailInfo.IsGet = true;
                            mailInfo.IsNew = false;
                        }

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAIL_GET, new CEventBaseArgs(allMails.mail_ids[i]));
                    }
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_MAIN_MAP_CHECK_MARK, new CEventBaseArgs((int)SysMarkType.FriendsAndMail));

                    MailManager2.Instance.UpdateRedPoint();
                    break;
                }
                case NetMsg.MSG_MAIL_DETAIL:
                {
                    S2CMailDetail allMails = S2CPackBase.DeserializePack<S2CMailDetail>(data);
                    MailInfo mailInfo = MailManager2.Instance.GetMail(allMails.mail_id);
                    if(mailInfo == null)
                        return;
                    mailInfo.netEmailAttachs.Clear();
                    foreach(var attach in allMails.attachments)
                    {
                        mailInfo.netEmailAttachs.Add(attach);
                    }
                    mailInfo.LinkUrl = allMails.link_url == null ? string.Empty:System.Text.Encoding.UTF8.GetString(allMails.link_url);
                    mailInfo.LinkTitle = allMails.link_desc == null ? string.Empty:System.Text.Encoding.UTF8.GetString(allMails.link_desc);
                    mailInfo.Content = allMails.content == null ? string.Empty:System.Text.Encoding.UTF8.GetString(allMails.content);
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAIL_DETAIL, new CEventBaseArgs(mailInfo));
                    break;
                }
            }
        }
    }
}