using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClicker : MonoBehaviour
{
    SpriteRenderer hitObjectRender;

    Vector3 mousePos;
    Vector2 mousePos2D;

    RaycastHit2D hit;

    public GameObject goNameObject;
    public Text gameObjectName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2D = new Vector2(mousePos.x, mousePos.y);

        hit = Physics2D.Raycast(mousePos2D, Vector2.zero);


        if (Input.GetMouseButtonDown(0))
        {
            
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "npc")
                {
                    hitObjectRender = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    StartCoroutine(objectNameDisplay());
                    hitObjectRender.color = Color.magenta;
                    
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (hit.collider != null && hitObjectRender != null)
            {
                if (hit.collider.gameObject.tag == "player")
                {                  
                    hitObjectRender.color = Color.white;
                }
            } 
        }
    }

    private IEnumerator objectNameDisplay()
    {
        gameObjectName.gameObject.SetActive(true);
        gameObjectName.text = hit.collider.gameObject.name;
        yield return new WaitForSeconds(2f);
        gameObjectName.gameObject.SetActive(false);
    }
}
