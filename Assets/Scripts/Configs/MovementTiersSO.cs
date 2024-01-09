using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeedTiers", menuName = "MoveSpeedSO", order = 0)]
public class MovementTiersSO : ScriptableObject
{
	public List<float> moveSpeedTiers = new List<float>();
}
