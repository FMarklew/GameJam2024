using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
	protected override void CauseDamage(GameObject go)
	{
		go.GetComponent<EnemyBase>().ReduceHealth(_damage);
		gameObject.SetActive(false);
	}
}
