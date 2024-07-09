using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardInteract : MonoBehaviour
{
    public CardProperties card;
    
    public void CardClick()
    {
        Debug.Log(card.card.name);
        
    }
}
