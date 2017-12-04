using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
	private Transform[] m_ghost_spawn_points;
	[SerializeField]
	private GameObject m_ghost_prefab;
	[SerializeField]
	private GameObject m_drop_item;


	// Use this for initialization
	void Start () {
		m_ghost_spawn_points = FindObjectOfType<Ghostspawnpoints>().GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (FindObjectsOfType<Snowghost>().Length == 0)
		{
			SpawnGhosts();
		}
	}

	public void DropItem()
	{
		GameObject item = Instantiate<GameObject>(m_drop_item, transform.position + Vector3.up,transform.rotation);
	}

	void SpawnGhosts()
	{
		foreach (var pos in m_ghost_spawn_points)
		{
			GameObject ghost = Instantiate<GameObject>(m_ghost_prefab, pos.position, pos.rotation);
		}
	}

	
}
