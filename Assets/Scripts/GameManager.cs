using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour 
{
    public CardProperties[] Cards;
    float time=0;
    public float delay=2;
    public List<GameObject> pair_card;
    public bool canClick;
    private void Update() {
        
        if(pair_card.Count==2)
        {        
            canClick=false;  
            time+=1f*Time.deltaTime;
           
            if(time>=delay)
            {
                 if (pair_card[0].GetComponent<Image>().sprite.name==pair_card[1].GetComponent<Image>().sprite.name)
                    {
                        pair_card[0].GetComponent<Button>().enabled=false;
                        pair_card[0].GetComponent<Image>().color=new UnityEngine.Color(1,1,1,0);
                        pair_card[1].GetComponent<Button>().enabled=false;
                        pair_card[1].GetComponent<Image>().color=new UnityEngine.Color(1,1,1,0);
                    }
                    else
                    {
                        foreach(var child in pair_card)
                            {
                                child.GetComponent<Image>().sprite=Cards[0].card;
                            }
                    }
                resetProp();
            }
        }
    }

    void resetProp()
    {
        time=0;
        pair_card.Clear();
        canClick=true;
    }
}
