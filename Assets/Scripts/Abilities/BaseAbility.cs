using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseAbility : MonoBehaviour
{
	public bool hasCooldown = true;
	public float cooldown = 1f;
	public float castingTime = 0f;

	public bool isOnCooldown = false;
	public float castOffset;

	public float visualDuration = 0.2f;

	public List<AbilityTags> abilityTags = new List<AbilityTags>();
	public virtual void ActivateAbility(GameObject caster, Transform targetTransform)
	{
		if (!isOnCooldown)
		{
			GameObject go = Instantiate(this.gameObject, caster.transform.position + castOffset*targetTransform.right.normalized, targetTransform.rotation);
			go.SetActive(true);
			Destroy(go, visualDuration);
		}
	}

	
}
