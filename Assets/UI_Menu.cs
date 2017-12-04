using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour {
	private Text m_score_text;
	private Image[] m_health_images;
	[SerializeField]
	private Sprite m_fullHeart;
	[SerializeField]
	private Sprite m_halfHeart;

	private Slider m_boss_slider;
	void Start () {
		//m_score_text = GetComponentsInChildren<Text>()[0];
		m_health_images = GetComponentsInChildren<Image>();
		//Debug.Log("length:" + m_health_images.Length);
		m_boss_slider = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateBossHealth(float health) 
	{
		m_boss_slider.value = health;
	}
	public void UpdateHealth(float health)
	{
		//Debug.Log("health udpate");
		//10 health is full heart - 5 health is half heart 
		int c = 0;
		for(;health >= 10 && c < 5;health-=10)
		{
			if (m_health_images.Length <= c) return;
			m_health_images[c++].sprite = m_fullHeart;
		}
		if (health >= 5 && c++ < m_health_images.Length && c < 5) m_health_images[c].sprite = m_halfHeart; 
		while(c < m_health_images.Length && c < 5) {
				if (m_health_images.Length <= c) return;
				m_health_images[c++].color = new Color(0,0,0,10f);
		}
	} 
}
