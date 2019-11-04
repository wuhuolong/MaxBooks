using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//FINISH:分离UI逻辑和数据逻辑
public class PuzzleItemUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //场景对象/组件：
    // public Camera playFieldCamera;
    public GeneralPanelUI generalPanelUI;
    public Transform puzzleMoveTrans;
    public DragController dragController;
    // public CanvasScaler canvasScaler;


    //格子Prefab：
    public GameObject puzzleGridPrefab1;
    public GameObject puzzleGridPrefab2;
    public GameObject puzzleGridPrefab3;
    public GameObject puzzleGridPrefab4;
    public GameObject puzzleGridPrefab5;
    public GameObject puzzleGridPrefab6;
    public GameObject nonGridPrefab;

    //同对象组件：
    public PuzzleItemData puzzleItemData;

    //绑定/生成的对象：
    public GameObject cloneForMove;
    public RectTransform screenSpaceRectTransform;//原始的屏幕空间的puzzle的rectTransform，用于做缩放比例计算

    //拖动状态
    private bool draggedState = false;
    public bool DraggedState
    {
        get { return draggedState; }
        set { draggedState = value; }
    }


    //拼图的一些UI相关的变量：
    private float scaleRatio = 1.0f;

    public float ScaleRatio
    {
        get { return scaleRatio; }
        set { scaleRatio = value; }
    }

    private float scaleRatioOfPanelGrid = 1.0f;
    public float ScaleRatioOfPanelGrid
    {
        set { scaleRatioOfPanelGrid = value; }
    }

    private int rotateState = 0;//0表示未旋转、1表示旋转90度、2表示180度、3表示270度
    public int RotateState
    {
        get { return rotateState; }
        set { rotateState = value; }
    }


    public void InitComp(/*Camera playFieldCamera,*/ GeneralPanelUI generalPanelUI, Transform puzzleMoveTrans, DragController dragController /* , CanvasScaler canvasScaler*/)
    {
        // this.playFieldCamera = playFieldCamera;
        this.generalPanelUI = generalPanelUI;
        this.puzzleMoveTrans = puzzleMoveTrans;
        this.dragController = dragController;
        // this.canvasScaler = canvasScaler;

        puzzleItemData = new PuzzleItemData();
        screenSpaceRectTransform = GetComponent<RectTransform>();
    }

    public void InitButtomPuzzleItemUI()
    {
        int[] Playout = puzzleItemData.Playout;
        int[] Pcenter = puzzleItemData.Pcenter;
        int Pwidth = puzzleItemData.Pwidth;
        int Pheight = puzzleItemData.Pheight;

        //FINISH:用以上数组生成拼图
        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();
        float cellSize = gridLayoutGroup.cellSize.x;
        GetComponent<RectTransform>().sizeDelta = new Vector2(cellSize * Pwidth, cellSize * Pheight);

        for (int i = 0; i < Playout.Length; ++i)
        {
            if (Playout[i] == 0)
            {
                GameObject.Instantiate(nonGridPrefab, this.transform);
            }
            else
            {
                int x = i % Pwidth;
                int y = i / Pwidth;
                List<bool> outlineSides = new List<bool> { false, false, false, false }; int outlineNum = 0;
                if (x - 1 < 0 || ((x - 1) >= 0 && Playout[x - 1 + Pwidth * y] == 0))
                {
                    outlineSides[0] = true;
                    outlineNum++;
                }
                if (y - 1 < 0 || ((y - 1) >= 0 && Playout[x + Pwidth * (y - 1)] == 0))
                {
                    outlineSides[1] = true;
                    outlineNum++;
                }
                if (x + 1 >= Pwidth || ((x + 1) < Pwidth && Playout[x + 1 + Pwidth * y] == 0))
                {
                    outlineSides[2] = true;
                    outlineNum++;
                }
                if (y + 1 >= Pheight || ((y + 1) < Pheight && Playout[x + Pwidth * (y + 1)] == 0))
                {
                    outlineSides[3] = true;
                    outlineNum++;
                }

                float rotateAngle;

                switch (outlineNum)
                {
                    case 0:
                        {
                            GameObject.Instantiate(puzzleGridPrefab6, this.transform);
                            break;
                        }
                    case 1:
                        {
                            int findOutlineSide = outlineSides.FindIndex((bool a) => a == true);
                            rotateAngle = -90 * (findOutlineSide + 1);
                            GameObject newPuzzleGrid = GameObject.Instantiate(puzzleGridPrefab5, this.transform);
                            newPuzzleGrid.GetComponent<RectTransform>().Rotate(Vector3.forward, rotateAngle);
                            break;
                        }
                    case 2:
                        {
                            int findOutlineSide1 = outlineSides.FindIndex((bool a) => a == true);
                            int findOutlineSide2 = outlineSides.FindLastIndex((bool a) => a == true);
                            if ((findOutlineSide1 == 0 && findOutlineSide2 == 1))
                            {
                                GameObject newPuzzleGrid = GameObject.Instantiate(puzzleGridPrefab4, this.transform);
                                newPuzzleGrid.GetComponent<RectTransform>().Rotate(Vector3.forward, -90);
                            }
                            else if ((findOutlineSide1 == 0 && findOutlineSide2 == 2))
                            {
                                GameObject newPuzzleGrid = GameObject.Instantiate(puzzleGridPrefab3, this.transform);
                            }
                            else if ((findOutlineSide1 == 0 && findOutlineSide2 == 3))
                            {
                                GameObject newPuzzleGrid = GameObject.Instantiate(puzzleGridPrefab4, this.transform);
                            }
                            else if ((findOutlineSide1 == 1 && findOutlineSide2 == 2))
                            {
                                GameObject newPuzzleGrid = GameObject.Instantiate(puzzleGridPrefab4, this.transform);
                                newPuzzleGrid.GetComponent<RectTransform>().Rotate(Vector3.forward, 180);
                            }
                            else if ((findOutlineSide1 == 1 && findOutlineSide2 == 3))
                            {
                                GameObject newPuzzleGrid = GameObject.Instantiate(puzzleGridPrefab3, this.transform);
                                newPuzzleGrid.GetComponent<RectTransform>().Rotate(Vector3.forward, -90);
                            }
                            else if ((findOutlineSide1 == 2 && findOutlineSide2 == 3))
                            {
                                GameObject newPuzzleGrid = GameObject.Instantiate(puzzleGridPrefab4, this.transform);
                                newPuzzleGrid.GetComponent<RectTransform>().Rotate(Vector3.forward, 90);
                            }
                        }
                        break;
                    case 3:
                        {
                            int findOutlineSide = outlineSides.FindIndex((bool a) => a == false);
                            rotateAngle = -90 * (findOutlineSide - 1);

                            GameObject newPuzzleGrid = GameObject.Instantiate(puzzleGridPrefab2, this.transform);
                            newPuzzleGrid.GetComponent<RectTransform>().Rotate(Vector3.forward, rotateAngle);

                            break;
                        }
                    case 4:
                        {
                            GameObject.Instantiate(puzzleGridPrefab1, this.transform);
                            break;
                        }
                    default:
                        break;
                }

            }

        }
        MakeMovePuzzle();
    }

    public void MakeMovePuzzle()
    {

        if (cloneForMove == null)
        {
            cloneForMove = GameObject.Instantiate(this.gameObject, puzzleMoveTrans);
            PuzzleItemUI clonePuzzleItemUI = cloneForMove.GetComponent<PuzzleItemUI>();
            clonePuzzleItemUI.puzzleItemData = new PuzzleItemData();
            PuzzleItemData clonePuzzleItemData = clonePuzzleItemUI.puzzleItemData;

            clonePuzzleItemData.InitButtomPuzzleItemData(
            puzzleItemData.PID,
            puzzleItemData.Pwidth,
            puzzleItemData.Pheight,
            puzzleItemData.Playout,
            puzzleItemData.Pcenter);

            clonePuzzleItemUI.screenSpaceRectTransform = this.screenSpaceRectTransform;

            cloneForMove.name = this.gameObject.name + "Move";
        }
        cloneForMove.SetActive(false);
    }


    public void SetScaleRatio()
    {
        // // 修改大小
        // // gridLength是世界空间的面板格子长度，先转换为屏幕空间的长度，再算出屏幕空间内当前块的宽度，再通过宽度与实际屏幕空间宽度的比例计算scale
        // //遇到的问题：最后算出的gridScreenLength看上去比一个grid短一点，GridLength可以确定无误（使用世界空间的3D物体衡量），可能是世界空间和屏幕空间的比例计算出错

        // float metaScaleFactor = canvasScaler.referenceResolution.x / Screen.width;
        // // Debug.Log("metaScaleFactor: " + metaScaleFactor);

        //float screenWidthInWorldSpace = (playFieldCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - playFieldCamera.ScreenToWorldPoint(Vector3.zero)).x;
        //float scaleFactor = screenWidthInWorldSpace / Screen.width;
        // Debug.Log("scaleFactor: " + scaleFactor);
        //float gridScreenLength = generalPanelUI.GridLength * metaScaleFactor / scaleFactor;//(Camera.main.WorldToScreenPoint(new Vector3(0, gridLength, 0)) - Camera.main.WorldToScreenPoint(Vector3.zero)).y;

        // cloneForMove.GetComponent<RectTransform>().sizeDelta=new Vector2(gridScreenLength * (Pwidth),gridScreenLength*Pheight);
        // cloneForMove.GetComponent<GridLayoutGroup>().cellSize=new Vector2(gridScreenLength,gridScreenLength);

        if (rotateState == 0 || rotateState == 2)
        {
            scaleRatio = generalPanelUI.GridLength * (puzzleItemData.Pwidth) / screenSpaceRectTransform.sizeDelta.x * scaleRatioOfPanelGrid;//! 拼图格子长度和面板格子长度的比例可调整
        }
        else if (rotateState == 1 || rotateState == 3)
        {
            scaleRatio = generalPanelUI.GridLength * (puzzleItemData.Pwidth) / screenSpaceRectTransform.sizeDelta.y * scaleRatioOfPanelGrid;//! 拼图格子长度和面板格子长度的比例可调整
        }

    }

    public void RotatePuzzleToState(int defineRotateState)
    {
        int revertRotateTimes = 4 - rotateState;

        for (int i = 0; i < revertRotateTimes; ++i)
        {
            RotatePuzzleOnce();
        }

        for (int i = 0; i < defineRotateState; ++i)
        {
            RotatePuzzleOnce();
        }
    }


    public void RotatePuzzleOnce()
    {
        //FINISH:旋转拼图，需要做的是修改UI（把拼图的rectTransform的rotation进行修改即可）,以及修改拼图的Data（修改pwidth，pheight，playout，pcenter）
        GetComponent<RectTransform>().Rotate(Vector3.forward, -90);
        rotateState++;
        if (rotateState == 4)
        {
            rotateState = 0;
        }

        puzzleItemData.RotatePuzzle();
    }


    private float startClickTime = 0.0f;
    private bool clickState = false;
    private bool dragState = false;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //按下手指在拼图上时，先记录一个按下的时间，
        //并将clickstate设为true，表示默认将本次操作作为点击，会发生旋转；
        //并将dragstate设为false；
        //然后等待一段时间，如果时间内发生drag操作就说明这次操作不是点击
        startClickTime = Time.time;
        clickState = true;
        dragState = false;

        StartCoroutine(WaitDrag(pointerEventData));
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        float endClickTime = Time.time;
        float duration = endClickTime - startClickTime;
        if (clickState)//如果松手时是clickstate，说明是点击，并分析是否进行旋转
        {
            clickState = false;

            if (puzzleItemData.NotSettleFlag)
            {
                //FINISH:在没放置时，点击一下旋转拼图
                //TODO:旋转动画
                Debug.Log("just click");
                RotatePuzzleOnce();
            }
        }
        else//如果松手时不是clickstate，就判断是否是dragstate，如果是dragstate就调用dragcontroller的onEndDrag
        {
            if (dragState)
            {
                dragController.OnEndDrag(pointerEventData, this, generalPanelUI);
            }
        }

    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        //该回调在开始拖拽的瞬间被调用，如果不是dragstate才会继续，避免与waitdrag时的检测发生冲突
        GetComponent<Animator>().enabled = false;
        if (!dragState)
        {
            dragController.OnBeginDrag(pointerEventData, this, generalPanelUI);
            clickState = false;
            dragState = true;
        }
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        //该回调在拖拽时被调用
        dragController.OnDrag(pointerEventData, this, generalPanelUI);
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        //该回调在结束拖拽时被调用，只有不是dragstate才会继续，避免与onPointerUp时的检测冲突
        if (!dragState)
        {
            dragController.OnEndDrag(pointerEventData, this, generalPanelUI);
        }
    }

    public IEnumerator WaitDrag(PointerEventData pointerEventData)
    {
        //等待拖动
        //有三种case：
        //如果按下手指之后的限定时间（在这里默认是0.125s）内松手（调用onPointerUp），则clickstate会发生改变为false，dragstate不发生改变，为false，说明发生了点击旋转事件，没有等待到拖动；
        //如果按下手指之后的限定时间（在这里默认是0.125s）内拖动（调用onBeginDrag），则clickstate发生改变，为false，dragstate发生改变，为true，说明等到了拖动事件，并且点击旋转事件不再发生，以及限定时间外也不再发生拖动事件；
        //如果按下手指0.125s后还没松手，也没拖动，clickstate则为true，且会在随后变化为false，dragstate为false，且在之后变化为true，说明等到了拖动，执行以下语句
        //  -如果按下手指0.125s后拖动：由于下方语句已经调用dragcontroller中的onBeginDrag且把dragstate设为true，回调函数onBeginDrag中不会再调用dragcontroller中的函数
        //  -如果按下手指0.125s后拖动，然后松手：onBeginDrag内部中断；并且由于clickstate已经变为false，dragstate已经变为true，onpointerup中会调用dragcontroller中的onEndDrag，而回调函数onEndDrag内部中断
        //  -如果按下手指0.125s后不拖动，并松手：由于clickstate已经变为false，dragstate已经变为true，onpointerup中会调用dragcontroller中的onEndDrag，而回调函数onEndDrag内部中断
        while (Time.time - startClickTime < 0.125f)
        {
            yield return null;
        }
        if (clickState && !dragState)
        {
            GetComponent<Animator>().enabled = false;
            dragController.OnBeginDrag(pointerEventData, this, generalPanelUI);
            clickState = false;
            dragState = true;
        }
    }

    public void PlaySettleAnim()
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled = true;
        animator.Play("Puzz", 0, 0f);
    }

    public void StopSettleAnim()
    {
        GetComponent<Animator>().enabled = false;
    }
}
