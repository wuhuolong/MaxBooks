using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//FINISH:分离UI逻辑和数据逻辑
public class PuzzleItemData
{

    //!拼图的id，不是指储存在bin中的id，而是在puzzlebar里的序号而已
    private int pID = -1;
    public int PID
    {
        get { return pID; }
        set { pID = value; }
    }

    //拼图在宽和高上的格子数量
    private int pwidth = 0;
    public int Pwidth
    {
        get { return pwidth; }
        set { pwidth = value; }
    }

    private int pheight = 0;
    public int Pheight
    {
        get { return pheight; }
        set { pheight = value; }

    }


    private int[] playout;
    public int[] Playout
    {
        get { return playout; }
        set { playout = MatrixUtil.ArrayCopy(value); }

    }

    private int pcenterOrigin = 0;
    public int PcenterOrigin
    {
        get { return pcenterOrigin; }
    }
    private int[] pcenter;//中心点的内部坐标，是一个长度为2的数组
    public int[] Pcenter
    {
        get { return pcenter; }
        set { pcenter = MatrixUtil.ArrayCopy(value); }
    }

    private bool plockstate = false;//解锁状态，如果是广告拼图就上锁
    public bool Plockstate
    {
        get { return plockstate; }
        set { plockstate = value; }
    }

    //-已不存在世界空间和屏幕空间的区分，主要是屏幕空间
    private bool notSettleFlag = true;//!未摆放和已经摆放的拼图的判断
    public bool NotSettleFlag
    {
        get { return notSettleFlag; }
        set { notSettleFlag = value; }
    }

    private int panelGridIndex = -1;
    public int PanelGridIndex
    {
        get { return panelGridIndex; }
        set { panelGridIndex = value; }
    }

    private int lastPanelGridIndex = -1;//!已放置拼图专用数据
    public int LastPanelGridIndex
    {
        get { return lastPanelGridIndex; }
        set { lastPanelGridIndex = value; }
    }

    public void InitButtomPuzzleItemData(int pID, int pwidth, int pheight, int[] playout, int[] pcenter, bool plockstate = false)
    {
        // Debug.Log("PID,Pwidth,Pheight:" + "\n" +
        // pID + " " + pwidth + " " + pheight + " ");
        //将数据读入，获得拼图的ID，长度和宽度（两个方向的格子数量），以及将拼图基础格子的信息保存进一个一维int数组

        //TODO:获取拼图的ID
        this.pID = pID;

        //FINISH:读入数据，获取的宽度和长度
        this.pwidth = pwidth;
        this.pheight = pheight;

        //FINISH:保存layout数据进一个一维int数组playout，保存center数据进pcenter
        this.playout = playout;
        this.pcenter = pcenter;

        this.plockstate = plockstate;

        this.pcenterOrigin = pcenter[0] + pcenter[1] * pwidth;


    }

    public void RotatePuzzle()
    {
        Debug.Log("origin pcenter:" + MatrixUtil.PrintIntArray(pcenter));

        int[] afterRotateLayout = new int[pwidth * pheight];
        for (int i = 0; i < playout.Length; ++i)
        {
            int x = i % pwidth;
            int y = i / pwidth;

            int arx = pheight - 1 - y;
            int ary = x;
            afterRotateLayout[ary * pheight + arx] = playout[i];
        }
        playout = afterRotateLayout;
        int[] tempPcenter = MatrixUtil.ArrayCopy(pcenter);
        pcenter = new int[2] { pheight - 1 - tempPcenter[1], tempPcenter[0] };
        int temp = pheight;
        pheight = pwidth;
        pwidth = temp;

        Debug.Log("new pcenter:" + MatrixUtil.PrintIntArray(pcenter));
    }

}
