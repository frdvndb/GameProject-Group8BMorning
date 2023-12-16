using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField] public GameObject gameOverManager;
	[SerializeField] public GameOver gameOver;
	[SerializeField] public GameObject player;
	//[SerializeField] public Player playerScript;
	//[SerializeField] public Animator animator;
	[SerializeField] private PlayerAudio playerAudio;
	void Update()
	{
		gameOverManager = GameObject.FindWithTag("GameOverManager");
		player = GameObject.FindWithTag("Player");
		if (gameOverManager != null)
		{
			playerAudio = player.GetComponent<PlayerAudio>();
			gameOver = gameOverManager.GetComponent<GameOver>();
			//playerScript = player.GetComponent<Player>();
			//animator = player.GetComponent<Animator>();
		}

	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			playerAudio.audioDead();
			gameOver.GameOverScreen();
			//playerScript.Die();
			//Scene currentScene = SceneManager.GetActiveScene();
			//string currentSceneName = currentScene.name;

			//SceneManager.LoadScene(currentSceneName);
		}
	}
}
