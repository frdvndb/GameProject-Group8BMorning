using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLv2 : MonoBehaviour
{
	[SerializeField] private int maxHealth = 550;
	[SerializeField] private int currentHealth;
	[SerializeField] private Scoreboard scoreboard;
	public bool enemyIsDead = false;

	Animator animator;
	public bool isDead;

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
			enemyIsDead = true;
			Die();
		}
	}

	private void Die()
	{
		isDead = true;
		animator.SetBool("IsDead", true);
		scoreboard.enemiesDefeated++;
		scoreboard.addEnemiesToScore();
	}
	public void DieEvent()
	{
		this.enabled = false;
		scoreboard.ShowScoreboard();
	}
}
