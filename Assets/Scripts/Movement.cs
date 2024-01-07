using UnityEngine;

public class Movement : MonoBehaviour
{
	public MovementTiersSO moveTiers;
	public PlayerMoveSpeedTiers.PlayerMoveSpeedTier currentMoveTier;
	private void LateUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		gameObject.transform.position = new Vector2(transform.position.x + (h * moveTiers.moveSpeedTiers[(int)currentMoveTier]),
		   transform.position.y + (v * moveTiers.moveSpeedTiers[(int)currentMoveTier]));
	}
}
