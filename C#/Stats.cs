using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Part of Menu and Health-Package
//Manages Level, Experience and Health-Display (general manages Stats of Player)


public class Stats : MonoBehaviour {
	
	public string UserName;				//Player Name
	private string Occupation;			//Player Game Occupation
	private int Level;						
	public int HealthPointsMax;
	private int HealthPoints;
	private int Experience;

	public Text UserNameText;				//Text-Element that displays Username if it exists in your game [i.i.e.i.y.g]
	public Text OccupationText;				// ...
	public Text LevelText;						// ...
	public Text HealthPointsText;			// ...			
	public Text ExperienceText;			// ...
	public Image ExperienceDisplay;			// ...
	private float ExperienceDisplayWidth;			
	private float ExperienceDisplayHeight;			


	// Use this for initialization
	void Start () {
		Level = 1;
		Occupation = "Cave-Resident";				//Set to whatever occupation you want a start
		HealthPoints = GetComponent<HealthScript> ().healthpoints;
		Experience = 0;
		ExperienceDisplayWidth = ExperienceDisplay.rectTransform.sizeDelta.x;
		ExperienceDisplayHeight = ExperienceDisplay.rectTransform.sizeDelta.y;

		ExperienceDisplay.rectTransform.sizeDelta = new Vector2(ExperienceDisplayWidth*((float)Experience/pointsForNextLevel())  ,ExperienceDisplayHeight);

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			UserNameText.text = UserName;
			OccupationText.text = Occupation;
			LevelText.text = "Lvl. " + Level;
			HealthPointsText.text ="HP: "+HealthPoints;
			ExperienceText.text = "EXP: "+Experience;
		}
	}

	public void newExperience(int x){
		Experience += x;
		ExperienceText.text = "EXP: "+Experience;
		ExperienceDisplay.rectTransform.sizeDelta = new Vector2(ExperienceDisplayWidth*((float)Experience/pointsForNextLevel())  ,ExperienceDisplayHeight);

		if (whichLevelAmI (Experience) > Level) {
			levelUp ();
		}
	}


	private int whichLevelAmI(int x){
		return (int) (0.1 *(float) x);
	}

	private void levelUp(){
		gameObject.GetComponent<HealthScript> ().changeHealth (gameObject.GetComponent<HealthScript> ().HEALTHMAX);
		Level++;
		LevelText.text= "Lvl. " + Level;	
		Experience = 0;
		ExperienceDisplay.rectTransform.sizeDelta = new Vector2(ExperienceDisplayWidth*((float)Experience/pointsForNextLevel())  ,ExperienceDisplayHeight);
	}
	

	//currently player needs Linear Points for each level: level1/0		level2/20		level3/30 		etc.
	private int pointsForNextLevel(){
		return (Level + 1) * 10;
	}

	public void changeHealthPoints(int x){
		HealthPoints=x;
		HealthPointsText.text ="HP: "+HealthPoints;
	}
}
