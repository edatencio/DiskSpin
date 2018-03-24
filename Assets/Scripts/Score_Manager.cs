using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Score_Manager : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public int Score;
    public int GaintToSpeedUp = 100;
    public Text ScoreLabel;
    private int ScoreToSpeedUp;
    private Difficulty_Manager difficultyManager;

	
    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   Score = 0;
	   ScoreToSpeedUp = GaintToSpeedUp;
	   difficultyManager = FindObjectOfType<Difficulty_Manager>();
    
    }//void Start
    
    
    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   ScoreLabel.text = "Score: " + Score.ToString();
    
    }//void Update


    /*************************************************************************************************
    *** OnDestroy
    *************************************************************************************************/
    void OnDestroy ()
    {
	   PlayerPrefs.SetInt("Score", Score);

    }//void OnDestroy


    /*************************************************************************************************
    *** Functions
    *************************************************************************************************/
    public void AddPoints (int HowMuch)
    {
	   Score += HowMuch;

	   if (Score >= ScoreToSpeedUp)
	   {
		  ScoreToSpeedUp += GaintToSpeedUp;
		  difficultyManager.HarderPls();

	   }//if

    }//AddPoints


    public void TakePoints (int HowMuch)
    {
	   Score -= HowMuch;

	   if (Score < 0)
	   {
		  Score = 0;

	   }//if

    }//TakePoints



    
}//public class Score_Manager