using UnityEngine;
using System.Collections;

public class applyShock : MonoBehaviour
{
	public float duration = 1f;
	public float shockChance = .33f;

	void ApplyStatusEffect(GameObject shockedCharacter){

		if(shockedCharacter.GetComponent<Shock>() == null){
			if(Random.Range (0f,1f) < shockChance){
				Shock.CreateComponent(shockedCharacter, duration);
			}
		}
		else{
			shockedCharacter.GetComponent<Shock>().addDuration(duration);
		}
	}
}