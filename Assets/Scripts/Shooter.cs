using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	const string PARENT_NAME = "Projectiles";
	public GameObject projectile;
	public GameObject gun;

	Animator animator;
	GameObject projectileParent;
	AttackerSpawner myLaneSpawner;

	void Start() {
		animator = GetComponent<Animator> ();
		projectileParent = GameObject.Find(PARENT_NAME);

		if (!projectileParent) {
			projectileParent = new GameObject (PARENT_NAME);
		}

		SetMyLaneSpawner ();
	}

	void Update() {
		animator.SetBool ("IsAttacking", IsAttackerAheadInLane ());
	}

	void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	void SetMyLaneSpawner() {
		AttackerSpawner[] spawners = GameObject.FindObjectsOfType<AttackerSpawner> ();

		foreach (AttackerSpawner spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
	}

	bool IsAttackerAheadInLane () {
		return myLaneSpawner.transform.childCount > 0;
	}
}
