using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
	public GameObject tPlayer;
	public Transform tFollowTarget;
	private CinemachineVirtualCamera vcam;

	// Use this for initialization
	void Start()
	{
		vcam = GetComponent<CinemachineVirtualCamera>();
		//tPlayer = GameObject.FindWithTag("Player");
		//tFollowTarget = tPlayer.transform;
		//vcam.Follow = tFollowTarget;
	}

	// Update is called once per frame
	void Update()
	{
		if (tPlayer == null)
		{
			tPlayer = GameObject.FindWithTag("Player");
			if (tPlayer != null)
			{
				tFollowTarget = tPlayer.transform;
				vcam.Follow = tFollowTarget;
				
			}
		}
	}
}
