using System;
using System.Collections;
using System.Collections.Generic;
using Utils;
using Net;
using UnityEngine;

namespace xc
{
    public enum PortalType : byte
    {
        PT_Normal = 0,
        PT_ChangeMap,
        PT_EnterInstance,
        PT_ResetLevel,
        PT_Cross,
    }

    public class CEventObjectArgs : CEventBaseArgs
    {
        object[] mArgs;
        public CEventObjectArgs(params object[] args)
        {
            mArgs = args;
        }

        public object[] Value
        {
            get
            {
                return mArgs;
            }
        }

    }

    public class CEventUintArgs : CEventBaseArgs
    {
        uint muiValue;
        public CEventUintArgs(uint uiValue)
        {
            muiValue = uiValue;
        }

        public uint Value
        {
            get
            {
                return muiValue;
            }
        }
    }

    public class CEventTransferArgs : CEventBaseArgs
    {
        PortalType type;
        uint targetID;

        public CEventTransferArgs(PortalType t, uint id)
        {
            type = t;
            targetID = id;
        }

        public PortalType Type
        {
            get { return type; }
        }

        public uint TargetID
        {
            get { return targetID; }
        }
    }

    public class CEventActorArgs : CEventBaseArgs
    {
        Actor mAct;
        public CEventActorArgs(Actor act)
        {
            mAct = act;
        }

        public Actor Act
        {
            get { return mAct; }
        }

    }

    public class CEventGVoiceArgs : CEventBaseArgs
    {
        string mFileID;
        string mResult;
        uint mTime;

        public CEventGVoiceArgs(string file_id, string result, uint time)
        {
            mFileID = file_id;
            mResult = result;
            mTime = time;
        }

        public string FileID
        {
            get { return mFileID; }
        }

        public string Result
        {
            get { return mResult; }
        }

        public uint Time
        {
            get { return mTime; }
        }
    }
}

