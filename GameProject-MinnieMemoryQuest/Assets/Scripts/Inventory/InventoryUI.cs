using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] ItemUI itemUIPrefab;
	[SerializeField] private GameObject itemContainer;
	[SerializeField] private GameObject itemPopUpContainer;

	public void AddItemUI(Item item)
	{
		ItemUI itemUI = Instantiate(itemUIPrefab, itemContainer.transform);
		itemUI.UpdateUI(item);

		//ItemUI itemUIPopUp = Instantiate(itemUIPrefab, itemPopUpContainer.transform);
		//itemUIPopUp.UpdateUI(item);
		//ItemUI lastItemUI = itemUIPopUp;
		Image imageComponent = itemPopUpContainer.GetComponent<Image>();
		imageComponent.sprite = item.itemIcon;
		// Update the last instantiated ItemUI
		//lastItemUI.UpdateUI(item);
	}
}
