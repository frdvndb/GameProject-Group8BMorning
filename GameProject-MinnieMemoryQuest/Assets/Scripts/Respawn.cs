using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] checkPoints;
    [SerializeField] private int currentCheckpoint;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
		LoadSave();
    }

    // Update is called once per frame
    public void LoadSave()
    {
		if (PlayerPrefs.HasKey("CurrentCheckpoint"))
        {
			currentCheckpoint = PlayerPrefs.GetInt("CurrentCheckpoint");
		}
		SpawnPlayer();
	}
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        currentCheckpoint = 0;
    }

    public void RandomCheckpoint()
    {
        currentCheckpoint = Random.Range(0, checkPoints.Length);
		SpawnPlayer();
	}

    private void SpawnPlayer()
    {
        if (player == null)
        {
			player = Instantiate(playerPrefabs, checkPoints[currentCheckpoint].transform.position, checkPoints[currentCheckpoint].transform.rotation);
		} else
        {
            player.transform.position = checkPoints[currentCheckpoint].transform.position;
            player.transform.rotation = checkPoints[currentCheckpoint].transform.rotation;

		}
        
    }

}
