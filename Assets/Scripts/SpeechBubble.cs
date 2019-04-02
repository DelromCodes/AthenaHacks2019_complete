using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {

	protected Vector3 offset = new Vector3(0f, 2f, 0f);
	protected GameObject cameraGO;

	public static SpeechBubble Create() {
		GameObject speechBubbleGO = Instantiate(Resources.Load("SpeechBubble", typeof(GameObject))) as GameObject;
		return speechBubbleGO.GetComponent<SpeechBubble>();
	}

	// Use this for initialization
	protected void Start () {
		cameraGO = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	protected void LateUpdate () {
		transform.rotation = Quaternion.LookRotation(transform.position - cameraGO.transform.position);
	}

	public void Reposition(Vector3 targetPosition) {
		gameObject.transform.position = targetPosition + offset;
	}
}
