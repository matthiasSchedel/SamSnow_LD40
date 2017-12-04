using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour {

		[SerializeField][Range(0,20000)]
	private float m_light_snow_power;
		[SerializeField][Range(0,20000)]
	private float m_heavy_snow_power;
		[SerializeField][Range(0,100)]
	private float m_wind_power;

	private ParticleSystem m_light_snow;
	private ParticleSystem m_heavy_snow;
	private WindZone m_windzone;

	private AudioSource m_audiosource;

	private Transform m_player_transform;
	private float m_max_pd = 5f;

	
	// Use this for initialization
	void Start () {
		m_light_snow = GetComponentsInChildren<ParticleSystem>()[0];
		m_heavy_snow = GetComponentsInChildren<ParticleSystem>()[1];
		m_windzone = GetComponentInChildren<WindZone>();
		m_player_transform = FindObjectOfType<Player>().GetComponent<Transform>();
		m_light_snow_power = m_light_snow.particleCount;
		m_heavy_snow_power = m_heavy_snow.particleCount;
		m_wind_power = m_windzone.windTurbulence;
		m_audiosource = GetComponent<AudioSource>();
	}
	void FollowPlayer() 
	{
	
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, m_player_transform.position) > m_max_pd) FollowPlayer();
		m_windzone.windTurbulence = m_wind_power;
		m_audiosource.volume = m_wind_power / 100f;
		//m_light_snow.SetParticles(m_light_snow.Get, m_light_snow_power);
		//m_heavy_snow.particleCount = m_heavy_snow_power;
	}
}
