﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {

	void Awake () {
		PlayerPrefs.DeleteAll ();

		PlayerPrefsManager.SetDefault ();
	}

}
