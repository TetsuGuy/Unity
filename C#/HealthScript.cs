using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handles HEALTH for ANY Object
//specify health max and if healtbar should 
//hide automatically (bool autohide)
//Autohide activates after [displayCooldown] seconds
//
//Example: Attach it to any Enemy 
//Set autohide on and cooldown to 5 seconds
//If enemy doesnt take damage, the healthbar will hide after 5s
//Make a canvas and an image, which represent the enemys health
//Drag/Attach both those things inside the HealthScript
//Since the player might have a different system, feel free
//to remove playerHP and the last lines 
//If enemys HP drops to 0, it automatically destroys the enemy 
//Game-Object. 
//The canvas of the enemyhealthbar will always face the player! 
//That way, it always looks perfectly visible!


public class HealthScript : MonoBehaviour {

	public int HEALTHMAX;
	public int healthpoints;
	public float imageHeight;
	public float imageWidth;
	public Canvas HealthPointCanvas;
	public Image HealthPointsDisplay;
	public bool autohide;
	public float displayCooldown;
	private float timer;
	public Text playerHP;

	// Use this for initialization
	void Start () {
		timer = Time.time;
		imageHeight = HealthPointsDisplay.rectTransform.sizeDelta.y;
		imageWidth = HealthPointsDisplay.rectTransform.sizeDelta.x;
		if (healthpoints <= 0)
			healthpoints = 10;
		if (HEALTHMAX <= 10)
			HEALTHMAX = 10;
	}
	
	// Update is called once per frame
	void Update () {
		HealthPointCanvas.transform.LookAt(Camera.main.transform);
		if (autohide) {
			if (Time.time - timer > displayCooldown) {
				Color c = new Color (1, 1, 1);
				c.a = 0;
				HealthPointsDisplay.GetComponent<Image> ().color = c;
			} else {
				Color c = new Color (1, 1, 1);
				c.a = 0.5f;
				HealthPointsDisplay.GetComponent<Image> ().color = c;
			}
		}

		if (healthpoints <= 0) {
			if (gameObject.tag != "Player") Destroy (gameObject);
		}
	}

	public void changeHealth(int x){
		timer = Time.time;


		healthpoints += x;
		if (healthpoints > HEALTHMAX)
			healthpoints = HEALTHMAX;
		Debug.Log (imageWidth * ((float)healthpoints / (float)HEALTHMAX));
		HealthPointsDisplay.rectTransform.sizeDelta = new Vector2( imageWidth*((float)healthpoints/(float)HEALTHMAX)  ,  imageHeight);

		if (gameObject.tag == "Player") {
			GameObject.Find("Player").GetComponent<Stats> ().changeHealthPoints (healthpoints);
		}

	}
}
