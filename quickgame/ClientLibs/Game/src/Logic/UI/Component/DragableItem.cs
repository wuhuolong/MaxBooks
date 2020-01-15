using UnityEngine;

public class DragableItem : MonoBehaviour
{
	Transform mTrans;
	bool mIsDragging = false;

	/// <summary>
	/// Drop the dragged object.
	/// </summary>
	void Drop ()
	{
		TweenAlpha.Begin (gameObject, 0.5f, 1);
	}

	/// <summary>
	/// Cache the transform.
	/// </summary>

	void Awake ()
	{ 
		mTrans = transform; 
	}

	/// <summary>
	/// Start the drag event and perform the dragging.
	/// </summary>

	void OnDrag (Vector2 delta)
	{
		if (enabled && UICamera.currentTouchID > -2) {
			if (!mIsDragging) {
				mIsDragging = true;
				
				Vector3 pos = mTrans.localPosition;
				pos.z = 0f;
				mTrans.localPosition = pos;
			} else {
				mTrans.localPosition += (Vector3)delta;
			}
		}
	}

	/// <summary>
	/// Start or stop the drag operation.
	/// </summary>

	void OnPress (bool isPressed)
	{
		if (enabled) {
			mIsDragging = false;
            Collider col = GetComponent<Collider>();
			if (col != null)
				col.enabled = !isPressed;
			if (!isPressed) 
				Drop ();
			else
				TweenAlpha.Begin (gameObject, 0.5f, 0.3f);
		}
	}
}
