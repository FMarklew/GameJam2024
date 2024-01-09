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

        anim.Play(blockedStateString);
    }

    public void AnimateWithCallback(System.Action callback = null)
	{
        storedCallback = callback;
        anim.Play(animString);
	}

    public void AnimationDone()
	{
        storedCallback?.Invoke();
	}

    public AbilityConfig test_ability;
    public int tier;
    [ContextMenu("Init")]
    public void Test()
	{
        Init(tier, test_ability);
        AnimateWithCallback(()=>
        {
            Debug.Log("Animation Done");
        });
	}
}
