using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Persistent : MonoBehaviour
{
	[SerializeField] private string firstScene;
	[SerializeField] public bool IsLevel2Unlocked = false;
	[SerializeField] private GameObject scoreboard;
	[SerializeField] private Scoreboard scoreboardScript;
	[SerializeField] private GameObject gameOver;
	[SerializeField] private GameOver gameOverScript;
	[SerializeField] public bool doubleJumpUnlocked = false;
	public float timePersistent = 0;

	//[SerializeField] private AudioSource audioSource;
	//[SerializeField] private AudioClip[] clipAudio;
	private void Start()
	{
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene(firstScene, LoadSceneMode.Additive);

	}



	private void Update()
	{
		if (SceneManager.GetActiveScene().name == "MainMenu")
		{
			timePersistent = 0;
			doubleJumpUnlocked = false;
		}
		if (Input.GetKeyDown(KeyCode.P))
		{

			IsLevel2Unlocked = true;
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			IsLevel2Unlocked = false;
		}

		if (scoreboard == null)
		{
			scoreboard = GameObject.Find("ScoreboardManager");
			scoreboardScript = scoreboard.GetComponent<Scoreboard>();
		}
		if (gameOver == null)
		{
			gameOver = GameObject.Find("GameOverManager");
			gameOverScript = gameOver.GetComponent<GameOver>();
		}

		if (Input.GetKeyDown(KeyCode.L))
		{
			scoreboardScript.ShowScoreboard();
			if (!IsLevel2Unlocked) { IsLevel2Unlocked = true; }
		}
	}

	public void doubleJumpPlayer(bool hasDoubleJump)
	{
		doubleJumpUnlocked = hasDoubleJump;
	}

	public float timeBeforeDeath()
	{
		return timePersistent;
	}
}
