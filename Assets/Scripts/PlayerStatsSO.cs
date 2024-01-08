using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerStats", menuName = "Player Stats", order = 1)]
public class PlayerStatsSO : ScriptableObject
{
	public const int DEFAULT_PERCENTAGEDAMAGETAKEN = 100;
	public const int DEFAULT_MOVESPEED_BONUS = 0;

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private float damageMultiplier;
    [SerializeField] private float lifesteal;

	[SerializeField] private int percentageDamageTaken = 100;
	[SerializeField] private float moveSpeedBonus = 0;

    public void DamagePlayer(int amount)
	{
        health -= (int)((percentageDamageTaken/100)*amount);
		if (health <= 0)
		{
            Debug.Log("Player dead :(");
		}
	}

	public void SetDamageReduction(int damageReductionValue)
	{
		percentageDamageTaken = damageReductionValue;
	}

	public void SetSpeedBonus(float speedBonus)
	{
		moveSpeedBonus = speedBonus;
	}

	public float GetMoveSpeedBonus()
	{
		return moveSpeedBonus;
	}

	public void HealPlayer(int amount)
	{
        health += amount;
        if(health > maxHealth)
		{
            health = maxHealth;
		}
	}
}
