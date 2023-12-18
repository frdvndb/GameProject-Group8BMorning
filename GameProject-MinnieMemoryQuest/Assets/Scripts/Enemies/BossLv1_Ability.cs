using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLv1_Ability : MonoBehaviour
{
	private Animator animator;
	[SerializeField] Transform attackPoint;
	[SerializeField] float attackRange = 1f;
	[SerializeField] LayerMask playerLayers;
	[SerializeField] int attackDamage = 30;
	public bool playerInRange = false;

	[SerializeField] private float cooldownAttack = 1.5f;
	private float lastAttack;
	public bool isAttacking;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		attackDamage = attackDamage / 2;
	}

	// Update is called once per frame
	void Update()
	{
		if (playerInRange && Time.time-lastAttack>=cooldownAttack && !isAttacking)
		{
			lastAttack = Time.time;
			Attack();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			playerInRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
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
