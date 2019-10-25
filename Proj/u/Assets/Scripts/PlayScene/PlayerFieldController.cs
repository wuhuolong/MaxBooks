using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFieldController : MonoBehaviour
{
    Camera cmr;
    float deltaSize;
    float intiCmrSize;

    Touch curTouch0, curTouch1, lastTouch0, lastTouch1;
    bool firstTwoTouch = true;

    // Start is called before the first frame update
    void Start()
    {
        cmr = gameObject.GetComponent<Camera>();
        intiCmrSize = cmr.orthographicSize;
        deltaSize = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //PC测试
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        if (Input.GetKey(KeyCode.W))
        {
            if (cmr.orthographicSize > 2.5f)
                ScaleScreen(x,y,deltaSize);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (cmr.orthographicSize < 5.0f)
                ScaleScreen(x,y,-deltaSize);
        }
        //缩小到最小时初始化位置
        if (cmr.orthographicSize >= 5.0f)
            gameObject.transform.Translate((new Vector3(0, 0, -10) - gameObject.transform.position)*Time.deltaTime*3.0f);
            //gameObject.transform.position = new Vector3(0, 0, -10);
        

        //手机端
        if(Input.touchCount==2)
        {
            if(firstTwoTouch)
            {
                lastTouch0 = Input.GetTouch(0);
                lastTouch1 = Input.GetTouch(1);
                firstTwoTouch = false;
            }
            curTouch0 = Input.GetTouch(0);
            curTouch1 = Input.GetTouch(1);

            x = (curTouch0.position.x + curTouch1.position.x) / 2.0f;
            y = (curTouch0.position.y + curTouch1.position.y) / 2.0f;

            float curDist = Mathf.Sqrt((curTouch0.position.x - curTouch1.position.x) * (curTouch0.position.x - curTouch1.position.x)
                + (curTouch0.position.y - curTouch1.position.y) * (curTouch0.position.y - curTouch1.position.y));
            float lastDist = Mathf.Sqrt((lastTouch0.position.x - lastTouch1.position.x) * (lastTouch0.position.x - lastTouch1.position.x)
                + (lastTouch0.position.y - lastTouch1.position.y) * (lastTouch0.position.y - lastTouch1.position.y));

            deltaSize = curDist / lastDist;
            //降低灵敏度
            if(deltaSize>0.1f)
            {
                ScaleScreen(x, y, deltaSize);
            }

        }
        else
        {
            firstTwoTouch = true;
        }
    }

    /// <summary>
    /// 双指缩放
    /// </summary>
    public void ScaleScreen(float x,float y,float deltaSize)
    {

        // 获取目标点位置
        var mousePos = cmr.ScreenToWorldPoint(new Vector3(x, y, 0));

        float size = cmr.orthographicSize;

        // 放大比例
        float ratio = deltaSize / size;

        gameObject.transform.position -= ratio * (cmr.transform.position - mousePos);
        cmr.orthographicSize = size - deltaSize;
    }

    /// <summary>
    /// 小地图
    /// </summary>
    public void DrawMiniMap()
    {

    }
}
