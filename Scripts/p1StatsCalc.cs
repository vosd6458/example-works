using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class p1StatsCalc : MonoBehaviour {
	//Allowed Stat points
	public int statPoints = 5;

	//player1
	public int size, damage, speed, cooldown = 0;
	int fire = 0; //Val taken from UI element
	int water = 0; //Val taken from UI element
	int air = 0; //Val taken from UI element
	int earth = 0; //Val taken from UI element

	//UI text showing Value
	public Text fireStatNumber;
	public Text waterStatNumber;
	public Text airStatNumber;
	public Text earthStatNumber;

	//UI text showing Damage Size speed CD
	public Text damageStatNumber;
	public Text sizeStatNumber;
	public Text speedStatNumber;
	public Text cooldownStatNumber;

	//UI text showing Max Stat Points
	public Text statPointNumber;

	//Stat Points Spent Bool
	public bool allStatPointsSpent = false;

	//Bools to check if number increases or decreases


	//don't destroy object

	//checking Scene
	public string menu;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}	




	// Update is called once per frame
	void Update () {
		fireStatNumber.text = fire.ToString ();
		waterStatNumber.text = water.ToString ();
		airStatNumber.text = air.ToString ();
		earthStatNumber.text = earth.ToString ();

		damageStatNumber.text = damage.ToString ();
		sizeStatNumber.text = size.ToString ();
		speedStatNumber.text = speed.ToString ();
		cooldownStatNumber.text = cooldown.ToString ();

		statPointNumber.text = statPoints.ToString ();
		checkPoints ();
	}

	public void checkPoints(){
		if (statPoints == 0) {
			allStatPointsSpent = true;
		} else {
			allStatPointsSpent = false;
		}
	}

	public void increaseFire(){
		if (statPoints > 0) {
			fire++;
			statPoints--;
			Debug.Log ("fire increased to: " + fire);
			size = size - 3;
			damage = damage + 3;
			speed = speed + 1;
			cooldown = cooldown + 2;
		}
	}
	public void increaseWater(){
		if (statPoints > 0) {
			water++;
			statPoints--;
			Debug.Log ("water increased to: " + water);
			size = size + 3;
			damage = damage - 3;
			speed = speed + 2;
			cooldown = cooldown + 1;
		}
	}
	public void increaseAir(){
		if (statPoints > 0) {
			air++;
			statPoints--;
			Debug.Log ("air increased to: " + air);
			size = size + 2;
			damage = damage + 1;
			speed = speed + 3;
			cooldown = cooldown - 3;
		}
	}
	public void increaseEarth(){
		if (statPoints > 0) {
			earth++;
			statPoints--;
			Debug.Log ("earth increased to: " + earth);
			size = size + 1;
			damage = damage + 2;
			speed = speed - 3;
			cooldown = cooldown + 3;
		}
	}

	public void decreaseFire(){
		if (fire == 0) {
			Debug.Log ("can't decrease Fire already 0");
		} else {
			fire--;
			statPoints++;
			Debug.Log ("fire decreased to: " + fire);
			size = size + 3;
			damage = damage - 3;
			speed = speed - 1;
			cooldown = cooldown - 2;
		}

	}
	public void decreaseWater(){
		if (water == 0) {
			Debug.Log ("can't decrease Water already 0");
		} else {
			water--;
			statPoints++;
			Debug.Log ("water decreased to: " + water);
			size = size - 3;
			damage = damage + 3;
			speed = speed - 2;
			cooldown = cooldown - 1;
		}
	}
	public void decreaseAir(){
		if (air == 0) {
			Debug.Log ("can't decrease Air already 0");
		} else {
			air--;
			statPoints++;
			Debug.Log ("air decreased to: " + air);
			size = size - 2;
			damage = damage - 1;
			speed = speed - 3;
			cooldown = cooldown + 3;
		}
	}
	public void decreaseEarth(){
		if (earth == 0) {
			Debug.Log ("can't decrease Earth already 0");
		} else {
			earth--;
			statPoints++;
			Debug.Log ("earth decreased to: " + earth);
			size = size - 1;
			damage = damage - 2;
			speed = speed + 3;
			cooldown = cooldown - 3;
		}
	}

	public void printStatsChange(){
		Debug.Log ("Size: " + size + " Damage: " + damage + " Speed: " + speed + " Cooldown: " + cooldown);
	}

	public void nextSceneP2(){
		if (allStatPointsSpent == true) {
			SceneManager.LoadScene ("statPageP2");
		} else {

		}
	}

}
