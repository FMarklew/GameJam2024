using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float damageMultiplier;
    public float lifesteal;

    public void ReduceHealth(int amount)
	{
        health -= amount;
        if(health > maxHealth)
		{
            health = maxHealth;
		} else if (health <= 0)
		{
            Debug.Log("Player dead :(");
		}
	}
}
