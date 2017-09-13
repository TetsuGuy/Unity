using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Works together with the healthskript
// Attach it to the player and it will load the specified DeathScreen (a Scene in your project)
// You can set the Scene in the variable IndexOfDeathScene

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
