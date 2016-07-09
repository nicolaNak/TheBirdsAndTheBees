using UnityEngine;
using System.Collections;

public class SpiderScript : MonoBehaviour {

	public Vector2 point; //put in the values for the centre of the sunflower
	public GameObject setLost; //put the game over object here
	public GameObject YummyBee;
	public static float speed = 60f, maxspeed = 200;
	float angle = 0;
	int radius = 100;
	bool inWeb = false;
	bool setSpeed = false;
	bool beeForDinner = false;
	public static bool nommedBee = false;


	void Start () {
	
	}
	

	void Update () {

		beeForDinner = YummyBee.GetComponent<TestMovement> ().WebSlow; //get update for this

		if (!nommedBee) {
			if (inWeb && !setSpeed && beeForDinner) {
				if(speed <= maxspeed ){
					speed *= 2.0f;
					setSpeed = true;
				} else {

				}

			}
		}
		if (nommedBee) { //sets speed back to normal
			speed = 60f;
		}

		transform.RotateAround(point, Vector3.forward, speed*Time.deltaTime);
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		//Debug.Log ("entered trigger");
		if (c.tag == "Spider Web" && !inWeb) {
			inWeb = true;
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		//Debug.Log ("exited trigger");
		if (c.tag == "Spider Web") {
			inWeb = false;
			setSpeed = false;
			beeForDinner = false;
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.collider.tag == "Player") { //end of level, lost
		
			setLost.SetActive (true);
			GlobalScript.GameOver = false;
			beeForDinner = false;
			nommedBee = true;
			TestMovement.currentUpSpeed = 0;
		} 
	}
}
