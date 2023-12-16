using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
	[SerializeField] private Button level2Button;
	[SerializeField] private TextMeshProUGUI level2TMPro;
	[SerializeField] private GameObject persistent;
	[SerializeField] private Persistent persistentScript;


	private void Update()
	{
		if (persistent == null)
		{
			persistent = GameObject.Find("Persistent");
			persistentScript = persistent.GetComponent<Persistent>();

			if (persistentScript.IsLevel2Unlocked == false)
			{
				level2Button.interactable = false;
				level2TMPro.text = "...";
			}
			if (persistentScript.IsLevel2Unlocked == true)
			{
				level2Button.interactable = true;
				level2TMPro.text = "Level 2";
			}
		}
	}

	private void Start()
	{

	}
}
