using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttractiveBarControls : MonoBehaviour {

	//drop in objects in explorer
	public GameObject cameraGlobalScript;
	public Slider attractBar;
	public static bool Win;

	float score;
	float prevScore;
	float countDown;

	//these change each level, set in Inspector
	public int totalPollen; 
	public float reduceTime;
	

	void Start() 
	{
		//score = 0.00f;
		attractBar.interactable = true; //so can change the values
		countDown = 0;
		Win = false;
	}

	void PollenAdded()
	{
		attractBar.value = (score); //increase max value on slider
		//countDown = 0; //reset countdown
	}

	void Timer()
	{
		//countDown += Time.deltaTime;
		if (countDown >= reduceTime) 
		{
			//attractBar.value -= 1; //reduces the maxValue
			countDown = 0; //resets for next countDown
		}
	}

	void Update () 
	{
		PollenAdded();
		attractBar.maxValue = GlobalScript.LevelMaxPollen;
		if (attractBar.value <= 0) 
		{
			if(score > 0) //set to 0 at the start so can catch if at the beginning of the level
			{
				//end of level - lost level
			}
		}
		prevScore = score;

		score = GlobalScript.LevelScore; //update this

		Timer(); //checks if been 5 seconds since collected


		if (score == totalPollen) 
		{
			//end of level - won level
		}
		if (prevScore < score) 
		{
			//PollenAdded();
		}

	}
}
