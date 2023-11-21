using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	float hAxis;
	Vector2 walkDirection;
	Vector2 jumpDirection;
	bool hasDoubleJump = false;
	Animator animator;

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float walkSpeed = 5f;
	[SerializeField] private float jumpPower = 8f;
	[SerializeField] private bool onGround = false;
	[SerializeField] private int maxJumpCount = 2;
	[SerializeField] private PlayerAbility playerAbility;
	private int jumpCount;
	public bool allowMove = true;

	public bool AllowMove { set { allowMove = value; } get { return allowMove; } }

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (allowMove)
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

	}

	private void Jump()
	{
		jumpDirection = new Vector2(0, 1);
		
		if (onGround == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
		{
			playerAbility.Jump();
			rb.velocity = jumpDirection * jumpPower;
			jumpCount++;
		}
		if (onGround == false && hasDoubleJump == true && jumpCount < maxJumpCount && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
		{
			playerAbility.Jump();
			rb.velocity = jumpDirection * (jumpPower-2f);
			jumpCount++;
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
		}

		// If player is moving right scale = 1
		if (hAxis > 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Ground")
		{
			onGround = true;
			jumpCount = 0;
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
}