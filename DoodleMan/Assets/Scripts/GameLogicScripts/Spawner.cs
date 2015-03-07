using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Spawner Attributes
	public float spawnTime = 50.0f;			// Amount of Time before each Default Spawn.
	
	public GameObject[] characters;			// Array of Character Prefabs.

	
	// Spawns an Enemy at the location of the Spawner
	public void DefaultSpawn () {

		// Default Spawning Character
		GameObject defaultSpawn = characters[0];
		
		// Spawn the Character at the Spawner's Position
		Instantiate(defaultSpawn, transform.position, transform.rotation);
		
		// Play Spawning Particle Effect
		/*
			foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>()){
				p.Play();
			}
		*/
	
	}

	
	// Spawns a Specific Character at the location of the Spawner
	public void SpawnSingleCharacter(int characterID) {
		
		// Default Spawning Character
		GameObject defaultSpawn = characters[characterID];
		
		// Spawn the Character at the Spawner's Position
		Instantiate(defaultSpawn, transform.position, transform.rotation);
		
		// Play Spawning Particle Effect
		/*
			foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>()){
				p.Play();
			}
		*/
		
	}
}
