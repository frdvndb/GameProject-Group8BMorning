using System.Collections;
using System.Collections.Generic;
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

		ItemUI itemUIPopUp = Instantiate(itemUIPrefab, itemPopUpContainer.transform);
		itemUIPopUp.UpdateUI(item);
	}
}
