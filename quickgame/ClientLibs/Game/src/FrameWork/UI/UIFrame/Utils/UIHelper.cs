using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;
using xc;
using UnityEngine.UI;

namespace xc.ui.ugui
{
    public enum Pivot
    {
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight,
    }

    public class UIHelper
    {

        public static void SetRaycastDisable(GameObject root)
        {

            var mask = root.GetComponentsInChildren<NoDrawingRayCast>();

            foreach (var m in mask)
            {
                m.raycastTarget = false;
            }

            var imag = root.GetComponentsInChildren<Image>(true);

            foreach (var img in imag)
            {
                img.raycastTarget = false;
            }

            var raws = root.GetComponentsInChildren<RawImage>(true);

            foreach (var img in raws)
            {
                img.raycastTarget = false;
            }

        }


        public static Vector2 GetVector2ByPivot(Pivot piovt)
        {
            Vector2 vec = Vector2.zero;
            switch (piovt)
            {
                case Pivot.TopLeft:
                    {
                        vec.Set(0, 1);
                        break;
                    }
                case Pivot.Top:
                    {
                        vec.Set(0.5f, 1);
                        break;
                    }
                case Pivot.Left:
                    {
                        vec.Set(0, 0.5f);
                        break;
                    }
                case Pivot.Right:
                    {
                        vec.Set(1, 0.5f);
                        break;
                    }
                case Pivot.BottomLeft:
                    {
                        vec.Set(0, 0);
                        break;
                    }
                case Pivot.Bottom:
                    {
                        vec.Set(0, 0.5f);
                        break;
                    }
                case Pivot.TopRight:
                    {
                        vec.Set(1, 1);
                        break;
                    }
                case Pivot.BottomRight:
                    {
                        vec.Set(1, 0);
                        break;
                    }
                default:
                    {
                        vec.Set(0.5f, 0.5f);
                        break;
                    }
            }
            return vec;
        }

        public static T[] GetComponentsInChildren<T>(Transform parent) where T : Component
        {
            List<T> result = new List<T>();
            GetComponentsInChildren<T>(parent, result);
            return result.ToArray();
        }

        public static void GetComponentsInChildren<T>(Transform parent, List<T> result) where T : Component
        {
            if (parent == null || result == null)
                return;

            T c = parent.GetComponent<T>();
            if (c != null)
                result.Add(c);

            for (int i = 0; i < parent.childCount; i++)
            {
                Transform childTrans = parent.GetChild(i);
                if (childTrans != null)
                    GetComponentsInChildren<T>(childTrans, result);
            }
        }

        public static Transform FindChildInHierarchy(Transform parent, string name)
        {
            if (parent == null)
                return null;

            var trans = parent.Find(name);
            if (trans != null)
                return trans;

            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child_trans = parent.GetChild(i);
                var t = FindChildInHierarchy(child_trans, name);
                if (t != null)
                    return t;
            }

            return null;
        }

        //通过读表返回面板类型
        public static bool GetSupportBack(string name)
        {
            var ui_info = DBUIManager.Instance.GetData(name);
            if (ui_info != null)
            {
                return ui_info.support_back;
            }
            else
                return false;
        }

        public static GameObject FindChild(GameObject parent, string childName)
        {
            Transform trans = UIHelper.FindChildInHierarchy(parent.transform, childName);
            if (trans != null)
                return trans.gameObject;
            else
                return null;
        }

        public static GameObject FindChild(Transform transform, string childName)
        {
            var trans = UIHelper.FindChildInHierarchy(transform, childName);
            if (trans != null)
            {
                return trans.gameObject;
            }
            else
            {
                return null;
            }
        }

        public static void FindAllChildrenInHierarchy_out(Transform parent, string name, out List<GameObject> childrenObj)
        {
            childrenObj = new List<GameObject>();
            FindAllChildrenInHierarchy_private(parent, name, ref childrenObj);
        }

        private static void FindAllChildrenInHierarchy_private(Transform parent, string name, ref List<GameObject> childrenObj)
        {
            if (parent == null)
                return;
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform childTrans = parent.GetChild(i);
                if (childTrans.name == name)
                    childrenObj.Add(childTrans.gameObject);
                else
                {
                    FindAllChildrenInHierarchy_private(childTrans, name, ref childrenObj);
                }
            }
        }

        public static Canvas GetObjectCanvas(GameObject Obj)
        {
            var canvas = Obj.GetComponent<Canvas>();
            if (canvas != null)
                return canvas;
            else
                return null;
        }

        static HashSet<string> mHasReadWins = new HashSet<string>();
        static Dictionary<string, HashSet<string>> mWindowParents = new Dictionary<string, HashSet<string>>();
        public static bool IsUniqueWin(string name)
        {
            if (mWindowParents.ContainsKey(name) == false)
                return true;
            if (mWindowParents[name].Count <= 1)
                return true;
            return false;
        }
        //获取某个面板的初始打开的子面板
        public static List<string> GetWindowInitOpenSubWin(string name)
        {
            List<string> wins = new List<string>();
            var ui_info = DBUIManager.Instance.GetData(name);
            if (ui_info != null)
            {
                if(string.IsNullOrEmpty(ui_info.init_open_panels) == false)
                {
                    var raw = ui_info.init_open_panels.Replace("[", "").Replace("]", "");
                    string[] results = raw.Split(',');
                    for (int i = 0; i < results.Length; i++)
                    {
                        if (results[i].CompareTo(string.Empty) != 0)
                            wins.Add(results[i]);
                    }
                }

                if (mHasReadWins.Contains(name) == false)
                {
                    if (string.IsNullOrEmpty(ui_info.sub_panels) == false)
                    {
                        var sub_raw = ui_info.sub_panels.Replace("[", "").Replace("]", "");
                        var results = sub_raw.Split(',');
                        for (int i = 0; i < results.Length; i++)
                        {
                            if (results[i].CompareTo(string.Empty) != 0 && results[i] != "UIBlurWindow")
                            {
                                string child_name = results[i];
                                if (mWindowParents.ContainsKey(child_name) == false)
                                    mWindowParents[child_name] = new HashSet<string>();
                                if(mWindowParents[child_name].Contains(name) == false)
                                    mWindowParents[child_name].Add(name);
                            }
                        }
                    }
                    
                    mHasReadWins.Add(name);
                }
            }
            return wins;
        }

        public static GameObject InstUIObject(GameObject obj)
        {
            if (obj == null)
            {
                return null;
            }

            GameObject copyObj = GameObject.Instantiate(obj);
            copyObj.transform.SetParent(obj.transform.parent);
            copyObj.transform.localScale = obj.transform.localScale;
            copyObj.transform.localPosition = obj.transform.localPosition;
            copyObj.transform.localRotation = obj.transform.localRotation;
            return copyObj;
        }

        public static bool CheckWindowIsModalByName(string name)
        {
            var ui_info = DBUIManager.Instance.GetData(name);
            if (ui_info != null)
                return ui_info.is_modal;
            else
                return false;
        }
        //通过读表返回面板类型
        public static UIType GetUITypeByWindowName(string name)
        {
            var ui_info = DBUIManager.Instance.GetData(name);
            if (ui_info != null)
                return (UIType)ui_info.ui_type;
            else
                return UIType.Hud;
        }

        //通过是否禁止返回上层面板
        public static bool IsBanBackLastPanelByWindowName(string name)
        {
            var ui_info = DBUIManager.Instance.GetData(name);
            if (ui_info != null)
                return ui_info.ban_back_last_panel;
            else
                return false;
        }

        //返回的时候是否禁止子界面
        public static bool IsBanSubWindowWhenBack(string name)
        {
            var ui_info = DBUIManager.Instance.GetData(name);
            if (ui_info != null)
                return ui_info.ban_sub_window_when_back;
            else
                return false;
        }

        //这里用作处理登陆流程的UI初始化
        public static void InitLoginAllUI()
        {
            var root = UIManager.Instance.MainCtrl.LoadingRoot;
            if (root == null)
            {
                Debug.LogError("Login All UI Error!");
                return;
            }

            UIManager.Instance.LoadingWindow = new UILoadingWindow();
            UIManager.Instance.LoadingWindow.mUIObject = root.Find("UILoadingWindow").gameObject;
            UIManager.Instance.LoadingWindow.InitData();
        }

        public static Sprite LoadSpriteByBaseWindow(UIBaseWindow win, string spriteName)
        {
            if (win == null)
            {
                GameDebug.LogError("UIHelper.LoadSpriteByBaseWindow UIBaseWindow is null");
                return null;
            }

            if (win.mUIObject == null)
                return null;

            CanvasInfo info = win.mUIObject.GetComponent<CanvasInfo>();
            if (info == null)
            {
                GameDebug.LogError(string.Format("UIHelper.LoadSpriteByBaseWindow {0}  CanvasInfo is null", win.mWndName));
                return null;
            }
            return info.LoadSprite(spriteName);
        }

        public static Material LoadMaterialByBaseWindow(UIBaseWindow win, string materialName)
        {
            if (win == null)
            {
                GameDebug.LogError("UIHelper.LoadMaterialByBaseWindow UIBaseWindow is null");
                return null;
            }

            if (win.mUIObject == null)
                return null;

            CanvasInfo info = win.mUIObject.GetComponent<CanvasInfo>();
            if (info == null)
            {
                GameDebug.LogError(string.Format("UIHelper.LoadMaterialByBaseWindow {0}  CanvasInfo is null", win.mWndName));
                return null;
            }
            return info.LoadMaterial(materialName);
        }

        public static AudioClip LoadAudioClipByBaseWindow(UIBaseWindow win, string audioClipName)
        {
            if (null == win)
            {
                GameDebug.LogError("UIHelper.LoadAudioClipByBaseWindow UIBaseWindow is null");
                return null;
            }

            if (null == win.mUIObject)
                return null;

            SoundInfo info = win.mUIObject.GetComponent<SoundInfo>();
            if (null == info)
            {
                GameDebug.LogError(string.Format("UIHelper.LoadAudioClipByBaseWindow {0}  CanvasInfo is null", win.mWndName));
                return null;
            }

            return info.LoadAudioClip(audioClipName);
        }

        public static string GetLuaWindowPath(string winName)
        {
            var ui_info = DBUIManager.Instance.GetData(winName);
            if (ui_info != null)
                return ui_info.lua_path;
            else
                return "";
        }

        /// <summary>
        /// 获取界面的分包id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetWindowPatchId(string name)
        {
            int path_id = -1;

            var ui_info = DBUIManager.Instance.GetData(name);
            if(ui_info != null)
            {
                path_id = ui_info.patch_id;
            }

            return path_id;
        }

        public static Vector3 GetDBTextResourceVector(string str)
        {
            return DBTextResource.ParseVector3(str);
        }

        public static void SetLayer(Transform root, int layer)
        {
            if (root == null)
                return;
            root.gameObject.layer = layer;
            for (int i = 0; i < root.childCount; i++)
            {
                Transform childTrans = root.GetChild(i);
                SetLayer(childTrans, layer);
            }
        }

        ///<summary>
        /// 根据系统id获取主界面系统按钮
        /// </summary>
        public static UISysConfigBtn GetMainUISysBtnBySysId( uint sysId )
        {
            var mainUiWin = UIManager.Instance.GetWindow("UIMainmapWindow");
            if (null == mainUiWin)
                return null;

            var mainUiSysBehaviour = mainUiWin.GetBehaviour("UIMainMapSysOpenBehaviour") as UIMainMapSysOpenBehaviour;
            if (null == mainUiSysBehaviour)
                return null;

            var sysConfig = DBManager.GetInstance().GetDB<DBSysConfig>().GetConfigById(sysId);
            if (null == sysConfig)
                return null;

            return mainUiSysBehaviour.GetConfingBtn(sysConfig);
        }

        public static UISysConfigBtn CreateMainUISysBtnBySysId(uint sysId, Transform parent_trans, uint sort_index)
        {
            if (parent_trans == null)
                return null;
            var mainUiWin = UIManager.Instance.GetWindow("UIMainmapWindow");
            if (mainUiWin == null)
                return null;

            var mainUiSysBehaviour = mainUiWin.GetBehaviour("UIMainMapSysOpenBehaviour") as UIMainMapSysOpenBehaviour;
            if (mainUiSysBehaviour == null)
                return null;

            var sysConfig = DBManager.GetInstance().GetDB<DBSysConfig>().GetConfigById(sysId);
            if (sysConfig == null)
                return null;

            return mainUiSysBehaviour.CreateConfigBtn(sysConfig, parent_trans, sort_index);
        }

        /// <summary>
        /// 指定的界面是否是独立存在的系统界面，不受其他系统界面的影响
        /// </summary>
        static List<string> sIndependentSysWindows = null;
        public static bool IsIndependentSysWindow(string windowName)
        {
            if (sIndependentSysWindows == null)
            {
                sIndependentSysWindows = GameConstHelper.GetStringList("GAME_INDEPENDENT_SYS_WINDOWS");
            }
            return sIndependentSysWindows.Contains(windowName);
        }

        public static void SetChildrenActiveExclude(Transform parent, bool active, string[] name_list)
        {
            if (parent == null)
            {
                return;
            }

            for (var i = 0; i < parent.childCount; i++)
            {
                bool exclude = false;
                var child_trans = parent.GetChild(i);
                for (var j = 0; j < name_list.Length; j++)
                {
                    if (child_trans.name == name_list[j])
                    {
                        exclude = true;
                        break;
                    }
                }
                if (!exclude)
                    child_trans.gameObject.SetActive(active);
            }
        }
    }
}
