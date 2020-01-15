using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Kernel:ILive
{
    private Server mSvr = null;
    private List<IWork> mWorks;
    public ushort FrameCout = 30;
    private bool mIsLoop = false;
    private Thread mLoopThread; 
    public bool Init()
    {
        mSvr = new Server();
        mWorks = new List<IWork>(){
            (IWork)(new GameLogic())
        };

        mSvr.Run();
        mIsLoop =  true;
        mLoopThread = new Thread(RunAsyncTick);
        foreach(IWork work in mWorks){
            work.OnInit();
        }
        return true;
    }
    public void RunTickAsync(){
        mLoopThread.Start();
    }
    private ulong mLasttime;
    private void RunAsyncTick(){
        while(mIsLoop){
            foreach(IWork work in mWorks){
                work.Tick();
            }
            Thread.Sleep(1000);
        }
    }
    public void DeInit()
    {
        foreach(IWork work in mWorks){
            work.OnDeInit();
        }
    }
    /*
     * 流程：客户端登录连接服务器，服务器收到消息后创建对应Client，保存
     * 驱动每个
     */
    public bool GetInput()
    {
        ConsoleKeyInfo key = Console.ReadKey();
        Console.WriteLine("Input==>"+key.Key);
        if (key.Key == ConsoleKey.Q)
        {
            mSvr.isLoop = false;
            mIsLoop = false;
            return false;
        }
        return true;
    }
}
