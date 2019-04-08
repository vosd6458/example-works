using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projMovementP1 : MonoBehaviour
{

    float baseHSpeed = 5f;
	public float trueHSpeed;

	float baseProjSize = 3f;
	public float trueProjSize;

	int baseDamage = 10;
	public int trueDamage;

	private GameObject player1;
	private GameObject player2;
	private GameObject player1Stats;

	p2Controller p2controll;

	p1StatsCalc p1Stats;


	void Awake(){
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		p2controll = player2.GetComponent <p2Controller> ();

		player1Stats = GameObject.Find ("P1StatSceneManager");
		p1Stats = player1Stats.GetComponent <p1StatsCalc> ();


	}

	void Start () {

		calculateDamage ();
		calculateSize ();
		calculateSpeed ();
	}

    void Update()
    {
		gameObject.transform.localScale = new Vector3 (trueProjSize, trueProjSize/3, 1);
        gameObject.transform.position += gameObject.transform.right * trueHSpeed * Time.deltaTime;

		if (gameObject.transform.position.x < -30 || gameObject.transform.position.x > 40) {
			DestroyObject(gameObject);
		}
    }

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "ground") {
			DestroyObject (gameObject);
		} else if (coll.gameObject.tag == "player2") {
			p2controll.damaged (trueDamage);
			DestroyObject (gameObject);


		}
	}


	void calculateDamage(){
		trueDamage = baseDamage + p1Stats.damage;
		if (trueDamage < 1) {
			trueDamage = 1;
		}
	}

	void calculateSpeed(){
		trueHSpeed = baseHSpeed + (p1Stats.speed / 3f);
		if (trueHSpeed <= 0f) {
			trueHSpeed = .3f;
		}
	}

	void calculateSize(){
		trueProjSize = baseProjSize + (p1Stats.size / 10f);
		if (trueProjSize <= 0f) {
			trueProjSize = .1f;
		}
	}
}
