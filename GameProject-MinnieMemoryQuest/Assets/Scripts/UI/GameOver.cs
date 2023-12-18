using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MonoBehaviour
{
	[SerializeField] private GameObject gameOverUI;
	[SerializeField] private Score scoreOriginal;
	[SerializeField] private UITimer timeOriginal;
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI timeText;
	[SerializeField] private TextMeshProUGUI enemiesDefeatedText;
	[SerializeField] private Scoreboard scoreBoard;
	public float timeTemporary;
	private int scoreTemporary;
	[SerializeField] private GameObject persistentObject;
	[SerializeField] private Persistent persistentScript;
	// Start is called before the first frame update
	void Update()
    {
		if (persistentObject == null)
		{
			persistentObject = GameObject.Find("Persistent");
			persistentScript = persistentObject.GetComponent<Persistent>();
		}
	}

	private void Start()
	{
		//timeTemporary = persistentScript.timePersistent;
	}

	public void GameOverScreen()
	{
		Time.timeScale = 0f;
		gameOverUI.SetActive(true);
		scoreTemporary = scoreOriginal.score;
		scoreText.text = "Scores = " + scoreTemporary;
		timeTemporary = timeOriginal.timeRemaining;
		persistentScript.timePersistent = timeTemporary;
		timeText.text = "Times : " + timeTemporary;
		enemiesDefeatedText.text = "Enemies Defeated : " + scoreBoard.enemiesDefeated;


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
