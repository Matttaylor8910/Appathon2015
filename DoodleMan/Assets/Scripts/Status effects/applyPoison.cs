using UnityEngine;
using System.Collections;

public class applyPoison : MonoBehaviour {

	public int damage;
	public float duration;

	void ApplyStatusEffect(GameObject poisonedCharacter){
		if(poisonedCharacter.GetComponent<Poison>() == null){
			Poison.CreateComponent(poisonedCharacter, damage, duration);
		}
	}
}
