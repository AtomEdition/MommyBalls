using UnityEngine;
using System.Collections;

public class AttachSimpleBehaviour : MonoBehaviour {

	public GameObject parent;

	// Use this for initialization
	void Start () {

		this.gameObject.transform.parent = parent.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
