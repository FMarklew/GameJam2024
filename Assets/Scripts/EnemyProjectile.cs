using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
	public PlayerStatsSO playerStats;

	protected override void CauseDamage(GameObject go)
	{
		playerStats.DamagePlayer(_damage);
		gameObject.SetActive(false);
	}
}
