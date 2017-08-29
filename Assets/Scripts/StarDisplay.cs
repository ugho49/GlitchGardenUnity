using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Text))]
public class StarDisplay : MonoBehaviour {

	Text text;
	int stars;

	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		stars = 100;
		UpdateDisplay ();
	}

	void UpdateDisplay() {
		text.text = stars.ToString ();
	}

	public void AddStars(int amount) {
		stars += amount;
		UpdateDisplay ();
	}

	public Status UseStars(int amount) {
		if (stars < amount) {
			return Status.FAILURE;
		}

		stars -= amount;
		UpdateDisplay ();
		return Status.SUCCESS;
	}
}
