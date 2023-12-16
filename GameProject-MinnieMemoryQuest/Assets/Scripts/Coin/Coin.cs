using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	[SerializeField] Score scoreScript;

	[SerializeField] private GameObject coinManager;
	[SerializeField] private CoinAudio coinAudio;

	private void Update()
	{
		if (coinManager == null)
		{
			coinManager = GameObject.Find("Coins");
			coinAudio = coinManager.GetComponent<CoinAudio>();
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			scoreScript.AddScore();
			coinAudio.GetCoinAudio();
			Destroy(gameObject);
		}
	}


}
