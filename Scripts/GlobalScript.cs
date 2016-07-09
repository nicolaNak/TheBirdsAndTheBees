using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalScript : MonoBehaviour {

	public int levelNumberAss;

	public static int LevelMaxPollen, LevelClearScore, LevelPollenLeft, levelNumber;
	public static float LevelScore,
	Rtimer = 0.1f;

	public GameObject LostLevel, WinLevel, Spawnpoint, bee, Tutorial,
		Level1Pollen,
		Level2Pollen,
		Level3Pollen,
		Level4Pollen,
		Level5Pollen,
		Level6Pollen,
		Level7Pollen,
		Level8Pollen,
		Level9Pollen,
		Level10Pollen,


		Level4Obsticals,
		Level5Obsticals,
		Level6Obsticals,
		Level7Obsticals,
		Level8Obsticals,
		Level9Obsticals,
		Level10Obsticals,


	Milestone1,
	Milestone2,
	Milestone3;

	public Text PollenleftTxt;

	public static AudioSource Collect;
	public AudioSource CollectAss;

	public Camera Minimap;

	public Texture EmptyHeart, Heart;

	public static bool GameOver = false;


	// Use this for initialization
	void Start () {
		Collect = CollectAss;
		LevelScore = 0;
		LevelSet ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Rtimer -= Time.deltaTime;

		PollenleftTxt.text = LevelPollenLeft.ToString();

		if (LevelScore > 0 && Rtimer < 0) {
			LevelScore -= 0.05f;
			Rtimer = 0.1f;
		}

		if (LevelPollenLeft <= 0) {
			if (LevelScore >= LevelClearScore){

			//end of level - won level
				//WinLevel.SetActive(true);
				AttractiveBarControls.Win = true;
				LadyBeeScript.BombusWon = true;
				TestMovement.WinActive = true;
				TestMovement.currentUpSpeed = 0;

				int ScoreTier = LevelMaxPollen/3;
				//Debug.Log("set the score tier");
				if (LevelScore >= ScoreTier && LevelScore < (ScoreTier * 2)) //if only get a third of the max score no heart awarded
				{
					//1 heart shows up on end screen
					Milestone1.GetComponent<RawImage>().texture = Heart;
					Milestone2.GetComponent<RawImage>().texture = EmptyHeart;
					Milestone3.GetComponent<RawImage>().texture = EmptyHeart;
					Debug.Log("milestone1");
				}
				if(LevelScore >= (ScoreTier * 2) && LevelScore < (ScoreTier * 2.7))
				{
					//2 hearts
					Milestone1.GetComponent<RawImage>().texture = Heart;
					Milestone2.GetComponent<RawImage>().texture = Heart;
					Milestone3.GetComponent<RawImage>().texture = EmptyHeart;
					Debug.Log("milestone2");
				}
				if(LevelScore >= (ScoreTier * 2.6)) // this is the top 90%
				{
					//3 hearts
					Milestone1.GetComponent<RawImage>().texture = Heart;
					Milestone2.GetComponent<RawImage>().texture = Heart;
					Milestone3.GetComponent<RawImage>().texture = Heart;
					Debug.Log("milestone3");
				}

			} else {
				// end of level - lost level
				LostLevel.SetActive(true);
			}
		} else {
			Rtimer -= Time.deltaTime;
		}
	
	}

	public void Restart (){
		Application.LoadLevel (Application.loadedLevel);
		AttractiveBarControls.Win = false;
		LadyBeeScript.BombusWon = false;
		TestMovement.WinActive = false;
		TestMovement.currentUpSpeed = 5;
		SpiderScript.nommedBee = false;
		GameOver = false;

		Milestone1.GetComponent<RawImage>().enabled = false;
		Milestone2.GetComponent<RawImage>().enabled = false;	
		Milestone3.GetComponent<RawImage>().enabled = false;
		
	}
	public void BacktoMenu(){
		Application.LoadLevel ("StartMenu");
		GameOver = false;
	}
	public void NextLevel(){
//		if (levelNumber == 0) {
//			Application.LoadLevel("Level1");
//		} else if (levelNumber == 1) {
//			Application.LoadLevel("Level2");
//		} else if (levelNumber == 2) {
//			Application.LoadLevel("Level3");
//
//		}
		levelNumber += 1;
		LevelSet ();
		WinLevel.SetActive (false);
		AttractiveBarControls.Win = false;
		LadyBeeScript.BombusWon = false;
		TestMovement.WinActive = false;
		SpiderScript.nommedBee = false;
		LostLevel.SetActive (false);
		GameOver = false;

	}
	public void CloseTutorial (){
		Time.timeScale = 1;
	}
	void LevelSet(){
		if (levelNumber == 0) {
			LevelMaxPollen = 24;
			LevelPollenLeft = 24;
			LevelClearScore = 5;

		} else if (levelNumber == 1) {
			Time.timeScale = 0;
			LevelMaxPollen = 28;
			LevelPollenLeft = 28;
			LevelClearScore = 5;
			LevelScore = 0;
			TestMovement.currentUpSpeed = 5;
			bee.transform.position = Spawnpoint.transform.position;
			Tutorial.SetActive (true);
			Level1Pollen.SetActive (true);
			Minimap.orthographicSize = 200;
			Minimap.transform.position = new Vector3 (176, -18, -120);
		} else if (levelNumber == 2) {
			LevelMaxPollen = 22;
			LevelPollenLeft = 22;
			LevelClearScore = 5;
			LevelScore = 0;
			TestMovement.currentUpSpeed = 5;
			bee.transform.position = Spawnpoint.transform.position;
			Minimap.orthographicSize = 250;
			Level2Pollen.SetActive (true);
		} else if (levelNumber == 3) {
			LevelMaxPollen = 50;
			LevelPollenLeft = 50;
			LevelClearScore = 15;
			LevelScore = 0;
			TestMovement.currentUpSpeed = 5;
			bee.transform.position = Spawnpoint.transform.position;
			Level3Pollen.SetActive (true);
			Minimap.orthographicSize = 300;
		} else if (levelNumber == 4) {
			LevelMaxPollen = 20;
			LevelPollenLeft = 20;
			LevelClearScore = 5;
			LevelScore = 0;
			TestMovement.currentUpSpeed = 5;
			bee.transform.position = Spawnpoint.transform.position;
			Level4Pollen.SetActive (true);
			Level4Obsticals.SetActive (true);
			Minimap.orthographicSize = 200;
		} else if (levelNumber == 5) {
			LevelMaxPollen = 26;
			LevelPollenLeft = 26;
			LevelClearScore = 10;
			LevelScore = 0;
			TestMovement.currentUpSpeed = 5;
			bee.transform.position = Spawnpoint.transform.position;
			Level5Pollen.SetActive (true);
			Level4Obsticals.SetActive (false);
			Level5Obsticals.SetActive (true);
			Minimap.orthographicSize = 200;
			Minimap.transform.position = new Vector3 (-45, -18, -120);
		} else if (levelNumber == 6) {
			LevelMaxPollen = 42;
			LevelPollenLeft = 42;
			LevelClearScore = 20;
			LevelScore = 0;
			TestMovement.currentUpSpeed = 5;
			bee.transform.position = Spawnpoint.transform.position;
			Level6Pollen.SetActive (true);
			Level5Obsticals.SetActive (false);
			Level6Obsticals.SetActive (true);
			Minimap.orthographicSize = 210;
			Minimap.transform.position = new Vector3 (35, -18, -120);
		} else if (levelNumber == 7) {
			LevelMaxPollen = 55;
			LevelPollenLeft = 55;
			LevelClearScore = 20;
			LevelScore = 0;
			TestMovement.currentUpSpeed = 5;
			bee.transform.position = Spawnpoint.transform.position;
			Level7Pollen.SetActive (true);
			Level6Obsticals.SetActive (false);
			Level7Obsticals.SetActive (true);
			Minimap.orthographicSize = 200;
			Minimap.transform.position = new Vector3 (-100, -18, -120);
		} else if (levelNumber == 8) {
				LevelMaxPollen = 53;
				LevelPollenLeft = 53;
				LevelClearScore = 20;
				LevelScore = 0;
				TestMovement.currentUpSpeed = 5;
				bee.transform.position = Spawnpoint.transform.position;
				Level8Pollen.SetActive (true);
				Level7Obsticals.SetActive (false);
				Level8Obsticals.SetActive (true);
				Minimap.orthographicSize = 260;
				Minimap.transform.position = new Vector3 (30, -18, -120);
				
		} else if (levelNumber == 9) {
			LevelMaxPollen = 33;
			LevelPollenLeft = 33;
			LevelClearScore = 15;
			LevelScore = 0;
			TestMovement.currentUpSpeed = 5;
			bee.transform.position = Spawnpoint.transform.position;
			Level9Pollen.SetActive (true);
			Level8Obsticals.SetActive (false);
			Level9Obsticals.SetActive (true);
			Minimap.orthographicSize = 200;
			Minimap.transform.position = new Vector3 (150, -18, -120);
			
		} else if (levelNumber == 10) {
			LevelMaxPollen = 44;
			LevelPollenLeft = 44;
			LevelClearScore = 20;
			LevelScore = 0;
			TestMovement.currentUpSpeed = 5;
			bee.transform.position = Spawnpoint.transform.position;
			Level10Pollen.SetActive (true);
			Level9Obsticals.SetActive (false);
			Level10Obsticals.SetActive (true);
			Minimap.orthographicSize = 250;
			Minimap.transform.position = new Vector3 (0, -18, -120);
		}
			else if (levelNumber == 11) {
			Application.LoadLevel("End Image");
			levelNumber +=1;
		}
		
	}
	
}
