﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

//FINISH:分离UI逻辑和数据逻辑
public class GeneralPanelUI : MonoBehaviour
{

    //面板的真实长宽和格子的真实长宽：
    private float PX = 0.0f;
    private float PY = 0.0f;
    private float gridLength = 0.0f;
    public float GridLength
    {
        get
        {
            return gridLength;
        }
    }

    //场景对象/组件：
    // public RectTransform spaceTrans;//MainUICanvas中的Space，用于面板大小初始化
    // public Camera playFieldCamera;//playFieldCanvas对应的Camera
    // public RectTransform playFieldCanvasTrans;//playFieldCanvas，处于世界空间
    public CanvasScaler canvasScaler;//当前canvas
    public Transform preCheckPanelTrans;//预判断面板preCheckPanel的Transfrom，即预判断的红色和绿色的块所处的对象的父对象的Transform，位于playField
    public Transform puzzleContainPanelTrans;//放置puzzle的面板puzzleContainPanel的Transform，位于playField
    public Transform whiteLightPanelTrans;//放置白光的面板whiteLightPanel的Transform，位于playField上层
    public GameObject deleteArea;//删除区对象
    public OperationHistoryRecorder operationHistoryRecorder;//操作历史记录器
    public UIPlay uiplayPage;

    //各种格子的Prefab：
    public GameObject nonGridPrefab;
    public GameObject blankGridPrefab;
    public GameObject fixGridPrefab;
    public GameObject preCheckGreenGridPrefab;
    public GameObject preCheckRedGridPrefab;
    public GameObject whiteLightGridPrefab;
    public ParticleSystem deleteParticleEffect;
    public ParticleSystem sparkParticleEffect;

    //同对象组件：
    public GeneralPanelData generalPanelData;
    private GridLayoutGroup gridLayoutGroup;

    //面板中的拼图：
    private List<GameObject> settlePuzzleList = new List<GameObject>();

    // private float xRatio = 0.0f;
    // private float yRatio = 0.0f;


    public void InitComp(bool isregen = false)
    {
        generalPanelData = new GeneralPanelData();
        generalPanelData.InitGeneralPanelData(isregen);
    }

    public void InitGeneralPanelUI()
    {
        deleteParticleEffect.transform.position = new Vector3(deleteArea.transform.position.x, deleteArea.transform.position.y, deleteParticleEffect.transform.position.z);

        settlePuzzleList.Clear();

        gridLayoutGroup = GetComponent<GridLayoutGroup>();

        // //通过一个不渲染的UI对象Space确定面板的中心位置、长度、宽度等

        // playFieldCanvasTrans.position = new Vector3(spaceTrans.position.x, spaceTrans.position.y, playFieldCanvasTrans.transform.position.z);

        // //获取Space的长宽
        // Vector3[] worldCornersOfSpace = new Vector3[4];
        // spaceTrans.GetWorldCorners(worldCornersOfSpace);

        // Vector3 leftUpperCornerPos = worldCornersOfSpace[1];
        // Vector3 rightLowerCornerPos = worldCornersOfSpace[3];

        // //!test
        // Debug.Log("rightLowerCornerPos:" + rightLowerCornerPos);
        // Debug.Log("leftUpperCornerPos:" + leftUpperCornerPos);


        // float spaceX = rightLowerCornerPos.x - leftUpperCornerPos.x;
        // float spaceY = leftUpperCornerPos.y - rightLowerCornerPos.y;

        // //奇怪的bug：如果长和宽是1080*1920（与canvasScaler里设置的referenceResolution一致），就会导致GetWorldCorners获取到的四个角的坐标的x被拉到很远的位置
        // 解决方法：
        // if (Screen.width == canvasScaler.referenceResolution.x && Screen.height == canvasScaler.referenceResolution.y)
        // {
        //     spaceX = playFieldCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x * 2;
        // }

        int Pwidth = generalPanelData.Pwidth;
        int Pheight = generalPanelData.Pheight;
        int[] Playout = generalPanelData.Playout;

        RectTransform playFieldRectTrans = this.transform.parent.GetComponent<RectTransform>();

        float spaceX = playFieldRectTrans.rect.width;
        float spaceY = playFieldRectTrans.rect.height;

        // xRatio = canvasScaler.referenceResolution.x / (float)Screen.width;
        // yRatio = canvasScaler.referenceResolution.y / (float)Screen.height;

        //根据面板的长度和宽度（两个方向的格子数量）、playField的长度和宽度，计算出面板的真实长宽
        float GPratio = (float)Pwidth / (float)Pheight;
        if (GPratio <= spaceX / spaceY)
        {
            PY = spaceY;
            PX = GPratio * PY;
        }
        else
        {
            PX = spaceX;
            PY = PX / GPratio;
        }

        // //修改PlayFieldCanvas的真实长宽、其中的面板（当前面板、puzzleContainPanel）的真实长宽、以及一个格子的真实边长
        // playFieldCanvasTrans.sizeDelta = new Vector2(spaceX, spaceY);

        //FINISH：修改面板（当前面板、puzzleContainPanel）的真实长宽、以及一个格子的真实边长
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(PX, PY);
        gridLength = PX / Pwidth;
        Debug.Log("PX=" + PX);
        Debug.Log("gridLength:" + gridLength);
        gridLayoutGroup.cellSize = new Vector2(gridLength, gridLength);

        puzzleContainPanelTrans.GetComponent<RectTransform>().sizeDelta = new Vector2(PX, PY);
        preCheckPanelTrans.GetComponent<RectTransform>().sizeDelta = new Vector2(PX, PY);
        preCheckPanelTrans.GetComponent<GridLayoutGroup>().cellSize = new Vector2(gridLength, gridLength);
        whiteLightPanelTrans.GetComponent<RectTransform>().sizeDelta = new Vector2(PX, PY);
        whiteLightPanelTrans.GetComponent<GridLayoutGroup>().cellSize = new Vector2(gridLength, gridLength);

        //FINISH:利用上面的数组搭建面板
        //TODO:利用对象池优化
        //!此处逻辑应该改为显示面板，在游戏打开时就要搭建面板了
        foreach (GeneralPanelData.GridType i in Playout)
        {
            switch (i)
            {
                case GeneralPanelData.GridType.Non:
                    {
                        GameObject grid = GameObject.Instantiate(nonGridPrefab, this.transform);
                        GameObject preCheckGrid = new GameObject("PreCheckGrid");
                        preCheckGrid.AddComponent<RectTransform>();
                        preCheckGrid.transform.SetParent(preCheckPanelTrans, false);
                        GameObject.Instantiate(preCheckGreenGridPrefab, preCheckGrid.transform).SetActive(false);
                        GameObject.Instantiate(preCheckRedGridPrefab, preCheckGrid.transform).SetActive(false);

                        GameObject.Instantiate(nonGridPrefab, whiteLightPanelTrans.transform);

                        break;
                    }
                case GeneralPanelData.GridType.Blank:
                    {
                        GameObject grid = GameObject.Instantiate(blankGridPrefab, this.transform);

                        GameObject preCheckGrid = new GameObject("PreCheckGrid");
                        preCheckGrid.AddComponent<RectTransform>();
                        preCheckGrid.transform.SetParent(preCheckPanelTrans, false);
                        GameObject.Instantiate(preCheckGreenGridPrefab, preCheckGrid.transform).SetActive(false);
                        GameObject.Instantiate(preCheckRedGridPrefab, preCheckGrid.transform).SetActive(false);

                        GameObject.Instantiate(whiteLightGridPrefab, whiteLightPanelTrans.transform);

                        break;
                    }
                case GeneralPanelData.GridType.Fix:
                    {
                        GameObject grid = GameObject.Instantiate(fixGridPrefab, this.transform);
                        GameObject preCheckGrid = new GameObject("PreCheckGrid");
                        preCheckGrid.AddComponent<RectTransform>();
                        preCheckGrid.transform.SetParent(preCheckPanelTrans, false);
                        GameObject.Instantiate(preCheckGreenGridPrefab, preCheckGrid.transform).SetActive(false);
                        GameObject.Instantiate(preCheckRedGridPrefab, preCheckGrid.transform).SetActive(false);

                        GameObject.Instantiate(whiteLightGridPrefab, whiteLightPanelTrans.transform);

                        break;
                    }
                case GeneralPanelData.GridType.Fill:
                    {
                        GameObject grid = GameObject.Instantiate(blankGridPrefab, this.transform);
                        GameObject preCheckGrid = new GameObject("PreCheckGrid");
                        preCheckGrid.AddComponent<RectTransform>();
                        preCheckGrid.transform.SetParent(preCheckPanelTrans, false);
                        GameObject.Instantiate(preCheckGreenGridPrefab, preCheckGrid.transform).SetActive(false);
                        GameObject.Instantiate(preCheckRedGridPrefab, preCheckGrid.transform).SetActive(false);

                        GameObject.Instantiate(whiteLightGridPrefab, whiteLightPanelTrans.transform);

                        break;
                    }
                default:
                    break;
            }

        }

    }


    public int InteractWithPuzzle(PuzzleItemUI puzzleItemUI, out int panelGridIndex, out int[] outputBlankLayout)
    {
        //关于返回值：0表示拼图在面板中的位置是满足填充条件的位置，可以填充；1表示拼图在面板中，但不满足填充条件；2表示拼图不在面板中，也不在删除区；3表示拼图在删除区
        PuzzleItemData puzzleItemData = puzzleItemUI.puzzleItemData;

        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        pointerData.position = Camera.main.WorldToScreenPoint(puzzleItemUI.transform.GetChild((int)(puzzleItemData.Pcenter[0] + puzzleItemData.Pwidth * puzzleItemData.Pcenter[1])).position);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        if (results.Count > 0)
        {
            //此时results[0]是当前拼图上的格子，results[...]才是底下的东西
            //如果射到的是格子，其父对象必为当前脚本挂载的对象，即GeneralPanel面板
            GameObject hitObj = results.Find((RaycastResult a) => a.gameObject.transform.parent == this.transform).gameObject;

            if (hitObj != null)
            {
                int gridIndex = hitObj.transform.GetSiblingIndex();
                int[] blankLayout;
                bool isFit = generalPanelData.IsFit(puzzleItemData, gridIndex, out blankLayout);

                panelGridIndex = gridIndex;
                outputBlankLayout = blankLayout;


                if (isFit)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }

            }

            // 输出射线射到的所有对象：
            // string allhit = "hit:::\n";
            // foreach (RaycastResult r in results)
            // {
            //     allhit += r.gameObject.name + "\n";
            // }
            // Debug.Log(allhit);

            GameObject hitObj2 = results.Find((RaycastResult a) => a.gameObject.transform == deleteArea.transform).gameObject;
            if (hitObj2 != null)
            {
                deleteArea.transform.localScale = Vector3.one * 1.1f;
                panelGridIndex = -1;
                outputBlankLayout = null;
                return 3;
            }
            else
            {
                deleteArea.transform.localScale = Vector3.one;
            }



        }

        panelGridIndex = -1;
        outputBlankLayout = null;
        return 2;
    }

    public void ClearBothIndices()
    {
        List<int> greenGridIndices = generalPanelData.GreenGridIndices;
        List<int> redGridIndices = generalPanelData.RedGridIndices;

        for (int i = 0; i < greenGridIndices.Count; ++i)
        {
            int greenGridIndex = greenGridIndices[i];
            if (greenGridIndex >= preCheckPanelTrans.childCount)
            {
                Debug.Log("greenGridIndex OUTOFBOUNDRY:" + greenGridIndex);
            }
            preCheckPanelTrans.GetChild(greenGridIndex).GetChild(0).gameObject.SetActive(false);
        }
        for (int i = 0; i < redGridIndices.Count; ++i)
        {
            int redGridIndex = redGridIndices[i];
            preCheckPanelTrans.GetChild(redGridIndex).GetChild(1).gameObject.SetActive(false);
        }
        generalPanelData.ClearBothIndices();
    }

    public void ShowGreenGrids()
    {
        List<int> greenGridIndices = generalPanelData.GreenGridIndices;
        for (int i = 0; i < greenGridIndices.Count; ++i)
        {
            int greenGridIndex = greenGridIndices[i];
            preCheckPanelTrans.GetChild(greenGridIndex).GetChild(0).gameObject.SetActive(true);
        }
    }

    public void ShowRedGrids()
    {
        List<int> redGridIndices = generalPanelData.RedGridIndices;
        for (int i = 0; i < redGridIndices.Count; ++i)
        {
            int redGridIndex = redGridIndices[i];
            preCheckPanelTrans.GetChild(redGridIndex).GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ShowPreCheckResult(int state, PuzzleItemUI puzzleItemUI = null, int[] blankLayout = null)
    {
        //Fit state：
        //0表示Fit，
        //1表示unFit，
        //2 及以上表示没在格子上，全部PreCheck的红绿格都要隐藏
        if (state >= 2)
        {
            ClearBothIndices();
            return;
        }

        PuzzleItemData puzzleItemData = puzzleItemUI.puzzleItemData;
        int gridIndex = puzzleItemData.PanelGridIndex;

        int x = gridIndex % generalPanelData.Pwidth;
        int y = gridIndex / generalPanelData.Pheight;
        int[] puzzleLayout = puzzleItemData.Playout;

        if (generalPanelData.CheckDirtyFlag(gridIndex))
        {
            if (state == 0)//绿色
            {
                //清空greenGridIndices和redGridIndices
                ClearBothIndices();

                //添加greenGridIndices
                generalPanelData.AddToGreenGridIndices(puzzleItemData);

                //显示绿色的grids
                ShowGreenGrids();

            }
            else if (state == 1)//红色
            {
                //清空greenGridIndices和redGridIndices
                ClearBothIndices();

                //添加redGridIndices
                generalPanelData.AddToRedGridIndices(puzzleItemData, blankLayout);

                //显示红色的grid
                ShowRedGrids();

            }
            generalPanelData.LastGridIndex = gridIndex;
        }
        else
        {
            //如果dirtyflag是false，不刷新
            //do nothing
        }

    }

    public void InsertPuzzle(GameObject puzzle = null, bool opRecordFlag = true)
    {
        Debug.Log("insert!");
        PuzzleItemUI puzzleItemUI = puzzle.GetComponent<PuzzleItemUI>();
        PuzzleItemData puzzleItemData = puzzleItemUI.puzzleItemData;

        int gridIndex = puzzleItemData.PanelGridIndex;

        if (puzzleItemData.NotSettleFlag)
        {
            //删除摄像机后不存在屏幕空间与世界空间的区分，但仍保留放置与否的区分
            //如果是从底部拖上来的拼图：
            //插入拼图时，生成一份新的拼图放在当前面板的同级面板puzzleContainPanel中
            //FINISH：如果在puzzleContainPanel中（即settlePuzzleList中）存在一个位置（gridIndex）相同，playout和rotatestate也相同的拼图，直接setactive即可
            bool existFlag = false;
            GameObject opPuzzle = null;
            foreach (GameObject settlePuzzle in settlePuzzleList)
            {
                PuzzleItemUI settlePuzzleItemUI = settlePuzzle.GetComponent<PuzzleItemUI>();
                PuzzleItemData settlePuzzleItemData = settlePuzzleItemUI.puzzleItemData;

                // Debug.Log(
                //     "difference:" + "\n" +
                //     settlePuzzleItemUI.RotateState + " " + puzzleItemUI.RotateState + "\n" +
                //     settlePuzzleItemData.PanelGridIndex + " " + puzzleItemData.PanelGridIndex + "\n" +
                //     MatrixUtil.PrintIntArray(settlePuzzleItemData.Playout) + " " + MatrixUtil.PrintIntArray(puzzleItemData.Playout)
                // );

                //!数组不可直接用==进行对比

                if (settlePuzzleItemUI.RotateState == puzzleItemUI.RotateState
                && settlePuzzleItemData.PanelGridIndex == puzzleItemData.PanelGridIndex
                && Enumerable.SequenceEqual(settlePuzzleItemData.Playout, puzzleItemData.Playout))
                {
                    existFlag = true;
                    opPuzzle = settlePuzzle;
                    break;
                }
            }

            if (existFlag)
            {
                opPuzzle.transform.localScale = Vector3.one;
                opPuzzle.GetComponent<PuzzleItemUI>().cloneForMove = puzzleItemUI.cloneForMove;
            }
            else
            {
                //这里还需要根据拼图的中心与pcenter的位置关系修改位置关系
                Transform gridTrans = this.transform.GetChild(gridIndex);
                float pwidthCenter = puzzleItemData.Pwidth / 2.0f;
                float pheightCenter = puzzleItemData.Pheight / 2.0f;

                float pcenterX = puzzleItemData.Pcenter[0] + 0.5f;
                float pcenterY = puzzleItemData.Pcenter[1] + 0.5f;

                float offsetX = (pwidthCenter - pcenterX) * gridLength;
                float offsetY = (pheightCenter - pcenterY) * gridLength;

                Vector3 gridTransCanvasSpacePos = gridTrans.GetComponent<RectTransform>().anchoredPosition;//Camera.main.WorldToScreenPoint(gridTrans.position);

                Vector3 newPos = new Vector3(gridTransCanvasSpacePos.x + offsetX, gridTransCanvasSpacePos.y - offsetY, puzzle.transform.position.z);

                // Debug.Log("PcenterX" + pcenterX + "PcenterY" + pcenterY + "\n" +
                //     "gridIndex:" + gridIndex + "\n" + "newPos:" + newPos + "\n" +
                // "gridTrans.position:" + gridTrans.position + " " + gridTransCanvasSpacePos + "\n" +
                // "offsetX:" + offsetX + "\n" +
                // "offsetY:" + offsetY + "\n" +
                // "gridLength:" + gridLength + "\n" +
                // "canvasScaler.scaleFactor:" + canvasScaler.scaleFactor);

                GameObject newPuzzle = GameObject.Instantiate(puzzle, puzzleContainPanelTrans);
                RectTransform newPuzzleRectTrans = newPuzzle.GetComponent<RectTransform>();
                newPuzzleRectTrans.anchorMin = new Vector2(0, 1);
                newPuzzleRectTrans.anchorMax = new Vector2(0, 1);
                newPuzzleRectTrans.anchoredPosition = newPos;

                settlePuzzleList.Add(newPuzzle);
                newPuzzle.name = "SettlePuzzle";
                //将raycastTarget设为false避免触摸空白区域会拖动当前拼图
                newPuzzle.GetComponent<Image>().raycastTarget = false;

                // Debug.Log("gen pos:" + newPuzzle.transform.position + " " + Camera.main.WorldToScreenPoint(newPuzzle.transform.position));

                PuzzleItemUI newPuzzleItemUI = newPuzzle.GetComponent<PuzzleItemUI>();
                newPuzzleItemUI.puzzleItemData = new PuzzleItemData();
                PuzzleItemData newPuzzleItemData = newPuzzleItemUI.puzzleItemData;

                //newPuzzleItemData=puzzleItemData;
                newPuzzleItemData.Pwidth = puzzleItemData.Pwidth;
                newPuzzleItemData.Pheight = puzzleItemData.Pheight;
                newPuzzleItemData.Playout = puzzleItemData.Playout;
                newPuzzleItemData.Pcenter = puzzleItemData.Pcenter;
                newPuzzleItemData.PanelGridIndex = puzzleItemData.PanelGridIndex;

                newPuzzleItemUI.ScaleRatio = puzzleItemUI.ScaleRatio;
                newPuzzleItemUI.RotateState = puzzleItemUI.RotateState;



                if (newPuzzleItemUI.RotateState == 0 || newPuzzleItemUI.RotateState == 2)
                {
                    newPuzzle.GetComponent<RectTransform>().sizeDelta = new Vector2(gridLength * newPuzzleItemData.Pwidth, gridLength * newPuzzleItemData.Pheight);
                }
                else
                {
                    newPuzzle.GetComponent<RectTransform>().sizeDelta = new Vector2(gridLength * newPuzzleItemData.Pheight, gridLength * newPuzzleItemData.Pwidth);
                }

                newPuzzle.GetComponent<GridLayoutGroup>().cellSize = new Vector2(gridLength, gridLength);

                //要为拼图设置可以移动的拼图
                newPuzzleItemData.NotSettleFlag = false;
                newPuzzleItemUI.cloneForMove = puzzleItemUI.cloneForMove;
                newPuzzleItemUI.screenSpaceRectTransform = puzzleItemUI.screenSpaceRectTransform;

                opPuzzle = newPuzzle;
            }


            int[] oldLayout = generalPanelData.Playout;
            generalPanelData.ModiLayout(GeneralPanelData.GridType.Fill, puzzleItemData);
            int[] newLayout = generalPanelData.Playout;

            puzzle.SetActive(true);

            if (opRecordFlag)
            {
                //操作历史记录
                Operation op = new Operation(0, oldLayout, newLayout, opPuzzle);
                operationHistoryRecorder.Record(op);

                //播放下落动画
                StartCoroutine(PuzzleDownMove(opPuzzle, 0.5f, 0.1f, () =>
                {
                    //检查游戏是否结束
                    if (generalPanelData.CheckOver())
                    {
                        //通关
                        //跳转到UIEnd
                        uiplayPage.LevelOverStep1();
                    }
                }));


            }
        }
        else
        {
            //-删除摄像机后不存在屏幕空间与世界空间的区分，但仍保留放置与否的区分
            //如果是从面板中拖出的拼图：
            //直接修改拼图的位置即可
            puzzle.transform.localScale = Vector3.one;
            Transform gridTrans = this.transform.GetChild(gridIndex);

            float pwidthCenter = puzzleItemData.Pwidth / 2.0f;
            float pheightCenter = puzzleItemData.Pheight / 2.0f;

            float pcenterX = puzzleItemData.Pcenter[0] + 0.5f;
            float pcenterY = puzzleItemData.Pcenter[1] + 0.5f;

            float offsetX = (pwidthCenter - pcenterX) * gridLength;
            float offsetY = (pheightCenter - pcenterY) * gridLength;

            Vector3 gridTransCanvasSpacePos = gridTrans.GetComponent<RectTransform>().anchoredPosition;

            Vector3 newPos = new Vector3(gridTransCanvasSpacePos.x + offsetX, gridTransCanvasSpacePos.y - offsetY, puzzle.transform.position.z);

            RectTransform puzzleRectTrans = puzzle.GetComponent<RectTransform>();
            puzzleRectTrans.anchorMin = new Vector2(0, 1);
            puzzleRectTrans.anchorMax = new Vector2(0, 1);
            puzzleRectTrans.anchoredPosition = newPos;

            // puzzle.transform.position = Camera.main.ScreenToWorldPoint(newPos);

            int[] oldLayout = generalPanelData.Playout;
            generalPanelData.ModiLayout(GeneralPanelData.GridType.Fill, puzzleItemData);
            int[] newLayout = generalPanelData.Playout;
            puzzle.SetActive(true);

            if (opRecordFlag)
            {
                //FINISH：操作历史记录
                Operation op = new Operation(1, oldLayout, newLayout, puzzle, puzzleItemData.LastPanelGridIndex, gridIndex);
                operationHistoryRecorder.Record(op);

                //播放下落动画
                StartCoroutine(PuzzleDownMove(puzzle, 0.5f, 0.1f, () => { }));



            }
        }


    }

    public void RemovePuzzle(GameObject puzzle, bool opRecordFlag = true)
    {
        Debug.Log("remove!");
        PuzzleItemUI puzzleItemUI = puzzle.GetComponent<PuzzleItemUI>();
        PuzzleItemData puzzleItemData = puzzleItemUI.puzzleItemData;

        //必定是已经摆放了的
        int[] oldLayout = generalPanelData.Playout;
        generalPanelData.ModiLayout(GeneralPanelData.GridType.Blank, puzzleItemData);
        int[] newLayout = generalPanelData.Playout;

        puzzle.SetActive(false);


        if (opRecordFlag)
        {
            deleteParticleEffect.Play();

            //FINISH：操作历史记录
            Operation op = new Operation(2, oldLayout, newLayout, puzzle);
            operationHistoryRecorder.Record(op);
        }

    }

    IEnumerator PuzzleDownMove(GameObject puzzle, float distance, float time, UnityAction afterAnimAction)
    {
        Vector3 finalPos = puzzle.transform.position;
        puzzle.transform.position = puzzle.transform.position + Vector3.up * distance;
        puzzle.SetActive(true);
        Vector3 originPos = puzzle.transform.position;
        Vector3 moveVec = finalPos - originPos;
        Vector3 normMoveVec = moveVec.normalized;
        float speed = distance / time;
        while (time > 0)
        {
            time -= Time.deltaTime;
            puzzle.transform.position = puzzle.transform.position + normMoveVec * speed * Time.deltaTime;
            yield return null;
        }
        puzzle.transform.position = finalPos;
        // Debug.Log("finalPos:" + finalPos + " " + Camera.main.WorldToScreenPoint(finalPos));
        puzzle.GetComponent<PuzzleItemUI>().PlaySettleAnim();
        sparkParticleEffect.transform.position = puzzle.transform.position;
        sparkParticleEffect.Play();
        afterAnimAction();
    }




}