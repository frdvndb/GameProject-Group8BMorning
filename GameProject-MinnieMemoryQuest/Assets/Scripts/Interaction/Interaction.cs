using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

	[SerializeField] private GameObject InteractUI;
	private Collider2D collider2D;
	private bool allowInteractUI = false;
	private bool allowInteractCol = true;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && allowInteractCol)
		{
			InteractUI.SetActive(true);
			allowInteractUI = true;
			//collider2D = GetComponent<Collider2D>();
			//GetComponent<Collider2D>().enabled = false;
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
		allowInteractCol = false;
		
	}
}
