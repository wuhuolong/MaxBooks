using UnityEngine;
using System.Collections;

namespace xc
{
    namespace ui
    {
        public class DragDropComponent : MonoBehaviour
        {
            public bool mIsDrag = false;
            public GameObject DragObj = null;//用做你将要拖拽的物体，考虑到类似itemsslot这样控件拖拽只拖拽UITexture其他不动so做的比较通用，但设置东西较多 斯米马赛！~~
            public GameObject CloneDragObj = null;//克隆拖动的镜像
            public delegate void OnDragInit(DragDropComponent item);
            public delegate bool OnCanDrop(System.Object obj , DragDropComponent dropObj , int group);
            public OnCanDrop  onCanDrop;
            public OnDragInit onDragInit;
            public System.Object Param = null;
            public int DropGroup = 0;
            LayerMask mUILayer ;
            LayerMask mUI2Layer ;
            LayerMask ColliderMask;
            // Use this for initialization
            void Start()
            {
                
            }

            void  Awake()
            {
                mUILayer =  LayerMask.NameToLayer("UI");
                mUI2Layer =  LayerMask.NameToLayer("UI2");
                ColliderMask = (1 << mUILayer) | (1 << mUI2Layer) ;
            }

            // Update is called once per frame
            void Update()
            {
                
            }

            void  OnDragStart()
            {
                if(mIsDrag == false)
                    return;
                if(onDragInit != null)
                {
                    if(onDragInit != null)
                    {
                        CloneDragObj = GameObject.Instantiate(DragObj) as GameObject;
                        CloneDragObj.transform.parent = DragObj.transform.parent;
                        CloneDragObj.transform.localScale = DragObj.transform.localScale;
                        DragObj.SetActive(false);
                        onDragInit(this);//回调内设置传递的参数object 接受的参数匹配
                    }
                }
            }

            void OnDrag (Vector2 delta)
            {
                if(mIsDrag == false)
                    return;
                Vector3 _delta = UIManager.GetInstance().UIMain.MainCam.ScreenToWorldPoint(Input.mousePosition);
                if(CloneDragObj != null)
                {
//                    DragDropManager.Instance.DragObj.SetActive(true);
                    CloneDragObj.transform.position = _delta;
                }
                    
            }
//            void OnDrop()
//            {
//                if(mIsDrag == false)
//                    return;
//                if(OnIsDrop != null)
//                {
//                    if(OnIsDrop() == false)
//                    {
//                        ResetUI();
//                    }
//                }
//            }
            /// <summary>
            /// 有些需求可能是要二次确认的那么如果点了取消请调用此方法
            /// </summary>
            public void ResetUI()
            {
                if(DragObj != null)
                {
//                    TweenPosition.Begin(DragDropManager.Instance.DragObj, 0.5f , DragDropManager.Instance.DragObj.transform.localPosition);
                    DragObj.SetActive(true);
                    GameObject.Destroy(CloneDragObj);
                    CloneDragObj = null;
//                    DelayDestroyComponent delayDestroy = DragDropManager.Instance.DragObj.AddComponent<DelayDestroyComponent>();
//                    delayDestroy.DelayTime = 0.5f;
                }

//                DragDropManager.Instance.DragObj = null;
//                DragDropManager.Instance.DragParams = null;
//                DragDropManager.Instance.DropObj = null;
//                DragDropManager.Instance.DropParams = null;


            }

            void OnDragEnd ()
            {
                if(mIsDrag == false)
                    return;
//                RaycastHit lastHit = new RaycastHit();
                Ray ray = UIManager.GetInstance().UIMain.MainCam.ScreenPointToRay(Input.mousePosition);  
                foreach(RaycastHit hit in Physics.RaycastAll(ray , 50.0f , ColliderMask))
                {
                   if( hit.collider.gameObject != null)
                    {
                        DragDropComponent com = hit.collider.gameObject.GetComponent<DragDropComponent>();
                        if(com != null)
                        {
                            if(onCanDrop != null)
                            {
                                if(onCanDrop(Param , com , com.DropGroup) == true)
                                {

                                }
                            }
                        }

                    }
                }
//                if (Physics.RaycastAll(ray,  out lastHit  , 80.0f , ColliderMask)) 
//                {
//                    if(lastHit.collider.gameObject != null)
//                    {
//                        DragDropComponent com = lastHit.collider.gameObject.GetComponent<DragDropComponent>();
//                        if(com != null)
//                        {
//                            if(onCanDrop != null)
//                            {
//                                if(onCanDrop(Param , com , com.DropGroup) == true)
//                                {
////                                    return;
//                                }
//                            }
//                        }
//                    }
//                }    
                ResetUI();
                    
            }
        }
    }
}


