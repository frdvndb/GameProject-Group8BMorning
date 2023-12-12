using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFire : MonoBehaviour
{
	[SerializeField] private Transform[] wayPoints;
	[SerializeField] private float moveSpeed = 2f;
	[SerializeField] private int wayDestination = 1;
	[SerializeField] private string movingFireType;
	[SerializeField] private Animator animator;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (movingFireType == "horizontal")
		{
			//animator.SetFloat("Move", 1f);
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

		if (movingFireType == "vertical")
		{
			//animator.SetFloat("Move", 1f);
			if (wayDestination == 0)
			{
				transform.position = Vector2.MoveTowards(transform.position, wayPoints[0].position, moveSpeed * Time.deltaTime);
				if (Vector2.Distance(transform.position, wayPoints[0].position) < .2f)
				{
					transform.localScale = new Vector3(1, -1, 1);
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
