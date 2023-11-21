using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			Scene currentScene = SceneManager.GetActiveScene();
			string currentSceneName = currentScene.name;

			SceneManager.LoadScene(currentSceneName);
		}
	}
}
