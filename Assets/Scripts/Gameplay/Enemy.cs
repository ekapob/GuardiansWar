using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	Manager manager;

	public float startSpeed = 10f;
	public float speed;

	public float startHealth = 100;
	public float currentHealth;

	public int worth = 50;

	public Image healthBar;

	void Start()
	{
		manager = Manager.instance;
		currentHealth = startHealth;

		speed = startSpeed;
	}

	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
		healthBar.fillAmount = currentHealth/startHealth;
		if (currentHealth <= 0)
			Die ();
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die()
	{
		PlayerStats.Money += worth;
		Destroy (gameObject);
	}


}
