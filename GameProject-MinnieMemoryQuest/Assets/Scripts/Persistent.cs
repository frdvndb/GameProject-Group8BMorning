using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Persistent : MonoBehaviour
{
	[SerializeField] private string firstScene;
	private void Start()
	{
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene(firstScene, LoadSceneMode.Additive);
	}

}
