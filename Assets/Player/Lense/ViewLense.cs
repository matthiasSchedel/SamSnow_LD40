using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ViewLense : MonoBehaviour {

	[SerializeField]
	private float m_size;
	private Transform m_player_transform;
	private float m_height_ratio;
	[SerializeField]
	private float m_max_size = 0.5f;
	private float m_max_height;
	[SerializeField]
	private float m_delta = .05f;
	// Use this for initialization
	void Start () {
		m_max_height = 0;
		m_player_transform = FindObjectOfType<Player>().GetComponent<Transform>();
		Color c = GetComponent<SpriteRenderer>().color;
		GetComponent<SpriteRenderer>().color = new Color(c.r,c.g,c.b,255);
		//m_height_ratio =  m_player_transform.position.y;
	}
	
	// Update is called once per frame

	void Update () {
		if (m_size >= m_max_size) { //TODO: Remember last position where size was changed and set it back at this position 
			m_size = 3 - m_player_transform.position.y * m_delta;
			Vector3 newScale = new Vector3(m_size,m_size,0);
			transform.localScale = newScale;
		} else if(m_max_height == 0)
		{
			m_max_height = m_player_transform.position.y;
		} else if(m_player_transform.position.y <= m_max_height)
		{
			m_size = m_max_size;
		}
	}
}
