using UnityEngine;
using System.Collections;

public class RaindropScript : MonoBehaviour {
	
	public GameObject bee; //need to grab a bool and change it to true

	public float rainSpeed; //can change this each level

	float XPos;
	bool HitBee;

	void Start () 
	{
		XPos = gameObject.transform.position.x; //this needs to be updated once at the start, used when reset the drop
		HitBee = bee.GetComponent<TestMovement>().HitByRain; //update this in update
	}

	void Update () 
	{
		gameObject.transform.Translate (Vector3.down * rainSpeed * Time.deltaTime); //continuosly move down the screen - the float can be changed

		HitBee = bee.GetComponent<TestMovement>().HitByRain;

		if (gameObject.transform.position.y <= -270) //has reached the bottom of the screen
		{
			gameObject.transform.position = new Vector3(XPos, 450.0f, 0); //moves back to top of the screen
			//make sure the disabled drops are enabled again
			gameObject.GetComponent<CircleCollider2D>().enabled = true;
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
		if (HitBee) //has hit the bee
		{
			gameObject.GetComponent<CircleCollider2D>().enabled = false; //disable the trigger
			
			gameObject.GetComponent<SpriteRenderer>().enabled = false; //hide image
		}

	}
}
