using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PuzzleBar : MonoBehaviour
{
    //场景对象/组件：
    // public Camera playFieldCamera;
    public GeneralPanelUI generalPanelUI;
    public Transform puzzleMoveTrans;
    public DragController dragController;
    // public CanvasScaler canvasScaler;

    //prefab:
    public GameObject puzzleItemPrefab;

    public List<PuzzleItemUI> puzzleItemUIList;


    public void InitPuzzleBar()
    {
        //FINISH:读入数据，获得界面下方的PuzzlePanel中要放的拼图的种类的信息
        uint curLevelID = LevelMgr.GetInstance().GetCurLevelID();
        LevelData curLevelData = LevelMgr.GetInstance().GetLevelConfig(curLevelID);

        Dictionary<string, int[]> FillTypeMap = new Dictionary<string, int[]>();
        Dictionary<string, int> WidthMap = new Dictionary<string, int>();
        Google.Protobuf.Collections.RepeatedField<string> usablePuzzleStrList = new Google.Protobuf.Collections.RepeatedField<string>();

        if (curLevelData == null || curLevelData.Config == null)
        {
            //!模拟读入
            FillTypeMap = new Dictionary<string, int[]>(){
                {"0",new int[]{0,0,1,1,1,1}},
                {"1",new int[]{1,1}},
                {"2",new int[]{1,1,0,0}},
                {"3",new int[]{1}},
            };

            WidthMap = new Dictionary<string, int>(){
                {"0",3},
                {"1",2},
                {"2",2},
                {"3",1},
            };
            usablePuzzleStrList = new Google.Protobuf.Collections.RepeatedField<string>(){
                "0","1","3"
            };

        }
        else
        {
            ToolMapArray toolMapArray = LevelMgr.GetInstance().GetToolMapArray();
            FillTypeMap = toolMapArray.FillTypeMap;
            WidthMap = toolMapArray.WidthMap;
            usablePuzzleStrList = curLevelData.Config.LevelPixel;
        }



        Debug.Log("usablePuzzleStrList.Count" + usablePuzzleStrList.Count);
        //FINISH:读入数据后，根据数据生成相应的若干PuzzleItem
        foreach (string usablePuzzleStr in usablePuzzleStrList)
        {
            int[] usablePuzzleLayout = new int[] { };
            if (FillTypeMap.TryGetValue(usablePuzzleStr, out usablePuzzleLayout))
            {
                int[] puzzleLayout = MatrixUtil.ArrayCopy(usablePuzzleLayout);

                int puzzleWidth = WidthMap[usablePuzzleStr];

                int puzzleHeight = puzzleLayout.Length / puzzleWidth;

                int puzzleCenterX = puzzleWidth / 2;
                int puzzleCenterY = puzzleHeight / 2;
                // Debug.Log("puzzleCenterX" + puzzleCenterX);
                // Debug.Log("puzzleCenterY" + puzzleCenterY);


                int[] puzzleCenter = new int[2] { puzzleCenterX, puzzleCenterY };

                GameObject puzzleItem = GameObject.Instantiate(puzzleItemPrefab, this.transform);
                PuzzleItemUI puzzleItemUI = puzzleItem.GetComponent<PuzzleItemUI>();
                puzzleItemUIList.Add(puzzleItemUI);
                // puzzleItemUI.InitComp(playFieldCamera, generalPanelUI, puzzleMoveTrans, dragControlMgr, canvasScaler);
                puzzleItemUI.InitComp(generalPanelUI, puzzleMoveTrans, dragController );

                puzzleItemUI.puzzleItemData.InitButtomPuzzleItemData(puzzleWidth, puzzleHeight, puzzleLayout, puzzleCenter);
                puzzleItemUI.InitButtomPuzzleItemUI();
            }
            else
            {
                Debug.Log("usablePuzzstr" + usablePuzzleStr);
            }
        }

    }

}
