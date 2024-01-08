using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SimpleAbility : BaseAbility
{
	public Vector2 hitboxScale;
	public LayerMask targetLayers;

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
		Collider2D[] colliders = Physics2D.OverlapBoxAll(position, hitboxScale, targetTransform.rotation.z, targetLayers);
		foreach (Collider2D col in colliders)
		{
			col.gameObject.GetComponent<EnemyBase>().ReduceHealth(GetCurrentDamage());
		}
	}

	private void OnDrawGizmos()
	{
		foreach(GameObject go in activeSprites) {
			Gizmos.color = Color.yellow;

			// Draw the OverlapBox gizmo with object rotation
			Matrix4x4 rotationMatrix = Matrix4x4.TRS(go.transform.position, Quaternion.Euler(0, 0, go.transform.rotation.eulerAngles.z), Vector3.one);
			Gizmos.matrix *= rotationMatrix;
			Gizmos.DrawWireCube(Vector3.zero, new Vector3(hitboxScale.x, hitboxScale.y, 1f));

			// Reset the Gizmos.matrix to avoid affecting other Gizmos draws
			Gizmos.matrix = Matrix4x4.identity;
		}
	}

	public int GetCurrentDamage()
	{
		return damage;
	}
}
