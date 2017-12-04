using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour {
	[SerializeField]
	private GameObject m_snowball_prefab;
	[SerializeField]
	private float m_projectile_speed = 5f;
	private float m_fire_rate = 2f;
	private bool m_is_throw_available;
	private Transform m_playertransform;
	private SpriteRenderer m_sr;
	[SerializeField]
	private float m_x_player_reach = 10f;
	private float m_y_player_reach = 2f;
	// Use this for initialization
	void Start () {
		m_playertransform = FindObjectOfType<Player>().GetComponent<Transform>();
		ResetThrow();
		m_sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(transform.position.y - m_playertransform.position.y) < m_y_player_reach
		&& (Mathf.Abs(transform.position.x - m_playertransform.position.x) < m_x_player_reach))
		{
			
			float direction = Mathf.Sign(m_playertransform.position.x - transform.position.x);
			m_sr.flipX = (-direction < 0) ? true : false;
			if (m_is_throw_available) ThrowSnowball(direction);
		}
	}
	void ResetThrow()
	{
		m_is_throw_available = true;
	}

	void ThrowSnowball(float direction) 
	{
		m_is_throw_available = false;
		Invoke("ResetThrow",m_fire_rate);
		GameObject snowball = Instantiate<GameObject>(m_snowball_prefab, transform.position + 1*Vector3.up + 1.5f* Vector3.right * direction, transform.rotation);
		//snowball.transform.Rotate(0,0,-180f*(direction - 1));
		snowball.GetComponent<Rigidbody2D>().velocity = direction * m_projectile_speed * Vector2.right;
		snowball.transform.parent = FindObjectOfType<Snowballs>().transform;
	}
}
