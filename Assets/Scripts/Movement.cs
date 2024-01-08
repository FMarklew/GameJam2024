using UnityEngine;

public class Movement : MonoBehaviour
{
	public MovementTiersSO moveTiers;
	public PlayerMoveSpeedTiers.PlayerMoveSpeedTier currentMoveTier;
	public PlayerStatsSO playerStats;
	private void LateUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		float speed = moveTiers.moveSpeedTiers[(int)currentMoveTier] + playerStats.GetMoveSpeedBonus();
		gameObject.transform.position = new Vector2(transform.position.x + (h * speed),
		   transform.position.y + (v * speed));
	}
}
