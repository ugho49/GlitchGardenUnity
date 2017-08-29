using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Slider))]
public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;

	Slider timeSlider;
	AudioSource audioSource;
	bool isEnOfLevel;
	LevelManager levelManager;
	GameObject winLabel;

	// Use this for initialization
	void Start () {
		isEnOfLevel = false;
		timeSlider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		winLabel = GameObject.Find ("WinLabel");
		winLabel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		HandleTime ();
	}

	void HandleTime() {
		if (isEnOfLevel) {
			return;
		}

		timeSlider.value = Time.timeSinceLevelLoad / levelSeconds;

		if (Time.timeSinceLevelLoad >= levelSeconds) {
			isEnOfLevel = true;
			winLabel.SetActive (true);
			audioSource.Play ();
			Invoke ("LoadNextLevel", audioSource.clip.length);
		}
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel ();
	}
}
