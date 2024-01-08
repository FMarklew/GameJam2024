using System.Collections;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    public AbilitySlot abilitySlot_1;
    public AbilitySlot abilitySlot_2;
    public AbilitySlot abilitySlot_3;

    private Camera cam;

    public AimController aimController;

    private float nextAbilityUnlock = 0f;
	private void Start()
	{
        cam = Camera.main;
	}

	void Update()
    {
		if (Input.GetButtonUp("Fire1") && !GetIsAbilityLocked())
		{
            ActivateAbility(abilitySlot_1 );
        }
        if(Input.GetButtonUp("Fire2") && !GetIsAbilityLocked())
		{
            ActivateAbility(abilitySlot_2);
        }
		if (Input.GetButtonUp("Fire3") && !GetIsAbilityLocked())
		{
            ActivateAbility(abilitySlot_3);
        }
    }

    public void EquipAbility(AbilitySlot slot, BaseAbility ability, int tier)
    {
		if (!slot.EquipAbilityInSlot(ability, tier))
		{
            Debug.Log("Failed");
		} else
		{
            Debug.Log("Success");
        }
    }

    private void ActivateAbility(AbilitySlot slot)
	{
        if (slot.activeAbility != null)
        {
            Debug.Log("Activating");
            slot.activeAbility.ActivateAbility(gameObject, aimController.transform);
            nextAbilityUnlock = Time.time + slot.activeAbility.abilityConfig.castingTime;
        }
	}

    private bool GetIsAbilityLocked()
	{
        return nextAbilityUnlock > Time.time;
	}
}