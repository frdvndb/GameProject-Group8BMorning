using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private GameObject scoreboardMenu;
	[SerializeField] private Score scoreOriginal;
	[SerializeField] private UITimer timeOriginal;
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI timeText;
	[SerializeField] private TextMeshProUGUI enemiesDefeatedText;
	[SerializeField] private TextMeshProUGUI ratingText;
	public int enemiesDefeated;
	private int scoreTemporary;
	public float timeTemporary;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip clipWin;
	[SerializeField] private string scene;
	[SerializeField] public int fromScore;
	[SerializeField] private GameObject persistentObject;
	[SerializeField] private Persistent persistentScript;

	// Start is called before the first frame update
	void Start()
    {
        enemiesDefeated = 0;
		fromScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (persistentObject == null)
		{
			persistentObject = GameObject.Find("Persistent");
			persistentScript = persistentObject.GetComponent<Persistent>();
		}
	}

	public void addEnemiesToScore()
	{
		scoreOriginal.AddScore();
	}
	public void ShowScoreboard()
	{
		Time.timeScale = 0f;
		scoreboardMenu.SetActive(true);
		audioSource.PlayOneShot(clipWin);
		persistentScript.timePersistent = 0;
		scoreTemporary = scoreOriginal.score;
		scoreText.text = "Scores : " + scoreTemporary;
		timeTemporary = timeOriginal.timeRemaining;
		timeText.text = "Times : " + timeTemporary;
		enemiesDefeatedText.text = "Enemies Defeated : " + enemiesDefeated;
		if (scoreTemporary == 20) { ratingText.text = "A"; }
		else if (scoreTemporary >= 15) { ratingText.text = "B"; }
		else if(scoreTemporary >= 10){ ratingText.text = "C"; }
		else if(scoreTemporary < 10) { ratingText.text = "D"; }
		persistentScript.doubleJumpPlayer(false);
	}

	public void NextLevel()
	{
		Time.timeScale = 1f;
		scoreboardMenu.SetActive(false);
		SceneManager.LoadScene(scene);
		PlayerPrefs.DeleteAll();
		//int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		//SceneManager.LoadScene(currentSceneIndex + 1);
	}
}
