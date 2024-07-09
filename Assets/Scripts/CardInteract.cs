using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class CardInteract : MonoBehaviour
{
    public CardProperties cardProperties;
    public GameManager gameManager;
    private void Start() {
        gameManager=FindObjectOfType<GameManager>();
        name=cardProperties.card.name;
    }
    public void CardClick()
    {
        if(gameManager.canClick)
        {
            Debug.Log(name);
            gameObject.GetComponent<Image>().sprite=cardProperties.card;
            gameManager.pair_card.Add(gameObject);
        }
        
    }
}
