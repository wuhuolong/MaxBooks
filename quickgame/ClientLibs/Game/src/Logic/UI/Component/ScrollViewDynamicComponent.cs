using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollViewDynamicComponent : MonoBehaviour
{
    UIScrollView mScrollView;
    private UIPanel mPanel;
    /// <summary>
    /// 用来供外部调用设置item表现形式
    /// </summary>
    public delegate void OnSetItemFunc(int idx , GameObject go);
    public OnSetItemFunc OnSetFunc;
    /// <summary>
    /// 总共用来循环使用item个数
    /// </summary>
    /// <value>The items.</value>
    private List<GameObject> mItems = new List<GameObject>();
    public List<GameObject> Items
    {
        get { return mItems; }
    }

    private int mTotalItemLenght = 0;
    public int TotalItemLength
    {
        set { mTotalItemLenght = value; }
    }

    public int mXcount = 0; //单页单排显示个数
    public int mYcount = 0;//单页竖排显示个数
    public float mXSpace = 0.0f;
    public float mYSpace = 0.0f;
    private int mDisplayCount = 0;
    public Vector3 mFirstVec = Vector3.zero;
    private int mDisplayIdx = 0;
    private int mDisplayEndIdx = 0;
    private bool mStart = false;
    public float mOneSetDetalTime = 0.005f;//单个设置itme间隔时间提高帧数
    private float mTime = 0;
    private int mIdx = 0;
    private int mItemIdx = 0;
    private int mList = 0;
    private int mTmpXcount =0;
    private int mCount = 0;
    private int mRow = 0;
    private UIWidget.Pivot mOrig = UIWidget.Pivot.Top;
    void Start()
    {
        
    }

    void Awake ()
    {
        //设置UIscrollveiw 参数
        mScrollView = gameObject.GetComponent<UIScrollView>();

        if(mScrollView != null)
        {
            mScrollView.onOutOfBounds += OnOutOfBoundsNotification;
            mScrollView.dragEffect = UIScrollView.DragEffect.MomentumAndSpring;
            mScrollView.disableDragIfFits = false;
            //        mScrollView.scrollWheelFactor = 0.0f;
            //        mScrollView.momentumAmount = 0.0f;
            mScrollView.restrictWithinPanel = true;
            //mScrollView.disableDragIfFits = true;
            //mScrollView.smoothDragStart = true;
            mScrollView.iOSDragEmulation = true;
           // mScrollView.contentPivot = UIWidget.Pivot.Left;
        }
        mOrig = mScrollView.contentPivot;
        //设置panel剔除优化参数
        mPanel = gameObject.GetComponent<UIPanel>();
        mPanel.cullWhileDragging = true;
        mPanel.alwaysOnScreen  = true;
    }

    void OnOutOfBoundsNotification(UIScrollView.OutOfBounds outOfBounds)
    {
        if(mScrollView == null)
        {
            return;
        }

        if(mStart)
            return;
        if(mScrollView.movement == UIScrollView.Movement.Vertical)
        {
            if(outOfBounds == UIScrollView.OutOfBounds.VerticalBottom)
            {
                if(mDisplayIdx == 0)
                    return;
                mDisplayIdx -= mDisplayCount;
                float _y = mYcount * mYSpace;
                mFirstVec.Set(0 , mFirstVec.y+_y , 0);
                SetUI(false);
            }
            else if(outOfBounds == UIScrollView.OutOfBounds.VerticalTop)
            {
                int goodsEndIdx = mTotalItemLenght - 1;
                if(mDisplayEndIdx == goodsEndIdx)
                    return;
                mDisplayIdx += mDisplayCount;
                float _y = mYcount * mYSpace;
                mFirstVec.Set(0 , mFirstVec.y-_y , 0);
                SetUI(false);
            }
        }
        else if(mScrollView.movement == UIScrollView.Movement.Horizontal)
        {
            if(outOfBounds == UIScrollView.OutOfBounds.HorizontalLeft)
            {
                int goodsEndIdx = mTotalItemLenght - 1;
                if(mDisplayEndIdx == goodsEndIdx)
                    return;
                mDisplayIdx += mDisplayCount;
//                float _y = mYcount * mYSpace;
//                mFirstVec.Set(0 , mFirstVec.y+_y , 0);
                float _x = mXcount * mXSpace;
                mFirstVec.Set(mFirstVec.x +_x , 0 , 0);
                SetUI(false);

            }
            else if(outOfBounds == UIScrollView.OutOfBounds.HorizontalRight)
            {
                if(mDisplayIdx == 0)
                    return;
                mDisplayIdx -= mDisplayCount;
//                float _y = mYcount * mYSpace;
//                mFirstVec.Set(0 , mFirstVec.y-_y , 0);
                float _x = mXcount * mXSpace;
                mFirstVec.Set(mFirstVec.x -_x , 0 , 0);
                SetUI(false);
            }
        }
    }
    void OnDestroy()
    {
        if(mScrollView)
        {
            mScrollView.onOutOfBounds -= OnOutOfBoundsNotification;
        }
        OnSetFunc = null;
        mItems.Clear();
        mPanel = null;
    }
    public void ScorllToIndex(int index , int total)
    {
        if (index < 0)
            index = 0;
        mTotalItemLenght = total;
        if (index >= mTotalItemLenght)
            return;
        if(mScrollView.movement == UIScrollView.Movement.Vertical)
        {
//            if(index < mDisplayCount)
//            {
//                SpringPanel springPanel = gameObject.GetComponent<SpringPanel>();
//                if(springPanel != null)
//                    springPanel.enabled = false;
//                mPanel.clipOffset = new Vector2(mPanel.clipOffset.x , 0);
//                mScrollView.transform.localPosition = new Vector3(mScrollView.transform.localPosition.x , 0  , mScrollView.transform.localPosition.z);
//                SetUI(false);
//            }
            if (index < (mDisplayCount*3 ))
            {
                mDisplayIdx = 0;
                int pageIndex = index/mDisplayCount;
                float y  = 0;
                float detal = 0;
                if (mPanel.GetViewSize().y >= mDisplayCount*mYSpace)
                    detal = mPanel.GetViewSize().y - mDisplayCount*mYSpace;
                if (index == 0)
                    index = 0;
                y = (mYSpace*index) + detal;
                SpringPanel springPanel = gameObject.GetComponent<SpringPanel>();
                if(springPanel != null)
                    springPanel.enabled = false;
//                mPanel.clipOffset = new Vector2(mPanel.clipOffset.x , -y);
//                mScrollView.transform.localPosition = new Vector3(mScrollView.transform.localPosition.x , y  , mScrollView.transform.localPosition.z);
//                mScrollView.contentPivot = UIWidget.Pivot.Bottom;
                SetUI(false);
                SpringPanel.Begin(mPanel.gameObject,  new Vector3(mScrollView.transform.localPosition.x  , y), 13.0f);
            }
            else
            {

                int totalPage = Mathf.FloorToInt(mTotalItemLenght /mDisplayCount);
                int curPage = Mathf.FloorToInt(index /mDisplayCount);
                float indexY = 0;
                int pageCount = 0;
                if(curPage == totalPage)
                {
                    mDisplayIdx = (curPage-2)*mDisplayCount;
                    int cutIndex = -((mTotalItemLenght-1-mDisplayIdx)%mDisplayCount) + 1;
                    indexY =  cutIndex*mYSpace;
                    pageCount = 2;
                }
                else
                {
                    mDisplayIdx = (curPage-1)*mDisplayCount;
                    indexY = Mathf.FloorToInt((index-mDisplayIdx)/mDisplayCount)*mDisplayCount*mYSpace;
                    pageCount = 0;
                }
//                pageCount = Mathf.FloorToInt(index-mDisplayIdx)/mDisplayCount;
                float y  = 0;
                float detal = 0;
                if (mPanel.GetViewSize().y >= mDisplayCount*mYSpace)
                    detal = mPanel.GetViewSize().y - mDisplayCount*mYSpace;
                    
                y = (pageCount*mYSpace*mDisplayCount) + indexY+ detal;

                SpringPanel springPanel = gameObject.GetComponent<SpringPanel>();
                if(springPanel != null)
                    springPanel.enabled = false;

//                mScrollView.transform.localPosition = new Vector3(mScrollView.transform.localPosition.x , y  , mScrollView.transform.localPosition.z);
//                mPanel.clipOffset = new Vector2(mPanel.clipOffset.x , -y);
                SetUI(false);
                SpringPanel.Begin(mPanel.gameObject,  new Vector3(mScrollView.transform.localPosition.x  , y), 13.0f);
            }
        }
        else if(mScrollView.movement == UIScrollView.Movement.Horizontal)
        {
            
        }
    }

    /// <summary>
    /// 总item长度  这里只会添加不会重置重置请用InitScrollView
    /// items用作动态创建的个数必须是mDisplayCount*3倍
    /// </summary>
    public void InsertItem(int item_total_item)
    {
        if(mScrollView == null)
        {
            SetUI(false);
            return;
        }

        if(mTotalItemLenght !=  item_total_item)
        {
            mTotalItemLenght = item_total_item;
            if(mTotalItemLenght > mDisplayCount)
            {
                if(mScrollView.movement == UIScrollView.Movement.Vertical)
                {
                    if(mTotalItemLenght <= mDisplayCount*3)
                    {
                        SetUI(false);
                        mScrollView.contentPivot = UIWidget.Pivot.Bottom;
                        mScrollView.ResetPosition();
                        //mScrollView.contentPivot = mOrig;
                        //mScrollView.ScrollToBottom();
                    }
                    else
                    {
                        if((mTotalItemLenght - 1) % mDisplayCount == 0)
                        {
                            OnOutOfBoundsNotification(UIScrollView.OutOfBounds.VerticalTop);
                            mScrollView.contentPivot = UIWidget.Pivot.Bottom;
                            mScrollView.ResetPosition();
                            //mScrollView.contentPivot = mOrig;
                            //mScrollView.ScrollToBottom();
                        }
                        else
                        {
                            SetUI(false);
                            mScrollView.contentPivot = UIWidget.Pivot.Bottom;
                            mScrollView.ResetPosition();
                            //mScrollView.contentPivot = mOrig;
                            //mScrollView.ScrollToBottom();
                        }
                    }
                    
                }
                else if(mScrollView.movement == UIScrollView.Movement.Horizontal)
                {
                    SpringPanel.Begin(mPanel.gameObject,  new Vector3(mPanel.transform.localPosition.x + mXSpace , mPanel.transform.localPosition.y), 13.0f);
                }
            }
            else
            {
                SetUI(false);
            }
        }


    }

    /// <summary>
    /// 总item长度  
    /// items用作动态创建的个数必须是mDisplayCount*3倍
    /// </summary>
    /// <param name="Count">Count.</param>
    /// <param name="row_count">Row_count.</param>
    public void InitScrollView( List<GameObject> items , int item_total_item)
    {
        InitScrollView(items , item_total_item , false);
    }

    public void InitScrollView( List<GameObject> items , int item_total_item , bool IsDetal)
    {
//        mItems.Clear();
        mDisplayIdx = 0;
        mTotalItemLenght = item_total_item;
        mItems = items;
        if(mScrollView)
            mScrollView.enabled = false;
        mDisplayCount = mXcount*mYcount;
        mDisplayEndIdx = items.Count - 1;
        mFirstVec = Vector3.zero;
        SpringPanel springPanel = gameObject.GetComponent<SpringPanel>();
        if(springPanel != null)
            springPanel.enabled = false;
        if(mPanel != null)
        {
            mPanel.transform.localPosition = Vector3.zero;
            mPanel.clipOffset = Vector2.zero;
        }
        SetUI(IsDetal);
    }

    public void InitScrollView(GameObject item, int item_total_item)
    {
        int load_count = mItems.Count*3;
        List<GameObject> items = new List<GameObject>();
        for (int i = 0; i < load_count; ++i)
        {
            var new_item = (GameObject)UnityEngine.Object.Instantiate(item);
            new_item.transform.parent = item.transform.parent;
            new_item.transform.localScale = Vector3.one;

            items.Add(new_item);
        }

        InitScrollView(items, item_total_item);
    }

    public void ForceUpdate(int item_total_item)
    {
        if(item_total_item != mTotalItemLenght)
        {
            mDisplayIdx = 0;
            mTotalItemLenght = item_total_item;
            if(mScrollView)
                mScrollView.enabled = false;
            mDisplayCount = mXcount*mYcount;
            mDisplayEndIdx = mItems.Count - 1;
            mFirstVec = Vector3.zero;
            SpringPanel springPanel = gameObject.GetComponent<SpringPanel>();
            if(springPanel != null)
                springPanel.enabled = false;
            if(mPanel != null)
            {
                mPanel.transform.localPosition = Vector3.zero;
                mPanel.clipOffset = Vector2.zero;
            }
        }
        SetUI(true);
    }

    public void ForceUpdate()
    {
        SetUI(false);
    }

    public GameObject GetItemAt(int index)
    {
        index = index - mDisplayIdx;
        if (index < 0 || index >= mItems.Count)
            return null;

        return mItems[index];
    }

    void SetUI(bool openDetal)
    {
        if (mItems.Count == 0)
            return;
        foreach(GameObject go in mItems)
        {
            go.transform.localPosition = Vector3.zero;
            go.gameObject.SetActive(false);
        }
        
        
        mItemIdx = 0;
        mRow = 0;
        mList = 0;
        mTmpXcount = mXcount;
        mIdx = mDisplayIdx;
        
        if(mTotalItemLenght < mItems.Count)
            mCount = mTotalItemLenght;
        else
        {
            mCount = mDisplayIdx + mItems.Count;
            if(mCount - mTotalItemLenght >= 0)
            {
                mCount = mTotalItemLenght;
            }           
        }
        if(openDetal)
        {
            if (mScrollView != null)
            {
                mScrollView.enabled = true;
            }
            
            mStart = true;
        }
        else
        {
            int count = 0;
            int idx = 0;
            int row = 0;
            int list = 0;
            GameObject item = null;
            if (mScrollView != null)
            {
                mScrollView.enabled = true;
            }

            if (mTotalItemLenght < mItems.Count)
                count = mTotalItemLenght;
            else
            {
                count = mDisplayIdx + mItems.Count;
                if(count - mTotalItemLenght >= 0)
                {
                    count = mTotalItemLenght;
                }           
            }

            UIScrollView.Movement movement = UIScrollView.Movement.Vertical;

            if(mScrollView != null)
            {
                movement = mScrollView.movement;
            }

            if (movement == UIScrollView.Movement.Vertical)
            {
                for(int i = mDisplayIdx ; i < count ; i ++)
                {
                    item = mItems[idx];
                    if(row == mXcount)
                    {
                        row = 0;
                        list ++;
                    }            
                    item.gameObject.transform.localPosition = new Vector3(mFirstVec.x +(row*mXSpace) , mFirstVec.y + (list * (-mYSpace)) , 0);
                    mDisplayEndIdx = i;
                    item.gameObject.SetActive(true);
                    row ++;
                    idx ++;
                    if(OnSetFunc != null)
                        OnSetFunc(i , item);
                }
            }
            else if(movement == UIScrollView.Movement.Horizontal)
            {
                int Detal_Xcount = mXcount;
                for(int i = mDisplayIdx ; i < count ; i ++)
                {
                    item = mItems[idx];
                    if(row == Detal_Xcount)
                    {
                        row = 0;
                        if(list == mYcount)
                        {
                            Detal_Xcount += mXcount;
                            list = 0;
                        }
                        else
                            list ++;
                    }
                    item.gameObject.transform.localPosition = new Vector3(mFirstVec.x +(row*mXSpace) , mFirstVec.y + (list * (-mYSpace)) , 0);
                    mDisplayEndIdx = i;
                    item.gameObject.SetActive(true);
                    row ++;
                    idx ++;
                    if(OnSetFunc != null)
                        OnSetFunc(i , item);
//                    item = mItems[idx];
//                    if(list == mYcount)
//                    {
//                        list = 0;
//                        row ++;
//                    }            
//                    item.gameObject.transform.localPosition = new Vector3(mFirstVec.x +(row*mXSpace) , mFirstVec.y + (list * (-mYSpace)) , 0);
//                    mDisplayEndIdx = i;
//                    item.gameObject.SetActive(true);
//                    list ++;
//                    idx ++;
//                    if(OnSetFunc != null)
//                        OnSetFunc(i , item);
                }
            }
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        if (mStart == true)
        {
            if(mTime >= mOneSetDetalTime)
            {
                GameObject item = null;

                UIScrollView.Movement movement = UIScrollView.Movement.Vertical;

                if (mScrollView != null)
                {
                    movement = mScrollView.movement;
                }

                if (movement == UIScrollView.Movement.Vertical)
                {
                    if(mIdx < mCount && mItemIdx <mItems.Count)
                    {
                        item = mItems[mItemIdx];
                        if(mRow == mXcount)
                        {
                            mRow = 0;
                            mList ++;
                        }            
                        item.gameObject.transform.localPosition = new Vector3(mFirstVec.x +(mRow*mXSpace) , mFirstVec.y + (mList * (-mYSpace)) , 0);
                        mDisplayEndIdx = mIdx;
                        item.gameObject.SetActive(true);
                        mRow ++;
                        mItemIdx ++;
                        if(OnSetFunc != null)
                            OnSetFunc(mIdx , item);
                        mIdx ++;
                    }
                    else
                    {
//                        mScrollView.enabled = true;
                        mStart = false;
                    }
                }
                else if(movement == UIScrollView.Movement.Horizontal)
                {
                    if(mIdx < mCount && mItemIdx <mItems.Count)
                    {

                        item = mItems[mItemIdx];
                        if(mRow == mTmpXcount)
                        {
                            if(mList == mYcount - 1)
                            {
                                mTmpXcount += mXcount;
                                mList = 0;
                            }
                            else
                            {
                                mList ++;
                                mRow = mTmpXcount - mXcount;
                            }
                        }

//                        item = mItems[mItemIdx];
//                        if(mRow == mXcount)
//                        {
//                            mRow = 0;
//                            mList ++;
//                        }            
                        item.gameObject.transform.localPosition = new Vector3(mFirstVec.x +(mRow*mXSpace) , mFirstVec.y + (mList * (-mYSpace)) , 0);
                        mDisplayEndIdx = mIdx;
                        item.gameObject.SetActive(true);
                        mRow ++;
                        mItemIdx ++;
                        if(OnSetFunc != null)
                            OnSetFunc(mIdx , item);
                        mIdx ++;

//                        item = mItems[mItemIdx];
//                        if(mList == mYcount)
//                        {
//                            mList = 0;
//                            mRow ++;
//                        }            
//                        item.gameObject.transform.localPosition = new Vector3(mFirstVec.x +(mRow*mXSpace) , mFirstVec.y + (mList * (-mYSpace)) , 0);
//                        mDisplayEndIdx = mIdx;
//                        item.gameObject.SetActive(true);
//                        mList ++;
//                        mItemIdx ++;
//                        if(OnSetFunc != null)
//                            OnSetFunc(mIdx , item);
//                        mIdx ++;
                    }
                    else
                    {
//                        mScrollView.enabled = true;
                        mStart = false;
                    }
                }

                mTime = 0;
            }
            mTime += Time.deltaTime;
        }
    }
}

