using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseAbilityConfig", menuName = "Ability/Base Ability Config", order = 3)]
public class AbilityConfig : ScriptableObject 
{
	public string abilityName;

	public List<AbilityTags> abilityTags = new List<AbilityTags>();

	public GameObject vfxPrefab;
	public float vfxDuration = 0.2f;

	public float castOffset;
	public Sprite displaySprite;

	public bool hasCooldown = true;
	public float cooldown = 1f;
	public float castingTime = 0f;
	public PlayerMoveSpeedTiers.PlayerMoveSpeedTier moveSpeedTierWhenEquipped = PlayerMoveSpeedTiers.PlayerMoveSpeedTier.NORMAL;

	
}

