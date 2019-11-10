using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniMapController : MonoBehaviour
{
    public GameObject playField;
    public GameObject generalPanel;
    public GameObject puzzleContainPanel;
    public GameObject orangeOutline;
    private float relRatio = 0.8f;
    public float RelRatio
    {
        set { relRatio = value; }
    }

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private RectTransform orangeOutlineRectTrans;
    private float ratio = 0;

    private GameObject generalPanelClone;
    private GameObject puzzleContainPanelClone;

    private bool leftOrRight = true;

    private bool refreshFlag = false;
    public bool RefreshFlag
    {
        set { refreshFlag = value; }
    }

    void Update()
    {
        //!以下是鼠标移动到小地图上的处理

        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
        if (raycastResultsList.Count > 0)
        {
            string rayhitObjName = raycastResultsList[0].gameObject.name;
            if (rayhitObjName.Contains("MiniMap"))
            {
                MoveToTheOtherSide();
            }
        }
    }

    public void InitMiniMap()
    {
        orangeOutlineRectTrans = orangeOutline.GetComponent<RectTransform>();
        InitRatio();
        RefreshMiniMap();
        RefreshOrangeOutline(Vector3.zero, 1);
    }

    private void InitRatio()
    {
        rectTransform = this.GetComponent<RectTransform>();
        canvasGroup = this.GetComponent<CanvasGroup>();
        StopCoroutine(ListenRefresh());
        StartCoroutine(ListenRefresh());

        float miniMapWidth = rectTransform.rect.width;
        float playFieldWidth = playField.GetComponent<RectTransform>().rect.width;
        ratio = miniMapWidth / playFieldWidth * relRatio;
    }

    public void RefreshMiniMap()
    {
        if (puzzleContainPanelClone != null)
        {
            Destroy(puzzleContainPanelClone);
        }
        if (generalPanelClone != null)
        {
            Destroy(generalPanelClone);
        }

        puzzleContainPanelClone = GameObject.Instantiate(puzzleContainPanel, this.transform);
        puzzleContainPanelClone.transform.position = this.transform.position;
        puzzleContainPanelClone.transform.localScale = Vector3.one * ratio;
        puzzleContainPanelClone.transform.SetAsFirstSibling();

        generalPanelClone = GameObject.Instantiate(generalPanel, this.transform);
        generalPanelClone.transform.localPosition = this.transform.position;
        generalPanelClone.transform.localScale = Vector3.one * ratio;
        generalPanelClone.transform.SetAsFirstSibling();
        refreshFlag = true;
    }

    public void RefreshOrangeOutline(Vector3 offset, float scaleRatio)
    {
        //获取偏移值
        Vector3 miniMapOffset = offset * ratio / scaleRatio;
        orangeOutlineRectTrans.position = generalPanelClone.transform.position - miniMapOffset;
        Rect playFieldRect = playField.GetComponent<RectTransform>().rect;
        orangeOutlineRectTrans.sizeDelta = new Vector2((playFieldRect.width) * (ratio + 0.05f) / scaleRatio, (playFieldRect.height) * (ratio + 0.05f) / scaleRatio);//!test
        refreshFlag = true;
    }



    IEnumerator ListenRefresh()
    {
        while (true)
        {
            if (refreshFlag)
            {
                StartCoroutine(FadeIn(0.5f));
                yield return new WaitForSeconds(2.0f);
                refreshFlag = false;
            }
            else
            {
                StartCoroutine(FadeOut(0.5f));
            }
            yield return null;
        }
    }


    IEnumerator FadeIn(float time)
    {
        float fadeOutSpeed = 1.0f / time;
        while (canvasGroup.alpha < 1.0f)
        {
            canvasGroup.alpha += fadeOutSpeed * Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }

    IEnumerator FadeOut(float time)
    {
        float fadeOutSpeed = 1.0f / time;
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= fadeOutSpeed * Time.deltaTime;
            yield return null;
        }
    }

    public void MoveToTheOtherSide()
    {
        if (leftOrRight)
        {
            //在左边，移到右边
            RectTransform frameRectTrans = this.transform.parent.GetComponent<RectTransform>();
            frameRectTrans.pivot = Vector2.one;
            frameRectTrans.anchorMin = Vector2.one;
            frameRectTrans.anchorMax = Vector2.one;
            frameRectTrans.anchoredPosition = Vector2.zero;
            leftOrRight = false;
        }
        else
        {
            //在右边，移到左边
            RectTransform frameRectTrans = this.transform.parent.GetComponent<RectTransform>();
            frameRectTrans.pivot = Vector2.up;
            frameRectTrans.anchorMin = Vector2.up;
            frameRectTrans.anchorMax = Vector2.up;
            frameRectTrans.anchoredPosition = Vector2.zero;
            leftOrRight = true;
        }
    }

}
