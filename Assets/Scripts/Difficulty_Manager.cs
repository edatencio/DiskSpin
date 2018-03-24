using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Difficulty_Manager : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public int Level = 1;
    private int SpawnDelay_Level = 1;
    private int IconsMoveSpeed_Level = 1;
    private int DiskRotationSpeed_Level = 1;
    public float SpawnDelay = 3f;
    public float IconsMoveSpeed = 0.5f;
    public float DiskRotationSpeed = 100;
    public GameObject PlaneSpeedUp;
    public float DifficultyStep = 1;


    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start()
    {


    }//void Start


    /*************************************************************************************************
   *** Update
   *************************************************************************************************/
    void Update()
    {
	   if (Level > SpawnDelay_Level)
		  for (int i = 0; i < (Level - SpawnDelay_Level); i++)
			 SpawnDelay = SpawnDelay_Decrement(SpawnDelay);

	   if (Level > IconsMoveSpeed_Level)
		  for (int i = 0; i < (Level - IconsMoveSpeed_Level); i++)
			 IconsMoveSpeed = IconsMoveSpeed_Increment(IconsMoveSpeed);

	   if (Level > DiskRotationSpeed_Level)
		  for (int i = 0; i < (Level - DiskRotationSpeed_Level); i++)
			 DiskRotationSpeed = DiskRotationSpeed_Increment(DiskRotationSpeed);

    }//void Update


    /*************************************************************************************************
    *** FUNCTIONS
    *************************************************************************************************/
    public void HarderPls()
    {
	   PlaneSpeedUp.SetActive(true);
	   Level++;
	   SpawnDelay = SpawnDelay_Decrement(SpawnDelay);
	   IconsMoveSpeed = IconsMoveSpeed_Increment(IconsMoveSpeed);
	   DiskRotationSpeed = DiskRotationSpeed_Increment(DiskRotationSpeed);

    }//MoreDifficult


    private float SpawnDelay_Decrement(float CurrentDelay)
    {
	   //El delay se reduce por 0.6 (1 / 2.5 = 0.4)
	   CurrentDelay -= DifficultyStep / 2.5f;

	   if (CurrentDelay < 0.4f)
		  CurrentDelay = 0.4f;

	   SpawnDelay_Level++;
	   return CurrentDelay;

    }//private void SpawnDelay_Reduce


    private float IconsMoveSpeed_Increment(float CurrentSpeed)
    {
	   //La velocidad de los Icons incrementa por 0.2
	   CurrentSpeed += DifficultyStep / 5f;

	   IconsMoveSpeed_Level++;
	   return CurrentSpeed;

    }//private float IconsMoveSpeed_Increment


    private float DiskRotationSpeed_Increment(float CurrentSpeed)
    {
	   //La velocidad para rotar el disco incrementa en 10 (1 * 10 = 10)
	   CurrentSpeed += DifficultyStep * 10;

	   DiskRotationSpeed_Level++;
	   return CurrentSpeed;

    }//private float DiskRotationSpeed_Increment


}//public class Difficulty_Manager