using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityGeneratorHandler : MonoBehaviour
{
    private static AbilityGeneratorHandler _inst;

    public static AbilityGeneratorHandler Inst { get { return _inst; } }

    private const int TOTAL_TIERS = 3;
    private const int TOTAL_SELECTIONS = 3;
    [SerializeField] private List<AbilityConfig> allPossibleAbilities = new List<AbilityConfig>();

    [SerializeField] private float cardAnimateOffset = 0.5f;
    [SerializeField] private GameObject upgradePanel;

    [SerializeField] private List<UpgradeCard> upgradeCards = new List<UpgradeCard>();

    private void Awake()
    {
	    if (_inst == null)
	    {
		    _inst = this;
	    }
    }

    private List<AbilityConfig> GenerateAbilities(int size)
    {
	    List<AbilityConfig> copied = new List<AbilityConfig>(allPossibleAbilities);
        copied.Shuffle();
        return copied.GetRange(0, size);
    }

    [ContextMenu("Test")]
    public void GenerateAndShowAbilities()
    {
	    List<AbilityConfig> selectedAbilities = GenerateAbilities(TOTAL_SELECTIONS);
	    for (int i = 0; i < upgradeCards.Count; i++)
	    {
		    int tier = SelectTier();
            upgradeCards[i].Init(tier, selectedAbilities[i]);
	    }

        upgradePanel.SetActive(true);
        float offset = 0f;

        foreach (var card in upgradeCards)
        {
	        card.AnimateWithCallback(offset);
	        offset += cardAnimateOffset;
        }

        AbilitySystem.Inst.EnableAbilitySelection();
    }

    private int SelectTier()
    {
	    List<int> numbers = Enumerable.Range(0, TOTAL_TIERS).ToList();
	    numbers.Shuffle();
	    return numbers[0];
    }
}
