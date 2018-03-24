using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pointer_PointingAt : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public GameObject CurrentTarget;
    public string TargetsLayerName = "Targets";
    private LayerMask TargetsLayer;


    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start ()
    {
	   TargetsLayer = LayerMask.NameToLayer(TargetsLayerName);

    }//void Start


    /*************************************************************************************************
    *** OnTriggerEnter2D
    *************************************************************************************************/
    void OnTriggerEnter2D (Collider2D col)
    {
	   if (col.gameObject.layer == TargetsLayer)
	   {
		  CurrentTarget = col.gameObject;

	   }//if

    }//void OnTriggerEnter2D
	
    
}//public class Pointer_PointingAt