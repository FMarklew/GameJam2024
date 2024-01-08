using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePotion : BaseAbility
{
	public PlayerStatsSO playerStats;

	public override void Init(int tier)
	{
		currentTier = tier;
	}
	public override void OnAbilityActivate(GameObject caster, Transform targetTransform, Vector3 position)
	{
		MiscItemConfig config = (abilityConfig as MiscItemConfig);
		MiscItemConfig.PotionEffect potionEffect = config.potionEffect;
		switch (potionEffect) {
			case MiscItemConfig.PotionEffect.HEAL:
				playerStats.HealPlayer((int)config.miscItemTiers[currentTier].affectorAmt);
				break;
			case MiscItemConfig.PotionEffect.DAMAGE_REDUCTION:
				playerStats.SetDamageReduction((int)config.miscItemTiers[currentTier].affectorAmt);
				StartCoroutine(ResetDamageReductionAfterDuration());
				break;
			case MiscItemConfig.PotionEffect.SPEED_BOOST:
				playerStats.SetSpeedBonus(config.miscItemTiers[currentTier].affectorAmt);
				StartCoroutine(ResetMoveSpeedBonusAfterDuration());
				break;
			default:
				break;
		}
		
	}

	IEnumerator ResetDamageReductionAfterDuration()
	{
		MiscItemConfig config = (abilityConfig as MiscItemConfig);
		yield return new WaitForSeconds(config.miscItemTiers[currentTier].affectorDuration);
		playerStats.SetDamageReduction(PlayerStatsSO.DEFAULT_PERCENTAGEDAMAGETAKEN);
		
	}

	IEnumerator ResetMoveSpeedBonusAfterDuration()
	{
		MiscItemConfig config = (abilityConfig as MiscItemConfig);
		yield return new WaitForSeconds(config.miscItemTiers[currentTier].affectorDuration);
		playerStats.SetSpeedBonus(PlayerStatsSO.DEFAULT_MOVESPEED_BONUS);
		
	}
}