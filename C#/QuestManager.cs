using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {


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
