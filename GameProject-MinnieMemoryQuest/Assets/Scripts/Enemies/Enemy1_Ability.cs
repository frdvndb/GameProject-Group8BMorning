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

	private float nextAttackTime = 0f;
	private bool playerInRange = false;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("Player in range: " + playerInRange);
		Debug.Log("Next attack time: " + nextAttackTime);

		if (playerInRange && Time.time >= nextAttackTime)
		{
			Debug.Log("Attacking!");
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
		Debug.Log("Performing attack!");
		animator.SetFloat("Move", 0f);
		animator.SetTrigger("Attack");
		Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
		foreach (Collider2D player in hitPlayers)
		{
			player.GetComponent<Player>().TakeDamage(attackDamage);
		}
	}

	public void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
			return;
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
