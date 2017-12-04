using UnityEngine;

public class Explosion : MonoBehaviour {
	[SerializeField]
	private float m_destroy_in_seconds;
	void Start () {
		Invoke("Destroy",m_destroy_in_seconds);	
	}
	void Destroy()
	{
		Destroy(gameObject);
	}
}
