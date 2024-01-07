using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePotion : BaseAbility
{
	public PlayerStatsSO playerStats;
	public enum PotionEffect { HEAL, DAMAGE_REDUCTION, SPEED_BOOST }
	public PotionEffect potionEffect;
	public List<PotionTier> potionTiers = new List<PotionTier>();
	public int currentTier = 0;

	public ParticleSystem particlePrefab;
	public override void OnAbilityActivate(GameObject caster, Transform targetTransform, Vector3 position)
	{
		if(particlePrefab != null)
		{
			particlePrefab.Play();
		}

		switch (potionEffect) {
			case PotionEffect.HEAL:
				playerStats.HealPlayer((int)potionTiers[currentTier].affectorAmt);
				break;
			case PotionEffect.DAMAGE_REDUCTION:
				playerStats.SetDamageReduction((int)potionTiers[currentTier].affectorAmt);
				StartCoroutine(ResetDamageReductionAfterDuration());
				break;
			case PotionEffect.SPEED_BOOST:
				playerStats.SetSpeedBonus(potionTiers[currentTier].affectorAmt);
				StartCoroutine(ResetMoveSpeedBonusAfterDuration());
				break;
			default:
				break;
		}
	}

	IEnumerator ResetDamageReductionAfterDuration()
	{
		yield return new WaitForSeconds(potionTiers[currentTier].affectorDuration);
		playerStats.SetDamageReduction(PlayerStatsSO.DEFAULT_PERCENTAGEDAMAGETAKEN);
	}

	IEnumerator ResetMoveSpeedBonusAfterDuration()
	{
		yield return new WaitForSeconds(potionTiers[currentTier].affectorDuration);
		playerStats.SetSpeedBonus(PlayerStatsSO.DEFAULT_MOVESPEED_BONUS);
	}
}
[System.Serializable]
public class PotionTier
{
	public float affectorAmt = 1f;
	public float affectorDuration = 3f;
}