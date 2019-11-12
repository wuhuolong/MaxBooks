using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//FINISH:分离UI逻辑和数据逻辑
public class GeneralPanelData
{
    public enum GridType
    {
        Non = 0,
        Fix = 1,
        Blank = 2,
        Fill = 3,
    }

    //面板在宽和高上的格子数量
    private int pwidth = 0;
    public int Pwidth
    {
        get
        {
            return pwidth;
        }
    }

    private int pheight = 0;
    public int Pheight
    {
        get
        {
            return pheight;
        }
    }


    private int[] playout;
    public int[] Playout
    {
        get
        {
            return playout;
        }
    }

    public void InitGeneralPanelData(bool isReGen = false)
    {
        //将数据读入，获得面板的长度和宽度（两个方向的格子数量），以及将面板基础格子的信息保存进一个一维int数组
        //FINISH:读入数据，获取面板的宽度和长度
        uint curLevelID = LevelMgr.GetInstance().CurLevelID;
        //Debug.Log("id = " + curLevelID);
        LevelData curLevelData = LevelMgr.GetInstance().GetLevelConfig(curLevelID);

        //插入逻辑判断是否有存档，有的话就直接读取，返回
        if (isReGen)
        {
            Recorder rec = XPlayerPrefs.GetRec(curLevelID);
            pwidth = curLevelData.Map.MapWidth + 2;
            pheight = curLevelData.Map.MapHeight + 2;

            //保存数据进一个一维int数组
            playout = MatrixUtil.ArrayCopy(rec.layout);
        }
        else if (curLevelData == null || curLevelData.Map == null || curLevelID == 0)
        {
            Debug.Log("Sim");
            //!模拟读入长宽
            pwidth = 15;
            pheight = 15;

            //!模拟读入一个一维数组
            playout = new int[]{
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,
                1,1,1,2,1,1,2,2,2,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                };
        }
        else
        {
            pwidth = curLevelData.Map.MapWidth + 2;
            pheight = curLevelData.Map.MapHeight + 2;

            //保存数据进一个一维int数组
            int[] tempLayout = curLevelData.Map.MapArray;
            playout = new int[pwidth * pheight];

            // FINISH:扩充int数组的边界
            // UPDATE
            for (int i = 0; i < playout.Length; ++i)
            {
                int x = i % (pwidth);
                int y = i / (pwidth);
                if (x != 0 && x != pwidth - 1 && y != 0 && y != pheight - 1)
                {
                    playout[y * (pwidth) + x] = tempLayout[(y - 1) * (pwidth - 2) + (x - 1)];
                }
                else
                {
                    playout[y * (pwidth) + x] = (int)GridType.Non;
                }
            }
            // pwidth = curLevelData.Map.MapWidth;
            // pheight = curLevelData.Map.MapHeight;
            // playout = MatrixUtil.ArrayCopy(curLevelData.Map.MapArray);


        }

    }

    int[][] gridOffsetArr = new int[][] {
        new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 },
        new int[] { -1, 0 }, new int[] { 0, 0 }, new int[] { 1, 0 },
        new int[] { -1, 1 }, new int[] { 0, 1 }, new int[] { 1, 1 }};




    public bool IsFit(PuzzleItemData puzzleItemData, int gridIndex, out int[] outputBlankLayout)
    {
        //FINISH：面板的数据层中，该IsFit函数仅处理拼图的layout和面板的layout的关系
        int[] puzzleCenter = puzzleItemData.Pcenter;//获取拼图的中心的内部坐标
        int puzzleCenterX = puzzleCenter[0];
        int puzzleCenterY = puzzleCenter[1];
        int puzzleWidth = puzzleItemData.Pwidth;//获取拼图宽方向的格子数
        int puzzleHeight = puzzleItemData.Pheight;//获取拼图高方向的格子数


        int x = gridIndex % pwidth;
        int y = gridIndex / pwidth;
        int[] puzzleLayout = puzzleItemData.Playout;

        //创建一个和puzzlelayout相同大小的一维数组，用来记录面板上同样大小的格子中的空位，2为有空位，1为无空位（存在非可填的格子），0为没有格子（超出面板边界）
        int[] blankLayout = new int[puzzleLayout.Length];

        //按照puzzle的center和layout遍历面板上的格子
        int i = 0;
        for (int iy = y - puzzleCenterY; iy < y - puzzleCenterY + puzzleHeight; ++iy)
        {
            for (int ix = x - puzzleCenterX; ix < x - puzzleCenterX + puzzleWidth; ++ix)
            {
                if ((ix < 0 || ix > pwidth - 1) || (iy < 0 || iy > pheight - 1))
                {
                    //超出边界的情况
                    // Debug.Log("存在超出边界的格子");
                    // Debug.Log("coo:" + ix.ToString() +" "+ iy.ToString());
                    blankLayout[i] = 0;
                }
                else
                {
                    if (playout[ix + iy * pwidth] != (int)GridType.Blank)
                    {
                        //没超出边界但是存在非可填格子的情况
                        // Debug.Log("存在非可填格子");
                        // Debug.Log("coo:" + (ix + iy * pwidth).ToString());
                        blankLayout[i] = 1;
                    }
                    else
                    {
                        blankLayout[i] = 2;
                    }
                }
                i++;
            }
        }

        outputBlankLayout = blankLayout;

        //对比puzzleLayout和blankLayout即可
        for (i = 0; i < puzzleLayout.Length; ++i)
        {
            int si = blankLayout[i];
            int pi = puzzleLayout[i];
            if (si == 0 && pi == 1)
            {
                //超出边界的面板上的格子
                return false;
            }
            if (si == 1 && pi == 1)
            {
                //非可填格子
                return false;
            }

        }
        return true;

    }

    //显示预判断（红色和绿色的格子）所需成员变量：
    private List<int> greenGridIndices = new List<int>();
    public List<int> GreenGridIndices
    {
        get
        {
            return greenGridIndices;
        }
    }

    private List<int> redGridIndices = new List<int>();
    public List<int> RedGridIndices
    {
        get
        {
            return redGridIndices;
        }
    }

    private int lastGridIndex = -1;
    public int LastGridIndex
    {
        set
        {
            lastGridIndex = value;
        }
    }
    private bool dirtyFlag = true;

    public void ClearBothIndices()
    {
        greenGridIndices.Clear();
        redGridIndices.Clear();
        lastGridIndex = -1;
    }
    public bool CheckDirtyFlag(int gridIndex)
    {
        if (gridIndex != lastGridIndex)
        {
            //如果上一帧指向的grid的index和这一帧指向的grid的index不一样，设置dirtyflag为true
            dirtyFlag = true;
        }
        else
        {
            dirtyFlag = false;
        }
        return dirtyFlag;
    }
    public void AddToGreenGridIndices(PuzzleItemData puzzleItemData = null)
    {
        int gridIndex = puzzleItemData.PanelGridIndex;
        int x = gridIndex % pwidth;
        int y = gridIndex / pwidth;
        int[] puzzleLayout = puzzleItemData.Playout;

        //添加greenGridIndices
        for (int i = 0; i < puzzleLayout.Length; ++i)
        {
            if (puzzleLayout[i] == 1)
            {
                int ix = i % puzzleItemData.Pwidth;
                int iy = i / puzzleItemData.Pwidth;
                int offsetX = ix - puzzleItemData.Pcenter[0];
                int offsetY = iy - puzzleItemData.Pcenter[1];
                int gx = x + offsetX;
                int gy = y + offsetY;
                greenGridIndices.Add(gx + gy * pwidth);
            }
        }
    }
    public void AddToRedGridIndices(PuzzleItemData puzzleItemData, int[] blankLayout)
    {
        int gridIndex = puzzleItemData.PanelGridIndex;
        int x = gridIndex % pwidth;
        int y = gridIndex / pwidth;

        // Debug.Log("GridIndex when show pregrid：" + gridIndex);//!Test

        int[] puzzleLayout = puzzleItemData.Playout;
        //添加redGridIndices
        for (int i = 0; i < puzzleLayout.Length; ++i)
        {
            if (puzzleLayout[i] == 1)
            {
                int ix = i % puzzleItemData.Pwidth;
                int iy = i / puzzleItemData.Pwidth;
                int offsetX = ix - puzzleItemData.Pcenter[0];
                int offsetY = iy - puzzleItemData.Pcenter[1];
                if (blankLayout[i] == (int)GridType.Blank || blankLayout[i] == (int)GridType.Fix)
                {
                    int gx = x + offsetX;
                    int gy = y + offsetY;
                    redGridIndices.Add(gx + gy * pwidth);
                }
            }
        }
    }


    public void ModiLayout(GridType gridType, PuzzleItemData puzzleItemData)
    {
        int gridIndex = puzzleItemData.PanelGridIndex;
        int[] newPuzzleLayout = puzzleItemData.Playout;
        int x = gridIndex % pwidth;
        int y = gridIndex / pwidth;

        for (int i = 0; i < newPuzzleLayout.Length; ++i)
        {
            if (newPuzzleLayout[i] == 1)
            {
                int ix = i % puzzleItemData.Pwidth;
                int iy = i / puzzleItemData.Pwidth;
                int offsetX = ix - puzzleItemData.Pcenter[0];
                int offsetY = iy - puzzleItemData.Pcenter[1];
                int gx = x + offsetX;
                int gy = y + offsetY;
                int gi = gx + gy * pwidth;

                playout[gi] = (int)gridType;
            }
        }

    }

    public bool CheckOver()
    {
        foreach (int i in playout)
        {
            if (i == (int)GridType.Blank)
            {
                return false;
            }
        }
        uint curLevelID = LevelMgr.GetInstance().CurLevelID;
        XPlayerPrefs.DelRec(curLevelID);
        SDKMgr.GetInstance().Track(SDKMsgType.OnLevelClear, (int)curLevelID);
        return true;
    }


    public int CheckFixGrid(int gridIndex)
    {
        if (gridIndex < playout.Length)
        {
            //记录当前grid所在的九宫格的信息，0表示不是fixgrid，1表示是fixgrid
            int[] gridBesideStateArr = new int[9];
            int x = gridIndex % pwidth;
            int y = gridIndex / pwidth;
            // Debug.Log(gridIndex + " " + x + " " + y);
            for (int i = 0; i < gridOffsetArr.Length; ++i)
            {
                int[] gridOffset = gridOffsetArr[i];
                int offX = x + gridOffset[0];
                int offY = y + gridOffset[1];
                if (offX < 0 || offX >= pwidth || offY < 0 || offY >= pheight)
                {
                    gridBesideStateArr[i] = 0;
                }
                else
                {
                    int offGridIndex = offX + offY * pwidth;
                    // Debug.Log(offGridIndex+" "+offX + " " + offY);
                    if (playout[offGridIndex] == (int)GridType.Fix)
                    {
                        gridBesideStateArr[i] = 1;
                    }
                    else
                    {
                        gridBesideStateArr[i] = 0;
                    }
                }
            }
            // Debug.Log(MatrixUtil.PrintIntArray(gridBesideStateArr));
            //TODO:至此获得的gridBesideStateArr记录了九宫格中fixgrid的分布信息，对这些信息进行处理，确定返回值

            //记录边的信息
            List<int> sideFixGridIndexOfArrList = new List<int>();//记录的是fourSideIndexArr的索引
            int[] fourSideIndexArr = new int[] { 1, 3, 5, 7 };
            for (int i = 0; i < fourSideIndexArr.Length; ++i)
            {
                int fourSideIndex = fourSideIndexArr[i];
                if (gridBesideStateArr[fourSideIndex] == 0)
                {
                    // Debug.Log("fourSideIndex" + fourSideIndex);
                    sideFixGridIndexOfArrList.Add(i);
                }
            }
            //记录角的信息
            List<int> cornerFixGridIndexOfArrList = new List<int>();//记录的是fourCornerIndexArr的索引
            int[] fourCornerIndexArr = new int[] { 0, 2, 6, 8 };
            int[][] fourCornerSideIndexArrArr = new int[][] { new int[] { 1, 3 }, new int[] { 1, 5 }, new int[] { 3, 7 }, new int[] { 5, 7 } };
            for (int i = 0; i < fourCornerIndexArr.Length; ++i)
            {
                int fourCornerIndex = fourCornerIndexArr[i];
                if (gridBesideStateArr[fourCornerIndex] == 0)
                {
                    if (gridBesideStateArr[fourCornerSideIndexArrArr[i][0]] == 1 && gridBesideStateArr[fourCornerSideIndexArrArr[i][1]] == 1)
                    {
                        //只有角两边没有边时才记录这个角，否则不记录（因为有边则必然有角）
                        // Debug.Log("fourCornerIndex" + fourCornerIndex);
                        cornerFixGridIndexOfArrList.Add(i);
                    }
                }
            }

            int sideFixGridIndexOfArrListCount = sideFixGridIndexOfArrList.Count;
            int cornerFixGridIndexOfArrListCount = cornerFixGridIndexOfArrList.Count;


            /* 
            关于返回值：
            返回值为一个整型，大小为t*10+r，用于表达t-r
            其中：
            t表示Fix格子的类型，从0到14，共15种
            r表示旋转，有0 1 2 3 四种
            */

            //检查边的个数，再确定角
            if (sideFixGridIndexOfArrListCount == 0)
            {
                //如果没有边，检查四个角
                if (cornerFixGridIndexOfArrListCount == 0)
                {
                    //如果没有角
                    return 0;//0-0
                }
                else if (cornerFixGridIndexOfArrListCount == 1)
                {
                    //如果有一个角
                    return 10 + cornerFixGridIndexOfArrList[0];//1-0 1-1 1-2 1-3
                }
                else if (cornerFixGridIndexOfArrListCount == 2)
                {
                    //如果有两个角，判断是对角还是邻接的角
                    if (cornerFixGridIndexOfArrList[0] == 0 && cornerFixGridIndexOfArrList[1] == 3)
                    {
                        //左上和右下，对角
                        return 20;//2-0
                    }
                    else if (cornerFixGridIndexOfArrList[0] == 1 && cornerFixGridIndexOfArrList[1] == 2)
                    {
                        //右上和左下，对角
                        return 21;//2-1
                    }
                    else if (cornerFixGridIndexOfArrList[0] == 0 && cornerFixGridIndexOfArrList[1] == 1)
                    {
                        //左上和右上，邻接的角
                        return 30;//3-0
                    }
                    else if (cornerFixGridIndexOfArrList[0] == 0 && cornerFixGridIndexOfArrList[1] == 2)
                    {
                        //左上和左下，邻接的角
                        return 31;//3-1
                    }
                    else if (cornerFixGridIndexOfArrList[0] == 1 && cornerFixGridIndexOfArrList[1] == 3)
                    {
                        //右上和右下，邻接的角
                        return 32;//3-2
                    }
                    else if (cornerFixGridIndexOfArrList[0] == 2 && cornerFixGridIndexOfArrList[1] == 3)
                    {
                        //左下和右下，邻接的角
                        return 33;//3-3
                    }
                }
                else if (cornerFixGridIndexOfArrListCount == 3)
                {
                    //如果有三个角
                    if (cornerFixGridIndexOfArrList[0] == 0 && cornerFixGridIndexOfArrList[1] == 1 && cornerFixGridIndexOfArrList[2] == 2)
                    {
                        //除了右下的三个角
                        return 40;//4-0
                    }
                    else if (cornerFixGridIndexOfArrList[0] == 0 && cornerFixGridIndexOfArrList[1] == 1 && cornerFixGridIndexOfArrList[2] == 3)
                    {
                        //除了左下的三个角
                        return 41;//4-1
                    }
                    else if (cornerFixGridIndexOfArrList[0] == 0 && cornerFixGridIndexOfArrList[1] == 2 && cornerFixGridIndexOfArrList[2] == 3)
                    {
                        //除了右上的三个角
                        return 42;//4-2
                    }
                    else if (cornerFixGridIndexOfArrList[0] == 1 && cornerFixGridIndexOfArrList[1] == 2 && cornerFixGridIndexOfArrList[2] == 3)
                    {
                        //除了左上的三个角
                        return 43;//4-3
                    }
                }
                else if (cornerFixGridIndexOfArrListCount == 4)
                {
                    //如果有四个角
                    return 50;//5-0
                }
            }
            else if (sideFixGridIndexOfArrListCount == 1)
            {
                //如果有一条边，检查剩余的两个角
                int sideFixGridIndexOfArr0 = sideFixGridIndexOfArrList[0];
                if (cornerFixGridIndexOfArrListCount == 0)
                {
                    //如果没有角
                    if (sideFixGridIndexOfArr0 == 0)
                    {
                        //上面有边
                        return 60;//6-0
                    }
                    else if (sideFixGridIndexOfArr0 == 2)
                    {
                        //右面有边
                        return 61;//6-1
                    }
                    else if (sideFixGridIndexOfArr0 == 3)
                    {
                        //下面有边
                        return 62;//6-2
                    }
                    else if (sideFixGridIndexOfArr0 == 1)
                    {
                        //左面有边
                        return 63;//6-3
                    }

                }
                else if (cornerFixGridIndexOfArrListCount == 1)
                {
                    //如果有一个角
                    int cornerFixGridIndexOfArr0 = cornerFixGridIndexOfArrList[0];
                    if (sideFixGridIndexOfArr0 == 0)
                    {
                        //cornerFixGridIndexOfArr0为2或3
                        if (cornerFixGridIndexOfArr0 == 3)
                        {
                            return 70;//7-0
                        }
                        else if (cornerFixGridIndexOfArr0 == 2)
                        {
                            return 80;//8-0
                        }
                    }
                    else if (sideFixGridIndexOfArr0 == 1)
                    {
                        //cornerFixGridIndexOfArr0为1或3
                        if (cornerFixGridIndexOfArr0 == 1)
                        {
                            return 71;//7-1
                        }
                        else if (cornerFixGridIndexOfArr0 == 3)
                        {
                            return 81;//8-1
                        }
                    }
                    else if (sideFixGridIndexOfArr0 == 2)
                    {
                        //cornerFixGridIndexOfArr0为0或2
                        if (cornerFixGridIndexOfArr0 == 2)
                        {
                            return 72;//7-2
                        }
                        else if (cornerFixGridIndexOfArr0 == 0)
                        {
                            return 82;//8-2
                        }
                    }
                    else if (sideFixGridIndexOfArr0 == 3)
                    {
                        //cornerFixGridIndexOfArr0为0或1
                        if (cornerFixGridIndexOfArr0 == 0)
                        {
                            return 73;//7-3
                        }
                        else if (cornerFixGridIndexOfArr0 == 1)
                        {
                            return 83;//8-3
                        }
                    }
                }
                else if (cornerFixGridIndexOfArrListCount == 2)
                {
                    //如果有两个角
                    if (sideFixGridIndexOfArr0 == 0)
                    {
                        //上面有边
                        return 90;//9-0
                    }
                    else if (sideFixGridIndexOfArr0 == 2)
                    {
                        //右面有边
                        return 91;//9-1
                    }
                    else if (sideFixGridIndexOfArr0 == 3)
                    {
                        //下面有边
                        return 92;//9-2
                    }
                    else if (sideFixGridIndexOfArr0 == 1)
                    {
                        //左面有边
                        return 93;//9-3
                    }

                }
            }
            else if (sideFixGridIndexOfArrListCount == 2)
            {
                //先判断两边是哪两边，再检查角
                int sideFixGridIndexOfArr0 = sideFixGridIndexOfArrList[0];
                int sideFixGridIndexOfArr1 = sideFixGridIndexOfArrList[1];

                //如果是上下两边或者左右两边，则不会有角（或者说因为存在边，不重复记录角）
                if (sideFixGridIndexOfArr0 == 0 && sideFixGridIndexOfArr1 == 3)
                {
                    return 100;//10-0
                }
                else if (sideFixGridIndexOfArr0 == 1 && sideFixGridIndexOfArr1 == 2)
                {
                    return 101;//10-1
                }
                else
                {
                    //如果是邻接的两边
                    if (cornerFixGridIndexOfArrListCount == 0)
                    {
                        //如果没有角
                        if (sideFixGridIndexOfArr0 == 0 && sideFixGridIndexOfArr1 == 1)
                        {
                            return 110;//11-0
                        }
                        else if (sideFixGridIndexOfArr0 == 0 && sideFixGridIndexOfArr1 == 2)
                        {
                            return 111;//11-1
                        }
                        else if (sideFixGridIndexOfArr0 == 2 && sideFixGridIndexOfArr1 == 3)
                        {
                            return 112;//11-2
                        }
                        else if (sideFixGridIndexOfArr0 == 1 && sideFixGridIndexOfArr1 == 3)
                        {
                            return 113;//11-3
                        }
                    }
                    else if (cornerFixGridIndexOfArrListCount == 1)
                    {
                        //如果有一个角
                        int cornerFixGridIndexOfArr0 = cornerFixGridIndexOfArrList[0];
                        return 120 + cornerFixGridIndexOfArr0;//12-0 12-1 12-2 12-3
                    }
                }
            }
            else if (sideFixGridIndexOfArrListCount == 3)
            {
                //如果有三条边，不用检查角
                int sideFixGridIndexOfArr0 = sideFixGridIndexOfArrList[0];
                int sideFixGridIndexOfArr1 = sideFixGridIndexOfArrList[1];
                int sideFixGridIndexOfArr2 = sideFixGridIndexOfArrList[2];
                if (sideFixGridIndexOfArr0 == 0 && sideFixGridIndexOfArr1 == 1 && sideFixGridIndexOfArr2 == 2)
                {
                    //除了下面没边
                    return 130;//13-0
                }
                else if (sideFixGridIndexOfArr0 == 0 && sideFixGridIndexOfArr1 == 1 && sideFixGridIndexOfArr2 == 3)
                {
                    //除了右面没边
                    return 131;//13-1
                }
                else if (sideFixGridIndexOfArr0 == 1 && sideFixGridIndexOfArr1 == 2 && sideFixGridIndexOfArr2 == 3)
                {
                    //除了上面没边
                    return 132;//13-2
                }
                else if (sideFixGridIndexOfArr0 == 0 && sideFixGridIndexOfArr1 == 2 && sideFixGridIndexOfArr2 == 3)
                {
                    //除了左面没边
                    return 133;//13-3
                }

            }
            else if (sideFixGridIndexOfArrListCount == 4)
            {
                //如果有四条边，不用检查角
                return 140;//14-0
            }
        }
        return -1;
    }



}
