using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using xc;
namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIGoodsTipsComponent :MonoBehaviour,IPointerDownHandler
    {
        private void Awake()
        {
            
        }

        void Update()
        {
            var select = EventSystem.current.currentSelectedGameObject;
            if (select != null)
                GameDebug.LogError(string.Format("当前选择的Gameobj ===={0}", select.name));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            GameObject rawPointerPress = eventData.rawPointerPress;
            if (rawPointerPress != null)
            {

            }
        }
    }
}
