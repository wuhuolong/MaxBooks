using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Utils;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace xc
{
    public class GameInput : xc.Singleton<GameInput>
	{
        public GameInput()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
        }

        ui.UIJoystick mJoystick;
        // 虚拟摇杆
        public ui.UIJoystick Joystick
        {
            get { return mJoystick; }
            set { mJoystick = value; }
        }

        public bool UseJoyStick //是否已开启虚拟手柄
        {
            get
            {
                return mJoystick != null;
            }
        }

        public bool AcceptInput = true;      //是否接受输入操作
        protected bool mbEnableInput = true;
        protected int mInputRef = 0;
		
        public void EnableInput(bool b, bool set_ui = false)
        {
            if (!b)
                mInputRef++;
            else
                mInputRef--;
            if (mInputRef <= 0)
                mbEnableInput = true;
            else
                mbEnableInput = false;
            RockCommandSystem.GetInstance().Enable = mbEnableInput;

            if(set_ui)
            {
                EventSystem event_sys = xc.ui.ugui.UIManager.Instance.MainCtrl.EventSystemCom;
                if (event_sys != null)
                    event_sys.enabled = mbEnableInput;
            }
            //Debug.LogWarning("EnableInput ref: " + mInputRef);
        }

        public int GetInputRef()
        {
            return mInputRef;
        }

        public bool GetEnableInput()
        {
            return mbEnableInput;
        }

        /// <summary>
        /// 重设Input的引用计数, 只能在进入副本和主城状态的时候使用
        /// </summary>
        public void ResetInputRef()
        {
            mInputRef = 0;
            mbEnableInput = true;
            RockCommandSystem.GetInstance().Enable = mbEnableInput;
            Debug.LogWarning("EnableInput ref: " + mInputRef);
        }

		public Vector2 Position
		{
			get { return mCurPos; }
		}

        /// <summary>
        /// 是否有输入
        /// </summary>
        public bool IsInput
        {
            get
            {
                return mCurPos != Vector2.zero;
            }
        }

        /// <summary>
        /// 重置Input的数值
        /// </summary>
        public void Reset()
        {
            mCurPos = Vector2.zero;
            if(mJoystick != null)
                mJoystick.ResetJoystick();
        }

        /// <summary>
        /// 是否有Input
        /// </summary>
        public bool IsFingerDown
        {
            get
            {
                if (mJoystick != null)
                    return mJoystick.IsFingerDown;
                else
                    return Input.GetMouseButton(0);
            }
        }

        public class HandScaleDistinguish
		{
			public float Scale { get { return mScale; } }
			float mScale = -1.0f;
			
			int[] mFingerIds = new int[2] { -1, -1 };
			Vector2[] mStartPos = new Vector2[2] { Vector2.zero, Vector2.zero };
			Vector2[] mCurPos = new Vector2[2] { Vector2.zero, Vector2.zero };
			
			void Reset()
			{
				mFingerIds[0] = -1;
				mFingerIds[1] = -1;
				mStartPos[0] = Vector2.zero;
				mStartPos[1] = Vector2.zero;
				mCurPos[0] = Vector2.zero;
				mCurPos[1] = Vector2.zero;
				mScale = 1.0f;
			}
			
			public void Update()
			{
				int count = Input.touchCount;
				if (count != 2)
				{
					Reset();
					return;
				}
				
				for (int i=0; i<count; ++i)
				{
					Touch touch = Input.GetTouch(i);
					
					if (mFingerIds[i] == -1)
					{
						mFingerIds[i] = touch.fingerId;
						mStartPos[i] = touch.position;
					}
					
					if (mFingerIds[i] == touch.fingerId)
						mCurPos[i] = touch.position;
				}
				
				Vector2[] dir = new Vector2[2] { Vector2.zero, Vector2.zero };
				dir[0] = mCurPos[0] - mStartPos[0];
				dir[1] = mCurPos[1] - mStartPos[1];
				
				if (dir[0] != Vector2.zero && dir[1] != Vector2.zero)
				{
					if (Vector2.Dot(dir[0].normalized, dir[1].normalized) < 0)
					{
						float startDist = (mStartPos[0]-mStartPos[1]).magnitude;
						float curDist = (mCurPos[0]-mCurPos[1]).magnitude;
						mScale = curDist / startDist;
					}
					else
					{
						Reset();
					}
				}
			}
		}
		public float HandScale
		{
			get { return mHandScale.Scale; }
		}
		HandScaleDistinguish mHandScale = new HandScaleDistinguish();
		
		Vector2 mCurPos = new Vector2();
		
        /// <summary>
        /// 是否调转XY的控制
        /// </summary>
        private bool mTurnHV = false;

        /// <summary>
        /// 是否调转水平正负方向的控制
        /// </summary>
        private bool mTurnHSide = false;

        /// <summary>
        /// 是否调转垂直正负方向的控制
        /// </summary>
        private bool mTurnVSide = false;

        /// <summary>
        /// Turns the input.
        /// </summary>
        /// <param name="hv">是否调转XY的控制</param>
        /// <param name="hSide">是否调转水平正负方向的控制</param>
        /// <param name="vSide">是否调转垂直正负方向的控制</param>
        public void TurnInput(bool hv, bool hSide, bool vSide)
        {
            mTurnHV = hv;
            mTurnHSide = hSide;
            mTurnVSide = vSide;
        }

        public void ResetTurn()
        {
            mTurnHV = false;
            mTurnHSide = false;
            mTurnVSide = false;
        }

		Vector2 GetInputDir()
		{
			float v = 0f;
			float h = 0f;
            if (GameInput.Instance.AcceptInput)
            {
                if (!UseJoyStick)
			    {
				    v = Input.GetAxis("Vertical");
				    h = Input.GetAxis("Horizontal");
					if(v != 0.0f) 
                        v = v > 0.0f ? -1.0f : 1.0f;
				    if(h != 0.0f) 
                        h = h > 0.0f ? -1.0f : 1.0f;
				}
				else
				{
                    if(mJoystick != null)
                    {
                        v = -mJoystick.position.y;
                        h = -mJoystick.position.x;
                    }
				}

                if(mTurnHV)
                {
                    float tmp = h;
                    h = v;
                    v = tmp;
                }

                if(mTurnHSide)
                {
                    h = -h;
                }

                if(mTurnVSide)
                {
                    v = -v;
                }
			}

			return new Vector2(h, v);
		}
		
        void OnStartSwitchScene(CEventBaseArgs arg)
        {
            ResetTurn();
        }

        public void Update()
		{
			if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
				mHandScale.Update();

			Vector2 pos = GetInputDir();
			mCurPos = pos;
		}
	}
}

