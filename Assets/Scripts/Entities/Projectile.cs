using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float dammage;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider) {

		GameObject obj = collider.gameObject;
		Attacker attacker = obj.GetComponent<Attacker> ();
		Health health = obj.GetComponent<Health> ();

		if (!attacker || !health) {
			return;
		}

		health.DealDammage (dammage);
		GameObject.Destroy (gameObject);
	}
}