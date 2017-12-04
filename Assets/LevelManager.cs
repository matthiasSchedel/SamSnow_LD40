using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string levelName) {
		SceneManager.LoadScene(levelName);	
	}
	public void GameOver()
	{
		LoadLevel("GameOver");
	}

	public void CallGameOver()
	{
		Invoke("GameOver",3f);	
	}
	
}
