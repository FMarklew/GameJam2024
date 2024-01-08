using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform followTarget;
	public float followLag = 0.25f;
	private void LateUpdate()
	{
		if(followTarget != null)
		{
			Vector3 targetVec = Vector3.Lerp(transform.position, followTarget.position, followLag);
			transform.position = new Vector3(targetVec.x,targetVec.y,transform.position.z);
		}
	}
}
