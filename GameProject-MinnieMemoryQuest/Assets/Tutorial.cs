using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	[SerializeField] private GameObject InteractUI;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			InteractUI.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		InteractUI.SetActive(false);
	}
}
