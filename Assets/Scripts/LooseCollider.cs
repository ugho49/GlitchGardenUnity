using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour {

	LevelManager levelManager;

	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		if (!levelManager) {
			Debug.LogError ("No levelManager found");
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		levelManager.LoadLevel ("99b_Loose");
	}
}
