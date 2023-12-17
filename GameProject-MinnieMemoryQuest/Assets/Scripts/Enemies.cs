using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Scoreboard scoreboard;
    Animator animator;
    Enemy1Audio enemyAudio;
    public bool isDead;
    WaypointEnemy waypointEnemy;
    public bool enemyIsDead = false;

	// Start is called before the first frame update
	void Start()
    {
        waypointEnemy = GetComponent<WaypointEnemy>();
        enemyAudio = GetComponent<Enemy1Audio>();
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
        waypointEnemy.KnockbackEffect();
		animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            enemyIsDead = true;
			Die();
        }
    }

	private void Die()
	{
        isDead = true;
		enemyAudio.audioDead();
		animator.SetBool("IsDead", isDead);
		scoreboard.enemiesDefeated++;
		scoreboard.addEnemiesToScore();
	}
	public void DieEvent()
	{
        Destroy(gameObject);
	}
}
