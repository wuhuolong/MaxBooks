using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xc.ui;
namespace xc
{
    public class UIArcTabMenu : MonoBehaviour
    {
        public Transform MenuItemParent;
        public Transform DestinationPosition;
        public bool IsDynamic = false;
        public string ArcTabGroup = "mission";
        public UIScrollView ScrollView { get; set; }
        public Transform MainBtnsRoot;
        public string SpriteUnToogle;
        public string SpriteToggle;
        public string DefaultToggleName;
         
        public EventDelegate BranchBtnCB { get; set; }

        private Dictionary<string, List<string>> mRankTypeToSubMenu = new Dictionary<string, List<string>>();
        private UIButton currentBranchButton;
        private UIButton currentMainButton;
        private bool mIsAnimating = false;
        public delegate void onHideMenu(List<string> branchBtnNames);
        public onHideMenu onHide;
        public static string currentSubTypeName;
        /// <summary>
        /// menus 主btn 附btnlist
        /// </summary>
       
        private void OnEnable()
        {
            if (currentMainButton != null)
            {
                currentMainButton.GetComponent<UIButton>().normalSprite = SpriteUnToogle;
                currentMainButton.GetComponent<UIButton>().hoverSprite = SpriteUnToogle;

                List<string> items = mRankTypeToSubMenu [currentMainButton.name];
                foreach (string item in items)
                {
                    Transform t = MenuItemParent.FindChild(item);
                    if(t == null)
                    {
                        continue;
                    }
                    t.gameObject.SetActive(false);
                }

                currentMainButton = null;
            }
        }

        void OnDisable()
        {
            mIsAnimating = false;
        }

        public void SetArcTabMenu(Dictionary<string, List<string>> menus)
        {
            mRankTypeToSubMenu = menus;
        }

        public void OnBranchButton()
        {
            if(UIButton.current != null)
                SwitchBranchButton(UIButton.current.name);
        }

        public void OnMainButton()
        {
            if(UIButton.current != null)
                SwitchMainButton(UIButton.current.name);
        }

        public void SwitchMainButton(string name)
        {
            if (IsAnimating())
            {
                return;
            }
            Transform buttonTran = null;
            if(MainBtnsRoot != null)
                buttonTran = MainBtnsRoot.FindChild(name);
            if (buttonTran == null)
            {
                return;
            }
            UIButton button = buttonTran.GetComponent<UIButton>();
            if (currentMainButton == button)
            {
                StartCoroutine(HideSubMenuOnly(currentMainButton));
                return;
            }
            else
            {
                StartCoroutine(ShowSubMenu(button));
            }
        }

        public bool IsAnimating()
        {
            return mIsAnimating;
        }

        public void OnBrunchButton()
        {
            if(UIButton.current != null)
                SwitchBranchButton(UIButton.current.name);
        }

        public void SwitchBranchButton(string name)
        {
            currentSubTypeName = name;
            Transform buttonTran = MenuItemParent.FindChild(name);
            if (buttonTran == null)
            {
                return;
            }

            UIButton button = buttonTran.GetComponent<UIButton>();
            
            if (currentBranchButton == button)
            {
                return;
            }
            
            if (currentBranchButton != null)
            {
                UIRankButton rankButton = currentBranchButton.GetComponent<UIRankButton>();

                if(rankButton != null)
                {
                    rankButton.DisActive();
                }

            }

            UIRankButton rankButton2 = button.GetComponent<UIRankButton>();

            if(rankButton2 != null)
            {
                rankButton2.Active();
            }

            currentBranchButton = button;
            if (BranchBtnCB != null)
            {
                BranchBtnCB.Execute();
            }
        }
        private IEnumerator ShowSubMenu(UIButton button)
        {
            mIsAnimating = true;
            if (button == null)
            {
                yield break;
            }

            //hide
            if (currentMainButton != null)
            {
                yield return StartCoroutine(HideSubMenu(currentMainButton));

            }

            if (button == null)
            {
                yield break;
            }

            UIRankButton rankButton = button.GetComponent<UIRankButton>();

            if (rankButton != null)
            {
                rankButton.Active();
            }

            List<string> items = null;

            if (mRankTypeToSubMenu.TryGetValue(button.name, out items) == false)
            {
                mIsAnimating = false;
                yield break;
            }

            button.GetComponent<UIButton>().normalSprite = SpriteToggle;
            button.GetComponent<UIButton>().hoverSprite = SpriteToggle;
            gameObject.transform.localPosition = new Vector3(-848 ,  gameObject.transform.localPosition.y , gameObject.transform.localPosition.z);
            TweenPosition tweener = TweenPosition.Begin(gameObject , 0.1f ,  new Vector3(-476 , gameObject.transform.localPosition.y , gameObject.transform.localPosition.z));
            //                      TweenPosition tweener = TweenPosition.Begin(gameObject , 0.3f ,  new Vector3(-848 , gameObject.transform.localPosition.y , gameObject.transform.localPosition.z));
            while (tweener.enabled)
            {
                yield return new WaitForEndOfFrame();
            } 
            currentMainButton = button;

            //show sub
            if (currentMainButton == null)
            {
                yield break;
            }

            UIArcTab dstArcTab = null;
            UIToggle toggleFirst = null;
            UIToggle toggleDefault = null;
            if (items != null)
            {
                int index = 0;
                int middle = items.Count / 2;
                foreach (string item in items)
                {
                    Transform t = MenuItemParent.FindChild(item);
                    if (t == null)
                    {
                        continue;
                    }
                    if(index == 0)
                    {
                        toggleFirst = t.GetComponent<UIToggle>();
                    }
                    if(item == DefaultToggleName)
                    {
                        toggleDefault = t.GetComponent<UIToggle>();
                    }
                    if(index == middle)
                    {
                        dstArcTab = t.gameObject.GetComponent<UIArcTab>();
                    }
                    t.position = currentMainButton.transform.position;
                    t.gameObject.SetActive(true);
                    index ++;
                }
            }
            yield return StartCoroutine(UIArcTab.RefreshToDstPosition(ArcTabGroup, dstArcTab, DestinationPosition));
//            yield return StartCoroutine (UIArcTab.RefreshToDstPosition(ArcTabGroup, currentMainButton.GetComponent<UIArcTab>(), currentMainButton.transform));
            //restrict with in panel
            ScrollView.RestrictWithinBounds(true);
            mIsAnimating = false;
            if (toggleDefault != null)
            {
                toggleDefault.value = true;
                SwitchBranchButton(toggleDefault.name);
            }
            else
            {
                //set the frist
                if (toggleFirst != null)
                {
                    toggleFirst.value = true;
                }
                SwitchBranchButton(items[0]);
            }

            DefaultToggleName = "";
        }

        private IEnumerator HideSubMenuOnly (UIButton button)
        {
            mIsAnimating = true;
            yield return StartCoroutine(HideSubMenu(button));
            mIsAnimating = false;
        }

        private IEnumerator HideSubMenu(UIButton button)
        {
            if (button == null)
            {
                yield break;
            }
            button.GetComponent<UIButton>().normalSprite = SpriteUnToogle;
            button.GetComponent<UIButton>().hoverSprite = SpriteUnToogle;
            UIRankButton rankButton = button.GetComponent<UIRankButton>();

            if (rankButton != null)
            {
                rankButton.DisActive();
            }

            if (!mRankTypeToSubMenu.ContainsKey(button.name))
            {
                yield break;
            }

            List<string> items = mRankTypeToSubMenu [button.name];
            foreach (string item in items)
            {
                Transform t = MenuItemParent.FindChild(item);
                if(t == null)
                {
                    continue;
                }
                t.gameObject.SetActive(false);
            }
            gameObject.transform.localPosition = new Vector3(-476 ,  gameObject.transform.localPosition.y , gameObject.transform.localPosition.z);
            TweenPosition tweener = TweenPosition.Begin(gameObject , 0.1f ,  new Vector3(-848 , gameObject.transform.localPosition.y , gameObject.transform.localPosition.z));
            while (tweener.enabled)
            {
                yield return new WaitForEndOfFrame();
            }
            yield return StartCoroutine (UIArcTab.RefreshToDstPosition(ArcTabGroup, button.GetComponent<UIArcTab>(), button.transform));
            currentMainButton = null;
            if(IsDynamic)
            {
                if(onHide != null)
                    onHide(items);
            }
        }
    }
}


