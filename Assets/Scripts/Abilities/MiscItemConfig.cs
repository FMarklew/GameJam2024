using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiscAbilityConfig", menuName = "Ability/Misc Ability Config", order = 3)]

public class MiscItemConfig : AbilityConfig
{
	public enum PotionEffect { HEAL, DAMAGE_REDUCTION, SPEED_BOOST }
	public PotionEffect potionEffect;
	public List<MiscItemTier> miscItemTiers = new List<MiscItemTier>();
}

[System.Serializable]
public class MiscItemTier
{
	public float affectorAmt = 1f;
	public float affectorDuration = 3f;
	public float cooldown = 1f;
}