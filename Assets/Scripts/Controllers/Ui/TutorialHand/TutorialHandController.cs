﻿using UnityEngine;
using System.Collections;

public class TutorialHandController : MonoBehaviour {

	readonly InputService inputService = Singleton<InputService>.GetInstance();

	// Update is called once per frame
	void Update () {

		if (inputService.IsInputDown ()) {

			Destroy (gameObject);
		}
	}
}
