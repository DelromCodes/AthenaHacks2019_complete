using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	protected SpeechBubble speechBubble;

	public void LookAt(Transform target) {
		gameObject.transform.LookAt(target);
	}

	public void OnTriggerEnter() {
		Debug.Log ("Saying hello to " + gameObject.name);
		DestroySpeechBubble();
		CreateSpeechBubble();
	}

	public void OnTriggerExit() {
		Debug.Log("Goodbye, " + gameObject.name);
		DestroySpeechBubble();
	}

	protected void CreateSpeechBubble() {
		speechBubble = SpeechBubble.Create();
		speechBubble.Reposition(gameObject.transform.position);
		//Must set parent to be WorldCanvas so we can see the UI rendered!
		speechBubble.gameObject.transform.SetParent(GameObject.Find("WorldCanvas").transform);
	}

	protected void DestroySpeechBubble() {
		if (speechBubble != null) {
			GameObject.Destroy(speechBubble.gameObject);
		}	
	}
}
