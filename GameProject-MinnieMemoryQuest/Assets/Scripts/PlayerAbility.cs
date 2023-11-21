using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private PlayerAudio playerAudio;
    [SerializeField] private KeyCode keyCodeSus = KeyCode.E;
	[SerializeField] private KeyCode keyCodeAttack = KeyCode.R;
	private Animator animator;
	[SerializeField] Transform attackPoint;
	[SerializeField] float attackRange = 0.5f;
	[SerializeField] LayerMask enemyLayers;
	[SerializeField] int attackDamage = 20;
	[SerializeField] float attackRate = 2f;
	[SerializeField] float nextAttackTime = 0f;

    // Start is called before the first frame update
    public void Sus()
    {
        playerAudio.PlaySusRandom();
    }

	public void Attack()
	{
        animator.SetTrigger("Attack");
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
		foreach(Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<Enemies>().TakeDamage(attackDamage);
		}
	}

	public void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
			return;
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}

	public void Jump()
    {
		animator.SetTrigger("Jump");
	}

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(keyCodeSus))
        {
            Sus();
        }

		if (Time.time >= nextAttackTime && Input.GetKeyDown(keyCodeAttack))
		{
			Attack();
			nextAttackTime = Time.time + 1f / attackRate;
		}
	}
}
