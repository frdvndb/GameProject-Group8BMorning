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
	private float timeTemporary;
	// Start is called before the first frame update
	void Start()
    {
        enemiesDefeated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void ShowScoreboard()
	{
		Time.timeScale = 0f;
		scoreboardMenu.SetActive(true);
		scoreTemporary = scoreOriginal.score;
		scoreText.text = "Scores : " + scoreTemporary;
		timeTemporary = timeOriginal.timeRemaining;
		timeText.text = "Times : " + timeTemporary;
		enemiesDefeatedText.text = "Enemies Defeated : " + enemiesDefeated;
		if (scoreTemporary == 20) { ratingText.text = "A"; }
		if (scoreTemporary >=15) { ratingText.text = "B"; }
		if (scoreTemporary >= 10){ ratingText.text = "C"; }
		if (scoreTemporary < 10) { ratingText.text = "D"; }
	}

	public void NextLevel()
	{
		Time.timeScale = 1f;
		scoreboardMenu.SetActive(false);
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}
}
