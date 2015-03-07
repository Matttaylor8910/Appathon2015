using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public int	health  = 100;

	// Update is called once per frame
	void Update () {	
		if(health <= 0){
			kill ();
		}
	}

	void ReceiveDamage(int damage){
		
		health -= damage;
		
	}

	void kill(){
	
		bool win = false;
		
		if(this.tag.CompareTo("Enemy") == 0){
			
			win = true;
		
		}
	
		// Destroy Base
		this.gameObject.SetActive(false);
		Destroy(this.gameObject);
		
		// Send Message to EndGame in "MainGame.cs"
		GameObject.Find("Main Camera").transform.GetComponent<MainGame>().SendMessage("EndGame", win);
	}
}
