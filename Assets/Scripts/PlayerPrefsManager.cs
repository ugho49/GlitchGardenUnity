using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	const string KEY_MASTER_VOLUME = "master_volume";
	const string KEY_DIFFICULTY = "difficulty";
	const string KEY_LEVEL_UNLOCKED = "level_unlocked_";

	public static void SetDefault() {
		SetMasterVolume (0.15f);
		SetDifficulty (1f);

		Debug.Log ("reset prefs values to default");
	}

	public static void SetMasterVolume(float volume) {
		volume = Mathf.Clamp(volume, 0f, 1f);
		PlayerPrefs.SetFloat (KEY_MASTER_VOLUME, volume);
	}

	public static float GetMasterVolume() {
		return PlayerPrefs.GetFloat (KEY_MASTER_VOLUME);
	}

	public static void UnlockLevel(int level) {
		if (level > SceneManager.sceneCount - 1) {
			Debug.LogError ("Trying to unlock level not in build order");
		}

		PlayerPrefs.SetInt (KEY_LEVEL_UNLOCKED + level.ToString(), 1);
	}

	public static bool IsLevelUnlocked(int level) {
		string key = (KEY_LEVEL_UNLOCKED + level).ToString();

		if (!PlayerPrefs.HasKey (key)) {
			return false;
		}

		return PlayerPrefs.GetInt (key) == 1;
	}

	public static void SetDifficulty(float difficulty) {
		PlayerPrefs.SetFloat (KEY_DIFFICULTY, difficulty);
	}

	public static float GetDifficulty() {
		return PlayerPrefs.GetFloat (KEY_DIFFICULTY);
	}
}
