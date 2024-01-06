using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed;
	private void LateUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		gameObject.transform.position = new Vector2(transform.position.x + (h * speed),
		   transform.position.y + (v * speed));
	}
}
