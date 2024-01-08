using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseAbility : MonoBehaviour
{
	public string abilityName;

	public bool hasCooldown = true;
	public float cooldown = 1f;
	public float castingTime = 0f;

	public bool isOnCooldown = false;
	public float castOffset;

	public GameObject spritePrefab;
	public float visualDuration = 0.2f;

	public PlayerMoveSpeedTiers.PlayerMoveSpeedTier moveSpeedTierWhenEquipped =
		PlayerMoveSpeedTiers.PlayerMoveSpeedTier.NORMAL;

	public List<AbilityTags> abilityTags = new List<AbilityTags>();

	private Coroutine activeCast = null;
	private Coroutine cooldownRoutine = null;

	protected List<GameObject> activeSprites = new List<GameObject>();
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
		yield return new WaitForSeconds(castingTime);

		var modifiedPos = caster.transform.position + castOffset * targetTransform.right.normalized;

		// visual
		GameObject go = null;
		if (spritePrefab != null)
		{
			go = Instantiate(spritePrefab, modifiedPos, targetTransform.rotation);
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
		while (t < cooldown)
		{
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime;
		}
		isOnCooldown = false;
		cooldownRoutine = null;
	}
	IEnumerator I_DestroyAfterSeconds(GameObject sprite)
	{
		yield return new WaitForSeconds(visualDuration);
		activeSprites.Remove(sprite);
		Destroy(sprite);
	}

	public virtual void OnAbilityActivate(GameObject caster, Transform targetTransform, Vector3 position)
	{

	}

	
}
