using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using X.Res;

public class CircleShaderViewer : MonoBehaviour
{
    enum AnimationState
    {
        Drag1,
        Drag2,
        Rotate,
        Delete,
        Great
    }


    public uint curID;
    public int curIndex;
    public int maxIndex;

    public GameObject animOpObj;
    public GameObject animGreatObj;

    public RectTransform tap;
    public RectTransform tap1;
    public RectTransform tap2;
    public RectTransform tap3;

    public Animator animOp;
    public Animator animGreat;

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
        //shaderCtl.SetTarget(targets);
        //shaderCtl.Init();
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


        animOpObj.SetActive(true);
        //animGreatObj.SetActive(false);
        //TODO:根据配置表数据设置targets
        switch (opType)
        {
            case 1:
                targets.Add(puzzleBar.transform.GetChild(0).GetComponent<Image>());
                targets.Add(generalPanel.transform.GetChild(opSup).GetComponent<Image>());
                animOpObj.GetComponent<RectTransform>().position = puzzleBar.transform.GetChild(0).GetComponent<RectTransform>().position;
                animOpObj.GetComponent<RectTransform>().position = new Vector3(animOpObj.GetComponent<RectTransform>().position.x, 
                    animOpObj.GetComponent<RectTransform>().position.y - 0.2f, animOpObj.GetComponent<RectTransform>().position.z);
                ResetTapState();
                //animOp.SetBool("OnDrag1", true);
                switch (opSup)
                {
                    case 1:
                        animOp.Play("Mask_anim3", 0, 0f);
                        break;
                    case 2:
                        Debug.Log("drag2");
                        animOp.Play("Mask_anim5", 0, 0f);
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                targets.Add(puzzlePanel.transform.GetChild(0).GetComponent<Image>());
                targets.Add(deleteArea);
                animOpObj.GetComponent<RectTransform>().position = deleteArea.GetComponent<RectTransform>().position;
                animOpObj.GetComponent<RectTransform>().position = new Vector3(animOpObj.GetComponent<RectTransform>().position.x,
                    animOpObj.GetComponent<RectTransform>().position.y + 0.4f, animOpObj.GetComponent<RectTransform>().position.z);
                ResetTapState();
                //animOp.SetBool("OnDelete", true);
                animOp.Play("Mask_anim4", 0, 0f);
                break;
            case 3:
                targets.Add(puzzleBar.transform.GetChild(0).GetComponent<Image>());
                animOpObj.GetComponent<RectTransform>().position = puzzleBar.transform.GetChild(0).GetComponent<RectTransform>().position;
                animOpObj.GetComponent<RectTransform>().position = new Vector3(animOpObj.GetComponent<RectTransform>().position.x,
                    animOpObj.GetComponent<RectTransform>().position.y - 0.2f, animOpObj.GetComponent<RectTransform>().position.z);
                ResetTapState();
                //animOpObj.transform.position = puzzleBar.transform.GetChild(0).GetComponent<Transform>().position;
                Debug.Log(animOpObj.GetComponent<RectTransform>().anchoredPosition3D);
                //animOp.SetBool("OnTap", true);
                animOp.Play("Mask_anim2", 0, 0f);
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
                {
                    //转换动画状态
                    animOp.SetBool("OnDrag1", false);
                    animOp.SetBool("GreatEnd", false);                                               
                    animOpObj.SetActive(false);
                    animGreatObj.SetActive(true);
                    animOp.Play("donothing");
                    animGreat.Play("Mask_anim", 0, 0f);
                    return true;
                }
                break;
            case 2:
                if (op.opType == 2)
                {
                    //转换动画状态
                    animOp.SetBool("OnDelete", false);
                    animOp.SetBool("GreatEnd", false);
                    animOpObj.SetActive(false);
                    animGreatObj.SetActive(true);
                    //animGreatObj.GetComponent<RectTransform>().position = deleteArea.GetComponent<RectTransform>().position;
                    //animGreatObj.GetComponent<RectTransform>().position = new Vector3(animGreatObj.GetComponent<RectTransform>().position.x,
                    //    animGreatObj.GetComponent<RectTransform>().position.y + 0.4f, animGreatObj.GetComponent<RectTransform>().position.z);
                    //animOp.Play("donothing");
                    animGreat.Play("Mask_anim", 0, 0f);
                    return true;
                }
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
                    //转换动画状态
                    animOp.SetBool("OnTap", false);
                    animOp.SetBool("GreatEnd", false);
                    animOpObj.SetActive(false);
                    animGreatObj.SetActive(true);
                    animOp.Play("donothing");
                    //animGreat.Play("Mask_anim", 0, 0f);
                    Clear();
                    Debug.Log("step" + curIndex);
                    Init(curID, curIndex + 1);
                    Debug.Log(curIndex);
                    return true;
                }
                break;
            default:
                break;
        }
        return false;
    }

    private void ResetTapState()
    {
        Debug.Log("reset");
        tap1.anchoredPosition3D = Vector3.zero;
        tap2.anchoredPosition3D = Vector3.zero;
    }

    private void NextStep()
    {
        
    }
}
