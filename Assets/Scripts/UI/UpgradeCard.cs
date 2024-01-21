using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeCard : MonoBehaviour
{
    private const string animString = "UpgradeCardSpin";
    private const string blockedStateString = "UpgradeCardBlocked";

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public Image abilityIcon;
    public Image gemIcon;
    public Image glowIcon;

    public GameObject cardback;
    private AbilityConfig abilityConfig;
    private RarityConfig rarityConfig;
    private int currentTier;
    public Animator anim;
    private System.Action storedCallback;

    public void Init(int tier, AbilityConfig config)
    {
	    abilityConfig = config;
        titleText.text = abilityConfig.abilityName;
        abilityIcon.sprite = abilityConfig.displaySprite;

        currentTier = tier;

        glowIcon.color = rarityConfig.rarities[tier].glowColour;
        gemIcon.color = rarityConfig.rarities[tier].gemColour;
    }

    public void AnimateWithCallback(float delay, System.Action callback = null)
	{
		anim.Play(blockedStateString);
        storedCallback = callback;
        StartCoroutine(AnimateAfterDelay(delay));
	}

    // referenced from button
	public void OnClicked()
	{
        //AbilitySystem.Inst.EquipAbility();
	}

	IEnumerator AnimateAfterDelay(float delay)
	{
		yield return new WaitForSecondsRealtime(delay);
		anim.Play(animString);
    }

    // referenced from animation event
    public void AnimationDone()
	{
        storedCallback?.Invoke();
	}
}
