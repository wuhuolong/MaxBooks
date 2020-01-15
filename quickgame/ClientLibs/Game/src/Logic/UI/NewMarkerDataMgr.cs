using xc.ui;
using UnityEngine;
using System.Collections.Generic;

namespace xc
{
    [wxb.Hotfix]
    public class NewMarkerDataMgr : xc.Singleton<NewMarkerDataMgr>
    {
        private Dictionary<uint, List<xc.ui.NewMarker>> mData = new Dictionary<uint, List<NewMarker>>();

        public NewMarkerDataMgr()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_MARKER_BIND, OnBind);
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_MARKER_UNBIND, OnUnBind);

        }

        public void Reset()
        {
            if (mData != null)
                mData.Clear();
        }

        public void OnBind(CEventBaseArgs eventParam)
        {
            if (eventParam == null || eventParam.arg == null)
                return;
            ui.NewMarker newMarker = eventParam.arg as ui.NewMarker;
            if (newMarker == null)
                return;
            if (newMarker.SystemId == 0)
                return;
            BindNewMarker(newMarker.SystemId, newMarker);
            FreshNewMarker(newMarker, false);
        }

        public void OnUnBind(CEventBaseArgs eventParam)
        {
            if (eventParam == null || eventParam.arg == null)
                return;
            ui.NewMarker newMarker = eventParam.arg as ui.NewMarker;
            if (newMarker == null)
                return;
            if (newMarker.SystemId == 0)
                return;
            UnBindNewMarker(newMarker.SystemId, newMarker);
        }

        public void FreshBySystemId(uint systemId, bool show)
        {
            if (mData.ContainsKey(systemId))
            {
                List<NewMarker> newMarkerList = mData[systemId];
                for (int i = 0; i < newMarkerList.Count; i++)
                {
                    NewMarker newMarker = newMarkerList[i];
                    if (newMarker != null)
                    {
                        FreshNewMarker(newMarker, show);
                    }
                }
            }
        }

        public void FreshNewMarker(NewMarker newMarker, bool show)
        {
            if (newMarker == null)
                return;
            if (newMarker.SystemId == 0)
                return;
            if (newMarker.RealObj != null)
            {
                newMarker.RealObj.SetActive(show);
            }
        }

        public void BindNewMarker(uint systemId, NewMarker newMarker)
        {
            if (mData.ContainsKey(systemId) == false)
            {
                mData.Add(systemId, new List<NewMarker>());
            }

            List<NewMarker> newMarkerList = mData[systemId];
            if (newMarkerList.Contains(newMarker) == false)
            {
                newMarkerList.Add(newMarker);
            }
        }

        public void UnBindNewMarker(uint systemId, NewMarker newMarker)
        {
            if (mData.ContainsKey(systemId) == false)
            {
                mData.Add(systemId, new List<NewMarker>());
            }
            List<NewMarker> newMarkerList = mData[systemId];
            if (newMarkerList.Contains(newMarker))
            {
                newMarkerList.Remove(newMarker);
            }
        }
    }
}
