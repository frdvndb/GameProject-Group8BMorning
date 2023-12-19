using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class WallCheckPoint : MonoBehaviour
{
	[Header("For Jump")]
	[SerializeField] float moveSpeed;
	[SerializeField] Transform wallCheckPoint;
	[SerializeField] Transform groundCheckPoint;
	[SerializeField] float circleRadius = 0.2f;
	[SerializeField] LayerMask GroundLayerMask;
	private bool checkingWall;
	private bool checkingGround;
	[SerializeField] float jumpHeight;
	[SerializeField] Vector2 boxSize;
	[SerializeField] float jumpForceMultiplier;

	[Header("Other")]
	private Rigidbody2D enemyRB;
	private Animator animator;
	private BossLv1_Waypoint b1Waypoint;
	private bool isJumping = false;
	private BossLvl1Audio b1Audio;
	// Start is called before the first frame update
	void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		b1Waypoint = GetComponent<BossLv1_Waypoint>();
		b1Audio = GetComponent<BossLvl1Audio>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		checkingGround = Physics2D.OverlapBox(groundCheckPoint.position, boxSize, 0, GroundLayerMask);
		checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, GroundLayerMask);

	}
	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(wallCheckPoint.position, circleRadius);
		Gizmos.DrawCube(groundCheckPoint.position, boxSize);
	}

	public void JumpAbility(float positionEnemyX, float positionPlayerX)
	{
		//float distanceFromPlayer = (positionPlayerX - positionEnemyX); ;
		Vector2 distanceFromPlayer = new Vector2(Mathf.Sign(positionPlayerX - positionEnemyX), 1).normalized;
		if (checkingWall && !checkingGround) {;
			//enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight) * jumpForceMultiplier, ForceMode2D.Impulse);
			enemyRB.AddForce(distanceFromPlayer * jumpHeight * jumpForceMultiplier, ForceMode2D.Impulse);
		}

		else if (checkingGround)
		{
			//isJumping = true;
			//animator.SetBool("IsJumping", isJumping);
			//b1Audio.audioJump();
			//enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight) * jumpForceMultiplier, ForceMode2D.Impulse);
			enemyRB.AddForce(distanceFromPlayer/2 * jumpHeight * jumpForceMultiplier, ForceMode2D.Impulse);

		}


		//if (isJumping && checkingGround)
		//{
		//	isJumping = false;
		//	animator.SetBool("IsJumping", isJumping);
		//}
		//animator.SetBool("IsJumping", isJumping);

	}
}
