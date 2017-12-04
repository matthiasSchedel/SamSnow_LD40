using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {
	private Transform[] clouds;
	[SerializeField]
	private float m_cloud_move_speed;
	private Transform m_playertransform;
	// Use this for initialization
	void Start () {
		clouds = GetComponentsInChildren<Transform>();	
		m_playertransform = FindObjectOfType<Player>().transform;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var cloud in clouds)
		{
			
			if (cloud.position.x > m_playertransform.position.x + 20) cloud.position -= Vector3.right * 100; 
			cloud.position += Vector3.right * m_cloud_move_speed;
		}
	}
}
