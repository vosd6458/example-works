using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//simple enum for future use
public enum PlayerState
{
    movement,
    interact
}

public class player : MonoBehaviour
{
    public PlayerState currentState;//current state of character to be used with Enum
    public float speed; //Speed of the Character
    private Rigidbody2D myBody;
    private Vector3 change; //controlls the change in x and y space

    //character name
    public string playerName;
    //Stats
    public int health;
    public int strength;
    public int intelligence;
    public int charisma;



    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        //starting stats
        health = 100;
        strength = 10;
        intelligence = 10;
        charisma = 10;

    }

    // Update is called once per frame
    void Update()
    {  
        MoveCharacter();

    }

    void MoveCharacter()
    {
        //change.Normalize();
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        myBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
