using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLv2 : MonoBehaviour
{
	[SerializeField] private int maxHealth = 550;
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
	}
	public void DieEvent()
	{
		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
		scoreboard.ShowScoreboard();
	}
}
