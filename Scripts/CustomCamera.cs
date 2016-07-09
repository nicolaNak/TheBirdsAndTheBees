using UnityEngine;
using System.Collections;

public class CustomCamera : MonoBehaviour {
	
	public GameObject bee;
	
	float PrevYPos;
	bool HitAndWait;
	float HitTimer;
	// Use this for initialization
	void Start () 
	{
		PrevYPos = gameObject.transform.position.y;
		HitTimer = 0;
		HitAndWait = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bee.GetComponent<TestMovement>().HitByRain) //not to foolow the y coordinate when this is true
		{
			gameObject.transform.position = new Vector3 (bee.transform.position.x, PrevYPos, -10.0f);
			HitAndWait = true;
		} 
		if (HitAndWait) //starts the counter
		{
			HitTimer += Time.deltaTime;
			if(HitTimer >= 0.3f)
			{
				HitAndWait = false;
				HitTimer = 0;
			}
		}
		if(!HitAndWait) 
		{
			gameObject.transform.position = new Vector3 (bee.transform.position.x, bee.transform.position.y, -10.0f);
			//Camera.main.orthographicSize = St
			PrevYPos = gameObject.transform.position.y; //put this here so ready for next iteration through the function
		}
	}
	
	
}