using UnityEngine;
using System.Collections;

public class TouchMonoBehavior : MonoBehaviour {
	
	public void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
			Touch t = Input.GetTouch(i);
			//if (t.phase != TouchPhase.Stationary) // ignores Stationary in debugging since it's continuous
			//	Debug.Log ("Finger ID, " + t.fingerId + ", has " + t.phase + " at " + Time.time.ToString("0.00"));
			switch (t.phase) {
			case TouchPhase.Began:
				OnTouchBegan(t);
				break;
			case TouchPhase.Ended:
				OnTouchEnded(t);
				break;
			case TouchPhase.Moved:
				OnTouchMoved(t);
				break;
			case TouchPhase.Stationary:
				OnTouchStay(t);
				break;
			}
		}
	}

	// overrideable Touch event handlers
	// Note: each event handler is called depending on how many touches there are	
	public virtual void OnTouchBegan (Touch touch) {}
	public virtual void OnTouchEnded (Touch touch) {}
	public virtual void OnTouchMoved (Touch touch) {}
	public virtual void OnTouchStay (Touch touch) {}
	
	public virtual bool IsTouched () {
		return Input.touchCount > 0;
	}
	
	public bool IsRectTouched (Rect r) {
		for (int i = 0; i < Input.touchCount; i++) {
			if (r.Contains(Input.GetTouch(i).position))
				return true;
		}
		
		return false;
	}
}
