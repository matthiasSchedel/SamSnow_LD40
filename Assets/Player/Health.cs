using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	[SerializeField]
	private float m_max_health = 40f;
	private float m_curr_health;
	[SerializeField]
	private GameObject m_dieExplosion;
	void Start () {
		m_curr_health = m_max_health;
		if (gameObject.tag == "Player") 
		{ 
			Debug.Log("health" + m_curr_health);
			FindObjectOfType<UI_Menu>().UpdateHealth(m_curr_health);
		}
		if (GetComponent<Boss>())
		{
			FindObjectOfType<UI_Menu>().UpdateBossHealth(m_curr_health / m_max_health);
		}
	}
	public void Hit(float hit) 
	{
		if (m_curr_health - hit <= 0) 
		{
			m_curr_health = 0;
			if (gameObject.tag != "Player") 
			{
				GameObject explosion = Instantiate<GameObject>(m_dieExplosion, transform.position,transform.rotation);
				if (GetComponent<Boss>())
				{
					GetComponent<Boss>().DropItem();
				}
				Destroy(gameObject);
			} else 
			{
				GameOver();
			}
			//do die m_dieExplosion
			//go to game over screen 
		} else 
		{
			m_curr_health -= hit;	
		}
		if (GetComponent<Boss>())
		{
			FindObjectOfType<UI_Menu>().GetComponent<UI_Menu>().UpdateBossHealth(m_curr_health / m_max_health);
		}
		if (gameObject.tag == "Player") 
		{
			Debug.Log("health" + m_curr_health);
			FindObjectOfType<UI_Menu>().GetComponent<UI_Menu>().UpdateHealth(m_curr_health);
		}
	}
	void GameOver()
	{
		FindObjectOfType<LevelManager>().LoadLevel("gameOver");
	}
}
