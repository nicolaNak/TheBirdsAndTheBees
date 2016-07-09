using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour {

	public float rotatespeed = 2.00f;
	public float BreakSpeed = 150.00f, maxspeed = 150.00f;
	public static float currentUpSpeed = 5;
	public bool HitByRain = false; 
	public static bool WinActive;
	public bool WebSlow = false;

	bool slowedSpeed = false, coroutineRun = false;



	float speed; //whatever your speed is
	//float maxSpeed;
	float minSpeed = -50;
	bool speedy = false; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (WebSlow && !slowedSpeed) {
			currentUpSpeed = 10; //currentUpSpeed /5 ;
				slowedSpeed = true;
		}

		BeeMovement ();
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		Quaternion qTo = Quaternion.Euler (new Vector3 (0, 0, rot_z -90));
		transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotatespeed * Time.deltaTime);
		//transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

		
		gameObject.transform.Translate (Vector3.up * currentUpSpeed * Time.deltaTime);
//		gameObject.transform.Translate (Vector3.down * currentDownSpeed * Time.deltaTime);
//
//		if (currentUpSpeed > maxspeed) {
//			currentUpSpeed = maxspeed;
//		}
//		if (currentDownSpeed > maxspeed) {
//			currentDownSpeed = maxspeed;
//		}
//		if (currentUpSpeed >= maxspeed && currentDownSpeed >= maxspeed) {
//			currentUpSpeed = 10;
//			//currentDownSpeed = 10;
//		}
//
//		if (currentDownSpeed == currentUpSpeed) {
//			currentUpSpeed = 10;
//			//currentDownSpeed = 10;
//		}
		speed =  gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
		if(currentUpSpeed > maxspeed)
		{
			//gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity * 0.9f;
			currentUpSpeed *= 0.9f;
			speedy = true;
		}
		if(currentUpSpeed < minSpeed)
		{
			//gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity * 1.1f;
			currentUpSpeed = minSpeed;
			speedy = false;
		}
		if (!speedy) 
		{
			//normal translate/rotate code
		}
//		gameObject.transform.Translate (Vector3.left * currentLeftSpeed * Time.deltaTime);
//		gameObject.transform.Translate (Vector3.right * currentRightSpeed * Time.deltaTime);
//
//	if(Input.GetKey(KeyCode.A))
//		{
//			//gameObject.transform.Rotate (Vector3.forward * Speed * Time.deltaTime);
//			currentUpSpeed += Speed;
//		}
//		if(Input.GetKey(KeyCode.D))
//		{
//			//gameObject.transform.Rotate (Vector3.back, rotatespeed * Time.deltaTime);
//			currentDownSpeed += Speed;
//		}
//		if (Input.GetKey (KeyCode.W)) 
//		{
//			//gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * Speed * Time.deltaTime);
//		}
//		if (Input.GetKey (KeyCode.S)) 
//		{
//			//gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * -BreakSpeed * Time.deltaTime);
//		}
		if (HitByRain && !coroutineRun) {
			gameObject.transform.Translate (Vector3.down * currentUpSpeed *15.0f * Time.deltaTime);
			gameObject.transform.rotation = new Quaternion (0,0,50,0);
			coroutineRun = true;
			StartCoroutine (RainTime());
		}

	}
	void BeeMovement()
	{
		if (!WinActive || !GlobalScript.GameOver ) {
//			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
//				//move left
//				//gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(-0.5f, 0));
//				gameObject.transform.Rotate (Vector3.forward * rotatespeed * Time.deltaTime);
//			}
//			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
//				//move right
//				//gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(0.5f, 0));
//				gameObject.transform.Rotate (Vector3.back, rotatespeed * Time.deltaTime);
//			}
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				//move up
				//gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(0, 0.5f));
				currentUpSpeed *= 1.023f;
			}
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				//move down
				//gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(0, -0.5f));
				currentUpSpeed *= 0.980f;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Rain Drops" && !HitByRain){
			HitByRain = true;
		}
		if (c.tag == "Spider Web") {
			WebSlow = true;
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if (c.tag == "Spider Web") {
			WebSlow = false;
			slowedSpeed = false;
			SpiderScript.speed = 60f;
		}
	}

	public IEnumerator RainTime(){

		yield return new WaitForSeconds(0.5f);
		HitByRain = false;
		coroutineRun = false;

	}

}
