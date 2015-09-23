using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	
	// Use this for initialization
	private void Start () {

	}

	// Update is called once per frame
	private void Update () {

		CheckDestroyCondition ();
	}

	private void CheckDestroyCondition(){	

		if (this.transform.position.y < (-8F))
			Destroy (gameObject);

	}

}