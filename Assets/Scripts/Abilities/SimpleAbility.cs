using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAbility : BaseAbility
{
	public bool hasLifesteal = false;
	public int damage = 10;

	public Vector2 hitboxScale;
	public LayerMask targetLayers;

	private void OnEnable()
	{
		Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, hitboxScale, transform.rotation.z, targetLayers);
		foreach(Collider2D col in colliders)
		{
			Debug.Log(col.gameObject.name);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		// Draw the OverlapBox gizmo with object rotation
		Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z), Vector3.one);
		Gizmos.matrix *= rotationMatrix;
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(hitboxScale.x, hitboxScale.y, 1f));

		// Reset the Gizmos.matrix to avoid affecting other Gizmos draws
		Gizmos.matrix = Matrix4x4.identity;

	}
}
