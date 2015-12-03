using UnityEngine;
using System.Collections;

public class AttachSimpleBehaviour : MonoBehaviour {

	public GameObject parent;

	// Use this for initialization
	void Start () {

		gameObject.transform.parent = parent.transform;
	}
}
