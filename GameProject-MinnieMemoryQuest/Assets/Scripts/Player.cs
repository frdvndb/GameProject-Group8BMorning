using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] public int maxHealth = 100;
	[SerializeField] public int currentHealth;
	[SerializeField] public GameOver gameOver;
	[SerializeField] public GameObject gameOverManager;
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
		gameOverManager = GameObject.FindWithTag("GameOverManager");
		if (gameOverManager != null)
		{
			gameOver = gameOverManager.GetComponent<GameOver>();
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		//animator.SetTrigger("Hurt");
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public void Die()
	{
		//isDead = true;
		animator.SetBool("IsDead", true);
		//Scene currentScene = SceneManager.GetActiveScene();
		//string currentSceneName = currentScene.name;
		//SceneManager.LoadScene(currentSceneName);
	}
	public void DieEvent()
	{
		gameOver.GameOverScreen();
	}
}
