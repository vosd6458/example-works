using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed; //Speed of the Character
    private Rigidbody2D myBody;
    private Vector3 change; //controlls the change in x and y space

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        MoveCharacter();

        
    }

    void MoveCharacter()
    {
        change.Normalize();
        myBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
