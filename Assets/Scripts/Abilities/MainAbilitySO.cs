using UnityEngine;

[CreateAssetMenu(fileName = "Main Ability", menuName = "Ability/Main Ability", order = 0)]
public class MainAbilitySO : ScriptableObject
{
    public void ActivateAbility()
	{
		Debug.Log("Activated");
	}
}
