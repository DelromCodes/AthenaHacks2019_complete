using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

	public Camera MainCamera;
	public Player Player;
	public NPC NPC1;
	public NPC NPC2;

	protected Vector3 cameraOffset;

	 //Use this for initialization
	 protected void Start () {
		if (Player == null) {
			Debug.LogError("Player was not set!  Attach a Player in the Main.scene!");
		}
		if (MainCamera == null) {
			Debug.LogError("Main Camera is not set.  Attach a Camera in the Main.scene!");
		}
		cameraOffset = MainCamera.transform.position - Player.transform.position;
	}

	 //Update is called once per frame; good for input
	protected void Update() {
		ResolveInput();
		ResolveNPCs();
	}
	 
	 //LateUpdate is called once per frame after Update(); good for cameras following characters
	protected void LateUpdate() {
		RepositionCamera();
	}

	//Helper methods
	protected void ResolveInput() {
		OnKeyDown();
		HandleInputAxes();
	}

	protected void OnKeyDown() {
		//Input.GetKeyDown returns true on the frame the Key was pressed down
		if (Input.GetKeyDown(KeyCode.Space)) {
			Player.Jump();
		}
	}

	protected void HandleInputAxes() {
		//Input.GetAxisRaw returns a value -1, 0, or 1
		float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime; //multiply by Time.deltaTime to normalize movement
		float z = Input.GetAxisRaw("Vertical") * Time.deltaTime;

		//If we're moving, let's tell the player to move
		if (x != 0f || z != 0f) {
			Player.Move(x, z);
		}
	}

	protected void ResolveNPCs() {
		if (NPC1 != null) {
			NPC1.LookAt (Player.transform);
		}
		if (NPC2 != null) {
			NPC2.LookAt (Player.transform);
		}
	}

	protected void RepositionCamera() {
		MainCamera.transform.position = new Vector3(Player.transform.position.x + cameraOffset.x, 
			cameraOffset.y, 
			Player.transform.position.z + cameraOffset.z);
	}
}
