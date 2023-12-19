using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudio : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] clip;

	public void ItemPopUpAudio()
	{
		audioSource.PlayOneShot(clip[0]);
	}
}
