using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Disk_Controller : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public float ShootWindow = 10;
    private float F_RotationObjetive;
    private Quaternion Q_RotationObjetive;
    private bool IsRotating;
    private Difficulty_Manager difficultyManager;

    public GameObject Pointer;
    public GameObject[] Bullets = new GameObject[2];


    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start()
    {
	   IsRotating = false;
	   difficultyManager = FindObjectOfType<Difficulty_Manager>();
	   Q_RotationObjetive = gameObject.transform.rotation;

    }//void Start


    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update()
    {
	   #if UNITY_STANDALONE || UNITY_WEBGL
		  //Derecha
		  if (Input.GetAxis("Horizontal") > 0.25f)
			 RotateRight();

		  //Izquierda
		  if (Input.GetAxis("Horizontal") < -0.25f)
			 RotateLeft();

		  //Fire 1: Plus
		  if (Input.GetButtonDown("Fire1"))
			 Fire_1();

		  //Fire 2: Cross
		  if (Input.GetButtonDown("Fire2"))
			 Fire_2();
	   #endif

	   //Rotate Disk
	   if (gameObject.transform.rotation != Q_RotationObjetive)
		  gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Q_RotationObjetive, difficultyManager.DiskRotationSpeed * Time.deltaTime);
	   else
		  IsRotating = false;

    }//void Update


    /*************************************************************************************************
    *** Rotate Disk Functions
    *************************************************************************************************/
    public void RotateRight ()
    {
	   if (IsRotating == false)
	   {
		  IsRotating = true;
		  F_RotationObjetive += 45f;
		  Q_RotationObjetive = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, F_RotationObjetive);

	   }//if

    }//public void RotateRight


    public void RotateLeft ()
    {
	   if (IsRotating == false)
	   {
		  IsRotating = true;
		  F_RotationObjetive -= 45f;
		  Q_RotationObjetive = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, F_RotationObjetive);

	   }//if

    }//public void RotateLeft


    /*************************************************************************************************
    *** Fire Functions
    *************************************************************************************************/
    public void Fire_1 ()
    {
	   if (Quaternion.Angle(gameObject.transform.rotation, Q_RotationObjetive) <= ShootWindow)
		  Instantiate(Bullets[0], Pointer.transform.position, Pointer.transform.rotation, gameObject.transform);

    }//public void Fire_1


    public void Fire_2 ()
    {
	   if (Quaternion.Angle(gameObject.transform.rotation, Q_RotationObjetive) <= ShootWindow)
		  Instantiate(Bullets[1], Pointer.transform.position, Pointer.transform.rotation, gameObject.transform);

    }//public void Fire_2


}//public class Disk_Controller