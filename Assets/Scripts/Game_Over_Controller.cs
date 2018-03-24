using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_Over_Controller : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public string GameSceneName = "Game";
    public string MainMenuSceneName = "Main Menu";
    public Text ScoreText;
	
	
    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   if (PlayerPrefs.HasKey("Score"))
		  ScoreText.text = "Your Score: " + PlayerPrefs.GetInt("Score");
	   else
		  ScoreText.text = "";
    
    }//void Start
    
    
    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
        
    
    }//void Update


    /*************************************************************************************************
    *** OnDestroy
    *************************************************************************************************/
    void OnDestroy ()
    {
	   if (PlayerPrefs.HasKey("Score"))
		  PlayerPrefs.DeleteKey("Score");

    }//void OnDestroy


    /*************************************************************************************************
    *** Buttons
    *************************************************************************************************/
    public void Retry ()
    {
	   SceneManager.LoadScene(GameSceneName);

    }//Retry


    public void MainMenu ()
    {
	   SceneManager.LoadScene(MainMenuSceneName);

    }//MainMenu


}//public class Game_Over_Controller