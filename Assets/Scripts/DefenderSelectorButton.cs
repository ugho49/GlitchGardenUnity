using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSelectorButton : MonoBehaviour {

	public GameObject prefab;
	public static GameObject selectedDefender;

	DefenderSelectorButton[] buttons;

	// Use this for initialization
	void Start () {
		buttons = GameObject.FindObjectsOfType<DefenderSelectorButton> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Defender selected : " + selectedDefender);
	}

	void OnMouseDown() {
		foreach (DefenderSelectorButton btn in buttons) {
			btn.GetComponent<SpriteRenderer> ().color = Color.black;
		}

		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = prefab;
	}
}
