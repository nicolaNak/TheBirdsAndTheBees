using UnityEngine;
using System.Collections;

public class PollenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Foreground";

	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			Destroy (gameObject);
			GlobalScript.LevelScore += 1;
			GlobalScript.LevelPollenLeft -= 1;
			GlobalScript.Collect.Play ();
		}
	}
}
