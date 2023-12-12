using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    //[SerializeField] private PlayerAudio playerAudio;
    //[SerializeField] private KeyCode keyCodeSus = KeyCode.E;
	[SerializeField] private KeyCode keyCodeAttack = KeyCode.R;
	private Animator animator;
	[SerializeField] Transform attackPoint;
	[SerializeField] float attackRange = 0.5f;
	[SerializeField] LayerMask enemyLayers;
	[SerializeField] public int attackDamage = 20;
	[SerializeField] private PlayerController playerController;
	//[SerializeField] private float cooldownAttack = 1f;
	//private float lastAttack;
	public bool isAttacking;

	// Start is called before the first frame update
	//public void Sus()
	//   {
	//       playerAudio.PlaySusRandom();
	//   }

	public void Attack()
	{
		//if (Time.time-lastAttack < cooldownAttack)
		//{
		//	return;
		//}
		//lastAttack = Time.time;
		if (playerController.onGround == true && !isAttacking)
		{
			isAttacking = true;
			animator.SetTrigger("Attack");
		}
	}
	public void AttackEvent()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
		foreach (Collider2D enemy in hitEnemies)
		{
			BossLv1 bossLv1Component = enemy.GetComponent<BossLv1>();
			BossLv2 bossLv2Component = enemy.GetComponent<BossLv2>();
			Enemies enemiesComponent = enemy.GetComponent<Enemies>();

			if (bossLv1Component != null)
			{
				bossLv1Component.TakeDamage(attackDamage);
			}
			else if (bossLv2Component != null)
			{
				bossLv2Component.TakeDamage(attackDamage);
			}
			else if (enemiesComponent != null)
			{
				enemiesComponent.TakeDamage(attackDamage);
			}
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

	public void Jump()
    {
		animator.SetTrigger("Jump");
	}

	void Start()
	{
		animator = GetComponent<Animator>();
		attackDamage = attackDamage / 2;
	}

	private void Update()
	{
		//if (Input.GetKeyDown(keyCodeSus))
  //      {
  //          Sus();
  //      }

		if (Input.GetKeyDown(keyCodeAttack))
		{
			Attack();
		}
	}
}
