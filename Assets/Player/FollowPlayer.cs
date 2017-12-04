using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private Transform m_playertransform;
	[SerializeField][Range(.1f,10)]
	private float m_x_threshold = 5f;
	[SerializeField][Range(.1f,10)]
	private float m_y_threshold = 5f;
	private Vector3 m_player_diff;
	// Use this for initialization
	void Start () {
		m_playertransform = FindObjectOfType<Player>().GetComponent<Transform>();
		m_player_diff = transform.position - m_playertransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(m_playertransform.position.y  - transform.position.y) > m_y_threshold) 
		{
			float new_y = m_playertransform.position.y + m_player_diff.y;
			transform.position += Vector3.up * (new_y - transform.position.y);
		}
		if (Mathf.Abs(m_playertransform.position.x  - transform.position.x) > m_x_threshold) 
		{
			float new_x = m_playertransform.position.x + m_player_diff.x;
			transform.position += Vector3.right * (new_x - transform.position.x);
		}
	}
}
