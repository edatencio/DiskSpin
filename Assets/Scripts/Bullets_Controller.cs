using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bullets_Controller : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public float BulletSpeed;
    private Vector3 DiskPosition;
    private GameObject CurrentTarget;
    private LayerMask TargetsLayer;
    public string TargetsLayerName = "Targets";


    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   DiskPosition = FindObjectOfType<Disk_Controller>().transform.position;
	   TargetsLayer = LayerMask.NameToLayer(TargetsLayerName);
	   CurrentTarget = FindObjectOfType<Pointer_PointingAt>().CurrentTarget;
    
    }//void Start
    
    
    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, DiskPosition, BulletSpeed * Time.deltaTime);

	   if (gameObject.transform.position == DiskPosition)
	   {
		  Destroy(gameObject);

	   }//else if


    }//void Update


    /*************************************************************************************************
    *** OnTriggerEnter2D
    *************************************************************************************************/
    void OnTriggerEnter2D (Collider2D col)
    {    
	   if (col.tag == gameObject.tag && col.GetComponent<Icon_Controller>().CurrentTarget == CurrentTarget)
	   {
		  Destroy(col.gameObject);
		  Destroy(gameObject);

	   } else if (col.GetComponent<Icon_Controller>().CurrentTarget == CurrentTarget)
	   {
		  Destroy(gameObject);

	   }//if else

    }//OnTriggerEnter2D


}//public class Bullets_Controller