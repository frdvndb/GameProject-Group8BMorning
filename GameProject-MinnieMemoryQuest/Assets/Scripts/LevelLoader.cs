using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public void LoadLevel(string scene)
	{
		SceneManager.LoadScene(scene);
		Time.timeScale = 1f;
		PlayerPrefs.DeleteAll();

	}

	public void Exit()
	{
		Application.Quit();
	}
}
