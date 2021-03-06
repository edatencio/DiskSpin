using UnityEngine;

public class TimeScale : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     [SerializeField] private float timeScale = 1f;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          if (timeScale != 1f)
               Debug.LogWarning(string.Concat(gameObject.name, ": Time scale set to ", timeScale.ToString(), "."));
     }

     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     private void Update()
     {
          if (timeScale != 1f)
               Time.timeScale = timeScale;
     }

     /*************************************************************************************************
     *** Properties
     *************************************************************************************************/

     /*************************************************************************************************
     *** Methods
     *************************************************************************************************/
}
