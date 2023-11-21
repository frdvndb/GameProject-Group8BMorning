using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private int maxHealth = 100;
	[SerializeField] private int health;
    [SerializeField] private Respawn respawn;

	// Start is called before the first frame update
	void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            respawn.LoadSave();
        }
    }
}
