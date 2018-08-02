using UnityEngine;

public class Icon_Controller : MonoBehaviour, IObjectPooled
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public float moveSpeed;
     public int healthToTake = 1;
     public int pointsToAdd = 10;
     public int pointsToTake = 5;
     public string plusIconName = "Plus";
     public string crossIconName = "Cross";
     public GameObject currentTarget;
     public int targetSelection;
     public string[] targets;
     public bool debugTarget = false;
     public int debugTargetSelection;
     private Score_Manager score;
     private Health_Manager healthManager;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          targetSelection = Random.Range(0, targets.Length);

          Debug.Log(targetSelection.ToString());

          if (debugTarget)
               targetSelection = debugTargetSelection;

          currentTarget = GameObject.Find(targets[targetSelection]);
          transform.rotation = currentTarget.transform.rotation;

          score = FindObjectOfType<Score_Manager>();
          healthManager = FindObjectOfType<Health_Manager>();
     }

     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     private void Update()
     {
          transform.position = Vector3.MoveTowards(gameObject.transform.position, currentTarget.transform.position, moveSpeed * Time.deltaTime);

          if (gameObject.transform.position == currentTarget.transform.position)
               Pool.Vanish(gameObject);
     }

     /*************************************************************************************************
     *** OnDestroy
     *************************************************************************************************/
     private void OnDestroy()
     {
          if (gameObject.transform.position == currentTarget.transform.position && gameObject.tag == crossIconName)
          {
               score.TakePoints(pointsToTake);
               healthManager.TakeHealth(healthToTake);
          }

          if (gameObject.transform.position != currentTarget.transform.position && gameObject.tag == plusIconName)
               score.AddPoints(pointsToAdd);
     }

     /*************************************************************************************************
     *** Properties
     *************************************************************************************************/
     public ObjectPool Pool { get; set; }
}
