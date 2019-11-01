using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragController : MonoBehaviour
{
    public PanelTransformationController panelTransformationController;
    public MiniMapController miniMapController;

    public float finalUpMoveDistance = 0.6f;
    public float finalUpMoveTime = 0.06f;

    private float upMoveDistance = 0.0f;//实时上移距离，发生上移时，该值变大，OnBeginDrag和OnDrag的位置确定需要参考该值
    private bool upFlag;
    private PointerEventData curPointerEventData = new PointerEventData(EventSystem.current);

    private bool generalDragFlag = false;
    public bool GeneralDragFlag
    {
        get { return generalDragFlag; }
    }

    private bool gameOverFlag = false;
    public bool GameOverFlag
    {
        get { return gameOverFlag; }
        set { gameOverFlag = value; }
    }



    [DllImport("__Internal")]
    private static extern void VibrateFeedback();


    private bool beginDragFlag = false;
    public void OnBeginDrag(PointerEventData pointerEventData, PuzzleItemUI puzzleItemUI, GeneralPanelUI generalPanelUI)
    {
        if (gameOverFlag)
        {
            return;
        }
        if (puzzleItemUI.puzzleItemData.Plockstate)
        {
            return;
        }
        if (Input.touchCount > 1)
        {
            return;
        }
        miniMapController.RefreshFlag = true;
        generalDragFlag = true;

        if (!beginDragFlag)
        {
            beginDragFlag = true;
            dragPuzzle = puzzleItemUI;

            //Debug.Log("Drag begin");


            //TODO：手机震动一下
#if UNITY_EDITOR
            Debug.Log("Play vibration");
#else
       VibrateFeedback();
    //    Handheld.Vibrate();
#endif

            PuzzleItemData puzzleItemData = puzzleItemUI.puzzleItemData;
            //FINISH:开始拖动拼图时，生成（或显示）一块可以跟随手指的拼图，生成（显示）时规定好位置和大小（修改scale缩放即可）

            if (!puzzleItemData.NotSettleFlag)
            {
                //?如果开始拖动的是已经摆放好的拼图，就先隐藏，但是隐藏会影响多个接口的使用，可以把它scale缩小为0
                puzzleItemUI.transform.localScale = Vector3.zero;

                //FINISH:同时还要修改GeneralPanel的layout数组，先记录一次上次插入时的格子的坐标，再消去Puzzle         
                puzzleItemData.LastPanelGridIndex = puzzleItemData.PanelGridIndex;
                generalPanelUI.generalPanelData.ModiLayout(GeneralPanelData.GridType.Blank, puzzleItemData);
            }

            float gridLength = generalPanelUI.GridLength;

            //FINISH:修改大小
            //FINISH:加上双指缩放的比例
            //根据摄像机的缩放比例调整拼图的scaleratio
            puzzleItemUI.SetScaleRatio();
            float ratio = puzzleItemUI.ScaleRatio * panelTransformationController.ScaleRatio;
            Debug.Log(ratio + " " + puzzleItemUI.ScaleRatio + " " + panelTransformationController.ScaleRatio);
            puzzleItemUI.cloneForMove.GetComponent<RectTransform>().localScale = new Vector3(ratio, ratio, 1);

            //FINISH:修改旋转
            //根据PuzzleItemUI的RotateState进行旋转
            PuzzleItemUI cloneForMovePuzzleItemUI = puzzleItemUI.cloneForMove.GetComponent<PuzzleItemUI>();
            cloneForMovePuzzleItemUI.RotatePuzzleToState(puzzleItemUI.RotateState);

            //FINISH:修改位置
            Vector3 puzzleBeginPosPre = Camera.main.ScreenToWorldPoint(pointerEventData.position);
            puzzleItemUI.cloneForMove.transform.position = new Vector3(puzzleBeginPosPre.x, puzzleBeginPosPre.y, puzzleItemUI.cloneForMove.transform.position.z);
            puzzleItemUI.cloneForMove.SetActive(true);

            StartCoroutine(UpMove(Vector3.up * finalUpMoveDistance, finalUpMoveTime));//!可以调整上移的距离和下落时间
            curPointerEventData.position = pointerEventData.position;
            StartCoroutine(UpdatePos(puzzleItemUI.cloneForMove.transform));


            beginDragFlag = false;



            // !Test：输出cloneForMove的旋转角度：
            // float angle;
            // Vector3 axis;
            // puzzleItemUI.cloneForMove.transform.rotation.ToAngleAxis(out angle, out axis);
            // Debug.Log("angle::" + angle + "\n" + "axis::" + axis);




            // !Test：输出puzzleItemUI cloneForMove的layout:
            // string test = "puzzleItemUI cloneForMove Layout::\n";
            // PuzzleItemData testpd = puzzleItemUI.cloneForMove.GetComponent<PuzzleItemUI>().puzzleItemData;
            // int[] testlayout = testpd.Playout;
            // for (int i = 0; i < testlayout.Length; ++i)
            // {
            //     test += testlayout[i].ToString() + " ";
            //     if (i > 0 && (i + 1) % (testpd.Pwidth) == 0)
            //     {
            //         test += "\n";
            //     }
            // }
            // Debug.Log(test);
        }

    }

    private bool dragFlag = false;
    private PuzzleItemUI dragPuzzle = null;
    public void OnDrag(PointerEventData pointerEventData, PuzzleItemUI puzzleItemUI, GeneralPanelUI generalPanelUI)
    {
        if (gameOverFlag)
        {
            return;
        }
        if (puzzleItemUI.puzzleItemData.Plockstate)
        {
            return;
        }
        if (dragPuzzle != puzzleItemUI)
        {
            return;
        }
        miniMapController.RefreshFlag = true;


        if (!dragFlag)
        {
            dragFlag = true;
            PuzzleItemData puzzleItemData = puzzleItemUI.puzzleItemData;
            //拖动时拼图跟随手指位置移动
            //FINISH:在此过程中拼图会和面板产生交互

            Vector3 puzzlePosPre = Camera.main.ScreenToWorldPoint(pointerEventData.position) + Vector3.up * upMoveDistance;
            puzzleItemUI.cloneForMove.transform.position = new Vector3(puzzlePosPre.x, puzzlePosPre.y, puzzleItemUI.cloneForMove.transform.position.z);
            curPointerEventData.position = pointerEventData.position;

            int gridIndex = -1;
            int[] blankLayout = null;
            int interactRet = generalPanelUI.InteractWithPuzzle(puzzleItemUI.cloneForMove.GetComponent<PuzzleItemUI>(), out gridIndex, out blankLayout);
            puzzleItemData.PanelGridIndex = gridIndex;

            generalPanelUI.ShowPreCheckResult(interactRet, puzzleItemUI, blankLayout);
            dragFlag = false;
        }

    }

    private bool endDragFlag = false;
    public void OnEndDrag(PointerEventData pointerEventData, PuzzleItemUI puzzleItemUI, GeneralPanelUI generalPanelUI)
    {
        if (gameOverFlag)
        {
            return;
        }
        if (puzzleItemUI.puzzleItemData.Plockstate)
        {
            return;
        }
        if (dragPuzzle != puzzleItemUI)
        {
            return;
        }
        miniMapController.RefreshFlag = true;

        if (!endDragFlag)
        {
            endDragFlag = true;

            //拖动结束后，满足一定条件时拼图可以被插进面板，否则移除生成的拼图（隐藏显示）
            PuzzleItemData puzzleItemData = puzzleItemUI.puzzleItemData;
            Debug.Log("End Drag At:" + pointerEventData.position);
            puzzleItemUI.cloneForMove.SetActive(false);

            int gridIndex = -1;
            int[] blankLayout = null;
            int interactRet = generalPanelUI.InteractWithPuzzle(puzzleItemUI.cloneForMove.GetComponent<PuzzleItemUI>(), out gridIndex, out blankLayout);

            puzzleItemData.PanelGridIndex = gridIndex;

            generalPanelUI.ShowPreCheckResult(2);

            //FINISH：进行操作记录，interactRet为0时，进行填充记录或位置移动记录；interactRet为3时，进行删除记录(操作历史记录的实现写于GeneralPanelUI中)

            if (interactRet == 0)//如果拼图在满足填充条件的位置
            {
                //把拼图插入
                generalPanelUI.InsertPuzzle(puzzleItemUI.gameObject);

            }
            else if (interactRet == 1 || interactRet == 2)//如果拼图在不满足填充条件以及不在删除区的其他位置
            {
                if (!puzzleItemData.NotSettleFlag)//如果被开始拖的拼图已经放置了
                {
                    puzzleItemData.PanelGridIndex = puzzleItemData.LastPanelGridIndex;
                    generalPanelUI.InsertPuzzle(puzzleItemUI.gameObject, false);
                }

                Debug.Log("not fit " + interactRet);
            }
            else if (interactRet == 3)//如果拼图在删除区
            {
                //删除
                if (!puzzleItemData.NotSettleFlag)
                {
                    Debug.Log("删除拼图");
                    puzzleItemData.PanelGridIndex = puzzleItemData.LastPanelGridIndex;
                    generalPanelUI.RemovePuzzle(puzzleItemUI.gameObject);
                }
            }

            //TODO:deleteArea缩小为1
            generalPanelUI.OnDeleteAreaFlag = false;
            StartCoroutine(generalPanelUI.DeleteAreaLinearScaleDown());
            // generalPanelUI.deleteArea.transform.localScale = Vector3.one;

            endDragFlag = false;
        }

        generalDragFlag = false;

    }


    public IEnumerator UpMove(Vector3 moveVec, float time)
    {
        upMoveDistance = 0.0f;
        upFlag = true;

        float distance = Vector3.Magnitude(moveVec);
        float speed = distance / time;

        while (time > 0)
        {
            upMoveDistance += speed * Time.deltaTime;
            time -= Time.deltaTime;
            yield return null;
        }
        upFlag = false;
    }

    IEnumerator UpdatePos(Transform transform)
    {
        while (upFlag)
        {
            Vector3 pointerPos = Camera.main.ScreenToWorldPoint(curPointerEventData.position);
            transform.position = new Vector3(pointerPos.x, pointerPos.y, transform.position.z) + Vector3.up * upMoveDistance;
            yield return null;
        }
    }

}
