using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private int coinCount = 2;
	[SerializeField] private float minXCoinPosition = -8f;
	[SerializeField] private float maxXCoinPosition = 2f;
    // Start is called before the first frame update
    void Start()
	{
		GenerateCoin();
	}

	private void GenerateCoin()
	{
		for (int i = 0; i < coinCount; i++)
		{
			GameObject instantiatedCoin = Instantiate(coin, transform);
			instantiatedCoin.transform.Translate(new Vector2(Random.Range(minXCoinPosition, maxXCoinPosition), 0));
		}
	}
}
