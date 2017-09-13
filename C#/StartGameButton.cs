using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ButtonScript
//Attach to any button or even Object (e.g. doors)
//and set the Scene you want to load
//if on button, set "onclick" Function to this new_Scene() function


public class StartGameButton : MonoBehaviour {
	public int SceneNr;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void new_Scene(){
		SceneManager.LoadScene (SceneNr);
	}


	public void exit_Game(){
		Application.Quit ();
	}
}
