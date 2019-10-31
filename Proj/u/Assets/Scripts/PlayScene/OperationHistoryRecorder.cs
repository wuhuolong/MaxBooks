using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SettlePuzzle
{
    public SettlePuzzle() { }
    public SettlePuzzle(int puzzleID, int puzzleRotateState, int puzzleGridIndex)
    {
        this.puzzleID = puzzleID;
        this.puzzleRotateState = puzzleRotateState;
        this.puzzleGridIndex = puzzleGridIndex;
    }
    public int puzzleID;
    public int puzzleRotateState;
    public int puzzleGridIndex;
}


[System.Serializable]
public class Operation
{

    public Operation(int opType, int[] oldLayout, int[] newLayout, GameObject opPuzzle, int lastGridIndex = -1, int newGridIndex = -1)
    {
        this.opType = opType;
        this.oldLayout = oldLayout;
        this.newLayout = newLayout;
        this.opPuzzle = opPuzzle;
        this.lastGridIndex = lastGridIndex;
        this.newGridIndex = newGridIndex;
    }
    public int opType;//0表示从下方拖入填充；1表示在面板上修改位置的填充；2表示删除
    public int[] oldLayout;
    public int[] newLayout;
    public GameObject opPuzzle;
    public int lastGridIndex;//opType==1 专用数据
    public int newGridIndex;//opType==1 专用数据

};

[System.Serializable]
public class Recorder
{
    public uint LevelId;
    public int[] layout;
    public int TimeCount;
    public int LeftedAdNum;

    [System.NonSerialized]
    public List<SettlePuzzle> settlePuzzleList = new List<SettlePuzzle>();

    [System.NonSerialized]
    public Stack<Operation> undoStack = new Stack<Operation>();
    [System.NonSerialized]
    public Stack<Operation> redoStack = new Stack<Operation>();

    public bool isFilled()
    {
        for (int i = 0; i < layout.Length; i++)
        {
            if (layout[i] ==(int) GeneralPanelData.GridType.Fill)
            {
                return true;
            }
        }
        return false;
    }
}
public class OperationHistoryRecorder : MonoBehaviour
{
    public GeneralPanelUI generalPanelUI;

    public Transform puzzleContainPanelTrans;

    public Button undoButton;
    public Button redoButton;
    public MiniMapController miniMapController;

    private Recorder m_recoder;
    public Recorder Recoder
    {
        get
        {
            return m_recoder;
        }
    }

    public void SetLevelId(uint levelId, bool isregen = false)
    {

        //判断当前关卡有没有存档
        if (isregen)
        {
            Recorder rec = XPlayerPrefs.GetRec(levelId);
            m_recoder = rec;
        }
        else
        {
            m_recoder = new Recorder();
            m_recoder.LevelId = levelId;
        }
    }

    private void CheckButton()
    {
        if (m_recoder.undoStack.Count == 0)
        {
            undoButton.interactable = false;
        }
        else
        {
            undoButton.interactable = true;
        }
        if (m_recoder.redoStack.Count == 0)
        {
            redoButton.interactable = false;
        }
        else
        {
            redoButton.interactable = true;
        }
    }

    public void Record(Operation op)
    {
        //记录时把op记入undoStack，并清空redoStack
        m_recoder.undoStack.Push(op);
        m_recoder.redoStack.Clear();
        Debug.Log("undoStack记录数： " + m_recoder.undoStack.Count);
        CheckButton();
        RefreshMiniMap();
        RefreshSettlePuzzleList();


    }

    public void Undo()
    {
        //撤销时把undoStack的最上操作op取出，进行逆操作，并把op加入redoStack
        if (m_recoder.undoStack.Count > 0)
        {
            Operation op = m_recoder.undoStack.Pop();

            //执行op的逆操作
            OperateReverse(op);

            m_recoder.redoStack.Push(op);
            Debug.Log("afterundo undoStack记录数： " + m_recoder.undoStack.Count);
            CheckButton();
            RefreshMiniMap();
            RefreshSettlePuzzleList();

        }

    }

    public void Redo()
    {
        //重做时把redoStack的最上操作op取出，进行操作，并把op加入undoStack

        if (m_recoder.redoStack.Count > 0)
        {
            Operation op = m_recoder.redoStack.Pop();

            //执行op
            Operate(op);

            m_recoder.undoStack.Push(op);
            Debug.Log("afterredo undoStack记录数： " + m_recoder.undoStack.Count);
            CheckButton();
            RefreshMiniMap();
            RefreshSettlePuzzleList();

        }
    }

    public void RefreshMiniMap()
    {
        miniMapController.RefreshMiniMap();
    }

    public void Operate(Operation op)
    {
        switch (op.opType)
        {
            case 0:
                {
                    generalPanelUI.InsertPuzzle(op.opPuzzle, false);
                    break;
                }
            case 1:
                {
                    PuzzleItemData opPuzzleItemData = op.opPuzzle.GetComponent<PuzzleItemUI>().puzzleItemData;
                    generalPanelUI.generalPanelData.ModiLayout(GeneralPanelData.GridType.Blank, opPuzzleItemData);
                    opPuzzleItemData.PanelGridIndex = op.newGridIndex;
                    generalPanelUI.InsertPuzzle(op.opPuzzle, false);
                    break;
                }
            case 2:
                {
                    generalPanelUI.RemovePuzzle(op.opPuzzle, false);
                    break;
                }
            default:
                break;
        }
    }

    public void OperateReverse(Operation op)
    {
        switch (op.opType)
        {
            case 0:
                {
                    generalPanelUI.RemovePuzzle(op.opPuzzle, false);
                    break;
                }
            case 1:
                {
                    PuzzleItemData opPuzzleItemData = op.opPuzzle.GetComponent<PuzzleItemUI>().puzzleItemData;
                    generalPanelUI.generalPanelData.ModiLayout(GeneralPanelData.GridType.Blank, opPuzzleItemData);
                    opPuzzleItemData.PanelGridIndex = op.lastGridIndex;
                    generalPanelUI.InsertPuzzle(op.opPuzzle, false);
                    break;
                }
            case 2:
                {
                    generalPanelUI.InsertPuzzle(op.opPuzzle, false);
                    break;
                }
            default:
                break;
        }
    }

    public void RefreshSettlePuzzleList()
    {
        m_recoder.settlePuzzleList.Clear();
        int childCount = puzzleContainPanelTrans.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            GameObject puzzle = puzzleContainPanelTrans.GetChild(i).gameObject;
            if (puzzle.activeSelf)
            {
                PuzzleItemUI settlePuzzleUI = puzzle.GetComponent<PuzzleItemUI>();
                PuzzleItemData settlePuzzleData = settlePuzzleUI.puzzleItemData;
                SettlePuzzle settlePuzzle = new SettlePuzzle(settlePuzzleData.PID, settlePuzzleUI.RotateState, settlePuzzleData.PanelGridIndex);
                m_recoder.settlePuzzleList.Add(settlePuzzle);
            }
        }

    }

    public void Clear()
    {
        m_recoder.undoStack.Clear();
        m_recoder.redoStack.Clear();
    }

}


