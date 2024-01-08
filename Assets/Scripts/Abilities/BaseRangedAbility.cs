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

	public int baseDamage = 10;
	public int damageGrowth = 0;

	public int currentWeaponTier;

	protected List<Projectile> projectileList = new List<Projectile>();

	public override void OnAbilityActivate(GameObject caster, Transform targetTransform, Vector3 position)
	{
		StartCoroutine(ShootAll(caster, targetTransform, position));
	}

	IEnumerator ShootAll(GameObject caster, Transform targetTransform, Vector3 position)
	{
		for (int i = 0; i < numProjectiles; i++)
		{
			Quaternion rotVal = targetTransform.rotation;
			Projectile p = projectileList.Find(x => !x.gameObject.activeInHierarchy);
			if (p == null)
			{
				var go = Instantiate(projectilePrefab, position, rotVal);
				p = go.GetComponent<Projectile>();
				projectileList.Add(p);
			}
			Vector2 targetVel = targetTransform.right.normalized * launchVelocity;
			p.Init(baseDamage, position, rotVal);
			p.FireProjectile(targetVel);
			yield return new WaitForSeconds(delayBetweenShots);
		}
	}

	public int GetCurrentDamage()
	{
		return baseDamage + (currentWeaponTier * damageGrowth);
	}
}
