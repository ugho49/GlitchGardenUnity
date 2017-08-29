using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip("Average number of seconds between appearances")]
	public float seenEverySeconds;

	const float minSpeed = -1f;
	const float maxSpeed = 10f;
	float currentSpeed;
	GameObject currentTarget;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		currentSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);

		CheckAttackIsFinish ();
	}

	void CheckAttackIsFinish () {
		if (!currentTarget) {
			animator.SetBool ("IsAttacking", false);
		}
	}

	public void SetSpeed(float speed) {
		currentSpeed = Mathf.Clamp (speed, minSpeed, maxSpeed);
	}

	public void StrikeCurrentTarget(float damage) {

		if (!currentTarget) {
			return;
		}

		Health health = currentTarget.GetComponent<Health> ();

		if (!health) {
			return;
		}

		health.DealDammage (damage);
	}

	public void Attack(GameObject target) {
		currentTarget = target;
	}
}
