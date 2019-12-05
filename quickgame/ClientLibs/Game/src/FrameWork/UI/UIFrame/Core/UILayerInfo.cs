
using System.Collections.Generic;

namespace xc.ui.ugui
{
    public class UILayerInfo
    {

#region 表格配置区域常量
        public const int STATIC_CONFIG_BOTTOM_START = 1;
        public const int STATIC_CONFIG_BOTTOM_END = 100;

        public const int STATIC_CONFIG_TOP_START = 800;
        public const int STATIC_CONFIG_TOP_END = 1000;
        #endregion

        private const int DYN_INTERN = 20;

        public const int LEFT_MARGIN = 50;
        public const int RIGHT_MARGIN = 950;

        public const int STATIC_TOP_START = 600;
        public const int STATIC_TOP_END = 800;

        public const int STATIC_BOTTOM_START = 50;
        public const int STATIC_BOTTOM_END = 250;

        public const int DYNAMIC_START = 200;
        public const int DYNAMIC_END = 500;

        public int layerIndex;
        public int layerMin;
        public int layerMax;

        public int layerStaticTopMin;
        public int layerStaticTopMax;

        public int layerStaticBottomMin;
        public int layerStaticBottomMax;

        public int layerDynMin;
        public int layerDynMax;

        public UIType type;
        public float planeDistance;

        private class DynamicLayerIndexStackInfo
        {
            public int index;
            public string windowName;
        }

        private List<DynamicLayerIndexStackInfo> dynLayerStack;


        public UILayerInfo(int index, UIType type, float planeDistance)
        {
            this.layerIndex = index;
            this.type = type;
            this.planeDistance = planeDistance;

            int offset = index * 1000;

            this.layerMin = offset + LEFT_MARGIN;
            this.layerMax = offset + RIGHT_MARGIN;

            this.layerDynMin = offset + DYNAMIC_START;
            this.layerDynMax = offset + DYNAMIC_END;

            this.layerStaticBottomMin = offset + STATIC_BOTTOM_START;
            this.layerStaticBottomMax = offset + STATIC_BOTTOM_END;

            this.layerStaticTopMin = offset + STATIC_TOP_START;
            this.layerStaticTopMax = offset + STATIC_TOP_END;

            dynLayerStack = new List<DynamicLayerIndexStackInfo>();

        }

        /// <summary>
        /// 拿这个面板所在层级的新的动态层次
        /// </summary>
        /// <param name="win"></param>
        /// <returns></returns>
        public int GetNewDynamicLayerIndex(UIBaseWindow win)
        {

            if (win.staticLayerIndex != -1)
            {
                return win.staticLayerIndex;
            }

            string wndName = win.mWndName;

            if (dynLayerStack.Count == 0)
            {
                DynamicLayerIndexStackInfo first = new DynamicLayerIndexStackInfo();
                first.index = layerDynMin;
                first.windowName = wndName;

                dynLayerStack.Add(first);

                return first.index;
            }

            var info = GetDynLayerInfo(wndName);

            var top = dynLayerStack[dynLayerStack.Count - 1];

            if (info == null)
            {
                //没有取栈顶index
                info = new DynamicLayerIndexStackInfo();

                info.index = top.index + DYN_INTERN;
                info.windowName = wndName;

                dynLayerStack.Add(info);
            }
            else
            {
                //有的话移动到栈顶

                if (top != info)
                {
                    int topIndex = top.index + DYN_INTERN;

                    info.index = topIndex;

                    dynLayerStack.Remove(info);

                    dynLayerStack.Add(info);
                }
            }

            return info.index;

        }

        private DynamicLayerIndexStackInfo GetDynLayerInfo(string wndName)
        {
            for (int i = 0; i < dynLayerStack.Count; i++)
            {
                if (wndName == dynLayerStack[i].windowName)
                {
                    return dynLayerStack[i];
                }
            }

            return null;
        }

        /// <summary>
        /// 删除掉这个面板的动态层级
        /// </summary>
        /// <param name="win"></param>
        /// <returns></returns>
        public void RemoveDynamicLayerIndex(UIBaseWindow win)
        {
            if (win.staticLayerIndex != -1)
            {
                return;
            }

            var info = this.GetDynLayerInfo(win.mWndName);

            if (info == null)
            {
                return;
            }

            this.dynLayerStack.Remove(info);
        }


        public int GetStaticLayerIndex(int config_index)
        {
            if (config_index == -1)
            {
                return -1;
            }

            if (config_index >= STATIC_CONFIG_BOTTOM_START && config_index <= STATIC_CONFIG_BOTTOM_END)
            {
                return this.layerStaticBottomMin + config_index;
            }
            else if (config_index >= STATIC_CONFIG_TOP_START && config_index <= STATIC_CONFIG_TOP_END)
            {
                return this.layerStaticTopMin + (config_index - STATIC_CONFIG_TOP_START) + 1;
            }
            else
            {
                GameDebug.LogError("UI层级配置错误:" + config_index);
                return -1;
            }

        }


    }
}