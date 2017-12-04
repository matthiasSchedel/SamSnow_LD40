using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Key start");	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollision2DStay(Collision2D other)
	{
		//Debug.Log("Collision");
		if (other.gameObject.tag == "Player")
		{
			//load explosion
			FindObjectOfType<LevelManager>().LoadLevel("bosslevel01");
		}	
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Trigger");
		if (other.gameObject.tag == "Player")
		{
			//load explosion
			FindObjectOfType<LevelManager>().LoadLevel("bossLevel01");
		}
	}
}
