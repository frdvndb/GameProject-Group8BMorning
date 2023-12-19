using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Ability : MonoBehaviour
{
	private Animator animator;
	[SerializeField] Transform attackPoint;
	[SerializeField] float attackRange = 0.5f;
	[SerializeField] LayerMask playerLayers;
	[SerializeField] int attackDamage = 20;
	[SerializeField] float attackRate = 2f;
	[SerializeField] private Enemies enemies;

	private float nextAttackTime = 0f;
	public bool playerInRange = false;
	public bool isAttacking;

	// Start is called before the first frame update
	void Start()
	{
		enemies = GetComponent<Enemies>();
		animator = GetComponent<Animator>();
		attackDamage = attackDamage / 2;
	}

	// Update is called once per frame
	void Update()
	{
		if (playerInRange && Time.time >= nextAttackTime && !isAttacking && !enemies.isDead)
		{
			Attack();
			nextAttackTime = Time.time + 2f / attackRate;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Debug.Log("Player entered range.");
			playerInRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Debug.Log("Player exited range.");
			playerInRange = false;
		}
	}

	public void Attack()
	{
		animator.SetTrigger("Attack");
	}

	public void AttackEvent()
	{
		isAttacking = true;
		Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
		foreach (Collider2D player in hitPlayers)
		{
			player.GetComponent<Player>().TakeDamage(attackDamage);
		}
	}

	public void EndAttackEvent()
	{
		isAttacking = false;
	}

	public void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
			return;
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
