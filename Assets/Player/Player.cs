using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField]
	private float m_walk_speed;
	[SerializeField]
	private float m_jump_power;
	private Animator m_anim_controller;
	private SpriteRenderer m_sr;

	private bool m_is_grounded;
	private Vector3 m_camera_diff;
	private Rigidbody2D m_rb;
	[SerializeField]
	private GameObject m_fireball;

	[SerializeField]
	private List<AudioClip> m_footsteps;
	
	private AudioSource m_audiosource;
	private bool m_is_step_played;

	[SerializeField][Range(0,5)]
	private int m_max_jumps;
	private int m_jump_count;

	[SerializeField]
	private float m_projectile_speed;
	private float m_fire_rate = 1f;
	private bool m_can_fire;
	private float m_death_high = 10f;

	private float m_last_y;
	
	// Use this for initialization
	void Start () {
		m_can_fire = true;
		m_jump_count = m_max_jumps;
		m_anim_controller = GetComponent<Animator>();
		m_sr = GetComponent<SpriteRenderer>();
		m_anim_controller.SetBool("p_walking",false); 
		m_audiosource = GetComponent<AudioSource>();
		m_rb = GetComponent<Rigidbody2D>();
		m_camera_diff = Camera.main.transform.position - transform.position - 3*Vector3.up;
		m_is_step_played = true;

	}

	public void Hit(float damage) 
	{
		Debug.Log("hit with damage + " + damage);
	}
	void PlayFootStep() 
	{
		m_is_step_played = false;
		AudioClip step = m_footsteps[Random.Range(0,m_footsteps.Count)];
		m_audiosource.clip = step;
		m_audiosource.Play();
		Invoke("ResetStep", step.length);
	}
	void ResetStep()
	{
		m_is_step_played = true;
	}
	void Update()
	{
		if (transform.position.y < -10) 
		{
			GameOver();
		}
		float x = Input.GetAxis("Horizontal");
		if (x == 0) 
		{ 
			m_anim_controller.SetBool("p_walking",false); 
		}
		else 
		{
			m_sr.flipX = (x < 0) ? true : false;
			transform.position += Vector3.right * x * m_walk_speed;
			if (m_is_step_played && m_is_grounded) PlayFootStep();
			//Camera.main.transform.position =  transform.position.x * Vector3.right + m_camera_diff;
			if (m_is_grounded) m_anim_controller.SetBool("p_walking",true); 
		}
		if (Input.GetButton("Fire") && m_can_fire) {
			Fire(x < 0);
		}
		if (Input.GetButtonDown("Jump") && m_jump_count-- > 0) {
			m_is_grounded = false;
			m_anim_controller.SetBool("p_walking",false); 		
			m_anim_controller.SetBool("p_grounded",false); 
			m_rb.velocity = Vector3.up * m_jump_power; 
			//transform.position += Vector3.up * m_jump_power;


		}
	}

		void ResetThrow()
	{
		m_can_fire = true;
	}

	void Fire(bool toLeft) 
	{
		m_can_fire = false;
		Invoke("ResetThrow",m_fire_rate);
		float direction = (m_sr.flipX) ? -1 : 1;
		GameObject fireball = Instantiate<GameObject>(m_fireball, transform.position +  direction * Vector3.right + Vector3.up, transform.rotation);
		//snowball.transform.Rotate(0,0,-180f*(direction - 1));
		fireball.GetComponent<Rigidbody2D>().velocity = direction * m_projectile_speed * Vector2.right;
		fireball.transform.parent = FindObjectOfType<Fireballs>().transform;
	}
	void GameOver() 
	{
		FindObjectOfType<LevelManager>().LoadLevel("gameOver");
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Block") 
		{
			if ((m_last_y - transform.position.y) > m_death_high) GameOver();
			m_is_grounded = true;
			m_jump_count = m_max_jumps;
		}
		if(m_anim_controller)	m_anim_controller.SetBool("p_grounded",true); 
	}
	
	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "Block") 
		{
			
			m_last_y = transform.position.y;
			Debug.Log("Last position" + m_last_y);
		}
		
	}

}
