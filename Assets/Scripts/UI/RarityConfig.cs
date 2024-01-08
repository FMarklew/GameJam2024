using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RarityConfig", menuName = "Rarity Config", order = 2)]
public class RarityConfig : ScriptableObject
{
    public List<RarityTier> rarities = new List<RarityTier>();
}

[System.Serializable]
public class RarityTier
{
    public Color glowColour;
    public Color gemColour;
}