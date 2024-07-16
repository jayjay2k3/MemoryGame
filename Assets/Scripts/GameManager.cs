using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour 
{
    public int numOfRows;
    public Sprite defaultImg;
    public GameObject[] Cards;
    public float delay=2;
    public List<GameObject> pair_card;
    public bool canClick=true;
    public int levelTime;
    int tempLevelTime;
    public TextMeshProUGUI timer;
    public GameObject gameOverPanel;
    public GameObject CardField;
   float gameTimer=0,cardTimer=0;    
   bool gameStop=false;
    private void Start() {
        
       generateGame();
        
    }
    private void Update() {

        if(tempLevelTime!=0 && !gameStop)  
        {
            gameTimer+=1f*Time.deltaTime;

            if(gameTimer>=1f)
            {
                tempLevelTime-=1;
                timer.text="Time: "+tempLevelTime.ToString();
                gameTimer=0;
               
            }
            if(pair_card.Count==2)
            {        
                
                canClick=false;  
                cardTimer+=1f*Time.deltaTime;
                
                if(cardTimer>=delay)
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
                                    child.GetComponent<Image>().sprite=defaultImg;
                                }
                        }
                    ResetProp();
                }
            }
        }
        else if(tempLevelTime==0 && !gameStop)
        {
           canClick=false;
           gameOverPanel.SetActive(true);
           gameStop=true;
           Debug.Log(123);
        }
    }

    void generateGame()
    {
        tempLevelTime=levelTime;
        timer.text="Time: "+tempLevelTime.ToString();
        foreach(Transform child in CardField.transform)
        {
            Destroy(child.gameObject);
        }
        for(int i=0;i<numOfRows*5;i++)
        {
            int randomCard= Random.Range(0,8);
            GameObject card= GameObject.Instantiate(Cards[randomCard]);
            
            card.transform.SetParent(CardField.transform);
            card.transform.localScale=new Vector3(1,1,1);
        }
    }
    void ResetProp()
    {
        cardTimer=0;
        pair_card.Clear();
        canClick=true;
    }

    public void Retry()
    {
        generateGame();
        gameOverPanel.SetActive(false);
        canClick=true;
        gameStop=false;
        tempLevelTime=levelTime;
    }

}
