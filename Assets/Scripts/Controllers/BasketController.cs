using UnityEngine;
using System.Collections;

public class BasketController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static bool CheckCollisionBasket()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		
		if(hit.collider != null)
			
			if (hit.collider.gameObject.tag == "Basket")
				
				return true;
		
		return false;
	}
}
