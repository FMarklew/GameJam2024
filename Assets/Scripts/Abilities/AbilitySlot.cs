using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilitySlot
{
    [SerializeField] private List<AbilityTags> _requiredTags = new List<AbilityTags>();
    public AbilitySlot(List<AbilityTags> requiredTags)
	{
        _requiredTags = requiredTags;
	}

    public bool EquipAbilityInSlot(BaseAbilitySO ability)
	{
        bool equippedSuccess = false;
        List<AbilityTags> requiredTagsCopy = new List<AbilityTags>(_requiredTags);
        foreach(AbilityTags abilityTag in ability.abilityTags)
		{
			if (_requiredTags.Contains(abilityTag))
			{
                requiredTagsCopy.Remove(abilityTag);
			}
		}
        if(requiredTagsCopy == null || requiredTagsCopy.Count == 0)
		{
            equippedSuccess = true;
		}
        return equippedSuccess;
	}

}
