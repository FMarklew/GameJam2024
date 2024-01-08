using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeCard : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public Image weaponIcon;
    public Image gemIcon;
    public Image glowIcon;

    public RarityConfig rarityConfig;

    public void Init(int tier, Sprite weaponSprite)
	{

	}

    [ContextMenu("Init")]
    public void Test()
	{

	}
}
