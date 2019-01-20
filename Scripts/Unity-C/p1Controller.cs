using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p1Controller : MonoBehaviour {

	//movement variables
	public float moveSpeed;
	public float jumpForce;
	public bool lookingRight;

	//Rigid Body call
	private Rigidbody2D theRB;

	//movementkeys
	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode shoot;

	//Key Variables
	public bool lastKeyPressedLeft = false;
	public bool lastKeyPressedRight = false;

	//Shooting Stuff
	public GameObject projectilePrefab;
	GameObject projectileInstance;
	public float posOffset;

	//groundstuff
	public Transform groundCheckPointBottom;
	public Transform groundCheckPointLeft;
	public Transform groundCheckPointRight;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	//Player Health
	public int startingHealth = 100;
	public int currentHealth;
	public Slider p1HealthSlider;

	//groundCheck
	public bool onGround;

	//cooldown vars
	float baseCooldown = 1f;
	public float trueCooldown;
	float nextFire;

	//getting stats
	private GameObject player1Stats;
	p1StatsCalc p1Stats;


	void Awake(){
		player1Stats = GameObject.Find ("P1StatSceneManager");
		p1Stats = player1Stats.GetComponent <p1StatsCalc> ();
	}

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
		currentHealth = startingHealth;
		calculateCooldown ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		getShoot ();
		if (currentHealth <= 0) {
			DestroyObject (gameObject);
		}
	}


	void Movement (){
		if (Physics2D.OverlapCircle (groundCheckPointBottom.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle (groundCheckPointLeft.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle (groundCheckPointRight.position, groundCheckRadius, whatIsGround)) {
			onGround = true;
		} else {
			onGround = false;
		}
		if (Input.GetKey (left)) {
			theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
			lastKeyPressedLeft = true;
			lastKeyPressedRight = false;
		}
		else if (Input.GetKey (right)){
			theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
			lastKeyPressedLeft = false;
			lastKeyPressedRight = true;
		} else {
			theRB.velocity = new Vector2(0, theRB.velocity.y);
		}

		if (Input.GetKeyDown (jump) && onGround) {
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
		}
	}


	void getShoot(){
		if (Input.GetKeyDown (shoot) && Time.time > nextFire) {
			if (lastKeyPressedRight == true) {
				Vector3 projPosition = new Vector3 (gameObject.transform.position.x + posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
				projectileInstance = Instantiate (projectilePrefab, projPosition, Quaternion.identity) as GameObject;
				nextFire = Time.time + trueCooldown;
			} else {
				Vector3 projPosition = new Vector3 (gameObject.transform.position.x - posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
				projectileInstance = Instantiate (projectilePrefab, projPosition, Quaternion.Euler (Vector3.down * 180f)) as GameObject;
				nextFire = Time.time + trueCooldown;
			}
		}
	}


	public void damaged(int amount){
		if (currentHealth <= 0) {
			Destroy (gameObject);
		} else {
			currentHealth = currentHealth - amount;
			p1HealthSlider.value = currentHealth;
		}

	}

	void calculateCooldown(){
		trueCooldown = baseCooldown + (p1Stats.cooldown / 5f);
	}


}
