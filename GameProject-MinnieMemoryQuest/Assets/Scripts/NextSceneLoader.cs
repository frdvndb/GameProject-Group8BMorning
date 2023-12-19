using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
	[SerializeField] private string scene;
	private void OnEnable()
	{
		SceneManager.LoadScene(scene);
		Time.timeScale = 1f;
		PlayerPrefs.DeleteAll();
	}
}
