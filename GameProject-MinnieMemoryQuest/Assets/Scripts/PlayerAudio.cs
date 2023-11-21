using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
	[SerializeField] private AudioSource audioSourceFootStep;
	[SerializeField] private AudioSource audioSourceSus;
	[SerializeField] private AudioClip clipFootStep;
	[SerializeField] private AudioClip[] clipSus;
	private AudioClip currentSusClip;
	public void PlayOneShot()
	{
		audioSourceFootStep.PlayOneShot(clipFootStep);
	}

	public void PlaySusRandom()
	{
		if (!audioSourceSus.isPlaying)
			audioSourceSus.PlayOneShot(clipSus[Random.Range(0, clipSus.Length)]);
	}

}
