using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardInteract : MonoBehaviour
{
    Image image;
    private void Start() {
         image = gameObject.GetComponent<Image>();
         
    }
    public void CardClick()
    {
        Debug.Log(image.sprite.name);
        
    }
}
