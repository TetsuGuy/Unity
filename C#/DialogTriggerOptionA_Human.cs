using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerOptionA_Human : MonoBehaviour {

	public float distance = 0.0f;
	private GameObject player = null;
	private GameObject self = null;
	public List<DialogTrigger> trigger = null;
	public int DialogSelector;
	private bool done = false;
	// Use this for initialization
	void Start () {
		DialogSelector = 0;
		player = GameObject.Find ("Player");
		self = gameObject;
	}

	// Update is called once per frame
	void Update () {
		if (!done && Vector3.Distance (player.transform.position, transform.position) < distance && Input.GetMouseButtonUp (1)) {
			trigger[DialogSelector].TriggerDialogue ();
			done = true;
		} 

		if (done && Vector3.Distance (player.transform.position, transform.position) > 2 * distance) {
			FindObjectOfType<DialogBase> ().EndDialog ();
			done = false;
		}
	}

	public void nextDialog(){
		if(DialogSelector<trigger.Count-1) 
			DialogSelector=DialogSelector+1;
	}

	public bool isDone(){
		return done;
	}
}