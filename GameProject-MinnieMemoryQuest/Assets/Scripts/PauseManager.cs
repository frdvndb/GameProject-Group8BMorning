using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
	[SerializeField] private GameObject settingMenuUI;
	private bool isPaused;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    // Update is called once per frame
    private void Pause()
    {
        if (!isPaused)
        {
			isPaused = true;
			Time.timeScale = 0f;
		}
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            settingMenuUI.SetActive(false);
        }
        pauseMenuUI.SetActive(isPaused);
    }

	public void Resume()
	{
		isPaused = false;
		Time.timeScale = 1f;
		pauseMenuUI.SetActive(isPaused);
	}
}
