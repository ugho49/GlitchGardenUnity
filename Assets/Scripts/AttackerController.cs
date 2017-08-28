using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController : MonoBehaviour {

	[Range(-1f, 1f)]
	public float walkSpeed;

	// Use this for initialization
	void Start () {
		Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D> ();
		rigidbody2D.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log (name + " trigger enter");
	}
}
