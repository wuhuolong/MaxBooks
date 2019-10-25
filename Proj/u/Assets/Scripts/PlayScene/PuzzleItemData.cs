using System.Collections;
using System.Collections.Generic;

[System.Serializable]
//FINISH:分离UI逻辑和数据逻辑
public class PuzzleItemData
{

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

    private int[] pcenter;//中心点的内部坐标，是一个长度为2的数组
    public int[] Pcenter
    {
        get { return pcenter; }
        set { pcenter = MatrixUtil.ArrayCopy(value); }

    }

    // public int[] PoffsetX;
    // public int[] PoffsetY;


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

    public void InitButtomPuzzleItemData(int pwidth, int pheight, int[] playout, int[] pcenter)
    {
        //将数据读入，获得拼图的长度和宽度（两个方向的格子数量），以及将拼图基础格子的信息保存进一个一维int数组
        //FINISH:读入数据，获取的宽度和长度
        this.pwidth = pwidth;
        this.pheight = pheight;

        //FINISH:保存layout数据进一个一维int数组playout，保存center数据进pcenter
        this.playout = playout;
        this.pcenter = pcenter;
       
    }

    public void RotatePuzzle()
    {
        int[] afterRotateLayout = new int[pwidth * pheight];
        for (int i = 0; i < playout.Length; ++i)
        {
            int x = i % pwidth;
            int y = i / pwidth;

            int arx = Pheight - 1 - y;
            int ary = x;
            afterRotateLayout[ary * pheight + arx] = playout[i];
        }
        playout = afterRotateLayout;
        int[] tempPcenter = pcenter;
        pcenter = new int[2] { Pheight - 1 - tempPcenter[1], tempPcenter[0] };
        int temp = pheight;
        pheight = pwidth;
        pwidth = temp;
    }

}
