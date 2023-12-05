using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField] public GameObject gameOverManager;
	[SerializeField] public GameOver gameOver;
	void Update()
	{
		gameOverManager = GameObject.FindWithTag("GameOverManager");
		if (gameOverManager != null)
		{
			gameOver = gameOverManager.GetComponent<GameOver>();
		}

	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			gameOver.GameOverScreen();

			//Scene currentScene = SceneManager.GetActiveScene();
			//string currentSceneName = currentScene.name;

			//SceneManager.LoadScene(currentSceneName);
		}
	}
}
