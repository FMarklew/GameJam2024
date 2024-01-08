using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : SimpleAbility
{
	public int numChecks = 6;
	public float delayBetweenChecks = 0.1f;
	public override void OnAbilityActivate(GameObject caster, Transform targetTransform, Vector3 position)
	{
		StartCoroutine(I_Multicast(caster, targetTransform, position));
	}

	IEnumerator I_Multicast(GameObject caster, Transform targetTransform, Vector3 position)
	{
		foreach(GameObject go in activeSprites)
		{
			go.transform.parent = targetTransform;
		}
		for (int i = 0; i < numChecks; i++)
		{
			Collider2D[] colliders = Physics2D.OverlapBoxAll(position, hitboxScale, targetTransform.rotation.z, targetLayers);
			foreach (Collider2D col in colliders)
			{
				col.gameObject.GetComponent<EnemyBase>().ReduceHealth(GetCurrentDamage());
			}
			yield return new WaitForSeconds(delayBetweenChecks);
		}
		
	}
}
