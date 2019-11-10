using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class PanelTransformationController : MonoBehaviour
{
    public Transform playFieldTrans;
    public MiniMapController miniMapController;
    public GeneralPanelUI generalPanelUI;
    public DragController dragController;

    public float relRatio = 0.8f;

    public float scaleDeltaSpeed = 0.8f;


    private bool moveMode = false;
    private bool scaleMode = false;

    private Vector3 curPos = Vector3.zero;
    private Vector3 lastPos = Vector3.zero;


    private Vector3 playFieldOriginPos = Vector3.zero;
    private Vector3 playFieldOriginScreenPos = Vector3.zero;

    private float scaleRatio = 1; public float ScaleRatio { get { return scaleRatio; } }
    private float lastScaleRatio = 1;
    private float maxScaleRatio = 0;

    private float twoFingersCurDistance = 0;
    private float twoFingersLastDistance = 0;
    private Vector3 scalePoint = Vector3.zero;
    private Vector2 centerToScalePointVec = Vector2.zero;



    private Vector2 positiveLimitVec = Vector2.zero;
    private Vector2 negativeLimitVec = Vector2.zero;
    private Vector2 positiveLimitScreenSpaceVec = Vector2.zero;
    private Vector2 negativeLimitScreenSpaceVec = Vector2.zero;


    private float playFieldOriginWidth = 0;
    private float playFieldOriginHeight = 0;


    private bool gameOverFlag = false;

    public void InitPTController()
    {
        miniMapController.RelRatio = relRatio;
        gameOverFlag = false;

        scaleRatio = 1;
        curPos = Vector3.zero;
        lastPos = Vector3.zero;

        playFieldOriginPos = playFieldTrans.position;
        playFieldOriginScreenPos = Camera.main.WorldToScreenPoint(playFieldOriginPos);
        RectTransform playFieldRectTrans = playFieldTrans.GetComponent<RectTransform>();
        playFieldOriginWidth = playFieldRectTrans.rect.width;
        playFieldOriginHeight = playFieldRectTrans.rect.height;
        positiveLimitScreenSpaceVec = new Vector2((playFieldOriginScreenPos.x + playFieldOriginWidth * (1 - relRatio / scaleRatio)), (playFieldOriginScreenPos.y + playFieldOriginHeight * (1 - relRatio / scaleRatio)));
        negativeLimitScreenSpaceVec = new Vector2((playFieldOriginScreenPos.x - playFieldOriginWidth * (1 - relRatio / scaleRatio)), (playFieldOriginScreenPos.y - playFieldOriginHeight * (1 - relRatio / scaleRatio)));
        maxScaleRatio = Mathf.Max((float)generalPanelUI.generalPanelData.Pwidth / 10.0f, (float)generalPanelUI.generalPanelData.Pheight / 10.0f);

        positiveLimitVec = Camera.main.ScreenToWorldPoint(positiveLimitScreenSpaceVec);
        negativeLimitVec = Camera.main.ScreenToWorldPoint(negativeLimitScreenSpaceVec);

    }

    public void Update()
    {
        UpdateCheck();
    }

    private void UpdateCheck()
    {
        if (!gameOverFlag)
        {
            //?PC上无法模拟Input.Touch
            Input.simulateMouseWithTouches = true;//设置touch=mouse，但mouse!=touch

            int touchCount = Input.touchCount;
            if (touchCount > 0)
            {
                miniMapController.RefreshFlag = true;
            }

            if (dragController.GeneralDragFlag)
            {
                return;
                //如果正在drag puzzle，以下的单指双指输入全部屏蔽
            }
            if (elasticBackFlag)
            {
                return;
            }
            else
            {
                if (touchCount == 1)
                {
                    //TODO:实现单指移动，避免单指触摸的位置是puzzle或者ui按钮
                    Touch touch = Input.GetTouch(0);
                    if (moveMode)
                    {
                        //单指移动模式时，记录每一帧的手指位移，应用至playField的位移
                        curPos = touch.position;
                        Vector3 moveVec = Camera.main.ScreenToWorldPoint(curPos) - Camera.main.ScreenToWorldPoint(lastPos);
                        playFieldTrans.position += moveVec;

                        // DetectCurrentPos();

                        Vector3 offset = playFieldTrans.position - playFieldOriginPos;
                        miniMapController.RefreshOrangeOutline(offset, scaleRatio);

                        lastPos = curPos;
                    }

                    if (touch.phase == TouchPhase.Began)
                    {
                        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                        pointerEventData.position = touch.position;
                        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
                        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
                        if (raycastResultsList.Count > 0)
                        {
                            Debug.Log("raycastHit obj:" + raycastResultsList[0].gameObject.name);
                            string rayhitObjName = raycastResultsList[0].gameObject.name;
                            if (rayhitObjName == "BG" || rayhitObjName.Contains("BlankGrid") || rayhitObjName.Contains("FixGrid"))
                            {
                                //如果第一次按下时触摸到的是BG或空格子或固定格子，就开始单指移动模式
                                moveMode = true;
                                lastPos = touch.position;
                            }
                        }
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        DetectCurrentPos();

                        moveMode = false;
                        scaleMode = false;
                    }

                }
                else if (touchCount == 2)
                {
                    //TODO：实现双指缩放，双指开始的位置需要是非UI以及puzzle
                    Touch touch1 = Input.GetTouch(0);
                    Touch touch2 = Input.GetTouch(1);

                    if (scaleMode)
                    {
                        //双指模式时，记录每一帧的手指位移，应用至playField的缩放
                        //!由于PC无法进行双指缩放，故使用右键进行模拟，右键点击位置为缩放点，右键持续点击滚动鼠标滚轮时，表示双指的距离加大，即缩放比例增大

                        //TODO:双指距离增加时，scale相应增加，减少时scale相应减少
                        twoFingersCurDistance = Vector3.Magnitude(touch1.position - touch2.position);
                        float deltaDistance = twoFingersCurDistance - twoFingersLastDistance;

                        scaleRatio += deltaDistance * scaleDeltaSpeed * Time.deltaTime;
                        Debug.Log("ScaleRatio:" + scaleRatio);
                        if (scaleRatio > maxScaleRatio)
                        {
                            scaleRatio = maxScaleRatio;
                        }
                        else if (scaleRatio < 1)
                        {
                            scaleRatio = 1;
                        }
                        playFieldTrans.localScale = Vector3.one * scaleRatio;

                        Vector3 newPos = new Vector3(scalePoint.x - centerToScalePointVec.x * (scaleRatio / lastScaleRatio), scalePoint.y - centerToScalePointVec.y * (scaleRatio / lastScaleRatio), playFieldTrans.position.z);
                        playFieldTrans.position = newPos;

                        // DetectCurrentPos();

                        Vector3 offset = playFieldTrans.position - playFieldOriginPos;
                        miniMapController.RefreshOrangeOutline(offset, scaleRatio);

                        twoFingersLastDistance = twoFingersCurDistance;
                    }

                    if ((touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began) ||
                        (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Moved) ||
                        (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Began) ||
                        (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Stationary) ||
                        (touch1.phase == TouchPhase.Stationary && touch2.phase == TouchPhase.Began))
                    {

                        PointerEventData pointerEventData1 = new PointerEventData(EventSystem.current);
                        pointerEventData1.position = touch1.position;
                        PointerEventData pointerEventData2 = new PointerEventData(EventSystem.current);
                        pointerEventData2.position = touch2.position;
                        List<RaycastResult> raycastResultsList1 = new List<RaycastResult>();
                        EventSystem.current.RaycastAll(pointerEventData1, raycastResultsList1);
                        List<RaycastResult> raycastResultsList2 = new List<RaycastResult>();
                        EventSystem.current.RaycastAll(pointerEventData2, raycastResultsList2);

                        if (raycastResultsList1.Count > 0 && raycastResultsList2.Count > 0)
                        {
                            Debug.Log("raycastHit1 obj:" + raycastResultsList1[0].gameObject.name);
                            Debug.Log("raycastHit2 obj:" + raycastResultsList2[0].gameObject.name);

                            string rayhitObjName1 = raycastResultsList1[0].gameObject.name;
                            string rayhitObjName2 = raycastResultsList2[0].gameObject.name;

                            if ((rayhitObjName1 == "BG" || rayhitObjName1.Contains("BlankGrid") || rayhitObjName1.Contains("FixGrid") || rayhitObjName1.Contains("SettlePuzzle"))
                            && (rayhitObjName2 == "BG" || rayhitObjName2.Contains("BlankGrid") || rayhitObjName2.Contains("FixGrid") || rayhitObjName2.Contains("SettlePuzzle")))
                            {
                                //如果双指hit的是以上这些，就开始双指缩放模式
                                //TODO：确定一个缩放点，确定初始的双指距离
                                Vector3 touchCenterPos = (touch1.position + touch2.position) / 2;

                                scaleMode = true;
                                scalePoint = Camera.main.ScreenToWorldPoint(touchCenterPos);
                                lastScaleRatio = scaleRatio;

                                twoFingersCurDistance = Vector3.Magnitude(touch1.position - touch2.position);
                                twoFingersLastDistance = twoFingersCurDistance;


                                centerToScalePointVec = new Vector2(scalePoint.x - playFieldTrans.position.x, scalePoint.y - playFieldTrans.position.y);
                            }
                        }


                    }

                    if (touch1.phase == TouchPhase.Ended && touch2.phase == TouchPhase.Ended)
                    {
                        DetectCurrentPos();
                        moveMode = false;
                        scaleMode = false;
                    }
                }
            }



            //!以下为PC端的单指移动的模拟

            // if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            // {
            //     miniMapController.RefreshFlag = true;
            // }

            // if (moveMode)
            // {
            //     //单指移动模式时，记录每一帧的手指位移，应用至playField的位移
            //     curPos = Input.mousePosition;
            //     Vector3 moveVec = Camera.main.ScreenToWorldPoint(curPos) - Camera.main.ScreenToWorldPoint(lastPos);
            //     playFieldTrans.position += moveVec;

            //     // DetectCurrentPos();

            //     Vector3 offset = playFieldTrans.position - playFieldOriginPos;
            //     miniMapController.RefreshOrangeOutline(offset, scaleRatio);

            //     lastPos = curPos;
            // }

            // if (Input.GetMouseButtonDown(0))
            // {
            //     PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            //     pointerEventData.position = Input.mousePosition;
            //     List<RaycastResult> raycastResultsList = new List<RaycastResult>();
            //     EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
            //     if (raycastResultsList.Count > 0)
            //     {
            //         Debug.Log("raycastHit obj:" + raycastResultsList[0].gameObject.name);
            //         string rayhitObjName = raycastResultsList[0].gameObject.name;
            //         if (rayhitObjName == "BG" || rayhitObjName.Contains("BlankGrid") || rayhitObjName.Contains("FixGrid"))
            //         {
            //             //如果第一次按下时触摸到的是BG或空格子或固定格子，就开始单指移动模式
            //             moveMode = true;
            //             lastPos = Input.mousePosition;
            //         }
            //     }
            // }

            // if (Input.GetMouseButtonUp(0))
            // {
            //     DetectCurrentPos();

            //     moveMode = false;
            // }

            //!以下是PC端双指缩放的模拟

            // if (scaleMode)
            // {
            //     //双指模式时，记录每一帧的手指位移，应用至playField的缩放
            //     //!由于PC无法进行双指缩放，故使用右键进行模拟，右键点击位置为缩放点，右键持续点击时，表示双指的距离加大，即缩放比例增大


            //     scaleRatio += Input.mouseScrollDelta.y * 1.5f * Time.deltaTime;
            //     Debug.Log("ScaleRatio:" + scaleRatio);
            //     if (scaleRatio > maxScaleRatio)
            //     {
            //         scaleRatio = maxScaleRatio;
            //     }
            //     else if (scaleRatio < 1)
            //     {
            //         scaleRatio = 1;
            //     }
            //     playFieldTrans.localScale = Vector3.one * scaleRatio;

            //     Vector3 newPos = new Vector3(scalePoint.x - centerToScalePointVec.x * (scaleRatio / lastScaleRatio), scalePoint.y - centerToScalePointVec.y * (scaleRatio / lastScaleRatio), playFieldTrans.position.z);
            //     playFieldTrans.position = newPos;

            //     // DetectCurrentPos();

            //     Vector3 offset = playFieldTrans.position - playFieldOriginPos;
            //     miniMapController.RefreshOrangeOutline(offset, scaleRatio);
            // }

            // if (Input.GetMouseButtonDown(1))
            // {
            //     //确定一个缩放点
            //     PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            //     pointerEventData.position = Input.mousePosition;
            //     List<RaycastResult> raycastResultsList = new List<RaycastResult>();
            //     EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
            //     if (raycastResultsList.Count > 0)
            //     {
            //         Debug.Log("raycastHit obj:" + raycastResultsList[0].gameObject.name);
            //         string rayhitObjName = raycastResultsList[0].gameObject.name;
            //         if (rayhitObjName == "BG" || rayhitObjName.Contains("BlankGrid") || rayhitObjName.Contains("FixGrid") || rayhitObjName.Contains("SettlePuzzle"))
            //         {
            //             //如果缩放点是以上这些，就开始双指缩放模式
            //             scaleMode = true;
            //             scalePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //             lastScaleRatio = scaleRatio;

            //             centerToScalePointVec = new Vector2(scalePoint.x - playFieldTrans.position.x, scalePoint.y - playFieldTrans.position.y);
            //         }
            //     }
            // }

            // if (Input.GetMouseButtonUp(1))
            // {
            //     DetectCurrentPos();

            //     scaleMode = false;
            // }
        }

    }

    bool elasticBackFlag = false;
    public void DetectCurrentPos()
    {
        bool outFlag = false;

        Vector3 playFieldCurScreenPos = Camera.main.WorldToScreenPoint(playFieldTrans.position);
        float finalX = playFieldTrans.position.x;
        float finalY = playFieldTrans.position.y;

        positiveLimitScreenSpaceVec = new Vector2((playFieldOriginScreenPos.x + playFieldOriginWidth * (1 - relRatio / scaleRatio)), (playFieldOriginScreenPos.y + playFieldOriginHeight * (1 - relRatio / scaleRatio)));
        negativeLimitScreenSpaceVec = new Vector2((playFieldOriginScreenPos.x - playFieldOriginWidth * (1 - relRatio / scaleRatio)), (playFieldOriginScreenPos.y - playFieldOriginHeight * (1 - relRatio / scaleRatio)));

        positiveLimitVec = Camera.main.ScreenToWorldPoint(positiveLimitScreenSpaceVec);
        negativeLimitVec = Camera.main.ScreenToWorldPoint(negativeLimitScreenSpaceVec);


        if (playFieldCurScreenPos.x > positiveLimitScreenSpaceVec.x)
        {
            finalX = positiveLimitVec.x;
            outFlag = true;
        }
        else if (playFieldCurScreenPos.x < negativeLimitScreenSpaceVec.x)
        {
            finalX = negativeLimitVec.x;
            outFlag = true;
        }
        if (playFieldCurScreenPos.y > positiveLimitScreenSpaceVec.y)
        {
            finalY = positiveLimitVec.y;
            outFlag = true;
        }
        else if (playFieldCurScreenPos.y < negativeLimitScreenSpaceVec.y)
        {
            finalY = negativeLimitVec.y;
            outFlag = true;
        }


        // playFieldTrans.position = new Vector3(finalX, finalY, playFieldTrans.position.z);
        Vector3 finalPos = new Vector3(finalX, finalY, playFieldTrans.position.z);

        if (outFlag)
        {
            elasticBackFlag = true;
            StartCoroutine(ElasticBack(finalPos, 0.5f));
        }

    }

    public IEnumerator ReturnToOrigin(float time, Action afterMoveAction)
    {
        gameOverFlag = true;
        StopCoroutine("ElasticBack");

        Vector3 playFieldCurPos = playFieldTrans.position;
        Vector3 direction = Vector3.Normalize(playFieldOriginPos - playFieldCurPos);
        float moveSpeed = Vector3.Magnitude(playFieldOriginPos - playFieldCurPos) / time;
        float scaleSpeed = (scaleRatio - 1) / time;
        while (time > 0)
        {
            time -= Time.deltaTime;
            playFieldTrans.position = playFieldTrans.position + direction * moveSpeed * Time.deltaTime;
            if (playFieldTrans.localScale.x > 1)
            {
                playFieldTrans.localScale = playFieldTrans.localScale - Vector3.one * scaleSpeed * Time.deltaTime;
            }
            yield return null;
        }
        playFieldTrans.position = playFieldOriginPos;
        playFieldTrans.localScale = Vector3.one;
        afterMoveAction();
        yield return null;
    }

    IEnumerator ElasticBack(Vector3 finalPos, float time)
    {
        Vector3 startPos = playFieldTrans.position;
        Vector3 moveVec = finalPos - startPos;
        Vector3 normDirection = Vector3.Normalize(moveVec);
        float speed = Vector3.Magnitude(moveVec) / time;
        float totalTime = 0;
        while (totalTime < time)
        {
            playFieldTrans.position = Vector3.Lerp(playFieldTrans.position, finalPos, totalTime / time);
            totalTime += Time.deltaTime;

            Vector3 offset = playFieldTrans.position - playFieldOriginPos;
            miniMapController.RefreshOrangeOutline(offset, scaleRatio);

            yield return null;
        }
        playFieldTrans.position = finalPos;
        elasticBackFlag = false;
    }



}
