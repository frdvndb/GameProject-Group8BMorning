using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] clipAudio;
	private bool isAudioPlaying = false;
	string lastScene;
	private void Update()
	{
		string activeSceneName = SceneManager.GetActiveScene().name;
		if (lastScene != activeSceneName)
		{
			isAudioPlaying = false;
		}
		if (!isAudioPlaying)
		{
			if (activeSceneName == "MainMenu" || activeSceneName == "LevelMenu")
			{
				audioSource.clip = clipAudio[0];
				audioSource.Play();
			}
			if (activeSceneName == "Level1")
			{
				audioSource.Stop();
				audioSource.clip = clipAudio[1];
				audioSource.Play();
				Debug.Log("wadwad");
			}
			isAudioPlaying = true;
		}
		else
		{
			if (!audioSource.isPlaying)
			{
				isAudioPlaying = false;
			}
		}
		lastScene = activeSceneName;

	}
}
