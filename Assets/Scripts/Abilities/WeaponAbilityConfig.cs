using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponAbilityConfig", menuName = "Ability/Weapon Ability Config", order = 3)]
public class WeaponAbilityConfig : AbilityConfig
{
    public List<WeaponTierInfo> weaponTierInfos = new List<WeaponTierInfo>();
}

[System.Serializable]
public class WeaponTierInfo
{
    public int damage;
    public float cooldown;
    public float castTime;
}