using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using xc.protocol;
using xc.ui;
using Net;

namespace xc
{
    //军团管理器
    [wxb.Hotfix]
    public class SocietyManagerEx : xc.Singleton<SocietyManagerEx>
    {
        public class MemberInfo
        {
            public MemberInfo(uint id, string name)
            {
                Id = id;
                Name = name;
            }

            public uint Id { get; set; }
            public string Name { get; set; }
        }
        Dictionary<uint, MemberInfo> mMembers = new Dictionary<uint, MemberInfo>();


        private uint mID = 0;
        public uint ID
        {
            get
            {
                return mID;
            }
            set
            {
                mID = value;
                PKModeManagerEx.Instance.UpdatePKIcons();
            }
        }

        public uint Level { get; set; }

        public uint MemberCount { get; set; }

        public void Reset()
        {
            mMembers.Clear();
        }

        public MemberInfo GetMemberInfo(uint uuid)
        {
            if (mMembers.ContainsKey(uuid) == true)
            {
                return mMembers[uuid];
            }

            return null;
        }

        public void AddMember(uint uuid, string name)
        {
            if (mMembers.ContainsKey(uuid) == false)
            {
                MemberInfo memberInfo = new MemberInfo(uuid, name);
                mMembers.Add(uuid, memberInfo);
            }
        }

        public void RemoveMember(uint uuid)
        {
            if (mMembers.ContainsKey(uuid) == true)
            {
                mMembers.Remove(uuid);
            }
        }

        public bool IsMember(uint uuid)
        {
            if (mMembers.ContainsKey(uuid) == true)
            {
                return true;
            }

            return false;
        }

        public void ClearMember()
        {
            mMembers.Clear();
        }

        public int GetMemberCount()
        {
            return mMembers.Count;
        }

        public bool HaveTeam()
        {
            if (mMembers.Count == 0)
            {
                return false;
            }

            return true;
        }

        public Actor GetMemberActor(uint uuid)
        {
            return ActorManager.Instance.GetPlayer(uuid);
        }

        public bool IsAllInAOIRange()
        {
            foreach (var item in mMembers)
            {
                if (GetMemberActor(item.Value.Id) == null)
                {
                    return false;
                }
            }

            return true;
        }

        public List<MemberInfo> GetNotInAOIRangeMembers()
        {
            List<MemberInfo> result = new List<MemberInfo>();

            foreach (var item in mMembers)
            {
                if (GetMemberActor(item.Value.Id) == null)
                {
                    result.Add(item.Value);
                }
            }

            return result;
        }
    }
}

