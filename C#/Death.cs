using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

	public int IndexOfDeathScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Player").GetComponent<HealthScript> ().healthpoints <= 0)
			SceneManager.LoadScene (IndexOfDeathScene);
	}
}
