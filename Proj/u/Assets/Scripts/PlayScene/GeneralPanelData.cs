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
        uint curLevelID = LevelMgr.GetInstance().GetCurLevelID();
        Debug.Log("id = " + curLevelID);
        LevelData curLevelData = LevelMgr.GetInstance().GetLevelConfig(curLevelID);

        //插入逻辑判断是否有存档，有的话就直接读取，返回
        if (isReGen)
        {
            Debug.Log("max==>InitGeneralPanelData");
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
                2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2,
                };
        }
        else
        {
            pwidth = curLevelData.Map.MapWidth + 2;
            pheight = curLevelData.Map.MapHeight + 2;

            //保存数据进一个一维int数组
            int[] tempLayout = curLevelData.Map.MapArray;
            playout = new int[pwidth * pheight];

            //FINISH:扩充int数组的边界
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

        }

    }

    int[][] gridOffsetArr = new int[][] {
        new int[] { -1, 1 }, new int[] { 0, 1 }, new int[] { 1, 1 },
        new int[] { -1, 0 }, new int[] { 0, 0 }, new int[] { 1, 0 },
        new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 }};

    public int CheckFixGrid(int gridIndex)
    {
        if (gridIndex < playout.Length)
        {
            //记录当前grid所在的九宫格的信息，0表示不是fixgrid，1表示是fixgrid
            int[] gridBesideStateArr = new int[9];
            int x = gridIndex % pwidth;
            int y = gridIndex / pwidth;
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
            //至此获得的gridBesideStateArr记录了九宫格中fixgrid的分布信息，对这些信息进行处理，确定返回值
            
        }
        return -1;
    }




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
        uint curLevelID = LevelMgr.GetInstance().GetCurLevelID();
        XPlayerPrefs.DelRec(curLevelID);
        return true;
    }

}
