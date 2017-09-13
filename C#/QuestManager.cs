using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
//Simple Quest Manager
//each Quest is set to a certain number
//Quest-Items will call invreaseHave() when picked up or similar
//Part of Quest-Package[Quest, QuestItem, QuestManager]
//Best attach to player object
	
	public List<Quest> QuestList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addItem (int x){
		foreach (Quest q in QuestList) {
			if (q.Nr == x) {
				q.increaseHave ();
			}
		}
	}

	public bool isDone(int x){
		if (QuestList [x].done)
			return true;
		else
			return false;
	}


}
