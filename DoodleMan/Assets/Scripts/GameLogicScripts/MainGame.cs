using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {
	public const float maxDelayBetweenSymbols = 3;
	public Spawner allySpawner;
	float delay;
	bool betweenGestures = false;
	string currentGesure;
	bool newGesture = false;
	string state = "waitFirGest";

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		if(betweenGestures){
			delay += Time.deltaTime;
		}

		switch (state){
		case "waitFirGest": 
			if(newGesture){
				switch (currentGesure){
				case "spiral":
					newGesture = false;
					allySpawner.SpawnSingleCharacter(0);
					break;
				case "star":
					updateState("star");
					break;
				case "triangle":
					newGesture = false;
					allySpawner.SpawnSingleCharacter(1);
					break;
				case "lightning":
					newGesture = false;
					allySpawner.SpawnSingleCharacter(2);
					break;
				}
			}
			break;
		case "star":
			if(newGesture){
				if(currentGesure == "square"){
					updateState("starSquare");
				}
				else{
					state = "waitFirGest";
					betweenGestures = false;
				}
			}
			else{
				if(delay > maxDelayBetweenSymbols){
					state = "waitFirGest";
					betweenGestures = false;
				}
			}
			break;
		case "starSquare":
			if(newGesture){
				if(currentGesure == "pigtail"){
					newGesture = false;
					allySpawner.SpawnSingleCharacter(3);
				}
				else{
					state = "waitFirGest";
					betweenGestures = false;
				}
			}
			else{
				if(delay > maxDelayBetweenSymbols){
					state = "waitFirGest";
					betweenGestures = false;
				}
			}
			break;
		}	 
	}
	
	private void updateState(string st){
		newGesture = false;
		state = st;
		delay = 0;
		betweenGestures = true;
	}

	public void recieveGesture(string gesture){
		currentGesure = gesture;
		newGesture = true;
	}
	
	private void EndGame(bool win){
		// Pause Game
		Time.timeScale = 0;

		string WinMessage = "";
	
		// Check if the Player Won/Lost
		if(win){
		
			WinMessage = "Victory!";
		
		} else {
		
			WinMessage = "Defeat...";
		
		}
		
		// Set GUI Win_Message Text
		GameObject.Find("Win_Message").GetComponent<GUIText>().text = WinMessage;
	}
}
