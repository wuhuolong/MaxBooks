using UnityEngine;

namespace xc
{
	namespace ui
	{
		public class UIMainmapJoystick : UIJoystick
		{
			public override void ResetJoystick()
			{
                m_Position = Vector2.zero;
                m_LastFingerId = -1;
                m_LastFingerTime = 0;

                if (m_Thumb != null)
                {
                    m_ThumbTrans.localPosition = new Vector3(0f, 0f, -1.0f);
                    m_Thumb.color = new Color(m_Thumb.color.r, m_Thumb.color.g, m_Thumb.color.b, TouchReleaseAlhpa);
                }

                Color release_color = Color.white;
                release_color.a = TouchReleaseAlhpa;
                m_BackImage.color = release_color;
			}

            /// <summary>
            /// 设置Joystick的透明度
            /// </summary>
			protected override void ShowJoystick(Vector3 screenPosition)
			{
                if(m_Thumb != null)
                    m_Thumb.color = new Color(m_Thumb.color.r, m_Thumb.color.g, m_Thumb.color.b, 1.0f);

                m_BackImage.color = Color.white;
			}
		}
	} // ui
} // xc

