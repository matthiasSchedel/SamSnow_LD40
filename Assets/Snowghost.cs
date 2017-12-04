using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowghost : MonoBehaviour {
	private Transform m_playertransform;
	[SerializeField]
	private float m_attack_distance;
	[SerializeField]
	private float m_move_speed;
	[SerializeField]
	private float m_attack_power = 5f;
	private bool m_can_attack;
	private float m_attack_speed = 2;
	// Use this for initialization
	void Start () {
		ResetAttack();
		m_playertransform = FindObjectOfType<Player>().transform;		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(m_playertransform.position, transform.position) < m_attack_distance)
		{
			transform.position = Vector3.MoveTowards(transform.position,  m_playertransform.position, m_move_speed);
		}
	}

	void ResetAttack()
	{
		m_can_attack = true;
	}


	void OnCollisionEnter2D(Collision2D other) {
	
	{
		if (other.gameObject.tag == "Player" && m_can_attack) 
		{
			other.gameObject.GetComponent<Health>().Hit(m_attack_power);
			transform.position = Vector3.MoveTowards(transform.position,  m_playertransform.position, 1f);
			Invoke("ResetAttack",m_attack_speed);
		}
	}
	}

	void Attack(GameObject other) 
	{
			other.gameObject.GetComponent<Health>().Hit(m_attack_power);
			transform.position = Vector3.MoveTowards(transform.position,  m_playertransform.position, 1f);
			Invoke("ResetAttack",m_attack_speed);
			m_can_attack = false;
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && m_can_attack) 
		{
			Attack(other.gameObject);
		}
	}
}
