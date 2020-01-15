using UnityEngine;
using xc.ui;

namespace xc
{
	public class TrackWorldTargetInUI : MonoBehaviour
	{
		public Transform target = null;
		public Vector3 Offset = Vector3.zero;
		public Vector3 Size = Vector3.one;
		
		public void Update()
		{
			if(null != target)
			{
				Vector3 screenPos = Game.Instance.MainCamera.WorldToScreenPoint(target.position + Offset);
				if((screenPos.y + Size.y) > Screen.height)
					screenPos.y = Screen.height - Size.y;
				Vector3 worldPos = xc.ui.ugui.UIMainCtrl.MainCam.ScreenToWorldPoint(screenPos);
				transform.position = worldPos;
				worldPos = transform.localPosition;
				worldPos.z = 20 - target.position.z;
				transform.localPosition = worldPos;
			}
			else
			{
				GameObject.Destroy(gameObject);
			}
		}
	}
}
