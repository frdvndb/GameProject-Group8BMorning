using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using static UnityEditor.Experimental.GraphView.GraphView;*/

public class WaypointEnemy : MonoBehaviour
{
	[SerializeField] private Transform[] wayPoints;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private int wayDestination = 1;
	[SerializeField] private GameObject player;
	[SerializeField] private Transform playerTransform;
    [SerializeField] bool isChasing;
    [SerializeField] float chaseDistance = 2f;
	[SerializeField] private Animator animator;
	[SerializeField] private Enemy1_Ability enemy1Ability;
	[SerializeField] private Enemies enemies;
	// Start is called before the first frame update
	void Start()
    {
		enemy1Ability = GetComponent<Enemy1_Ability>();
		enemies = GetComponent<Enemies>();
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
		if (isChasing && !enemy1Ability.isAttacking && !enemies.isDead)
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
        else if (!enemy1Ability.isAttacking && !enemies.isDead)
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
