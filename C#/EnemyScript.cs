using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Currently just used to store experience points for the player

public class EnemyScript : MonoBehaviour {

	public int EXP;
	// Use this for initialization
	void Start () {
		if (EXP <= 0) {
			EXP = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
