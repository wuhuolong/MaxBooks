using UnityEngine;
using System.Collections;

namespace xc.ui
{
    public class UIArcListEntryPositionModifier : MonoBehaviour
    {
        private static float mCenterWorldPosY;
        private static float mFactorDenominator;  // in world coordinate
        private static bool mStaticInitDone = false;

		public int radius = 200;
        public int maxHorizontalOffset = -200;
        public AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));

        private void Start()
        {
            if (!mStaticInitDone)
            {
				regetInitValue();
                mStaticInitDone = true;
            }
        }

        private void Update ()
        {
            if (transform.hasChanged)
            {
#if UNITY_EDITOR
				regetInitValue();
#endif
                float distance = transform.position.y - mCenterWorldPosY;
                float factor = Mathf.Abs(distance / mFactorDenominator);
                float clampedFactor = Mathf.Clamp01(factor);
                float animatedFactor = animationCurve.Evaluate(clampedFactor);
                float posX = animatedFactor * maxHorizontalOffset;
                Vector3 pos = transform.localPosition;
                pos.x = posX;
                transform.localPosition = pos;
                transform.hasChanged = false;
            }
        }

		private void regetInitValue()
		{
			UIRoot root = GetComponentInParent<UIRoot>();
			
			mCenterWorldPosY = root.transform.position.y;
			
			Vector3 pos = Vector3.zero;
			pos.y = root.activeHeight / 2 + radius;
			pos = root.transform.TransformPoint(pos);
			
			mFactorDenominator = pos.y - mCenterWorldPosY;
		}
    }
}
