using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

	[SerializeField] private GameObject InteractUI;

	private bool allowInteractUI = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			InteractUI.SetActive(true);
			allowInteractUI = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		InteractUI.SetActive(false);
		allowInteractUI = false;
	}

	private void Update()
	{
		if (allowInteractUI)
		{
			if(Input.GetKeyDown(KeyCode.F))
			{
				OnInteract();
			}
		}
	}

	protected virtual void OnInteract()
	{
		InteractUI.SetActive(false);
		allowInteractUI = false;
	}

	protected void DisableInteract()
	{
		InteractUI.SetActive(false);
		//gameObject.SetActive(false);
	}
}
