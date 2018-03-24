using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Icon_Spawn : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public GameObject[] Icons;
    private int SelectedIcon;
    private Transform Disk;
    private float Counter;
    private Difficulty_Manager difficultyManager;
    public bool ShieldsOn = false;

	
    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    { 
	   Disk = FindObjectOfType<Disk_Controller>().transform;
	   Counter = 0;

	   difficultyManager = FindObjectOfType<Difficulty_Manager>();

    }//void Start
    
    
	/*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   if (Counter <= 0)
	   {
		  //Stablecer la probabilidad en que se elije cada Icon
		  SelectedIcon = Mathf.RoundToInt(Random.Range(1, 10));

		  if (ShieldsOn == false && SelectedIcon == 1)
			 SelectedIcon++;

		  switch (SelectedIcon)
		  {
			 case 1: //Shields
				SelectedIcon = 2;
			 break;

			 case 2: case 3: case 4: case 5: case 6: //Plus
				SelectedIcon = 1;
			 break;

			 default: //Cross
				SelectedIcon = 0;
			 break;

		  }//switch

		  GameObject IconClone = Instantiate(Icons[SelectedIcon], Disk.position, Disk.rotation, Disk);
		  IconClone.GetComponent<Icon_Controller>().MoveSpeed = difficultyManager.IconsMoveSpeed;

		  Counter = difficultyManager.SpawnDelay;

	   }//if

	   Counter -= Time.deltaTime;
	   
    }//void Update


}//public class Icon_Spawn