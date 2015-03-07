using UnityEngine;
using System.Collections;

public class Burn : MonoBehaviour {

	private GameObject burnEffect;
	private GameObject character;
	private int damage = 1;
	private float delayDamage = 0;
	private float damageDelayConstant = (float)0.5;
	
	void Update () {
		
		delayDamage += Time.deltaTime;
		if(delayDamage > damageDelayConstant){
			delayDamage = 0;
			SendMessageUpwards("ReceiveDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
		
	}

	public static Burn CreateComponent (GameObject character, int dmg, float duration) {


		Burn burn = (Burn) character.AddComponent<Burn>();
		burn.damage = dmg;
		burn.character = character;
		burn.burnEffect = (GameObject)Instantiate(Resources.Load ("Effects/Burn"));
		burn.burnEffect.transform.parent = character.transform;
		burn.burnEffect.transform.localPosition = new Vector3(0,0,-5);
		burn.burnEffect.transform.localScale = new Vector3(1,1,1);
		Destroy (burn.burnEffect, duration);
		Destroy (burn, duration);
		
		return burn;
		
	}
}
