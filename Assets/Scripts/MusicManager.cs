using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChange;

	AudioSource audioSource;
	static int currentPlayIndex = 0;

	void Awake() {
		DontDestroyOnLoad (gameObject);
	}

	void Start() {
		audioSource = GetComponent<AudioSource> ();
		SetVolume (PlayerPrefsManager.GetMasterVolume ());
		// Load the splash sreen music here
		Play (levelMusicChange [0], false);
	}

	void OnEnable()
	{
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable()
	{
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		int index = scene.buildIndex;

		// Don't load the splash sreen music here
		if (index == 0) {
			return;
		}
			
		// Check if music exist for this scene
		if (levelMusicChange.Length <= index || levelMusicChange [index] == null) {
			Debug.Log ("no music for this scene");
			return;
		}

		if (currentPlayIndex == index) {
			Debug.Log ("Music already playing for this scene");
			return;
		}

		currentPlayIndex = index;
		Play (levelMusicChange [index], true);
	}

	void Play(AudioClip clip, bool loop) {
		if (clip) {
			audioSource.clip = clip;
			audioSource.loop = loop;
			audioSource.Play ();

			Debug.Log ("Playing " + clip.ToString());
		}
	}

	public void SetVolume(float volume) {
		if (volume == audioSource.volume) {
			return;
		}
		audioSource.volume = volume;
		Debug.Log ("set volume to " + volume.ToString());
	}
}
