using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Health_Manager : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public int Health;
    public int MaxHealth = 10;
    public Slider HealthSlider;
    public string GameOverScene = "Game Over";

    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   Health = MaxHealth;
	   HealthSlider.maxValue = MaxHealth;
    
    }//void Start
    
    
	/*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   HealthSlider.value = Health;
    
    }//void Update


    /*************************************************************************************************
    *** Add and Take Health
    *************************************************************************************************/
    public void AddHealth (int HowMuch)
    {
	   Health += HowMuch;

	   if (Health > MaxHealth)
	   {
		  Health = MaxHealth;

	   }//if

    }//AddHealth


    public void TakeHealth (int HowMuch)
    {
	   Health -= HowMuch;

	   if (Health <= 0)
	   {
		  SceneManager.LoadScene(GameOverScene);

	   }//if

    }//TakeHealth


}//public class Health_Manager