using UnityEngine;
using System.Collections;

public class applyBurn : MonoBehaviour
{
	public int damage;
	public float duration;

	void ApplyStatusEffect(GameObject burnedCharacter){
			Burn.CreateComponent(burnedCharacter, damage, duration);
	}
}

