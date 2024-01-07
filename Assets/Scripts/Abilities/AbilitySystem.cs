using System.Collections;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    public AbilitySlot abilitySlot_1;
    public AbilitySlot abilitySlot_2;
    public AbilitySlot abilitySlot_3;

    private Camera cam;

    public AimController aimController;
	private void Start()
	{
        cam = Camera.main;
	}

	void Update()
    {
		if (Input.GetButtonUp("Fire1"))
		{
            ActivateAbility(abilitySlot_1);
        }
        if(Input.GetButtonUp("Fire2"))
		{
            ActivateAbility(abilitySlot_2);
        }
		if (Input.GetButtonUp("Fire3"))
		{
            ActivateAbility(abilitySlot_3);
        }
    }

    public void EquipAbility(AbilitySlot slot, BaseAbility ability)
    {
		if (!slot.EquipAbilityInSlot(ability))
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
            slot.activeAbility.ActivateAbility(gameObject, aimController.transform);
            StartCoroutine(I_Cooldown(slot));
        }
	}

    private IEnumerator I_Cooldown(AbilitySlot slot)
    {
        slot.activeAbility.isOnCooldown = true;
        float cooldown = slot.activeAbility.cooldown;
        float t = 0f;
        while (t < cooldown)
        {
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
        }
        slot.activeAbility.isOnCooldown = false;
    }
}