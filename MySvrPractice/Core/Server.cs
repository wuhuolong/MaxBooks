using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


public class Server
{
    private Socket[] mSockets = null;
    private Thread mClientThread = null;
    public bool isLoop = true;
    private int mHeartBeat = 0;
    public Server()
    {
        mClientThread = new Thread(RunSvrThread);
        mHeartBeat = 0;
    }

    public void Run()
    {
        mClientThread.Start();
    }

    private void RunSvrThread()
    {
        while (isLoop)
        {

            mHeartBeat++;
            Console.WriteLine("heart==>" + mHeartBeat);
            Thread.Sleep(1000);
        }
    }
}

