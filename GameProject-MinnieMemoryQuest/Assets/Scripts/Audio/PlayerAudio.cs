using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
	[SerializeField] private AudioSource audioSourceFootStep;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip clipFootStep;
	[SerializeField] private AudioClip[] clipAudio;
	private AudioClip currentSusClip;
	public void audioFootStep()
	{
		audioSourceFootStep.PlayOneShot(clipFootStep);
	}

	//public void PlaySusRandom()
	//{
	//	if (!audioSource.isPlaying)
	//		audioSource.PlayOneShot(clipSus[Random.Range(0, clipSus.Length)]);
	//}

	public void audioAttack()
	{
		audioSource.PlayOneShot(clipAudio[0]);
	}

	public void audioJump()
	{
		audioSource.PlayOneShot(clipAudio[1]);
	}
	public void audioHit()
	{
		audioSource.PlayOneShot(clipAudio[2]);
	}

	public void audioDead()
	{
		audioSource.PlayOneShot(clipAudio[3]);
	}

}
