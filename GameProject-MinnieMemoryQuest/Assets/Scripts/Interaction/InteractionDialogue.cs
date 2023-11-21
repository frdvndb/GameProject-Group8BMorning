using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionDialogue : Interaction
{
	[SerializeField] private DialogBehaviour dialogBehaviour;
	[SerializeField] private DialogNodeGraph dialogNodeGraph;
	[SerializeField] private PlayerController playerController;
	[SerializeField] private GameObject tPlayer;

	protected override void OnInteract()
	{
		base.OnInteract();
		dialogBehaviour.StartDialog(dialogNodeGraph);
		
		tPlayer = GameObject.FindWithTag("Player");
		playerController = tPlayer.GetComponent<PlayerController>();
		playerController.AllowMove = false;
		dialogBehaviour.AddListenerToOnDialogFinished(HandleDialogEnd);
	}

	private void HandleDialogEnd()
	{
		playerController.AllowMove = true;
	}
}
