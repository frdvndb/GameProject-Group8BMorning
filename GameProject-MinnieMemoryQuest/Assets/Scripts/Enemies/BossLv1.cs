using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLv1 : MonoBehaviour
{
	[SerializeField] private int maxHealth = 350;
	[SerializeField] private int currentHealth;
	[SerializeField] private Scoreboard scoreboard;
	Animator animator;
	public bool isDead;
	[SerializeField] private GameObject persistent;
	[SerializeField] private Persistent persistentScript;
	public bool enemyIsDead = false;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update()
	{
		if (persistent == null)
		{
			persistent = GameObject.Find("Persistent");
			persistentScript = persistent.GetComponent<Persistent>();
		}
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
		persistentScript.IsLevel2Unlocked = true;
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
