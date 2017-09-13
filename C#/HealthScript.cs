using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
