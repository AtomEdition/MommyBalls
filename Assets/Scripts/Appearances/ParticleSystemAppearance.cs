﻿using UnityEngine;
using System.Collections;

public class ParticleSystemAppearance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sortingLayerName = "Foreground";
		GetComponent<Renderer>().sortingOrder = 10;
	}
}
