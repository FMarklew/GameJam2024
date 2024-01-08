using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BaseRangedAbility : BaseAbility
{
	public GameObject projectilePrefab;
	public float launchVelocity = 1f;

	public int numProjectiles = 3;
	public float delayBetweenShots = 0.15f;

	public int damage = 10;
	public int growth = 0;

	protected List<Projectile> projectileList = new List<Projectile>();

	public override void OnAbilityActivate(GameObject caster, Transform targetTransform, Vector3 position)
	{
		StartCoroutine(ShootAll(caster, targetTransform, position));
	}

	IEnumerator ShootAll(GameObject caster, Transform targetTransform, Vector3 position)
	{
		for (int i = 0; i < numProjectiles; i++)
		{
			Projectile p = projectileList.Find(x => !x.gameObject.activeInHierarchy);
			if (p == null)
			{
				var go = Instantiate(projectilePrefab, position, targetTransform.rotation);
				p = go.GetComponent<Projectile>();
				projectileList.Add(p);
			}
			Vector2 targetVel = (position - caster.transform.position).normalized * launchVelocity;
			p.Init(damage, position);
			p.FireProjectile(targetVel);
			yield return new WaitForSeconds(delayBetweenShots);
		}
	}
}
