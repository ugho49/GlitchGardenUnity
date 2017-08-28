using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Attacker))]
public class Lizard : MonoBehaviour {

	Animator animator;
	Attacker attacker;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject obj = collider.gameObject;

		// Leave if not colliding with defender
		if (!obj.GetComponent<Defender>()) {
			return;
		}

		animator.SetBool ("IsAttacking", true);
		attacker.Attack (obj);
	}
}
