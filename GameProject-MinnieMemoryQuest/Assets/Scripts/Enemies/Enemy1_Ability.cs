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
	[SerializeField] float nextAttackTime = 0f;
	private bool checkPlayerCol = false;
	// Start is called before the first frame update
	void Start()
    {
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		if (Time.time >= nextAttackTime && checkPlayerCol == true)
		{
			Attack();
			nextAttackTime = Time.time + 1f / attackRate;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Attack();
			checkPlayerCol = true;
		}

	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			checkPlayerCol = false;
		}
	}
	public void Attack()
	{
		animator.SetFloat("Move", 0f);
		animator.SetTrigger("Attack");
		Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
		foreach (Collider2D player in hitPlayer)
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
