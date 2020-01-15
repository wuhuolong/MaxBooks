using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 可用于展开三级菜单的ScrollView控件
/// </summary>
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("UGUIEX/ExpandScrollView")]
public class UIExpandScrollView : MonoBehaviour
{
    public enum EStyle
    {
        Horizontal,
        Vertical,
    }

    /// <summary>
    /// 一级子节点
    /// </summary>
    public class FirstClassNode
    {
        /// <summary>
        /// 自身高度
        /// </summary>
        public int SelfHeight;
        /// <summary>
        /// 偏移
        /// </summary>
        public int Offset = 5;

        /// <summary>
        /// 子节点
        /// </summary>
        public List<SecondClassNode> Nodes = new List<SecondClassNode>();

        public Object UIItemPrefabObject;

        /// <summary>
        /// 生成的UI实例
        /// </summary>
        public GameObject UIItemObject;
        /// <summary>
        /// 索引
        /// </summary>
        public int Index;
        /// <summary>
        /// 参数
        /// </summary>
        public System.Object Param;

        /// <summary>
        /// 点击回调
        /// </summary>
        /// <param name="param"></param>
        public delegate void Callback();
        public Callback ClickedCallback;
        public Callback SpawnCallback;
        public Callback ExpandCallback;

        public static FirstClassNode CurrentSpawn;
        public static FirstClassNode CurrentClick;
        public static FirstClassNode CurrentExpand;

        public UIExpandScrollView ParentExpandScrollView;

        public Transform MakeUIObject()
        {
            if(UIItemPrefabObject == null)
            {
                return null;
            }

            CurrentSpawn = this;

            UIItemObject = GameObject.Instantiate(UIItemPrefabObject) as GameObject;
            UIItemObject.SetActive(true);
            UIItemObject.transform.parent = ParentExpandScrollView.ContentObject.transform;
            UIItemObject.transform.localScale = new Vector3(1, 1, 1);
            UIItemObject.transform.localPosition = new Vector3(0, 0, 0);

            if (SpawnCallback != null)
            {
                SpawnCallback();
            }

            CurrentSpawn = null;

            return UIItemObject.transform;
        }

        public void Expand()
        {
            if(ParentExpandScrollView == null)
            {
                return;
            }

            ParentExpandScrollView.Expand(Index);
        }

        public void Retract()
        {
            if (ParentExpandScrollView == null)
            {
                return;
            }

            ParentExpandScrollView.Expand(-1);
        }

        public bool IsExpanding()
        {
            if(ParentExpandScrollView.CurrentExpandFirstIndex == Index)
            {
                return true;
            }

            return false;
        }

        private void OnItemClicked()
        {
            CurrentClick = this;

            if (IsExpanding())
            {
                Retract();
            }
            else
            {
                Expand();
            }

            if(ClickedCallback != null)
            {
                ClickedCallback();
            }

            CurrentClick = null;
        }
    }

    /// <summary>
    /// 二级子节点
    /// </summary>
    public class SecondClassNode
    {
        /// <summary>
        /// 自身高度
        /// </summary>
        public int SelfHeight;
        /// <summary>
        /// 偏移
        /// </summary>
        public int Offset = 5;

        /// <summary>
        /// 子节点
        /// </summary>
        public List<ThirdClassNode> Nodes = new List<ThirdClassNode>();

        public Object UIItemPrefabObject;

        /// <summary>
        /// 生成的UI实例
        /// </summary>
        public GameObject UIItemObject;

        public int Index;
        /// <summary>
        /// 参数
        /// </summary>
        public System.Object Param;
        public FirstClassNode Parent;
        public UIExpandScrollView ParentExpandScrollView;
        public delegate void Callback();
        public Callback ClickedCallback;
        public Callback SpawnCallback;
        public Callback ExpandCallback;

        public static SecondClassNode CurrentSpawn;
        public static SecondClassNode CurrentClick;
        public static SecondClassNode CurrentExpand;

        public Transform MakeUIObject()
        {
            if (UIItemPrefabObject == null)
            {
                return null;
            }

            CurrentSpawn = this;

            UIItemObject = GameObject.Instantiate(UIItemPrefabObject) as GameObject;
            UIItemObject.SetActive(true);
            UIItemObject.transform.parent = ParentExpandScrollView.ContentObject.transform;
            UIItemObject.transform.localScale = new Vector3(1, 1, 1);
            UIItemObject.transform.localPosition = new Vector3(0, 0, 0);

            if (SpawnCallback != null)
            {
                SpawnCallback();
            }

            CurrentSpawn = null;

            return UIItemObject.transform;
        }

        public void Expand()
        {
            if (ParentExpandScrollView == null)
            {
                return;
            }

            ParentExpandScrollView.Expand(Parent.Index, Index);
        }

        public void Retract()
        {
            if (ParentExpandScrollView == null)
            {
                return;
            }

            ParentExpandScrollView.Expand(Parent.Index, -1);
        }

        public bool IsExpanding()
        {
            if (ParentExpandScrollView.CurrentExpandSecondIndex == Index)
            {
                return true;
            }

            return false;
        }

        public void NotifyClicked()
        {
            OnItemClicked();
        }

        private void OnItemClicked()
        {
            CurrentClick = this;

            if (Nodes != null && Nodes.Count > 0)
            {
                if (IsExpanding())
                {
                    Retract();
                }
                else
                {
                    Expand();
                }
            }

            if (ClickedCallback != null)
            {
                ClickedCallback();
            }

            CurrentClick = null;
        }
    }

    /// <summary>
    /// 三级子节点
    /// </summary>
    public class ThirdClassNode
    {
        /// <summary>
        /// 自身高度
        /// </summary>
        public int SelfHeight;
        /// <summary>
        /// 偏移
        /// </summary>
        public int Offset = 5;

        public Object UIItemPrefabObject;

        /// <summary>
        /// 生成的UI实例
        /// </summary>
        public GameObject UIItemObject;

        public int Index;
        /// <summary>
        /// 参数
        /// </summary>
        public System.Object Param;
        public SecondClassNode Parent;
        public UIExpandScrollView ParentExpandScrollView;
        public delegate void Callback();
        public Callback ClickedCallback;
        public Callback SpawnCallback;

        public static ThirdClassNode CurrentSpawn;
        public static ThirdClassNode CurrentClick;

        public Transform MakeUIObject()
        {
            if (UIItemPrefabObject == null)
            {
                return null;
            }

            CurrentSpawn = this;

            UIItemObject = GameObject.Instantiate(UIItemPrefabObject) as GameObject;
            UIItemObject.SetActive(true);
            UIItemObject.transform.parent = ParentExpandScrollView.ContentObject.transform;
            UIItemObject.transform.localScale = new Vector3(1, 1, 1);
            UIItemObject.transform.localPosition = new Vector3(0, 0, 0);

            if (SpawnCallback != null)
            {
                SpawnCallback();
            }

            CurrentSpawn = null;

            return UIItemObject.transform;
        }

        public void NotifyClicked()
        {
            OnItemClicked();
        }

        private void OnItemClicked()
        {
            CurrentClick = this;

            if (ClickedCallback != null)
            {
                ClickedCallback();
            }

            CurrentClick = null;
        }
    }

    public GameObject ContentObject;

    public int CurrentExpandFirstIndex;
    public List<FirstClassNode> Nodes = new List<FirstClassNode>();

    public int CurrentExpandSecondIndex;
    public int CurrentExpandThirdIndex;

    public EStyle Style = EStyle.Vertical;

    private void Start()
    {
    }

    public void Expand(int firstIndex, int secondIndex, int thirdIndex)
    {
        CurrentExpandFirstIndex = firstIndex;
        CurrentExpandSecondIndex = secondIndex;
        CurrentExpandThirdIndex = thirdIndex;

        //         if(ContentObject == null || TargetScrollView == null)
        //         {
        //             return;
        //         }

        // 清空全部
        while (ContentObject.transform.childCount > 0)
        {
            Transform child = ContentObject.transform.GetChild(0);
            child.parent = null;
            GameObject.Destroy(child.gameObject);
        }

        ContentObject.transform.DetachChildren();
        SecondClassNode targetExpandSecondNode = null;
        ThirdClassNode targetExpandThirdNode = null;

        //         bool needExpandSecondNode = false;
        // 
        //         if(secondIndex >= 0)
        //         {
        //             needExpandSecondNode = true;
        //         }

        int lastXPos = 0;
        int lastYPos = 0;

        for (int i = 0; i < Nodes.Count; i++)
        {
            FirstClassNode firstNode = Nodes[i];

            if (i > 0)
            {
                if (Style == EStyle.Horizontal)
                {
                    lastXPos += firstNode.SelfHeight;
                    lastXPos += firstNode.Offset;
                }
                else if (Style == EStyle.Vertical)
                {
                    lastYPos += firstNode.SelfHeight;
                    lastYPos += firstNode.Offset;
                }
            }

            Transform firstTrans = firstNode.MakeUIObject();
            firstTrans.localPosition = new Vector3((float)lastXPos, -(float)lastYPos, 0.0f);

            if (firstNode.Index == CurrentExpandFirstIndex)
            {
                if (firstNode.Nodes.Count > 0)
                {
                    if (Style == EStyle.Horizontal)
                    {
                        lastXPos += firstNode.SelfHeight / 2;
                        lastXPos += firstNode.Offset;
                    }
                    else if (Style == EStyle.Vertical)
                    {
                        lastYPos += firstNode.SelfHeight / 2;
                        lastYPos += firstNode.Offset;
                    }
                }

                for (int j = 0; j < firstNode.Nodes.Count; j++)
                {
                    SecondClassNode secondNode = firstNode.Nodes[j];

                    if (j == 0)
                    {
                        if (Style == EStyle.Horizontal)
                        {
                            lastXPos += secondNode.SelfHeight / 2;
                        }
                        else if (Style == EStyle.Vertical)
                        {
                            lastYPos += secondNode.SelfHeight / 2;
                        }
                    }
                    else
                    {
                        if (Style == EStyle.Horizontal)
                        {
                            lastXPos += secondNode.SelfHeight;
                            lastXPos += secondNode.Offset;
                        }
                        else if (Style == EStyle.Vertical)
                        {
                            lastYPos += secondNode.SelfHeight;
                            lastYPos += secondNode.Offset;
                        }
                    }

                    Transform secondTrans = secondNode.MakeUIObject();
                    secondTrans.localPosition = new Vector3((float)lastXPos, -(float)lastYPos, 0.0f);

                    if (secondNode.Index == CurrentExpandSecondIndex)
                    {
                        if (secondNode.Nodes.Count > 0)
                        {
                            if (Style == EStyle.Horizontal)
                            {
                                lastXPos += secondNode.SelfHeight / 2;
                                lastXPos += secondNode.Offset;
                            }
                            else if (Style == EStyle.Vertical)
                            {
                                lastYPos += secondNode.SelfHeight / 2;
                                lastYPos += secondNode.Offset;
                            }
                        }

                        for (int k = 0; k < secondNode.Nodes.Count; k++)
                        {
                            ThirdClassNode thirdNode = secondNode.Nodes[k];

                            if (k == 0)
                            {
                                if (Style == EStyle.Horizontal)
                                {
                                    lastXPos += thirdNode.SelfHeight / 2;
                                }
                                else if (Style == EStyle.Vertical)
                                {
                                    lastYPos += thirdNode.SelfHeight / 2;
                                }
                            }
                            else
                            {
                                if (Style == EStyle.Horizontal)
                                {
                                    lastXPos += thirdNode.SelfHeight;
                                    lastXPos += thirdNode.Offset;
                                }
                                else if (Style == EStyle.Vertical)
                                {
                                    lastYPos += thirdNode.SelfHeight;
                                    lastYPos += thirdNode.Offset;
                                }
                            }

                            Transform thirdTrans = thirdNode.MakeUIObject();
                            thirdTrans.localPosition = new Vector3((float)lastXPos, -(float)lastYPos, 0.0f);

                            if (k == (secondNode.Nodes.Count - 1))
                            {
                                if (Style == EStyle.Horizontal)
                                {
                                    lastXPos += thirdNode.SelfHeight / 2;
                                    lastXPos += thirdNode.Offset;
                                }
                                else if (Style == EStyle.Vertical)
                                {
                                    lastYPos += thirdNode.SelfHeight / 2;
                                    lastYPos += thirdNode.Offset;
                                }

                                if (Style == EStyle.Horizontal)
                                {
                                    lastXPos -= secondNode.SelfHeight / 2;
                                    lastXPos -= secondNode.Offset;
                                }
                                else if (Style == EStyle.Vertical)
                                {
                                    lastYPos -= secondNode.SelfHeight / 2;
                                    lastYPos -= secondNode.Offset;
                                }
                            }

                            if (k == thirdIndex)
                            {
                                targetExpandThirdNode = thirdNode;
                            }
                        }

                        SecondClassNode.CurrentExpand = secondNode;

                        if (secondNode.ExpandCallback != null)
                        {
                            secondNode.ExpandCallback();
                        }

                        SecondClassNode.CurrentExpand = null;
                    }

                    if (j == secondIndex)
                    {
                        targetExpandSecondNode = secondNode;
                    }
                }

                FirstClassNode.CurrentExpand = firstNode;

                if (firstNode.ExpandCallback != null)
                {
                    firstNode.ExpandCallback();
                }

                FirstClassNode.CurrentExpand = null;
            }
        }

        if (targetExpandSecondNode != null)
        {
            targetExpandSecondNode.NotifyClicked();
        }

        if (targetExpandThirdNode != null)
        {
            targetExpandThirdNode.NotifyClicked();
        }
    }

    public void Expand(int firstIndex, int secondIndex)
    {
        Expand(firstIndex, secondIndex, -1);
    }

    public void Expand(int index)
    {
        Expand(index, -1);
    }
}
