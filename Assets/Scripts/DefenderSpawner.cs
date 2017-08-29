using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	const string PARENT_NAME = "Defenders";

	public Camera myCamera;

	GameObject defenderParent;
	StarDisplay starDisplay;

	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		defenderParent = GameObject.Find(PARENT_NAME);

		if (!defenderParent) {
			defenderParent = new GameObject (PARENT_NAME);
		}
	}

	void OnMouseDown() {
		GameObject defenderToSpawn = DefenderSelectorButton.selectedDefender;

		if (!defenderToSpawn) {
			return;
		}

		int defenderCost = defenderToSpawn.GetComponent<Defender> ().starCost;

		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.FAILURE) {
			return;
		}

		Vector2 position = SnapToGrid(CalculateWorldPointOfMouseClick());
		GameObject obj = Instantiate (defenderToSpawn, position, Quaternion.identity) as GameObject;
		obj.transform.parent = defenderParent.transform;
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);

		return myCamera.ScreenToWorldPoint (weirdTriplet);
	}

	Vector2 SnapToGrid(Vector2 rawPosition) {
		float newX = Mathf.RoundToInt (rawPosition.x);
		float newY = Mathf.RoundToInt (rawPosition.y);
		return new Vector2 (newX, newY);
	}
}
