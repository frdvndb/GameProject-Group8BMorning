using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLv2Audio : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] clipAudio;
	public void audioAttack()
	{
		audioSource.PlayOneShot(clipAudio[0]);
	}

	public void audioHurt()
	{
		audioSource.PlayOneShot(clipAudio[1]);
	}

	public void audioDead()
	{
		audioSource.PlayOneShot(clipAudio[2]);
	}

	public void audioWalk()
	{
		audioSource.Play();
	}

	public void Start()
	{
		audioSource.clip = clipAudio[3];
	}
}
