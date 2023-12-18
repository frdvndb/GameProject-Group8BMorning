using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLv2_Waypoint : MonoBehaviour
{
	[SerializeField] private Transform[] wayPoints;
	[SerializeField] private float moveSpeed = 1f;
	[SerializeField] private int wayDestination = 1;
	[SerializeField] private GameObject player;
	[SerializeField] private Transform playerTransform;
	[SerializeField] bool isChasing;
	[SerializeField] float chaseDistance = 2f;
	[SerializeField] private Animator animator;
	[SerializeField] private BossLv2_Ability bossLv2Ability;
	[SerializeField] private BossLv2 bossLv2;
	[SerializeField] private WallCheckPoint jumpScript;
	private Rigidbody2D rb;
	public float KBForce;
	public float KBCounter;
	public float KBTotalTime;
	public bool KnockFromRight;
	// Start is called before the first frame update
	void Start()
	{
		bossLv2 = GetComponent<BossLv2>();
		bossLv2Ability = GetComponent<BossLv2_Ability>();
		jumpScript = GetComponent<WallCheckPoint>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (player == null)
		{
			player = GameObject.FindWithTag("Player");
			if (player != null)
			{
				playerTransform = player.transform;
			}
		}
		if (KBCounter > 0)
		{
			if (KnockFromRight == true)
			{
				rb.velocity = new Vector2(KBForce, KBForce);
			}
			if (KnockFromRight == false)
			{
				rb.velocity = new Vector2(-KBForce, KBForce);
			}
			KBCounter -= Time.deltaTime;
		}
		if (isChasing && !bossLv2Ability.isAttacking && !bossLv2.isDead && !bossLv2Ability.playerInRange && KBCounter <= 0)
		{
			animator.SetFloat("Move", 1f);
			if (transform.position.x > playerTransform.position.x)
			{
				transform.localScale = new Vector3(1, 1, 1);
				transform.position += Vector3.left * moveSpeed * Time.deltaTime;
			}
			if (transform.position.x < playerTransform.position.x)
			{
				transform.localScale = new Vector3(-1, 1, 1);
				transform.position += Vector3.right * moveSpeed * Time.deltaTime;
			}
			jumpScript.JumpAbility(transform.position.x, playerTransform.position.x);
		}
		else if (!bossLv2Ability.isAttacking && !bossLv2.isDead)
		{
			animator.SetFloat("Move", 1f);
			if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance && !bossLv2Ability.playerInRange && KBCounter <= 0)
			{
				isChasing = true;
			}
			if (wayDestination == 0)
			{
				transform.position = Vector2.MoveTowards(transform.position, wayPoints[0].position, moveSpeed * Time.deltaTime);
				if (Vector2.Distance(transform.position, wayPoints[0].position) < .5f)
				{
					transform.localScale = new Vector3(-1, 1, 1);
					wayDestination = 1;
				}
			}

			if (wayDestination == 1)
			{
				transform.position = Vector2.MoveTowards(transform.position, wayPoints[1].position, moveSpeed * Time.deltaTime);
				if (Vector2.Distance(transform.position, wayPoints[1].position) < .5f)
				{
					transform.localScale = new Vector3(1, 1, 1);
					wayDestination = 0;
				}
			}
		}
	}
	public void KnockbackEffect()
	{
		KBCounter = KBTotalTime;
		if (playerTransform.position.x <= transform.position.x)
		{
			KnockFromRight = true;
		}
		if (playerTransform.position.x > transform.position.x)
		{
			KnockFromRight = false;

		}

	}
}
