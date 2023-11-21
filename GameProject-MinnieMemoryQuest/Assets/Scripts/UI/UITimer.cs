using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeIsRunning = true;
	TextMeshProUGUI timerText;

	// Start is called before the first frame update
	void Start()
    {
		timerText = GetComponent<TextMeshProUGUI>();

	}

	// Update is called once per frame
	void Update()
    {
        if (timeIsRunning)
		{
			if (timeRemaining >= 0)
			{
				timeRemaining += Time.deltaTime;
				DisplayTime(timeRemaining);
			}
		}
    }

	void DisplayTime(float timeToDisplay)
	{
		timeToDisplay += 1;
		float minutes = Mathf.FloorToInt(timeToDisplay / 60);
		float seconds = Mathf.FloorToInt(timeToDisplay % 60);
		timerText.text = minutes + ":" + seconds;
	}
}
