using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health;

	public void DealDammage(float dammage) {
		health -= dammage;

		if (health <= 0) {
			GameObject.Destroy (gameObject);
		}
	}
}
