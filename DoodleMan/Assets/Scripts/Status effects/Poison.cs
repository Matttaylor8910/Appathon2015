using UnityEngine;
using System.Collections;

public class Poison : MonoBehaviour {

	private GameObject poisonEffect;
	private int damage = 1;
	private float delayDamage = 0;
	private float damageDelayConstant = (float)1;

	void Update () {

		delayDamage += Time.deltaTime;

		if(delayDamage > damageDelayConstant){
			SendMessageUpwards("ReceiveDamage", damage, SendMessageOptions.DontRequireReceiver);
			delayDamage = 0;
		}

	}


	public static Poison CreateComponent (GameObject character, int dmg, float duration) {

		Poison poison = character.AddComponent<Poison>();
		poison.damage = dmg;
		poison.poisonEffect = (GameObject)Instantiate(Resources.Load ("Effects/Poison2"));
		poison.poisonEffect.transform.parent = character.transform;
		poison.poisonEffect.transform.localPosition = new Vector3(0,0,-2);
		poison.poisonEffect.transform.localScale = new Vector3(0.6f,2,2);
		Destroy (poison.poisonEffect, duration);
		Destroy (poison, duration);
		character.SendMessageUpwards("ReceiveDamage", dmg, SendMessageOptions.DontRequireReceiver);

		return poison;

	}

}
