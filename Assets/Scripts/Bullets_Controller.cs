using UnityEngine;

public class Bullets_Controller : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     [SerializeField] private float bulletSpeed;
     [SerializeField] private LayerMask targetsLayer;

     private Vector3 diskPosition;
     private GameObject currentTarget;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          //Get references
          diskPosition = FindObjectOfType<Disk_Controller>().transform.position;
          currentTarget = FindObjectOfType<Pointer_PointingAt>().CurrentTarget;
     }

     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     private void Update()
     {
          transform.position = Vector3.MoveTowards(transform.position, diskPosition, bulletSpeed * Time.deltaTime);

          if (transform.position == diskPosition)
          {
               Destroy(gameObject);
          }
     }

     /*************************************************************************************************
     *** OnTriggerEnter2D
     *************************************************************************************************/
     private void OnTriggerEnter2D(Collider2D other)
     {
          GameObject otherTarget = other.GetComponent<Icon_Controller>().CurrentTarget;

          if (other.tag == tag && otherTarget == currentTarget)
          {
               Destroy(other.gameObject);
               Destroy(gameObject);
          }
          else if (otherTarget == currentTarget)
          {
               Destroy(gameObject);
          }
     }
}
