using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using X.Res;

public class CircleShaderViewer : MonoBehaviour
{
    public uint curID;
    public int curIndex;
    public int maxIndex;

    GuidingConfig config;
    private CircleShaderController shaderCtl;
    private EventPenetrate ep;
    public GameObject puzzleBar;
    public GameObject generalPanel;
    public GameObject puzzlePanel;
    public Image deleteArea;
    private List<Image> targets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void InitData(uint id, int index)
    {
        curID = id;
        curIndex = index;
        targets = new List<Image>();
        shaderCtl = this.gameObject.GetComponent<CircleShaderController>();
        ep = this.gameObject.GetComponent<EventPenetrate>();
        config = GuidingMGr.GetInstance().GetConfigByID(curID);
        if(config.OpType[index]==1)
        {
            puzzleBar.transform.GetChild(0).GetComponent<PuzzleItemUI>().canRorate = false;
        }
        else
        {
            puzzleBar.transform.GetChild(0).GetComponent<PuzzleItemUI>().canRorate = true;
        }
        maxIndex = config.OpType.Count-1;
    }

    public void Init(uint id,int index)
    {
        puzzleBar.transform.GetChild(0).GetComponent<PuzzleItemUI>().shaderViewer = this;
        InitData(id,index);
        ReadConfig(index);
        ep.SetTarget(targets[0]);
        shaderCtl.SetTarget(targets);
        shaderCtl.Init();
    }

    public void Clear()
    {
        targets.Clear();
    }

    public void Delete()
    {
        this.gameObject.SetActive(false);
    }


    private void ReadConfig(int index)
    {
        //TODO:根据传入的index读取配置表中的数据
        int opType = config.OpType[index];//操作类型-1拖动放置，2拖动删除，3旋转
        
        int opSup = config.OpSup1[index];//辅助参数-仅用于拖动放置，旋转


        //switch (index)
        //{
        //    case 1:
        //        Debug.Log("case 1");
        //        targets.Add(puzzleBar.transform.GetChild(0).GetComponent<Image>());
        //        targets.Add(generalPanel.transform.GetChild(118).GetComponent<Image>());
        //        break;
        //    case 2:
        //        targets.Add(puzzleBar.transform.GetChild(0).GetComponent<Image>());
        //        break;
        //    default:
        //        break;
        //}


        //TODO:根据配置表数据设置targets
        switch (opType)
        {
            case 1:
                targets.Add(puzzleBar.transform.GetChild(0).GetComponent<Image>());
                targets.Add(generalPanel.transform.GetChild(opSup).GetComponent<Image>());
                break;
            case 2:
                targets.Add(puzzlePanel.transform.GetChild(0).GetComponent<Image>());
                targets.Add(deleteArea);
                break;
            case 3:
                targets.Add(puzzleBar.transform.GetChild(0).GetComponent<Image>());
                break;
        }

    }

    public bool CheckOP(int index, Operation op)
    {
        //TODO:根据传入的index读取配置表中的数据
        int opType = config.OpType[index];//操作类型-1拖动放置，2拖动删除，3旋转
        int opSup = config.OpSup2[index];//辅助参数-仅用于拖动放置，旋转
        //TODO:判断配置表引导操作是否完成
        switch (opType)
        {
            case 1:
                if (op.opType == 0)
                    return true;
                break;
            case 2:
                if (op.opType == 2)
                    return true;
                break;
            
        }
        return false;
    }

    public bool CheckRorate(int index)
    {
        //TODO:根据传入的index读取配置表中的数据
        int opType = config.OpType[index];//操作类型-1拖动放置，2拖动删除，3旋转
        int opSup = config.OpSup2[index];//辅助参数-仅用于拖动放置，旋转

        switch (opType)
        {
            case 3:
                if (targets[0].gameObject.GetComponent<PuzzleItemUI>().RotateState == opSup)
                {
                    return true;
                }
                break;
            default:
                break;
        }
        return false;
    }
}
