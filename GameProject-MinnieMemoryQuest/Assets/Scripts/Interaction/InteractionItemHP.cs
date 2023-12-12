using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItemHP : Interaction
{
	[SerializeField] private Inventory inventory;
	[SerializeField] private Item itemToAdd;
	[SerializeField] private Animator animator;
	public GameObject player;

	protected override void OnInteract()
	{
		base.OnInteract();
		inventory.AddItem(itemToAdd);
		DisableInteract();
		animator.SetBool("IsOpen", true);
		if (inventory.HasItem(itemToAdd))
		{
			player = GameObject.FindWithTag("Player");
			PlayerController playerController = player.GetComponent<PlayerController>();
			if (playerController != null)
			{
				playerController.getItemIncreaseHP();
			}
		}
	}
}
