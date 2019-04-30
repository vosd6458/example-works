using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{

    public GameObject playerMenu; //playerMenu is a GameObject instead of Image so SetActive() can be used.
    private bool pmIsActive = false; //a check to see if the menu is open to allow for toggleing

    public Text playerNameText; //will allow showing of character name on menu
    public Text playerStatsText;//will allow shoing of character stats on menu

    //PlayerScriptControll
    public GameObject player; //refrence to player gameobject
    private player mainCharacter; //will refrence maincharacters's script to allow for start retrevial

    //timeController
    public Image timer;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = player.GetComponent<player>();//getting mainCharacters Script compoenet
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMenuTextController();//function that controlls toggleable player info UI
        timeResourceControl();
    }

    public void playerMenuTextController()
    {
        //Setting up text to be displayed
        playerNameText.text = mainCharacter.playerName;

        playerStatsText.text = " Health: " + mainCharacter.health.ToString() +  
            "\n Strength: " + mainCharacter.strength.ToString() + 
            "\n Intelligence: " + mainCharacter.intelligence.ToString() + 
            "\n Charisma: " + mainCharacter.charisma.ToString() ;

        //the ability to toggle the player info screen
        if (Input.GetButtonDown("CharacterMenu") && pmIsActive == false)
        {
            playerMenu.SetActive(true);
            pmIsActive = true;
        }
        else if (Input.GetButtonDown("CharacterMenu") && pmIsActive == true)
        {
            playerMenu.SetActive(false);
            pmIsActive = false;
        }
    }

    public void timeResourceControl()
    {
        

    }
}
