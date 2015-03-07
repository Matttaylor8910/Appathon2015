using UnityEngine;
using System.Collections;

public class Shock : MonoBehaviour {
	
	private GameObject shockEffect;
	private float shockDelay = 0f;
	private float shockDuration = 1f;
	private float originalSpeed = 0f;
	private Character character;
	
	void Update () {

		shockDelay += Time.deltaTime;

		/////After delay unshock
		if(shockDelay > shockDuration){
			this.gameObject.GetComponent<Animator>().SetBool("isShocked", false);
			character.setSpeed (originalSpeed);
			Destroy(shockEffect);
			Destroy(this);
		}
	}

	/// Creates the component.
	/// creates a shock component on character for a duration
	public static Shock CreateComponent (GameObject characterObj, float duration) {

		Character character = characterObj.GetComponent<Character> ();
		float originalSpeed = character.moveSpeed;
		character.setSpeed (0);
		character.GetComponent<Animator>().SetBool("isShocked", true);

		Shock shock = characterObj.AddComponent<Shock>();
		shock.shockEffect = (GameObject)Instantiate(Resources.Load ("Effects/Shock"));
		shock.shockEffect.transform.parent = character.transform;
		shock.shockEffect.transform.localPosition = new Vector3(0,2f,-5f);
		shock.shockEffect.transform.localScale = new Vector3(1,2.5f,2);
		shock.shockDuration = duration;
		shock.character = character;
		shock.originalSpeed = originalSpeed;
		return shock;
		
	}

	public void addDuration(float time){
		shockDuration += time;
	}
}
