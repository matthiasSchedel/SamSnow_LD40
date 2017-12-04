using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour {
	private float m_damage = 10f;
	[SerializeField]
	private GameObject m_explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {
		GameObject explosion = Instantiate<GameObject>(m_explosion, transform.position,transform.rotation);
		explosion.transform.parent = FindObjectOfType<Explosions>().transform;
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Health>().Hit(m_damage);
		}
		Destroy(gameObject);

	}
}
