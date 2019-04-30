using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defaultFemaleNpc : MonoBehaviour
{

    public bool playerInRange;
    public GameObject player;
    private player playerScript;
    
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public Image imageArea;
    public Sprite face;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true)
        {
            playerScript = player.GetComponent<player>();
        }
        if (playerInRange == true && Input.GetButtonDown("Interaction"))
        {

            

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialog = "What a wonderful day " + playerScript.playerName;
                dialogText.text = dialog;
                imageArea.sprite = face;

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerInRange = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            player = null;

        }
    }
}
