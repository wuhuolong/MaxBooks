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
    public Transform puzzleBarForFreeLayoutTrans;

    //prefab:
    public GameObject puzzleItemPrefab;

    public GameObject adButtonPrefab;

    // public List<PuzzleItemUI> puzzleItemUIList;

    public float scaleRatioOfPanelGrid = 0.85f;

    private int adPuzzleNum = 0;

    //private bool adPuzzleUseFlag = false;//没有用于实际判断，暂时注释


    public void InitPuzzleBar()
    {
        //FINISH:读入数据，获得界面下方的PuzzlePanel中要放的拼图的种类的信息
        uint curLevelID = LevelMgr.GetInstance().CurLevelID;
        LevelData curLevelData = LevelMgr.GetInstance().GetLevelConfig(curLevelID);

        Dictionary<string, int[]> FillTypeMap = new Dictionary<string, int[]>();
        Dictionary<string, int> WidthMap = new Dictionary<string, int>();
        Google.Protobuf.Collections.RepeatedField<string> usablePuzzleStrList = new Google.Protobuf.Collections.RepeatedField<string>();
        int adPuzzleAvailFlagInt = 0;

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
            adPuzzleAvailFlagInt = 1;

        }
        else
        {
            ToolMapArray toolMapArray = LevelMgr.GetInstance().GetToolMapArray();
            FillTypeMap = toolMapArray.FillTypeMap;
            WidthMap = toolMapArray.WidthMap;
            usablePuzzleStrList = curLevelData.Config.LevelPixel;
            adPuzzleAvailFlagInt = curLevelData.Config.AdPuzzle;
        }



        //Debug.Log("usablePuzzleStrList.Count" + usablePuzzleStrList.Count);
        //FINISH:读入数据后，根据数据生成相应的若干PuzzleItem
        int i = 0;
        foreach (string usablePuzzleStr in usablePuzzleStrList)
        {
            int[] usablePuzzleLayout = new int[] { };
            if (FillTypeMap.TryGetValue(usablePuzzleStr, out usablePuzzleLayout))
            {
                int[] puzzleLayout = MatrixUtil.ArrayCopy(usablePuzzleLayout);

                int puzzleWidth = WidthMap[usablePuzzleStr];

                int puzzleHeight = puzzleLayout.Length / puzzleWidth;

                int puzzleCenterX = 0;
                int puzzleCenterY = 0;

                float puzzleCenterXFloor = Mathf.Floor((float)puzzleWidth / 2.0f);
                float puzzleCenterYFloor = Mathf.Floor((float)puzzleHeight / 2.0f);
                if ((float)puzzleWidth / 2.0f - puzzleCenterXFloor > 0.9f)
                {
                    puzzleCenterX = (int)puzzleCenterXFloor + 1;
                }
                else
                {
                    puzzleCenterX = (int)puzzleCenterXFloor;
                }
                if ((float)puzzleHeight / 2.0f - puzzleCenterYFloor > 0.9f)
                {
                    puzzleCenterY = (int)puzzleCenterYFloor + 1;
                }
                else
                {
                    puzzleCenterY = (int)puzzleCenterYFloor;
                }
                // Debug.Log("puzzleCenterX" + puzzleCenterX);
                // Debug.Log("puzzleCenterY" + puzzleCenterY);


                int[] puzzleCenter = new int[2] { puzzleCenterX, puzzleCenterY };

                GameObject puzzleItem = GameObject.Instantiate(puzzleItemPrefab, this.transform);
                PuzzleItemUI puzzleItemUI = puzzleItem.GetComponent<PuzzleItemUI>();
                // puzzleItemUIList.Add(puzzleItemUI);
                // puzzleItemUI.InitComp(playFieldCamera, generalPanelUI, puzzleMoveTrans, dragControlMgr, canvasScaler);
                puzzleItemUI.InitComp(generalPanelUI, puzzleMoveTrans, dragController);
                puzzleItemUI.puzzleItemData.InitButtomPuzzleItemData(i, puzzleWidth, puzzleHeight, puzzleLayout, puzzleCenter);
                puzzleItemUI.InitButtomPuzzleItemUI();
                puzzleItemUI.ScaleRatioOfPanelGrid = scaleRatioOfPanelGrid;
                i++;
            }
            else
            {
                Debug.Log("NOT usablePuzzstr:" + usablePuzzleStr);
            }
        }

        //TODO:判断是否可用广告方块
        if (adPuzzleAvailFlagInt == 0)
        {
            //不可用广告方块
            if (puzzleBarForFreeLayoutTrans.childCount > 0)
            {
                Transform adButtonTrans = puzzleBarForFreeLayoutTrans.GetChild(0);
                adButtonTrans.gameObject.SetActive(false);
            }
        }
        else//adPuzzleAvailFlagInt==1
        {
            //可用广告方块
            //TODO:添加广告方块 
            GameObject adPuzzle = AddAdPuzzle();
            //TODO:添加看广告按钮
            Transform adButtonTrans;
            if (puzzleBarForFreeLayoutTrans.childCount > 0)
            {
                adButtonTrans = puzzleBarForFreeLayoutTrans.GetChild(0);
            }
            else
            {
                GameObject adButton = GameObject.Instantiate(adButtonPrefab, puzzleBarForFreeLayoutTrans);
                adButtonTrans = adButton.transform;
            }
            //TODO:设置按钮的方法
            Button adButtonComp = adButtonTrans.GetComponent<Button>();
            adButtonComp.onClick.RemoveAllListeners();
            adButtonComp.onClick.AddListener(() =>
            {
                UnlockAdPuzzle();
            });
            //TODO:设置按钮位置，在协程中等待到当前帧的fixedupdate时进行，原因是adPuzzle的位置受horizontalLayout的影响会在fixedupdate时才生效
            StartCoroutine(SetAdButtonPos(adButtonTrans, adPuzzle));


        }
    }

    IEnumerator SetAdButtonPos(Transform adButtonTrans, GameObject adPuzzle)
    {
        yield return new WaitForFixedUpdate();

        RectTransform adPuzzleRectTrans = adPuzzle.GetComponent<RectTransform>();
        adButtonTrans.GetComponent<RectTransform>().anchoredPosition = adPuzzleRectTrans.anchoredPosition + new Vector2(adPuzzleRectTrans.rect.width / 2, adPuzzleRectTrans.rect.height / 2);

        adButtonTrans.gameObject.SetActive(true);
    }


    public GameObject AddAdPuzzle()
    {
        //Debug.Log("adPuzzleNum:" + adPuzzleNum);
        // adPuzzleUseFlag = true;
        if (adPuzzleNum == 0)
        {
            int[] puzzleLayout = { 1 };

            int puzzleWidth = 1;

            int puzzleHeight = 1;

            int puzzleCenterX = puzzleWidth / 2;
            int puzzleCenterY = puzzleHeight / 2;
            // Debug.Log("puzzleCenterX" + puzzleCenterX);
            // Debug.Log("puzzleCenterY" + puzzleCenterY);


            int[] puzzleCenter = new int[2] { puzzleCenterX, puzzleCenterY };

            GameObject puzzleItem = GameObject.Instantiate(puzzleItemPrefab, this.transform);
            PuzzleItemUI puzzleItemUI = puzzleItem.GetComponent<PuzzleItemUI>();
            // puzzleItemUIList.Add(puzzleItemUI);
            // puzzleItemUI.InitComp(playFieldCamera, generalPanelUI, puzzleMoveTrans, dragControlMgr, canvasScaler);
            puzzleItemUI.InitComp(generalPanelUI, puzzleMoveTrans, dragController);
            //TODO:限制广告方块的点击，即设置解锁状态
            puzzleItemUI.puzzleItemData.InitButtomPuzzleItemData(this.transform.childCount - 1, puzzleWidth, puzzleHeight, puzzleLayout, puzzleCenter, true);
            puzzleItemUI.InitButtomPuzzleItemUI();
            puzzleItemUI.ScaleRatioOfPanelGrid = scaleRatioOfPanelGrid;

            adPuzzleNum++;

            return puzzleItem;
        }
        return null;

    }

    public void ResetAdPuzzleUse()
    {
        //adPuzzleUseFlag = false;//没有用于实际判断，暂时注释
        adPuzzleNum = 0;
    }

    public void UnlockAdPuzzle()
    {
        //TODO：接入广告界面
        AdMgr.GetInstance().showRewardVideo(() =>
        {
            Debug.Log("play ad succ");
            //隐藏广告按钮
            if (puzzleBarForFreeLayoutTrans.childCount > 0)
            {
                puzzleBarForFreeLayoutTrans.GetChild(0).gameObject.SetActive(false);
            }

            //将拼图lockstate设置为false
            if (adPuzzleNum == 1)
            {
                Transform adPuzzleTrans = this.transform.GetChild(this.transform.childCount - 1);
                PuzzleItemUI adPuzzleUI = adPuzzleTrans.GetComponent<PuzzleItemUI>();
                PuzzleItemData adPuzzleData = adPuzzleUI.puzzleItemData;
                adPuzzleData.Plockstate = false;
            }

            //将useflag设为true
            //adPuzzleUseFlag = true;//没有用于实际判断，暂时注释
        },
        () =>
        {
            Debug.Log("play ad fail");
        },
        () =>
        {
            Debug.Log("close ad");
        });
    }

}
