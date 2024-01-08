using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseAbility : MonoBehaviour
{
	public bool isOnCooldown = false;

	public AbilityConfig abilityConfig;

	private Coroutine activeCast = null;
	private Coroutine cooldownRoutine = null;

	protected List<GameObject> activeSprites = new List<GameObject>();

	public int currentTier;
	protected float _cooldown;
	protected float _castingTime;
	public abstract void Init(int tier);
	public void ActivateAbility(GameObject caster, Transform targetTransform)
	{
		if (!isOnCooldown)
		{
			isOnCooldown = true;
			activeCast = StartCoroutine(I_WaitCast(caster, targetTransform));
			cooldownRoutine = StartCoroutine(I_Cooldown());
		}
	}

	IEnumerator I_WaitCast(GameObject caster, Transform targetTransform)
	{
		yield return new WaitForSeconds(abilityConfig.castingTime);

		var modifiedPos = caster.transform.position + abilityConfig.castOffset * targetTransform.right.normalized;

		// visual
		GameObject go = null;
		if (abilityConfig.vfxPrefab != null)
		{
			go = Instantiate(abilityConfig.vfxPrefab, modifiedPos, targetTransform.rotation);
			go.SetActive(true);
			activeSprites.Add(go);
		}

		StartCoroutine(I_DestroyAfterSeconds(go));

		// logic

		OnAbilityActivate(caster, targetTransform, modifiedPos);
		activeCast = null;
	}

	private IEnumerator I_Cooldown()
	{
		float t = 0f;
		while (t < abilityConfig.cooldown)
		{
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime;
		}
		isOnCooldown = false;
		cooldownRoutine = null;
	}
	IEnumerator I_DestroyAfterSeconds(GameObject sprite)
	{
		yield return new WaitForSeconds(abilityConfig.vfxDuration);
		activeSprites.Remove(sprite);
		Destroy(sprite);
	}

	public virtual void OnAbilityActivate(GameObject caster, Transform targetTransform, Vector3 position)
	{

	}

	
}
