using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleShaderController : MonoBehaviour
{
    /// <summary>
    /// 要高亮显示的目标
    /// </summary>

    private Image target;
    private List<Image> targets;
    public Canvas canvas;
    private GameObject puzzleBar;

    /// <summary>
    /// 区域范围缓存
    /// </summary>

    private Vector3[] _corners = new Vector3[4];
    private float Xmin, Xmax, Ymin, Ymax;

    /// <summary>
    /// 镂空区域圆心
    /// </summary>

    private Vector4 _center;

    /// <summary>
    /// 镂空区域半径
    /// </summary>

    private float _radius;

    /// <summary>
    /// 遮罩材质
    /// </summary>

    private Material _material;

    /// <summary>
    /// 当前高亮区域的半径
    /// </summary>

    private float _currentRadius;

    /// <summary>
    /// 高亮区域缩放的动画时间
    /// </summary>

    //private float _shrinkTime = 0.5f;

    //private bool isInit = false;

    /// <summary>
    /// 世界坐标向画布坐标转换
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns>返回画布上的二维坐标</returns>

    private Vector2 WorldToCanvasPos(Canvas canvas, Vector3 world)

    {

        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,

            world, canvas.GetComponent<Camera>(), out position);

        return position;

    }

    private void Awake()
    {
        
    }

    public void Init()
    {
        //获取高亮区域的四个顶点的世界坐标
        //target.rectTransform.GetWorldCorners(_corners);
        targets[0].rectTransform.GetWorldCorners(_corners);
        float minX = _corners[0].x;
        float maxX = _corners[2].x;
        float minY = _corners[0].y;
        float maxY = _corners[2].y;

        for (int j = 0; j < 4; j++)
        {
            if (_corners[j].x < minX)
                minX = _corners[j].x;
            if (_corners[j].x > maxX)
                maxX = _corners[j].x;
            if (_corners[j].y < minY)
                minY = _corners[j].y;
            if (_corners[j].y > maxY)
                maxY = _corners[j].y;
        }
        _corners[0].x = minX;
        _corners[0].y = minY;
        _corners[1].x = minX;
        _corners[1].y = maxY;
        _corners[2].x = maxX;
        _corners[2].y = maxY;
        _corners[3].x = maxX;
        _corners[3].y = minY;
        for (int i=1;i<targets.Count;i++)
        {
            Vector3[] tmpCorner = new Vector3[4];
            targets[i].rectTransform.GetWorldCorners(tmpCorner);

            //左下角
            _corners[0].x = Mathf.Min(_corners[0].x, tmpCorner[0].x);
            _corners[0].y = Mathf.Min(_corners[0].y, tmpCorner[0].y);

            //左上角
            _corners[1].x = Mathf.Min(_corners[1].x, tmpCorner[1].x);
            _corners[1].y = Mathf.Max(_corners[1].y, tmpCorner[1].y);

            //右上角
            _corners[2].x = Mathf.Max(_corners[2].x, tmpCorner[2].x);
            _corners[2].y = Mathf.Max(_corners[2].y, tmpCorner[2].y);

            //右下角
            _corners[3].x = Mathf.Max(_corners[3].x, tmpCorner[3].x);
            _corners[3].y = Mathf.Min(_corners[3].y, tmpCorner[3].y);
        }

        

        //Debug.Log("minx" + minX);
        //Debug.Log("maxx" + maxX);
        //Debug.Log("miny" + minY);
        //Debug.Log("maxy" + maxY);

        //计算最终高亮显示区域的半径
        _radius = Vector2.Distance(WorldToCanvasPos(canvas, _corners[0]),WorldToCanvasPos(canvas, _corners[2])) / 2f;

        //计算高亮显示区域的圆心
        float x = _corners[0].x + ((_corners[3].x - _corners[0].x) / 2f);       
        float y = _corners[0].y + ((_corners[1].y - _corners[0].y) / 2f);
        Vector3 centerWorld = new Vector3(x, y, 0);
        Vector2 center = WorldToCanvasPos(canvas, centerWorld);
        //设置遮罩材料中的圆心变量
        Vector4 centerMat = new Vector4(center.x, center.y, 0, 0);
        _material = GetComponent<Image>().material;
        _material.SetVector("_Center", centerMat);
        ////计算当前高亮显示区域的半径
        //RectTransform canRectTransform = canvas.transform as RectTransform;
        //if (canRectTransform != null)
        //{
        //    //获取画布区域的四个顶点
        //    canRectTransform.GetWorldCorners(_corners);
        //    //将画布顶点距离高亮区域中心最远的距离作为当前高亮区域半径的初始值
        //    foreach (Vector3 corner in _corners)
        //    {
        //        _currentRadius = Mathf.Max(Vector3.Distance(WorldToCanvasPos(canvas, corner), center),_currentRadius);
        //    }
        //}
        _material.SetFloat("_Slider", _radius);

        //isInit = true;
    }

    /// <summary>
    /// 收缩速度
    /// </summary>

    //private float _shrinkVelocity = 0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        //if(isInit)
        //{
        //    //从当前半径到目标半径差值显示收缩动画
        //    float value = Mathf.SmoothDamp(_currentRadius, _radius, ref _shrinkVelocity, _shrinkTime);
        //    if (!Mathf.Approximately(value, _currentRadius))
        //    {
        //        _currentRadius = value;
        //        _material.SetFloat("_Slider", _currentRadius);
        //    }
        //}
    }

    public void SetTarget(List<Image> imgs)
    {
        //target = puzzleBar.transform.GetChild(0).GetComponent<Image>();
        targets = imgs;
    }

    public void Clear()
    {
        this.gameObject.SetActive(false);
    }
}