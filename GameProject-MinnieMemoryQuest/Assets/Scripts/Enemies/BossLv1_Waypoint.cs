using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*using static UnityEditor.Experimental.GraphView.GraphView;*/

public class BossLv1_Waypoint : MonoBehaviour
{
	[SerializeField] private Transform[] wayPoints;
	[SerializeField] private float moveSpeed = 1f;
	[SerializeField] private int wayDestination = 1;
	[SerializeField] private GameObject player;
	[SerializeField] private Transform playerTransform;
	[SerializeField] bool isChasing;
	[SerializeField] float chaseDistance = 2f;
	[SerializeField] private Animator animator;
	[SerializeField] private BossLv1_Ability bossLv1Ability;
	// Start is called before the first frame update
	void Start()
	{

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
		if (isChasing)
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
		}
		//if (!bossLv1Ability.isAttacking)
		else
		{
			animator.SetFloat("Move", 1f);
			if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
			{
				isChasing = true;
			}
			if (wayDestination == 0)
			{
				transform.position = Vector2.MoveTowards(transform.position, wayPoints[0].position, moveSpeed * Time.deltaTime);
				if (Vector2.Distance(transform.position, wayPoints[0].position) < .2f)
				{
					transform.localScale = new Vector3(-1, 1, 1);
					wayDestination = 1;
				}
			}

			if (wayDestination == 1)
			{
				transform.position = Vector2.MoveTowards(transform.position, wayPoints[1].position, moveSpeed * Time.deltaTime);
				if (Vector2.Distance(transform.position, wayPoints[1].position) < .2f)
				{
					transform.localScale = new Vector3(1, 1, 1);
					wayDestination = 0;
				}
			}
		}
	}
}

