using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Icon_Controller : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    public float MoveSpeed;
    public int HealthToTake = 1;
    public int PointsToAdd = 10;
    public int PointsToTake = 5;
    public string PlusIconName = "Plus";
    public string CrossIconName = "Cross";
    public GameObject CurrentTarget;
    public int TargetSelection;
    public string[] Targets;
    public bool DebugTarget = false;
    public int DebugTargetSelection;
    private Score_Manager Score;
    private Health_Manager HealthManager;


    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void Start()
    {
	   TargetSelection = Mathf.RoundToInt(Random.Range(0, 8));
	   if (DebugTarget) { TargetSelection = DebugTargetSelection; }
	   
	   CurrentTarget = GameObject.Find(Targets[TargetSelection]);
	   transform.rotation = CurrentTarget.transform.rotation;

	   Score = FindObjectOfType<Score_Manager>();
	   HealthManager = FindObjectOfType<Health_Manager>();

    }//void Start


    /*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update()
    {
	   transform.position = Vector3.MoveTowards(gameObject.transform.position, CurrentTarget.transform.position, MoveSpeed * Time.deltaTime);
	   
	   if (gameObject.transform.position == CurrentTarget.transform.position)
	   {
		  Destroy(gameObject);

	   }//if

    }//void Update


    /*************************************************************************************************
    *** OnDestroy
    *************************************************************************************************/
    void OnDestroy ()
    {
	   if (gameObject.transform.position == CurrentTarget.transform.position && gameObject.tag == CrossIconName)
	   {
		  Score.TakePoints(PointsToTake);
		  HealthManager.TakeHealth(HealthToTake);

	   }//if

	   if (gameObject.transform.position != CurrentTarget.transform.position && gameObject.tag == PlusIconName)
	   {
		  Score.AddPoints(PointsToAdd);

	   }//if else

    }//OnDestroy


}//public class Icon_Controller