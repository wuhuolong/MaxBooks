using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;
using SGameEngine;

public class CEventBaseArgs
{
	public System.Object arg;

	public CEventBaseArgs(System.Object obj)
	{
		arg = obj;
	}
		
	public CEventBaseArgs()
	{
		arg = null;
	}
}

public class CEventEventParamArgs : CEventBaseArgs
{
    public System.Object[] mMoreParam = null;
    public CEventEventParamArgs(params System.Object[] args)
    {
        mMoreParam = args;
    }

    public CEventEventParamArgs()
    {
        mMoreParam = null;
    }

    public System.Object GetMoreParam(uint index)
    {
        return mMoreParam[index];
    }
}

public class ClientEventMgr : xc.Singleton<ClientEventMgr>
{
	public delegate void ClientEventFunc(CEventBaseArgs arg);

	Dictionary<int,List<ClientEventFunc> > mEventHandlers = new Dictionary<int, List<ClientEventFunc>>();

	// Post msg.
	class Message
	{
		public int e;
		public CEventBaseArgs arg = null;
	}
	LinkedList<Message> mMsgLst = new LinkedList<Message>();
		
	public void SubscribeClientEvent(int eventID, ClientEventFunc func)
	{
        List<ClientEventFunc> funcs;
		if (!mEventHandlers.TryGetValue(eventID, out funcs))
		{
			funcs = new List<ClientEventFunc>();
			mEventHandlers.Add(eventID, funcs);
		}
			
		if (!funcs.Contains(func))
			funcs.Add(func);
	}
		
	public void UnsubscribeClientEvent(int eventID, ClientEventFunc func)
	{
		List<ClientEventFunc> funcs;
		if (mEventHandlers.TryGetValue(eventID, out funcs))
		{
			funcs.Remove(func);
		}
	}


	public void FireEvent(int eventID, CEventBaseArgs arg)
	{
		List<ClientEventFunc> funcs;
		if (mEventHandlers.TryGetValue(eventID, out funcs))
		{
            List<ClientEventFunc> mTmpRunFuncs = Pool<ClientEventFunc>.List.New(funcs.Count);
            //List<ClientEventFunc> mTmpRunFuncs = new List<ClientEventFunc>(funcs.Count);
			foreach (ClientEventFunc func in funcs)
			{
                if (func != null)
                {
                    mTmpRunFuncs.Add(func);
                }
			}

			// 在触发事件时，可能会反注册 
			foreach(ClientEventFunc func in mTmpRunFuncs)
			{
				func(arg);
			}

            Pool<ClientEventFunc>.List.Free(mTmpRunFuncs);

		}
	}
		
	public void PostEvent(int eventID, CEventBaseArgs arg)
	{
		Message msg = new Message();
		msg.e = eventID;
		msg.arg = arg;
			
		mMsgLst.AddLast(msg);
	}
		
	public void UpdateMsgPump()
	{
		while (mMsgLst.Count > 0)
		{
			Message msg = mMsgLst.First.Value;
			FireEvent((int)msg.e, msg.arg);
				
			mMsgLst.RemoveFirst();
		}
	}
}
