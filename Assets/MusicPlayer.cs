using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	[SerializeField]
	private AudioClip m_clip;
	private AudioSource m_audiosource;
	// Use this for initialization
	void Start () {
		m_audiosource = GetComponent<AudioSource>();
		m_audiosource.clip = m_clip;
		m_audiosource.loop = true;
		m_audiosource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
