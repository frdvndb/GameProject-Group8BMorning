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
	public GameObject player;

	protected override void OnInteract()
	{
		base.OnInteract();
		inventory.AddItem(itemToAdd);
		DisableInteract();
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
