using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
	//[SerializeField] ItemUI itemUIPrefab;
	//[SerializeField] private GameObject itemContainer;
	[SerializeField] private GameObject popUpMenu;
	[SerializeField] private TextMeshProUGUI title;
	[SerializeField] private TextMeshProUGUI description;
	[SerializeField] private SFXAudio sfxAudio;

	//public void AddItemUI(Item item)
	//{
	//	ItemUI itemUI = Instantiate(itemUIPrefab, itemContainer.transform);
	//	itemUI.UpdateUI(item);
	//}

	public void openPopUp(string itemName, string itemDescription)
	{
		title.text = itemName; 
		description.text = itemDescription;
		sfxAudio.ItemPopUpAudio();
		popUpMenu.SetActive(true);
	}


 //   void Start()
 //   {
        
 //   }

 //   // Update is called once per frame
 //   void Update()
 //   {
        
 //   }
}
