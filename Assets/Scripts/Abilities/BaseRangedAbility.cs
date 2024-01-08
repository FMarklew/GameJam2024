using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BaseRangedAbility : BaseAbility
{
	public float launchVelocity = 1f;

	public int numProjectiles = 3;
	public float delayBetweenShots = 0.15f;

	protected List<Projectile> projectileList = new List<Projectile>();

	public int damage;
	private void Awake()
	{
		Init(currentTier);
	}

	public override void Init(int weaponTier)
	{
		WeaponTierInfo tierInfo = (abilityConfig as WeaponAbilityConfig).weaponTierInfos[weaponTier];
		currentTier = weaponTier;
		_cooldown = tierInfo.cooldown;
		_castingTime = tierInfo.castTime;
		damage = tierInfo.damage;
	}

	public override void OnAbilityActivate(GameObject caster, Transform targetTransform, Vector3 position)
	{
		StartCoroutine(ShootAll(caster, targetTransform, position));
	}

	IEnumerator ShootAll(GameObject caster, Transform targetTransform, Vector3 position)
	{
		RangedWeaponAbilityConfig config = abilityConfig as RangedWeaponAbilityConfig;
		for (int i = 0; i < numProjectiles; i++)
		{
			Quaternion rotVal = targetTransform.rotation;
			Projectile p = projectileList.Find(x => !x.gameObject.activeInHierarchy);
			if (p == null)
			{
				var go = Instantiate(config.bulletPrefab, position, rotVal);
				p = go.GetComponent<Projectile>();
				projectileList.Add(p);
			}
			Vector2 targetVel = targetTransform.right.normalized * launchVelocity;
			p.Init(GetCurrentDamage(), position, rotVal);
			p.FireProjectile(targetVel);
			yield return new WaitForSeconds(delayBetweenShots);
		}
	}

	public int GetCurrentDamage()
	{
		return damage;
	}
}
