using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFire : MonoBehaviour
{
    [SerializeField] private GameObject groundFire;
	private float deactivationTime;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip clip;
	void Start()
	{
		deactivationTime = Time.realtimeSinceStartup;
		StartCoroutine(DeactivateAndActivate());
		audioSource.clip = clip;
	}

	IEnumerator DeactivateAndActivate()
	{
		while (true)
		{
			if (Time.realtimeSinceStartup - deactivationTime >= 1f)
			{
				groundFire.SetActive(false);
				deactivationTime = Time.realtimeSinceStartup;
				yield return new WaitForSecondsRealtime(1f);
				audioSource.Play();
				groundFire.SetActive(true);
				yield return new WaitForSecondsRealtime(1f);
			}
			yield return null;
		}
	}
}
