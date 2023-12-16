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

	//[SerializeField] private AudioSource audioSource;
	//[SerializeField] private AudioClip[] clipAudio;
	private void Start()
	{
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene(firstScene, LoadSceneMode.Additive);
	}



	private void Update()
	{
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
		if (Input.GetKeyDown(KeyCode.L))
		{
			scoreboardScript.ShowScoreboard();
		}

	}
}
