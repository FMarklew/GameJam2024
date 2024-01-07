using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
	private Camera cam;
	private void Start()
	{
		cam = Camera.main;
	}

	private void Update()
	{
		var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector3 rotation = mousePos - transform.position;
		float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, rotZ);
	}
}
