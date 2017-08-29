using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerPrefabs;

	// Update is called once per frame
	void Update () {
		foreach (GameObject obj in attackerPrefabs) {
			if (IsTimeToSpawn (obj)) {
				Spawn (obj);
			}
		}
	}

	void Spawn(GameObject attacker) {
		GameObject obj = Instantiate (attacker) as GameObject;
		obj.transform.parent = transform;
		obj.transform.position = transform.position;
	}

	bool IsTimeToSpawn(GameObject obj) {
		Attacker attacker = obj.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSeconds = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			return false;
		}

		float threshold = (spawnsPerSeconds * Time.deltaTime) / 5;

		return Random.value < threshold;
	}
}
