using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xc.ui;

namespace xc
{
    [wxb.Hotfix]
    public class RedPointDataMgr
    {
        private static RedPointDataMgr instance = null;
        public static RedPointDataMgr Instance
        {
            get { return GetInstance(); }
        }

        public static RedPointDataMgr GetInstance()
        {
            if (null == instance)
            {
                instance = new RedPointDataMgr();
            }
            return instance;
        }

        /// <summary>
        /// 保存红点状态
        /// </summary>
        Dictionary<uint, bool> mRedPointState = new Dictionary<uint, bool>();

        private DBRedPoint mDBRedPoint;
        RedPointDataMgr()
        {
            mDBRedPoint = DBManager.Instance.GetDB<DBRedPoint>();
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_SHOW, OnShowRedPoint);
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_DISAPPEAR, OnDisappearRedPoint);
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_BIND, OnBind);
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_UNBIND, OnUnBind);
            
        }

        public void Reset()
        {
            mRedPointState.Clear();

            if (mDBRedPoint != null)
            {
                mDBRedPoint.ClearData();
            }
        }

        void OnBind(CEventBaseArgs event_param)
        {
            if (event_param == null || event_param.arg == null)
                return;
            ui.RedPoint tmp_redPoint = event_param.arg as ui.RedPoint;
            if (tmp_redPoint == null)
                return;
            if (tmp_redPoint.PointKey == 0)
                return;
            OnRegisterRedPoint(tmp_redPoint.PointKey, tmp_redPoint.RedPointObj);
        }

        void OnUnBind(CEventBaseArgs event_param)
        {
            if (event_param == null || event_param.arg == null)
                return;
            ui.RedPoint tmp_redPoint = event_param.arg as ui.RedPoint;
            if (tmp_redPoint == null)
                return;
            if (tmp_redPoint.PointKey == 0)
                return;
            OnUnbindRedPoint(tmp_redPoint.PointKey, tmp_redPoint.RedPointObj);
        }

        void OnShowRedPoint(CEventBaseArgs event_param)
        {
            if (event_param == null || event_param.arg == null)
                return;
            string id_str = (string)(event_param.arg);
            uint red_point_id = 0;
            if (uint.TryParse(id_str, out red_point_id) == false)
                return;
            SetRedPointVisible_out(red_point_id, true);
        }

        void OnDisappearRedPoint(CEventBaseArgs event_param)
        {
            if (event_param == null || event_param.arg == null)
                return;
            string id_str = (string)(event_param.arg);
            uint red_point_id = 0;
            if (uint.TryParse(id_str, out red_point_id) == false)
                return;
            SetRedPointVisible_out(red_point_id, false);
        }

        void OnRegisterRedPoint(uint red_point_id, GameObject game_obj)
        {
            if (game_obj == null)
                return;
            DBRedPoint.DBRedPointItem item = mDBRedPoint.GetRedPointItem(red_point_id);
            if (item == null)
                return;
            item.obj = game_obj;
            bool is_visible = item.IsVisible;
            item.obj.SetActive(is_visible);
            //GameDebug.LogError(string.Format("OnRegisterRedPoint game_obj_name = {0} cur_name = {1} is_visible = {2}", self.mTmpls[cur_name].obj.name, cur_name, tostring(is_visible)))
        }


        void OnUnbindRedPoint(uint red_point_id, GameObject game_obj )
        {
            DBRedPoint.DBRedPointItem item = mDBRedPoint.GetRedPointItem(red_point_id);
            if (item == null)
                return;
            if (item.obj == game_obj)
                item.obj = null;
        }
        
        //(对外接口）设置某个叶子小红点是否可见
        void SetRedPointVisible_out(uint red_point_id, bool is_visible )
        {
            DBRedPoint.DBRedPointItem item = mDBRedPoint.GetRedPointItem(red_point_id);
            if (item == null)
                return;
            if(item.ChildIds != null && item.ChildIds.Count > 0)
            {//不允许直接设定非叶子节点
                GameDebug.LogError("不允许直接设定非叶子节点 red_point_id = " + red_point_id);
                return;
            }
            SetRedPointVisible_inner(red_point_id, is_visible);
        }
        

//is_visible@param 红点是否可见

        void SetRedPointVisible_inner(uint red_point_id, bool is_visible )
        {
            DBRedPoint.DBRedPointItem item = mDBRedPoint.GetRedPointItem(red_point_id);
            if (item == null)
                return;
            if (item.IsVisible == is_visible)
                return;
            item.IsVisible = is_visible;
            if (item.obj != null)
            {
                item.obj.SetActive(is_visible);
                //GameDebug.LogError(string.Format("SetRedPointVisible_inner cur_name = {0} is_visible = {1}", cur_name, tostring(is_visible)))
            }
            if (item.ParentIds == null)
                //没有父节点
                return;

            List<uint> parent_array = item.ParentIds;

            for(int index = 0; index < parent_array.Count; ++index)
            {
                RefreshRedPointVisible(parent_array[index]);
            }
        }


        public void RefreshRedPointVisible(uint red_point_id)
        {
            DBRedPoint.DBRedPointItem item = mDBRedPoint.GetRedPointItem(red_point_id);
            if (item == null)
                return;
            List<uint> child_array = item.ChildIds;
            if (child_array == null)
                return;
            bool is_visible = false;
            for(int index = 0; index < child_array.Count; ++index)
            {
                uint child_red_point_id = child_array[index];
                DBRedPoint.DBRedPointItem child_item = mDBRedPoint.GetRedPointItem(child_red_point_id);
                if(child_item != null && child_item.IsVisible)
                {
                    is_visible = true;
                }
            }
            SetRedPointVisible_inner(red_point_id, is_visible);
        }
        

        //is_visible@param 红点是否可见
        public bool GetRedPointVisible(uint red_point_id)
        {
            DBRedPoint.DBRedPointItem item = mDBRedPoint.GetRedPointItem(red_point_id);
            if (item == null)
                return false;
            return item.IsVisible;
        }

        public void BindRedPoint(GameObject go, uint pointKey, float deltaX = 0, float deltaY = 0, float scale = 1)
        {
            RedPoint redPoint = go.GetComponent<RedPoint>();
            if (redPoint == null)
            {
                redPoint = go.AddComponent<RedPoint>();
            }
            redPoint.DeltaX = deltaX;
            redPoint.DeltaY = deltaY;
            redPoint.Scale = scale;
            redPoint.PointKey = pointKey;
        }

        public void ResetSize(GameObject go)
        {
            if (go == null)
                return;
            RectTransform rect_transform = go.GetComponent<RectTransform>();
            if (rect_transform == null)
                return;
            rect_transform.sizeDelta = xc.ui.ugui.UIManager.Instance.UICache.RedPointSize;
        }

        /// <summary>
        /// 显示/隐藏小红点(在Lua也有utility.EnableRedPoint的逻辑，注意对于同一系统ID，两个函数不能同时使用)
        /// </summary>
        /// <param name="id">id, X小红点.xlsx中配置的id</param>
        /// <param name="enable">true显示，false隐藏</param>
        public void EnableRedPoint(uint id, bool enable)
        {
            bool fireEvent = false;
            bool state = false;
            if (mRedPointState.TryGetValue(id, out state))
            {
                if (enable != state)
                    fireEvent = true;
            }
            else
                fireEvent = true;

            if (fireEvent)
            {
                mRedPointState[id] = enable;

                string idKey = id.ToString();
                if (enable)
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NEW_REDPOINT_SHOW, new CEventBaseArgs(idKey));
                else
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NEW_REDPOINT_DISAPPEAR, new CEventBaseArgs(idKey));
            }
        }
    }
}

