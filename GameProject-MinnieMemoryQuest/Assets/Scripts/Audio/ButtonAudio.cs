using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] audioClip;

	public void hoverSound() { audioSource.PlayOneShot(audioClip[0]); }
	public void clickSound() { audioSource.PlayOneShot(audioClip[1]); }
}
