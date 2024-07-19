using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class CardInteract : MonoBehaviour
{
    public Sprite cardProperties;
    public GameManager gameManager;
    public bool open=false;
    public float rotation=0;
    bool spriteChanged=false;
    private void Start() {
        gameManager=FindObjectOfType<GameManager>();
        name=cardProperties.name;
    }
    public void CardClick()
    {
        Debug.Log(4);
        if(gameManager.canClick && !open)
        {
            Debug.Log(name);
            gameManager.pair_card.Add(gameObject);
            open=true;
        }
        
    }

    private void Update() {
        if(open && rotation<=180f)
        {  
           FlipCard();
           Debug.Log(gameObject.GetComponent<Button>().interactable);
            
        }
        else if (rotation>=180f && !gameManager.canClick)
        {
            open=false;
            rotation=0;
            spriteChanged=false;
        }
    }
    void FlipCard()
    {
        Debug.Log(1);
        rotation+=180f*Time.deltaTime*2f;
        if(rotation>=90f && !spriteChanged)
        {
            gameObject.GetComponent<Image>().sprite=cardProperties;
            spriteChanged=true;
        }
        gameObject.transform.rotation= Quaternion.Euler(new Vector3(0,rotation,0));
        if(rotation>=180f)
        {
            gameObject.transform.rotation= Quaternion.Euler(new Vector3(0,180,0));
        }
        
    }
}
