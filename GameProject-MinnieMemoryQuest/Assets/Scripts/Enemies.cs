using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Scoreboard scoreboard;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            scoreboard.enemiesDefeated++;
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
		Destroy(this.gameObject);
	}
}
