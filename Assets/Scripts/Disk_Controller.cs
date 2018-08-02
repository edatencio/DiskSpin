using UnityEngine;

public class Disk_Controller : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public float shootWindow = 10;
     private float f_RotationObjetive;
     private Quaternion q_RotationObjetive;
     private bool isRotating;
     private Difficulty_Manager difficultyManager;

     public GameObject pointer;
     public ObjectPool[] bullets = new ObjectPool[2];

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          isRotating = false;
          difficultyManager = FindObjectOfType<Difficulty_Manager>();
          q_RotationObjetive = gameObject.transform.rotation;
     }

     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     private void Update()
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
          if (gameObject.transform.rotation != q_RotationObjetive)
               gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, q_RotationObjetive, difficultyManager.DiskRotationSpeed * Time.deltaTime);
          else
               isRotating = false;
     }

     /*************************************************************************************************
     *** Rotate Disk Functions
     *************************************************************************************************/
     public void RotateRight()
     {
          if (isRotating == false)
          {
               isRotating = true;
               f_RotationObjetive += 45f;
               q_RotationObjetive = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, f_RotationObjetive);
          }
     }

     public void RotateLeft()
     {
          if (isRotating == false)
          {
               isRotating = true;
               f_RotationObjetive -= 45f;
               q_RotationObjetive = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, f_RotationObjetive);
          }
     }

     /*************************************************************************************************
     *** Fire Functions
     *************************************************************************************************/
     public void Fire_1()
     {
          if (Quaternion.Angle(gameObject.transform.rotation, q_RotationObjetive) <= shootWindow)
               bullets[0].Spawn(transform, pointer.transform.position, pointer.transform.rotation);
     }

     public void Fire_2()
     {
          if (Quaternion.Angle(gameObject.transform.rotation, q_RotationObjetive) <= shootWindow)
               bullets[1].Spawn(transform, pointer.transform.position, pointer.transform.rotation);
     }
}
