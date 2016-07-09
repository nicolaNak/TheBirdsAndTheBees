using UnityEngine;
using System.Collections;

public class LadyBeeScript : MonoBehaviour {

	public GameObject BarControlScript , WinPanel;
	public GameObject Bombus;
	public static bool BombusWon;
	public Transform BombusP, RestPos;

	void Start () 
	{
		BombusWon = false;
		RestPos.position = new Vector3 (1500f, 100f, 2f);
	}
	

	void Update () 
	{
		Vector3 BombusPos = Bombus.transform.position; //get this so can move to where bombus is
		BombusP = Bombus.transform;
		if (BombusWon) {
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			gameObject.GetComponent<SpriteRenderer> ().enabled = true; //can see her now
			//track where bombus is
			//move towards bombus
			//Vector3 diff = Camera.main.ScreenToWorldPoint (BombusPos) - transform.position;
			gameObject.transform.position = Vector2.Lerp (gameObject.transform.position,BombusP.position, 0.03f);

			//diff.Normalize ();
			
			//float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
			//Quaternion qTo = Quaternion.Euler (new Vector3 (0, 0, rot_z - 90));
			//transform.rotation = Quaternion.RotateTowards (transform.rotation, qTo, 2.0f * Time.deltaTime);
			//transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
			
			
			//gameObject.transform.Translate (Vector3.up * 20.0f * Time.deltaTime);
		} else {
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			gameObject.transform.position = Vector2.Lerp (gameObject.transform.position,RestPos.position, 0.03f);
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") 
		{
			WinPanel.SetActive(true);
			//end of scene
		}
	}
}
