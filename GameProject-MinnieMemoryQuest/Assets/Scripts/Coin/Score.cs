using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	TextMeshProUGUI scoreText;
	int score = 0;
	// Start is called before the first frame update
	void Start()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	public void AddScore()
	{
		score = score + 1;
		scoreText.text = "Scores = " + score;
	}
}
