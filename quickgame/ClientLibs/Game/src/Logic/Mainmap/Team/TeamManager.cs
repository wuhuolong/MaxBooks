//------------------------------------------------------------------------------
// Desc   :  组队管理类
// Author :  ljy
// Date   :  2017.7.10
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class TeamManager : xc.Singleton<TeamManager>
    {
        /// <summary>
        /// 队伍id
        /// </summary>
        public uint TeamId { set; get; }

        /// <summary>
        /// 队长id
        /// </summary>
        public uint LeaderId { get; set; }

        /// <summary>
        /// 队员信息
        /// </summary>
        public List<PkgTeamMember> TeamMembers { get; set; }

        /// <summary>
        /// 申请列表信息
        /// </summary>
        public List<PkgTeamUserIntro> ApplyList { get; set; }

        /// <summary>
        /// 是否在自动匹配队伍
        /// </summary>
        bool mIsAutoMatchingTeam;
        public bool IsAutoMatchingTeam
        {
            get
            {
                return mIsAutoMatchingTeam;
            }
            set
            {
                if (mIsAutoMatchingTeam != value)
                {
                    mIsAutoMatchingTeam = value;
                    if (mIsAutoMatchingTeam == false)
                    {
                        UINotice.Instance.ShowMessage(DBConstText.GetText("TEAM_STOP_AUTO_MATCHING"));
                    }
                    else
                    {
                        UINotice.Instance.ShowMessage(DBConstText.GetText("TEAM_START_AUTO_MATCHING_TEAM"));
                    }

                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_AUTO_MATCHING_STATE_CHANGED, null);
                }
            }
        }
        /// <summary>
        /// 自动匹配队伍的时间间隔
        /// </summary>
        const float mAutoMatchTeamInterval = 3f;
        float mAutoMatchTeamElapsedTime = 0f;

        /// <summary>
        /// 是否在自动匹配玩家
        /// </summary>
        bool mIsAutoMatchingPlayer;
        public bool IsAutoMatchingPlayer
        {
            get
            {
                return mIsAutoMatchingPlayer;
            }
            set
            {
                mIsAutoMatchingPlayer = value;
                if (mIsAutoMatchingPlayer == false)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("TEAM_STOP_AUTO_MATCHING"));
                }
                else
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("TEAM_START_AUTO_MATCHING_PLAYER"));
                }

                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_AUTO_MATCHING_STATE_CHANGED, null);
            }
        }

        /// <summary>
        /// 是否自动接收入队申请
        /// </summary>
        public bool IsAutoAgree { get; set; }

        /// <summary>
        /// 被邀请信息
        /// </summary>
        public List<S2CTeamBeInvite> BeInvitedInfos { get; set; }

        /// <summary>
        /// 是否自动拒绝邀请
        /// </summary>
        public bool IsAutoRejectInvite { get; set; }

        /// <summary>
        /// 邀请CD
        /// </summary>
        Dictionary<uint, Utils.Timer> mInviteInfoCDs;
        Utils.Timer mInviteAllCD;
        const uint mInviteInterval = 30;

        /// <summary>
        /// 组队目标
        /// </summary>
        public uint TargetType { get; set; }
        public uint TargetId { get; set; }
        public uint TargetMinLevel { get; set; }
        public uint TargetMaxLevel { get; set; }

        /// <summary>
        /// 组队平台选中的组队目标类型
        /// </summary>
        public uint PlatformSelectedTargetType { get; set; }

        /// <summary>
        /// 组队平台选中的组队目标
        /// </summary>
        public uint PlatformSelectedTargetId { get; set; }

        /// <summary>
        /// 正在匹配队伍的目标id
        /// </summary>
        public uint MatchingTeamTargetId { get; set; }

        public TeamManager()
        {
            BeInvitedInfos = new List<S2CTeamBeInvite>();
            BeInvitedInfos.Clear();
        }

        public void Reset(bool ignore_reconnect)
        {
            TeamId = 0;
            LeaderId = 0;
            TeamMembers = new List<PkgTeamMember>();
            TeamMembers.Clear();
            ApplyList = new List<PkgTeamUserIntro>();
            ApplyList.Clear();
            TargetType = 1;
            TargetId = 0;
            TargetMinLevel = 0;
            TargetMaxLevel = 0;
            PlatformSelectedTargetType = 0;
            PlatformSelectedTargetId = 0;
            MatchingTeamTargetId = 0;
            mIsAutoMatchingTeam = false;
            mIsAutoMatchingPlayer = false;
            mAutoMatchTeamElapsedTime = 0f;
            mInviteInfoCDs = new Dictionary<uint, Utils.Timer>();
            mInviteInfoCDs.Clear();
            if (mInviteAllCD != null)
            {
                mInviteAllCD.Destroy();
                mInviteAllCD = null;
            }

            if (ignore_reconnect == false)
            {
                BeInvitedInfos.Clear();
            }
        }

        public void RegisterAllMessage()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_LIST, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_APPLY, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_APPLY_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_ADD_MEMBER, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_LEAVE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_BE_REJECTED, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_PROMOTE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_INVITE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_BE_INVITE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_HANDLE_INVITE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_INTRO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_TARGET, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_MEMBER_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_SET_MATCH, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_NEARBY_USER, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_ERROR, HandleServerData);
        }

        public void Update()
        {
            if (IsAutoMatchingTeam == true)
            {
                mAutoMatchTeamElapsedTime += Time.deltaTime;
                if (mAutoMatchTeamElapsedTime >= mAutoMatchTeamInterval)
                {
                    MatchTeamImpl();
                    mAutoMatchTeamElapsedTime = 0f;
                }
            }
        }

        public void BuildTeam()
        {
            C2STeamBuild data = new C2STeamBuild();
            data.target_id = TargetId;
            data.min_lv = TargetMinLevel;
            data.max_lv = TargetMaxLevel;

            NetClient.BaseClient.SendData<C2STeamBuild>(NetMsg.MSG_TEAM_BUILD, data);
        }

        public bool Apply(uint teamId)
        {
            if (HaveTeam == true)
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("TEAM_HAVE_TEAM_CAN_NOT_APPLY"));
                return false;
            }

            C2STeamApply data = new C2STeamApply();
            data.team_id = teamId;

            NetClient.BaseClient.SendData<C2STeamApply>(NetMsg.MSG_TEAM_APPLY, data);

            return true;
        }

        public void HandleApply(uint choice, List<uint> uuids)
        {
            if (uuids == null || uuids.Count == 0)
            {
                return;
            }

            if (choice == 1)
            {
                if (IsFull == true || IsReachTargetMemberLimit == true)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("TEAM_IS_FULL"));
                    return;
                }
            }

            C2STeamHandleApply data = new C2STeamHandleApply();
            data.choice = choice;
            data.uuids.AddRange(uuids);

            NetClient.BaseClient.SendData<C2STeamHandleApply>(NetMsg.MSG_TEAM_HANDLE_APPLY, data);

            foreach (uint uuid in uuids)
            {
                RemoveApplyInfo(uuid);
            }
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_APPLY_INFO_CHANGED, null);
        }

        public void LeaveTeamImmediate()
        {
            C2STeamLeave data = new C2STeamLeave();

            NetClient.BaseClient.SendData<C2STeamLeave>(NetMsg.MSG_TEAM_LEAVE, data);
        }

        public void LeaveTeam()
        {
            xc.ui.UIWidgetHelp.Instance.ShowNoticeDlg(ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel, DBConstText.GetText("TEAM_LEAVE_CONFIRM"),
                (param) => { LeaveTeamImmediate(); }, null);
            //LeaveTeamImmediate();
        }

        public void Expel(uint uuid)
        {
            C2STeamExpel data = new C2STeamExpel();
            data.uuid = uuid;

            NetClient.BaseClient.SendData<C2STeamExpel>(NetMsg.MSG_TEAM_EXPEL, data);
        }

        public void Promote(uint uuid)
        {
            C2STeamPromote data = new C2STeamPromote();
            data.uuid = uuid;

            NetClient.BaseClient.SendData<C2STeamPromote>(NetMsg.MSG_TEAM_PROMOTE, data);
        }

        public bool Invite(uint uuid)
        {
            uint cd = GetInviteCD(uuid);
            if (cd == 0)
            {
                C2STeamInvite data = new C2STeamInvite();
                data.uuids.Add(uuid);

                NetClient.BaseClient.SendData<C2STeamInvite>(NetMsg.MSG_TEAM_INVITE, data);

                return true;
            }
            else
            {
                UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("TEAM_INVITE_IN_CD"), cd));

                return false;
            }
        }

        public void Invite(List<uint> uuids)
        {
            if (mInviteAllCD == null)
            {
                C2STeamInvite data = new C2STeamInvite();
                foreach (uint uuid in uuids)
                {
                    if (GetInviteCD(uuid) == 0)
                    {
                        data.uuids.Add(uuid);
                    }
                }

                NetClient.BaseClient.SendData<C2STeamInvite>(NetMsg.MSG_TEAM_INVITE, data);

                mInviteAllCD = new Utils.Timer((int)mInviteInterval * 1000, false, 1000,
                    (dt) =>
                    {
                        if (dt <= 0f)
                        {
                            mInviteAllCD.Destroy();
                            mInviteAllCD = null;
                        }

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_INVITE_ALL_CD_CHANGED, null);
                    });

                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_INVITE_ALL_CD_CHANGED, null);
            }
            else
            {
                UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("TEAM_INVITE_IN_CD"), (int)(mInviteAllCD.Remain / 1000f)));
            }
        }

        void AddInviteCD(uint uuid)
        {
            if (mInviteInfoCDs.ContainsKey(uuid) == false)
            {
                Utils.Timer timer = new Utils.Timer((int)mInviteInterval * 1000, false, mInviteInterval * 1000,
                    (dt) =>
                    {
                        if (dt <= 0f)
                        {
                            mInviteInfoCDs.Remove(uuid);
                        }
                    });

                mInviteInfoCDs.Add(uuid, timer);
            }
            else
            {
                Utils.Timer timer = mInviteInfoCDs[uuid];
                timer.Reset((int)mInviteInterval * 1000);
            }
        }

        public uint GetInviteCD(uint uuid)
        {
            if (mInviteInfoCDs.ContainsKey(uuid) == false)
            {
                return 0;
            }
            else
            {
                int cd = (int)(mInviteInfoCDs[uuid].Remain / 1000f) - 1;
                if (cd < 0)
                {
                    cd = 0;
                }
                return (uint)cd;
            }
        }

        public uint GetInviteAllCD()
        {
            if (mInviteAllCD == null)
            {
                return 0;
            }

            int cd = (int)(mInviteAllCD.Remain / 1000f) - 1;
            if (cd < 0)
            {
                cd = 0;
            }
            return (uint)cd;
        }

        /// <summary>
        /// 处理组队邀请
        /// </summary>
        /// <param name="choice"> 1同意，2、拒绝</param>
        /// <param name="teamId">同意或拒绝的队伍id</param>
        /// <param name="type">客户端自定义，0：手动处理，1：本次登录不接受邀请的处理</param>
        public void HandleInvite(uint choice, uint teamId, uint type = 0)
        {
            C2STeamHandleInvite data = new C2STeamHandleInvite();
            data.choice = choice;
            data.team_id = teamId;
            data.type = type;

            NetClient.BaseClient.SendData<C2STeamHandleInvite>(NetMsg.MSG_TEAM_HANDLE_INVITE, data);

            if (choice == 1)
            {
                //RemoveAllBeInvitedInfos();
                RemoveBeInvitedInfo(teamId);
            }
            else
            {
                RemoveBeInvitedInfo(teamId);
            }
        }

        /// <summary>
        /// 处理所有组队邀请
        /// </summary>
        /// <param name="choice">1同意，2、拒绝</param>
        /// <param name="type">客户端自定义，0：手动处理，1：本次登录不接受邀请的处理</param>
        public void HandleAllInvites(uint choice, uint type = 0)
        {
            foreach (S2CTeamBeInvite beInvite in BeInvitedInfos)
            {
                C2STeamHandleInvite data = new C2STeamHandleInvite();
                data.choice = choice;
                data.team_id = beInvite.team_id;
                data.type = type;

                NetClient.BaseClient.SendData<C2STeamHandleInvite>(NetMsg.MSG_TEAM_HANDLE_INVITE, data);
            }

            ClearBeInvitedInfos();
        }

        public void Intro(uint teamId)
        {
            C2STeamIntro data = new C2STeamIntro();
            data.team_id = teamId;

            NetClient.BaseClient.SendData<C2STeamIntro>(NetMsg.MSG_TEAM_INTRO, data);
        }

        public void SetTarget(uint targetId, uint minLv, uint maxLv)
        {
            C2STeamTarget data = new C2STeamTarget();
            data.target_id = targetId;
            data.min_lv = minLv;
            data.max_lv = maxLv;

            NetClient.BaseClient.SendData<C2STeamTarget>(NetMsg.MSG_TEAM_TARGET, data);

            if (targetId == 0 && IsAutoMatchingPlayer)
            {
                MatchPlayer(false);
            }
        }

        /// <summary>
        /// 队长自动匹配玩家
        /// </summary>
        public void MatchPlayer(bool isMatch)
        {
            C2STeamSetMatch data = new C2STeamSetMatch();
            if (isMatch == false)
            {
                data.auto_match = 0;
            }
            else
            {
                data.auto_match = 1;
            }

            NetClient.BaseClient.SendData<C2STeamSetMatch>(NetMsg.MSG_TEAM_SET_MATCH, data);
        }

        /// <summary>
        /// 玩家自动匹配队伍
        /// </summary>
        public void MatchTeam(bool isMatch)
        {
            IsAutoMatchingTeam = isMatch;

            if (IsAutoMatchingTeam == true)
            {
                MatchTeamImpl();
            }
        }

        void MatchTeamImpl()
        {
            if (PlatformSelectedTargetId == 0)
            {
                GameDebug.LogError("Match team error!!! target id is zero!!!");
                return;
            }

            C2STeamAutoMatch data = new C2STeamAutoMatch();
            data.target_id = PlatformSelectedTargetId;

            NetClient.BaseClient.SendData<C2STeamAutoMatch>(NetMsg.MSG_TEAM_AUTO_MATCH, data);

            MatchingTeamTargetId = PlatformSelectedTargetId;
        }

        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_TEAM_INFO:
                    {
                        S2CTeamInfo pack = S2CPackBase.DeserializePack<S2CTeamInfo>(data);

                        // 如果是新创建的队伍
                        if (TeamId == 0 && pack.team_info.team_id > 0)
                        {
                            RemoveAllBeInvitedInfos();
                        }

                        TeamId = pack.team_info.team_id;
                        LeaderId = pack.team_info.leader_id;
                        TargetId = pack.team_info.target_id;
                        TargetMinLevel = pack.team_info.min_lv;
                        TargetMaxLevel = pack.team_info.max_lv;
                        TeamMembers = pack.team_info.members;
                        if (pack.team_info.auto_match == 0)
                        {
                            mIsAutoMatchingPlayer = false;
                        }
                        else
                        {
                            mIsAutoMatchingPlayer = true;
                        }
                        mIsAutoMatchingTeam = false;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, new CEventBaseArgs(pack.auto_build));
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_AUTO_MATCHING_STATE_CHANGED, null);

                        UpdateMembersTeamIcon(null);

                        break;
                    }
                case NetMsg.MSG_TEAM_LIST:
                    {
                        S2CTeamList pack = S2CPackBase.DeserializePack<S2CTeamList>(data);

                        break;
                    }
                case NetMsg.MSG_TEAM_APPLY:
                    {
                        S2CTeamApply pack = S2CPackBase.DeserializePack<S2CTeamApply>(data);

                        if (pack.result == 1)
                        {
                            UINotice.Instance.ShowMessage(DBConstText.GetText("TEAM_APPLY_SUCCESS"));
                        }
                        else
                        {
                            UINotice.Instance.ShowMessage(DBConstText.GetText("TEAM_APPLY_FAIL"));
                        }

                        break;
                    }
                case NetMsg.MSG_TEAM_APPLY_INFO:
                    {
                        S2CTeamApplyInfo pack = S2CPackBase.DeserializePack<S2CTeamApplyInfo>(data);

                        foreach (PkgTeamUserIntro applyInfo in pack.apply_list)
                        {
                            if (IsInApllyList(applyInfo.brief.uuid) == false)
                            {
                                ApplyList.Add(applyInfo);
                            }
                        }

                        if (IsAutoAgree == true && SceneHelp.Instance.IsInWildInstance() == true)
                        {
                            List<uint> uuids = new List<uint>();
                            uuids.Clear();
                            foreach (PkgTeamUserIntro apply in ApplyList)
                            {
                                uuids.Add(apply.brief.uuid);
                            }
                            HandleApply(1, uuids);
                        }
                        else
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_APPLY_INFO_CHANGED, null);
                        }

                        break;
                    }
                case NetMsg.MSG_TEAM_ADD_MEMBER:
                    {
                        S2CTeamAddMember pack = S2CPackBase.DeserializePack<S2CTeamAddMember>(data);

                        if (HaveMember(pack.member.brief.uuid) == false)
                        {
                            TeamMembers.Add(pack.member);

                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, null);

                            // 在申请列表里面删除该玩家
                            RemoveApplyInfo(pack.member.brief.uuid);
                        }

                        break;
                    }
                case NetMsg.MSG_TEAM_LEAVE:
                    {
                        S2CTeamLeave pack = S2CPackBase.DeserializePack<S2CTeamLeave>(data);

                        if (pack.uuid == Game.Instance.LocalPlayerID.obj_idx)
                        {
                            if (pack.reason == 1)
                            {
                                ApplyList.Clear();
                                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_APPLY_INFO_CHANGED, null);

                                if (TeamMembers.Count == 1)
                                {
                                    if (HaveTeam == true)
                                    {
                                        UINotice.Instance.ShowMessage(DBConstText.GetText("TEAM_DISMISS_TIPS"));
                                    }
                                }
                                else
                                {
                                    if (HaveTeam == true)
                                    {
                                        string msg = DBConstText.GetText("TEAM_ME_LEAVE_TIPS");
                                        //ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_SYSTEM_MESSAGE_SHOW, new CEventBaseArgs(msg));
                                        UINotice.Instance.ShowMessage(msg);
                                    }
                                }
                            }
                            else
                            {
                                if (HaveTeam == true)
                                {
                                    string msg = DBConstText.GetText("TEAM_ME_EXPEL_TIPS");
                                    //ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_SYSTEM_MESSAGE_SHOW, new CEventBaseArgs(msg));
                                    UINotice.Instance.ShowMessage(msg);
                                }
                            }

                            List<PkgTeamMember> tempMembers = new List<PkgTeamMember>(TeamMembers);

                            TeamId = 0;
                            LeaderId = 0;
                            TargetType = 1;
                            TargetId = 0;
                            TargetMinLevel = 0;
                            TargetMaxLevel = 0;
                            TeamMembers.Clear();

                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, null);

                            UpdateMembersTeamIcon(tempMembers);
                        }
                        else
                        {
                            PkgTeamMember leaveMember = GetMember(pack.uuid);
                            if (leaveMember != null)
                            {
                                TeamMembers.Remove(leaveMember);

                                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, null);

                                string msg = "";
                                if (pack.reason == 1)
                                {
                                    msg = string.Format(DBConstText.GetText("TEAM_LEAVE_TIPS"), System.Text.Encoding.UTF8.GetString(leaveMember.brief.name));
                                    UINotice.Instance.ShowMessage(msg);
                                }
                                else
                                {
                                    msg = string.Format(DBConstText.GetText("TEAM_EXPEL_TIPS"), System.Text.Encoding.UTF8.GetString(leaveMember.brief.name));
                                    UINotice.Instance.ShowMessage(msg);
                                }
                                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_SYSTEM_MESSAGE_SHOW, new CEventBaseArgs(msg));
                            }
                        }

                        if (IsAutoAgree == true && SceneHelp.Instance.IsInWildInstance() == true)
                        {
                            List<uint> uuids = new List<uint>();
                            uuids.Clear();
                            foreach (PkgTeamUserIntro apply in ApplyList)
                            {
                                uuids.Add(apply.brief.uuid);
                            }
                            HandleApply(1, uuids);
                        }

                        break;
                    }
                case NetMsg.MSG_TEAM_BE_REJECTED:
                    {
                        S2CTeamBeRejected pack = S2CPackBase.DeserializePack<S2CTeamBeRejected>(data);

                        UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("TEAM_REJECT_TIPS"), System.Text.Encoding.UTF8.GetString(pack.leader_name)));

                        break;
                    }
                case NetMsg.MSG_TEAM_PROMOTE:
                    {
                        S2CTeamPromote pack = S2CPackBase.DeserializePack<S2CTeamPromote>(data);

                        // 没有队伍的话，LeaderId要赋值为0
                        if (HaveTeam == true)
                        {
                            LeaderId = pack.uuid;
                        }
                        else
                        {
                            LeaderId = 0;
                        }

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, null);

                        UpdateMembersTeamIcon(null);

                        // 如果不是转让给自己，则清空申请列表
                        if (pack.uuid != Game.GetInstance().LocalPlayerID.obj_idx)
                        {
                            ApplyList.Clear();
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_APPLY_INFO_CHANGED, null);

                            PkgTeamMember member = GetMember(pack.uuid);
                            if (member != null)
                            {
                                string msg = string.Format(DBConstText.GetText("TEAM_PROMOTE_TIPS"), System.Text.Encoding.UTF8.GetString(member.brief.name));
                                UINotice.Instance.ShowMessage(msg);
                                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_SYSTEM_MESSAGE_SHOW, new CEventBaseArgs(msg));
                            }
                        }
                        else
                        {
                            string msg = DBConstText.GetText("TEAM_ME_PROMOTE_TIPS");
                            UINotice.Instance.ShowMessage(msg);
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_SYSTEM_MESSAGE_SHOW, new CEventBaseArgs(msg));

                            mIsAutoMatchingPlayer = false;

                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_AUTO_MATCHING_STATE_CHANGED, null);
                        }

                        break;
                    }
                case NetMsg.MSG_TEAM_INVITE:
                    {
                        S2CTeamInvite pack = S2CPackBase.DeserializePack<S2CTeamInvite>(data);

                        if (pack.type > 0)
                        {
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("TEAM_HAVE_INVITED"), System.Text.Encoding.UTF8.GetString(pack.name)));
                        }

                        AddInviteCD(pack.uuid);

                        break;
                    }
                case NetMsg.MSG_TEAM_BE_INVITE:
                    {
                        S2CTeamBeInvite pack = S2CPackBase.DeserializePack<S2CTeamBeInvite>(data);

                        if (IsAutoRejectInvite == true)
                        {
                            HandleInvite(2, pack.team_id, 1);
                            break;
                        }

                        bool existing = false;
                        foreach (S2CTeamBeInvite teamBeInvite in BeInvitedInfos)
                        {
                            if (teamBeInvite.team_id == pack.team_id)
                            {
                                existing = true;
                            }
                        }
                        if (existing == false)
                        {
                            BeInvitedInfos.Add(pack);
                        }

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_BE_INVITED, null);

                        break;
                    }
                case NetMsg.MSG_TEAM_HANDLE_INVITE:
                    {
                        S2CTeamHandleInvite pack = S2CPackBase.DeserializePack<S2CTeamHandleInvite>(data);

                        if (pack.choice == 2)
                        {
                            // 对方已设置本次登录不再接收邀请
                            if (pack.type == 1)
                            {
                                UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("TEAM_AUTO_REJECT_TIPS"), System.Text.Encoding.UTF8.GetString(pack.name)));
                            }
                            else
                            {
                                UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("TEAM_REJECT_INVITE"), System.Text.Encoding.UTF8.GetString(pack.name)));
                            }
                        }

                        break;
                    }
                case NetMsg.MSG_TEAM_INTRO:
                    {
                        S2CTeamIntro pack = S2CPackBase.DeserializePack<S2CTeamIntro>(data);

                        break;
                    }
                case NetMsg.MSG_TEAM_TARGET:
                    {
                        S2CTeamTarget pack = S2CPackBase.DeserializePack<S2CTeamTarget>(data);

                        TargetId = pack.target_id;
                        TargetMinLevel = pack.min_lv;
                        TargetMaxLevel = pack.max_lv;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_TARGET_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_TEAM_MEMBER_INFO:
                    {
                        S2CTeamMemberInfo pack = S2CPackBase.DeserializePack<S2CTeamMemberInfo>(data);

                        PkgTeamMember member = GetMember(pack.uuid);
                        if (member != null)
                        {
                            member.dungeon_id = pack.dungeon_id;
                            member.brief = pack.info;
                        }

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_TEAM_SET_MATCH:
                    {
                        S2CTeamSetMatch pack = S2CPackBase.DeserializePack<S2CTeamSetMatch>(data);

                        if (pack.auto_match == 0)
                        {
                            IsAutoMatchingPlayer = false;
                        }
                        else
                        {
                            IsAutoMatchingPlayer = true;
                        }

                        break;
                    }
                case NetMsg.MSG_TEAM_NEARBY_USER:
                    {
                        S2CTeamNearbyUser pack = S2CPackBase.DeserializePack<S2CTeamNearbyUser>(data);

                        break;
                    }
                case NetMsg.MSG_TEAM_ERROR:
                    {
                        S2CTeamError pack = S2CPackBase.DeserializePack<S2CTeamError>(data);

                        PkgTeamMember member = GetMember(pack.uuid);
                        if (member != null)
                        {
                            UINotice.Instance.ShowMessage(DBConstText.GetText("INSTANCE_CAN_NOT_START_INSTANCE") + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_83") + GameConst.COLOR_DARK_RED + System.Text.Encoding.UTF8.GetString(member.brief.name) + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_42") + DBErrorCode.GetErrorString(pack.err_code));
                        }

                        ui.ugui.UIManager.Instance.ShowWaitScreen(false);

                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// 是否有队伍
        /// </summary>
        public bool HaveTeam
        {
            get
            {
                return TeamId > 0;
            }
        }

        /// <summary>
        /// 是否存在某个id的队员
        /// </summary>
        public bool HaveMember(uint uuid)
        {
            foreach (PkgTeamMember member in TeamMembers)
            {
                if (member.brief.uuid == uuid)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取队员信息
        /// </summary>
        public PkgTeamMember GetMember(uint uuid)
        {
            foreach (PkgTeamMember member in TeamMembers)
            {
                if (member.brief.uuid == uuid)
                {
                    return member;
                }
            }

            return null;
        }

        public int MemberCount
        {
            get
            {
                return TeamMembers.Count;
            }
        }

        /// <summary>
        /// 获取队长
        /// </summary>
        public PkgTeamMember Leader
        {
            get
            {
                foreach (PkgTeamMember member in TeamMembers)
                {
                    if (member.brief.uuid == LeaderId)
                    {
                        return member;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 队伍是否满员
        /// </summary>
        public bool IsFull
        {
            get
            {
                return TeamMembers.Count >= GameConstHelper.GetUint("GAME_TEAM_MEMBER_LIMIT");
            }
        }

        /// <summary>
        /// 队伍人数是否达到组队目标人数上限
        /// </summary>
        public bool IsReachTargetMemberLimit
        {
            get
            {
                return TeamMembers.Count >= TeamHelper.GetTeamTargetMemberLimit();
            }
        }

        /// <summary>
        /// 是否队员
        /// </summary>
        public bool IsMember(uint uuid)
        {
            foreach (PkgTeamMember member in TeamMembers)
            {
                if (member.brief.uuid == uuid)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 自己是否是队长
        /// </summary>
        public bool MeIsLeader
        {
            get
            {
                return LeaderId == Game.Instance.LocalPlayerID.obj_idx;
            }
        }

        /// <summary>
        /// 是否队长
        /// </summary>
        public bool IsLeader(uint uuid)
        {
            return LeaderId == uuid;
        }

        /// <summary>
        /// 除了队长以外的队员
        /// </summary>
        public List<PkgTeamMember> MembersExceptLeader
        {
            get
            {
                List<PkgTeamMember> membersExceptLeader = new List<PkgTeamMember>();
                membersExceptLeader.Clear();

                foreach (PkgTeamMember member in TeamMembers)
                {
                    if (member.brief.uuid != LeaderId)
                    {
                        membersExceptLeader.Add(member);
                    }
                }

                return membersExceptLeader;
            }
        }

        public void RemoveApplyInfo(uint uuid)
        {
            PkgTeamUserIntro removeApplyInfo = null;
            foreach (PkgTeamUserIntro applyInfo in ApplyList)
            {
                if (applyInfo.brief.uuid == uuid)
                {
                    removeApplyInfo = applyInfo;
                }
            }
            if (removeApplyInfo != null)
            {
                ApplyList.Remove(removeApplyInfo);

                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_APPLY_INFO_CHANGED, null);
            }
        }

        public bool IsInApllyList(uint uuid)
        {
            foreach (PkgTeamUserIntro applyInfo in ApplyList)
            {
                if (applyInfo.brief.uuid == uuid)
                {
                    return true;
                }
            }

            return false;
        }

        public void ClearBeInvitedInfos()
        {
            BeInvitedInfos.Clear();

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_BE_INVITED, null);
        }

        public void RemoveBeInvitedInfo(uint teamId)
        {
            S2CTeamBeInvite removeBeInvitedInfo = null;
            foreach (S2CTeamBeInvite beInvitedInfo in BeInvitedInfos)
            {
                if (beInvitedInfo.team_id == teamId)
                {
                    removeBeInvitedInfo = beInvitedInfo;
                }
            }
            if (removeBeInvitedInfo != null)
            {
                BeInvitedInfos.Remove(removeBeInvitedInfo);

                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_BE_INVITED, null);
            }
        }

        public void RemoveAllBeInvitedInfos()
        {
            BeInvitedInfos.Clear();

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TEAM_BE_INVITED, null);
        }

        void UpdateMembersTeamIcon(List<PkgTeamMember> members)
        {
            if (HaveTeam == false)
            {
                Actor localPlayer = Game.GetInstance().GetLocalPlayer();
                if (localPlayer != null)
                {
                    localPlayer.SetHeadIcons(Actor.EHeadIcon.TEAM);
                }
            }

            if (members == null)
            {
                members = TeamMembers;
            }

            foreach (PkgTeamMember member in members)
            {
                Actor memberActor = ActorManager.Instance.GetPlayer(member.brief.uuid);
                if (memberActor != null)
                {
                    memberActor.SetHeadIcons(Actor.EHeadIcon.TEAM);
                }
            }
        }
    }
}
