using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] private int maxHealth = 100;
	[SerializeField] private int currentHealth;
	Animator animator;
	public bool isDead;
	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		currentHealth = maxHealth;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		animator.SetTrigger("Hurt");
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public void Die()
	{
		isDead = true;
		animator.SetBool("IsDead", isDead);

		Scene currentScene = SceneManager.GetActiveScene();
		string currentSceneName = currentScene.name;
		SceneManager.LoadScene(currentSceneName);
	}
}
