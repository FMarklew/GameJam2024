using System.Collections.Generic;
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

    public List<RarityColours> rarities = new List<RarityColours>();
}
[System.Serializable]
public class RarityColours
{
    public Color glowColour;
    public Color gemColour;
}