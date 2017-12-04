using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	[SerializeField]
	private GameObject m_explosion;
	[SerializeField]
	private float m_damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Snowman" || other.gameObject.tag == "Snowghost")
		{
			other.gameObject.GetComponent<Health>().Hit(m_damage);
		} 
		GameObject explosion = Instantiate<GameObject>(m_explosion, transform.position,transform.rotation);
		Destroy(gameObject);
		return;
	}

		void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Snowman" || other.gameObject.tag == "Snowghost")
		{
			other.gameObject.GetComponent<Health>().Hit(m_damage);
		} 
		GameObject explosion = Instantiate<GameObject>(m_explosion, transform.position,transform.rotation);
		Destroy(gameObject);
		return;
	}
}
