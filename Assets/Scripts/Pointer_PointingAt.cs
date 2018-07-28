using UnityEngine;

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
     private void Start()
     {
          TargetsLayer = LayerMask.NameToLayer(TargetsLayerName);
     }

     /*************************************************************************************************
     *** OnTriggerEnter2D
     *************************************************************************************************/
     private void OnTriggerEnter2D(Collider2D col)
     {
          if (col.gameObject.layer == TargetsLayer)
               CurrentTarget = col.gameObject;
     }
}
