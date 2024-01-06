using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseAbilitySO : ScriptableObject
{
	public bool hasCooldown = true;
	public float cooldown = 1f;
	public float castingTime = 0f;

	public UnityEvent onAbilityActivate;

	public List<AbilityTags> abilityTags = new List<AbilityTags>();
	public void ActivateAbility()
	{
		onAbilityActivate.Invoke();
	}
}
