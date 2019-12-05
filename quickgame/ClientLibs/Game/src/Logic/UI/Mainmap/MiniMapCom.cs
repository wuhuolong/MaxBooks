using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;
using xc.ui;
using SGameEngine;
using Utils;
namespace xc
{
    namespace ui
    {

        public class MiniMapCom:MonoBehaviour,IPointerClickHandler
        {
            public void OnPointerClick(PointerEventData eventData)
            {
                //GameDebug.LogError(string.Format("pointer.position.x==={0}pointer.position.y=={1}", eventData.position.x, eventData.position.y));
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MINI_MAP_COM_POS, new CEventBaseArgs(eventData.position));
            }
        }
    }
}
