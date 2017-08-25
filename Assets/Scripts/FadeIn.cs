using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;

	Image fadePanel;
	Color currentColor;

	void Start () {
		fadePanel = GetComponent<Image> ();
		currentColor = fadePanel.color;
	}

	void Update() {
		if (Time.timeSinceLevelLoad >= fadeInTime) {
			gameObject.SetActive (false);
			return;
		}

		float alphaChange = Time.deltaTime / fadeInTime;
		currentColor.a -= alphaChange;
		fadePanel.color = currentColor;
	}
}
