using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	bool CreditsOpen;
	public GameObject Credits, CreditsOpenPos, CreditsClosedPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
		if (CreditsOpen) {
			Credits.transform.position = Vector2.Lerp (Credits.transform.position, CreditsOpenPos.transform.position, 0.1f);
		} else {
			Credits.transform.position = Vector2.Lerp (Credits.transform.position, CreditsClosedPos.transform.position, 0.1f);
		}

	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Play()
	{
		Application.LoadLevel("Levels");
		GlobalScript.levelNumber = 1;
		AttractiveBarControls.Win = false;
		LadyBeeScript.BombusWon = false;
		TestMovement.WinActive = false;
		TestMovement.currentUpSpeed = 5;
		SpiderScript.nommedBee = false;
		GlobalScript.GameOver = false;
		
	}
	public void OpenCredits ()
	{
		CreditsOpen = true;
	}
	public void CloseCredits ()
	{
		CreditsOpen = false;
	}

}