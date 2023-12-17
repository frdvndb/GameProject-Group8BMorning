using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	TextMeshProUGUI scoreText;
	public int score = 0;
	private bool hasScoredThisFrame = false;

	// Start is called before the first frame update
	void Start()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	}
	private void Update()
	{
		hasScoredThisFrame = false;
	}
	// Update is called once per frame
	public void AddScore()
	{
		if (!hasScoredThisFrame)
		{
			score = score + 1;
			scoreText.text = "Scores = " + score;
			hasScoredThisFrame = true;
		}

	}
}
