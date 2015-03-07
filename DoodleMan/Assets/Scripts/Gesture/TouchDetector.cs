using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchDetector : TouchMonoBehavior {

	public TouchIdentifier touchIdentifier;
	private Transform touchId;
	private int fingerId;
	private float timeCreated;
	private Gesture gesture; 

	void Start () {
		Transform t = Instantiate(touchIdentifier.transform) as Transform;
		t.parent = transform;
		t.name = "Touch ";
		touchId = t;
		touchId.gameObject.SetActive(false);
		touchId.gameObject.GetComponent<ParticleSystem>().Stop();
		touchId.gameObject.GetComponent<ParticleSystem>().Clear();
		//touchId.gameObject.SetActive(true);
		fingerId = -1;
		timeCreated = Time.time;


		gesture = this.transform.GetComponent<Gesture>();
		}

	public override void OnTouchBegan (Touch touch)
	{
		if (!touchId.gameObject.activeSelf) {
			fingerId = touch.fingerId;
			timeCreated = Time.time;
			Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
			pos.z = 0;
			touchId.position = pos;
			touchId.gameObject.GetComponent<ParticleSystem>().Play();
			touchId.gameObject.SetActive(true);
			Vector2 p = new Vector2(pos.x , pos.y);
			gesture.AddPoint(p);
		}
	}
	
	public override void OnTouchMoved (Touch touch)
	{
		if (fingerId == touch.fingerId) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
			pos.z = 0;
			touchId.position = pos;
			Vector2 p = new Vector2(pos.x , pos.y);
			gesture.AddPoint(p);
		}
	}
	
	public override void OnTouchEnded (Touch touch)
	{
		if (fingerId == touch.fingerId) {
			fingerId = -1;
			gesture.Recognize();
			InitParticles();
			//Invoke("InitParticles", 1);
		}
	}

	public void InitParticles(){
		touchId.gameObject.SetActive(false);
		touchId.gameObject.GetComponent<ParticleSystem>().Stop();
		touchId.gameObject.GetComponent<ParticleSystem>().Clear();
	}

	
	//void OnGUI () {
	//	GUI.skin.box.fontSize = 32;
	//}
}
