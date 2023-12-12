using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
	[SerializeField] private GameObject creditUI;

	public void OpenUI()
	{
		creditUI.SetActive(true);
	}
}
