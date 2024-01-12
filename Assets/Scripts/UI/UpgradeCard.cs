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

    public RarityConfig rarityConfig;

    public Animator anim;

    private System.Action storedCallback;

    public void Init(int tier, AbilityConfig config)
    {
        titleText.text = config.abilityName;

        abilityIcon.sprite = config.displaySprite;

        glowIcon.color = rarityConfig.rarities[tier].glowColour;
        gemIcon.color = rarityConfig.rarities[tier].gemColour;
    }

    public void AnimateWithCallback(float delay, System.Action callback = null)
	{
		anim.Play(blockedStateString);
        storedCallback = callback;
        StartCoroutine(AnimateAfterDelay(delay));
	}

	IEnumerator AnimateAfterDelay(float delay)
	{
		yield return new WaitForSecondsRealtime(delay);
		anim.Play(animString);
    }

    public void AnimationDone()
	{
        storedCallback?.Invoke();
	}
}
