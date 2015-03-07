using UnityEngine;
using System.Collections;

public class RangeColliderListener : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		
		// If the Other Collider isn't the Ground or a Friendly
		if((other.tag.CompareTo("Ground") != 0) && (other.transform.parent.tag.CompareTo(this.transform.parent.tag) != 0)){
			this.SendMessageUpwards("EnemyInRange", true, SendMessageOptions.DontRequireReceiver);
		}

	}

	// Range Collider Listener (on Entrance)
	void OnTriggerStay2D(Collider2D other){

		// If the Other Collider isn't the Ground or a Friendly
		if((other.tag.CompareTo("Ground") != 0) && (other.transform.parent.tag.CompareTo(this.transform.parent.tag) != 0)){
			this.SendMessageUpwards("EnemyInRange", true,SendMessageOptions.DontRequireReceiver);
		}
		
	}

	// Range Collider Listener (on Exit)
	void OnTriggerExit2D(Collider2D other){
	
		// If the Other Collider isn't the Ground
		if(other == null || other.tag.CompareTo("Ground") != 0){
			this.SendMessageUpwards("EnemyInRange", false,SendMessageOptions.DontRequireReceiver);
		}
	}
}
