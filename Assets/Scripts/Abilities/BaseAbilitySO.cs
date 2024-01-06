using UnityEngine;

public abstract class BaseAbilitySO : ScriptableObject
{
	public bool hasCooldown = true;
	public float cooldown = 1f;
	public float castingTime = 0f;

	public abstract void ActivateAbility();
}
