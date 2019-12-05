// using UnityEngine;
// using xc.ui.ugui;
// 
// namespace xc
// {
//     namespace ui
//     {
//         public class RedPoint : MonoBehaviour
//         {
//             private uint mOldPointKey = 0;
//             public uint mPointKey = 0;
//             private bool mHasAwake = false;
//             public uint PointKey { get { return mOldPointKey; } }
// 
//             public float DeltaX = 0;
//             public float DeltaY = 0;
//             public float Scale = 1;
//             private GameObject mRedPointObj;    //实际小红点对象
//             public GameObject RedPointObj { get { return mRedPointObj; } }
//             void Awake()
//             {
//                 mHasAwake = true;
//                 mRedPointObj = UIManager.Instance.UICache.GetRedPointGameObj();
//                 RefreshPosAndScale();
//             }
// 
//             public void RefreshPosAndScale()
//             {
//                 if (mRedPointObj != null)
//                 {
//                     mRedPointObj.transform.SetParent(this.transform);
//                     mRedPointObj.transform.localEulerAngles = Vector3.zero;
//                     mRedPointObj.transform.localScale = new Vector3(Scale, Scale, 1);
//                     mRedPointObj.transform.localPosition = new Vector3(DeltaX, DeltaY, 0);
//                 }
//             }
// 
//             private void OnEnable()
//             {
//                 Bind();
//             }
// 
//             private void OnDisable()
//             {
//                 UnBind();
//             }
// 
//             void Bind()
//             {
//                 if (mHasAwake == false)
//                     return;
//                 if (PointKey == 0)
//                     return;
//                 ClientEventMgr.Instance.FireEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_BIND, new CEventBaseArgs(this));
//             }
//             void UnBind()
//             {
//                 if (mHasAwake == false)
//                     return;
//                 if (PointKey == 0)
//                     return;
//                 ClientEventMgr.Instance.FireEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_UNBIND, new CEventBaseArgs(this));
//             }
// 
//             private void OnDestroy()
//             {
//                 
//             }
// 
//             private void Update()
//             {
//                 if (mOldPointKey == mPointKey)
//                     return;
// 
//                 if (mHasAwake)
//                 {
//                     UnBind();
//                 }
//                 mOldPointKey = mPointKey;
//                 if (mHasAwake)
//                     Bind();
//             }
//         }
//     }
// }
