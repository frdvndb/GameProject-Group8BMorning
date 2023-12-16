using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioSoundTest : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] clip;

	void Start()
	{
		//audioSource = GetComponent<AudioSource>();
		audioSource.clip = clip[0];
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			audioSource.Play();
		}
	}
}
