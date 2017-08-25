using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;

	public LevelManager levelManager;
	MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();

		LoadSliders ();
	}
	
	// Update is called once per frame
	void Update () {
		if (musicManager) {
			musicManager.SetVolume(volumeSlider.value / 20);
		}
	}

	public void Save() {
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value / 20);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);

		Debug.Log("Options Saved");
		// Go back to start menu
		levelManager.LoadLevel ("01_Start");
	}

	public void SetDefault() {
		PlayerPrefsManager.SetDefault ();
		LoadSliders ();
	}

	void LoadSliders() {
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume () * 20;
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}
}
