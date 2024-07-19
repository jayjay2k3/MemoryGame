using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameMode{
                    Easy,
                    Normal,
                    Hard
                    };
public class GameManager : MonoBehaviour 
{
    
    public GameMode gameMode;
    public int numOfRows;
    public Sprite defaultImg;
    public GameObject[] Cards;
    public float delay=2;
    public List<GameObject> pair_card;
    public bool canClick=true;
    public int levelTime;
    int tempLevelTime;
    public GameObject CardField;
    public TextMeshProUGUI timer;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
    float gameTimer=0,cardTimer=0;    
    bool gameStop=false;

    public int cardLeft;
    public int wrongCardOpened=0;

    private void Start() {

       if(gameMode==GameMode.Easy)
       {
            numOfRows=3;
            CardField.GetComponent<RectTransform>().anchoredPosition=  new Vector3(-70,50,0);
       }
       else
       {
            numOfRows=4;
            CardField.GetComponent<RectTransform>().anchoredPosition=  new Vector3(-70,100,0);
       }

       generateGame();
       cardLeft=numOfRows*4;
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
                            foreach(var child in pair_card)
                                {
                                    child.GetComponent<Button>().enabled=false;
                                    child.GetComponent<Image>().color=new UnityEngine.Color(1,1,1,0);
                                    cardLeft--;
                                    
                                }
                                if(cardLeft==0)
                                {
                                    Debug.Log("You Won");
                                }

                                if(gameMode==GameMode.Hard)
                                {
                                    wrongCardOpened=0;
                                }
                        }
                        else
                        {
                            foreach(var child in pair_card)
                                {
                                    child.GetComponent<Image>().sprite=defaultImg;
                                    child.transform.rotation= Quaternion.Euler(new Vector3(0,0,0));
                                }
                                wrongCardOpened++;
                                if(wrongCardOpened==5)
                                {
                                    CardReposition();
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

    void CardReposition()
    {
        
    }

    void generateGame()
    {
        List<GameObject> cardlist=new List<GameObject>();
        tempLevelTime=levelTime;
        timer.text="Time: "+tempLevelTime.ToString();
        foreach(Transform child in CardField.transform)
        {
            Destroy(child.gameObject);
        }

       

        for(int i=0;i<numOfRows*2;i++)
        {
            int randomCard= Random.Range(0,8);
            
            cardlist.Add(Cards[randomCard]);
            cardlist.Add(Cards[randomCard]);
        }
        for(int i=0;i<numOfRows*4;i++)
        {
            int randomCard= Random.Range(0,cardlist.Count);
            GameObject card= GameObject.Instantiate(cardlist[randomCard]);
            cardlist.RemoveAt(randomCard);
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
