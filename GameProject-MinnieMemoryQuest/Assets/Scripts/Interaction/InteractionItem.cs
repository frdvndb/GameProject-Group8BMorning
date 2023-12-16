using cherrydev;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/*using static UnityEditor.Progress;*/

public class InteractionItem : Interaction
{
	[SerializeField] private Inventory inventory;
	[SerializeField] private Item itemToAdd;
	[SerializeField] private Animator animator;
	[SerializeField] private PopUpManager popUpManager;
	public GameObject player;

	protected override void OnInteract()
	{
		base.OnInteract();
		inventory.AddItem(itemToAdd);
		DisableInteract();
		animator.SetBool("IsOpen", true);
		popUpManager.openPopUp("Double Jump Item!", "Now You Can Jump Twice!");
		if (inventory.HasItem(itemToAdd))
		{
			player = GameObject.FindWithTag("Player");
			PlayerController playerController = player.GetComponent<PlayerController>();
			if (playerController != null)
			{
				playerController.getItemDoubleJump();
			}
		}
	}
}
