//************************************
//  UINavgationCtrl.cs
//  用于面板导航包含模态返回 stack等
//  Created by Wangwx 
//  Last modify 17-3-15 
//************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;
namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UINavgationCtrl : xc.Singleton<UINavgationCtrl>
    {
        //这里的只保存主面板（考虑的很多面板是打开时会打开其他他们面板）
        public static readonly int StackMaxCount = 10;

        private class WindowStackInfo
        {
            public string wndName;
            public object[] param;
            public bool supportBack = false;
            public List<UIBaseWindow.BackupWin> BackupOpenSubWindow = new List<UIBaseWindow.BackupWin>();
        }

        List<WindowStackInfo> Winds;//这里保存的是可以导航回去的link

        private bool ContainWindow(string wndName)
        {
            foreach (var info in Winds)
            {
                if (info.wndName == wndName)
                {
                    return true;
                }
            }

            return false;
        }

        public void ClearStack()
        {
            Winds.Clear();
        }

        public UINavgationCtrl()
        {
            Winds = new List<WindowStackInfo>();
        }

        void TryAddWinds(WindowStackInfo info)
        {
            if (Winds == null || info == null)
                return;
            if(Winds.Count > 0 && Winds[Winds.Count - 1].wndName == info.wndName && UIHelper.IsUniqueWin(info.wndName))
            {
                Winds.RemoveAt(Winds.Count - 1);
            }
            Winds.Add(info);
        }
        public void Push(string name, params object[] param)
        {
            //Winds.Clear();
            bool is_ban_back_last_panel = UIHelper.IsBanBackLastPanelByWindowName(name);
            if (is_ban_back_last_panel)
                Clear();
            List<UIBaseWindow> FinalWins = new List<UIBaseWindow>();

            UIType uitype = UIHelper.GetUITypeByWindowName(name);
            var activeWins = UIManager.Instance.GetNeedCloseSystemWindowsByType(uitype);

            // 打开独立存在的系统界面的时候其他系统界面不关闭
            if (UIHelper.IsIndependentSysWindow(name) == false)
            {
                // 打开其他界面的时候独立存在的系统界面不关闭
                foreach (UIBaseWindow activeWin in activeWins)
                {
                    if (UIHelper.IsIndependentSysWindow(activeWin.mWndName) == false)
                    {
                        FinalWins.Add(activeWin);
                    }
                }
            }

            //对当前显示的面板归类（处理是主面板等因素）
            var hasSubWinList = new List<UIBaseWindow>();
            for (int i = 0; i < activeWins.Count; i++)
            {
                var baseWin = activeWins[i];
                if (baseWin.SubWindow.Count != 0)
                {
                    for (int j = 0; j < baseWin.SubWindow.Count; j++)
                    {
                        string subWind = baseWin.SubWindow[j];
                        var subBaseWin = FinalWins.Find(delegate (UIBaseWindow wind) { return wind.mWndName == subWind; });
                        if (subBaseWin != null)
                        {
                            FinalWins.Remove(subBaseWin);
                        }
                    }
                }
            }

            for (int i = 0; i < FinalWins.Count; i++)
            {
                string finalName = FinalWins[i].mWndName;

                bool supportBack = UIHelper.GetSupportBack(finalName);

                if(supportBack)
                {
                    bool can_add = false;
                    if (Winds.Count > 0 && Winds[Winds.Count - 1].wndName == finalName && UIHelper.IsUniqueWin(finalName))
                    {
                        can_add = true;
                    }
                    if (this.ContainWindow(finalName) == false)
                        can_add = true;
                    if (can_add)
                    {
                        var info = new WindowStackInfo();
                        info.wndName = finalName;
                        info.param = FinalWins[i].ShowParam;
                        info.supportBack = supportBack;

                        foreach (var subInfo in FinalWins[i].BackupOpenSubWindows)
                        {
                            info.BackupOpenSubWindow.Add(subInfo);
                        }

                        //Winds.Add(info);
                        TryAddWinds(info);
                    }
                }

                UIManager.Instance.CloseWindow(finalName);

                //if (!Winds.Contains(finalName))
                //    Winds.Add(finalName);

            }

            if (is_ban_back_last_panel)
                Clear();
            var initOpenSubWin = UIHelper.GetWindowInitOpenSubWin(name);

            bool canback = UIHelper.GetSupportBack(name);

            if (canback)
            {
                var CurInfo = new WindowStackInfo();
                CurInfo.wndName = name;
                CurInfo.param = param;
                CurInfo.supportBack = canback;

                foreach (var subInfo in initOpenSubWin)
                {
                    //CurInfo.BackupOpenSubWindow.Add(subInfo);
                }

                //Winds.Add(CurInfo);
                TryAddWinds(CurInfo);

                //Winds.Add(name);
                if (Winds.Count > StackMaxCount)
                {
                    int count = Winds.Count - StackMaxCount;
                    for (int i = 0; i < count; i++)
                    {
                        Winds.RemoveAt(0);
                    }
                }

            }

            UIManager.Instance.ShowWindow(name, param);
            if (initOpenSubWin.Count > 0)
            {
                for (int i = 0; i < initOpenSubWin.Count; i++)
                {
                    UIManager.Instance.ShowWindow(initOpenSubWin[i]);
                }
            }
        }

        //用於緩存面板是否可顯示暫時用作模態窗口 (是否考慮用在全局面板中判斷？)
        bool CheckUIStatus()
        {
            //************************************
            // 這裏用來判斷狀態是否允許打開 包含游戲狀態 角色狀態 等
            //************************************
            bool canShow = false;
            if ((UIManager.Instance.ModalWindow == null) || (UIManager.Instance.ModalWindow != null && UIManager.Instance.ModalWindow.IsShow == false))
                canShow = true;
            return canShow;
        }
        public int GetStackLen()
        {
            return this.Winds.Count;
        }

        public bool Pop(string name)
        {
            bool is_open_other_sys_window = false;
            UIManager.Instance.CloseWindow(name);

            if (Winds.Count > 0)
            {
                var lastInfo = Winds[Winds.Count - 1];

                if (name == lastInfo.wndName)
                {
                    Winds.RemoveAt(Winds.Count - 1);

                    if (Winds.Count == 0)
                    {
                        return false;
                    }

                    lastInfo = Winds[Winds.Count - 1];
                }

                //                  UIType lastUItype = UIHelper.GetUITypeByWindowName(name);
                //                  UIType currentUItype = UIHelper.GetUITypeByWindowName(name);

                //if (/*lastUItype == currentUItype && */ && name != lastInfo.wndName)
                if (lastInfo != null)
                {
                    UIManager.IsPopBackWin = true;
                    is_open_other_sys_window = UIManager.Instance.IsOpenedSysWindow(lastInfo.wndName);
                    if (UIManager.Instance.GetWindow(lastInfo.wndName) == null)
                    {
                        UIManager.Instance.ShowWindow(lastInfo.wndName, lastInfo.param);
                    }

                    if (!UIHelper.IsBanSubWindowWhenBack(lastInfo.wndName))
                    {
                        var backUpList = lastInfo.BackupOpenSubWindow;
                        foreach (var subInfo in backUpList)
                        {
                            UIManager.Instance.ShowWindow(subInfo.WinName, subInfo.ShowParam);
                        }
                    }
                    UIManager.IsPopBackWin = false;
                }
                if (Winds.Count > 0)
                {
                    Winds.RemoveAt(Winds.Count - 1);
                }
            }

            return is_open_other_sys_window;
        }

        public void Clear()
        {
            Winds.Clear();
        }
    }

}

