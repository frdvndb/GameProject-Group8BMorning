using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float hAxis;
	Vector2 walkDirection;
	Vector2 jumpDirection;
	bool hasDoubleJump = false;
	Animator animator;

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float walkSpeed = 5f;
	[SerializeField] private float jumpPower = 8f;
	[SerializeField] public bool onGround = false;
	[SerializeField] private int maxJumpCount = 2;
	[SerializeField] private PlayerAbility playerAbility;
	[SerializeField] private Player player;
	[SerializeField] private PlayerAudio playerAudio;
	//[SerializeField] private ParticleSystem dustEffect;
	private int jumpCount;
	public bool allowMove = true;
	public bool doubleJump;
	public bool isJumping = true;

	public bool AllowMove { set { allowMove = value; } get { return allowMove; } }
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		jumpCount = maxJumpCount;
	}

	// Update is called once per frame
	void Update()
	{
		if (allowMove && !playerAbility.isAttacking)
		{
			Move();
			Jump();
		} else
		{
			hAxis = 0;
			rb.velocity = Vector2.zero;
		}

		Animations();
		Facing();
		animator.SetFloat("yVelocity", rb.velocity.y);

	}

	private void Jump()
	{
		jumpDirection = new Vector2(0, 1);
		
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && jumpCount > 0 && isJumping)
		{
			//CreateDust();
			isJumping = false;
			onGround = false;
			playerAudio.audioJump();
			animator.SetTrigger("Jump");
			rb.velocity = new Vector2(rb.velocity.x, jumpPower);
			jumpCount -= 1;

		}
		if (rb.velocity.y < 0)
		{
			isJumping = true;
		}
	}

	private void Move()
	{
		hAxis = Input.GetAxis("Horizontal");
		walkDirection = new Vector2(hAxis, 0);
		rb.velocity = new Vector2(walkDirection.x * walkSpeed, rb.velocity.y);
	}

	private void Animations()
	{
		animator.SetFloat("Move", Mathf.Abs(hAxis));
		animator.SetBool("OnGround", onGround);
	}

	private void Facing()
	{
		// If player is moving left scale = -1
		if (hAxis < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
			//dustEffect.transform.localScale = new Vector3(-1, 1, 1);
			//CreateDust();

		}

		// If player is moving right scale = 1
		if (hAxis > 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
			//dustEffect.transform.localScale = new Vector3(1, 1, 1);
			//CreateDust();

		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Ground" || col.tag == "GroundEnemy")
		{
			onGround = true;
			if (!hasDoubleJump)
			{
				jumpCount = 1;
			}
			if (hasDoubleJump)
			{
				jumpCount = maxJumpCount;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Ground")
		{
			onGround = false;
		}
	}

	public void getItemDoubleJump()
	{
		hasDoubleJump = true;
	}

	public void getItemIncreaseHP()
	{
		player.currentHealth = player.currentHealth + 50;
	}

	public void getItemIncreaseAttack()
	{
		playerAbility.attackDamage = playerAbility.attackDamage + 10;
	}

	public void CreateDust()
	{
		//dustEffect.Play();
	}
}