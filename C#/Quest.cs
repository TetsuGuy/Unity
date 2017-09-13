using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple Quest Script
//each Quest is set to a certain number
//Quest-Items will call invreaseHave() when picked up or similar
//Part of Quest-Package[Quest, QuestItem, QuestManager]

public class Quest : MonoBehaviour {

	public int Nr;
	public int QUANTITY;
	private int have;
	public bool done;

	// Use this for initialization
	void Start () {
		have = 0;
		done = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void increaseHave(){
		have++;
		if (have >= QUANTITY) {
			isDone ();
		}
	}

	public void isDone(){
		done = true;
	}

		
}
