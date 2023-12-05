using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MonoBehaviour
{
	[SerializeField] private Score scoreOriginal;
	[SerializeField] private GameObject gameOverUI;
	[SerializeField] private TextMeshProUGUI scoreText;
	private int scoreGameOver;
	// Start is called before the first frame update
	void Start()
    {
		
	}

	public void GameOverScreen()
	{
		Time.timeScale = 0f;
		gameOverUI.SetActive(true);
		scoreGameOver = scoreOriginal.score;
		scoreText.text = "Scores = " + scoreGameOver;

	}

	public void TryAgain()
	{
		Time.timeScale = 1f;
		gameOverUI.SetActive(false);
		Scene currentScene = SceneManager.GetActiveScene();
		string currentSceneName = currentScene.name;
		SceneManager.LoadScene(currentSceneName);
	}
}
