using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

	public Rigidbody Rigidbody;

	protected float speed = 6f;
	protected Vector3 movementDirection;
		
	public void Move(float x, float z) {
		movementDirection.Set(x * speed, 0f, z * speed);
		if (Rigidbody != null) {
			Rigidbody.MoveRotation (Quaternion.LookRotation (movementDirection));
			Rigidbody.MovePosition (gameObject.transform.position + movementDirection);
		}
	}
		
	public void Jump() {
		if (Rigidbody != null) {
			Rigidbody.AddForce (gameObject.transform.up * 5f, ForceMode.Impulse);
		}
	}
}
