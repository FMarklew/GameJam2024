using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile_PEN : Projectile
{
	private List<GameObject> alreadyHitEnemies = new List<GameObject>();

	public override void Init(int damage, Vector3 pos, Quaternion rot)
	{
		base.Init(damage, pos, rot);
		alreadyHitEnemies = new List<GameObject>();
	}
	protected override void CauseDamage(GameObject go)
	{
		Debug.Log("hit");
		if (!alreadyHitEnemies.Contains(go))
		{
			Debug.Log("hit2");
			go.GetComponent<EnemyBase>().ReduceHealth(_damage);
			alreadyHitEnemies.Add(go);
		}
	}
}
