using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;
	public float mouseSensitivity = 100.0f;
	private float verticalRotation = 0.0f;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked; // skryje kurzor myši

		controller = GetComponent<CharacterController>();
		if(controller is null)
		{
			Debug.LogError("Hráè musí mít komponentu CharacterController");
		}
	}

	void Update()
	{
		// pohyb hráèe
		if (controller.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= moveSpeed;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		// ovládání kamery pomocí myši
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		verticalRotation -= mouseY;
		verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);

		transform.Rotate(Vector3.up * mouseX);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
	}
}