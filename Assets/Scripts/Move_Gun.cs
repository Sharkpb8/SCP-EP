using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Gun : MonoBehaviour
{

	public float mouseSensitivity = 100.0f;
	private float verticalRotation = 0.0f;

	void Update()
	{


		// ovl�d�n� kamery pomoc� my�i
		float mouseY = -Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseX = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		verticalRotation -= mouseY;
		verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);

		transform.Rotate(Vector3.up * mouseX);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
	}
}
