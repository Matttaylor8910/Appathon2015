using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public Spawner enemySpawner;
	public const float enemySummonDelay = 3.5f;
	float timeFromLastEnemySummon = 0;
	
	// Update is called once per frame
	void Update () {
		timeFromLastEnemySummon += Time.deltaTime;
		if(timeFromLastEnemySummon > enemySummonDelay){
			timeFromLastEnemySummon = 0;
			enemySpawner.SpawnSingleCharacter(0);
		}
	}

}
