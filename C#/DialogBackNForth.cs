using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBackNForth : MonoBehaviour {

	public DialogTriggerOptionA_Human a;
	public DialogTriggerOptionA_Human b;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (a.isDone () && a.DialogSelector==b.DialogSelector) {
			b.nextDialog ();
		}
		if (b.isDone () && b.DialogSelector==a.DialogSelector+1) {
			a.nextDialog ();
		}
	}
}
