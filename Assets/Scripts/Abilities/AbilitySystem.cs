using System.Collections;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    public AbilitySlot abilitySlot_1;
    public AbilitySlot abilitySlot_2;
    public AbilitySlot abilitySlot_3;

    public const int maxAbilities = 3;
    void Update()
    {
        // input
    }

    public void EquipAbility(AbilitySlot slot, BaseAbilitySO ability)
    {
		if (!slot.EquipAbilityInSlot(ability))
		{
            Debug.Log("Failed");
		} else
		{
            Debug.Log("Success");
        }
    }


    public BaseAbilitySO testAbility;
    [ContextMenu("Test Func")]
    public void Test()
    {
        EquipAbility(abilitySlot_1, testAbility);
    }
}