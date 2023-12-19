using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip clip;
	// Start is called before the first frame update
	public void GetCoinAudio()
	{
		audioSource.PlayOneShot(clip);
	}
}
