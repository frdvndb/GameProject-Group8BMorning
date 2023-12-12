using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
	[SerializeField] private Image healthBar;
	[SerializeField] private Player playerHealth;
	[SerializeField] private Slider sliderHealth;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		GameObject playerObject = GameObject.FindWithTag("Player");

		if (playerObject != null)
		{
			playerHealth = playerObject.GetComponent<Player>();
		}

		if (playerHealth != null)
		{
			sliderHealth.maxValue = playerHealth.maxHealth;
			sliderHealth.value = playerHealth.currentHealth;
		}
	}
}
