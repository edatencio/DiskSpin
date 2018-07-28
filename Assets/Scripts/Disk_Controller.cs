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
     private void Start()
     {
          IsRotating = false;
          difficultyManager = FindObjectOfType<Difficulty_Manager>();
          Q_RotationObjetive = gameObject.transform.rotation;
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
          if (gameObject.transform.rotation != Q_RotationObjetive)
               gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Q_RotationObjetive, difficultyManager.DiskRotationSpeed * Time.deltaTime);
          else
               IsRotating = false;
     }

     /*************************************************************************************************
     *** Rotate Disk Functions
     *************************************************************************************************/
     public void RotateRight()
     {
          if (IsRotating == false)
          {
               IsRotating = true;
               F_RotationObjetive += 45f;
               Q_RotationObjetive = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, F_RotationObjetive);
          }
     }

     public void RotateLeft()
     {
          if (IsRotating == false)
          {
               IsRotating = true;
               F_RotationObjetive -= 45f;
               Q_RotationObjetive = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, F_RotationObjetive);
          }
     }

     /*************************************************************************************************
     *** Fire Functions
     *************************************************************************************************/
     public void Fire_1()
     {
          if (Quaternion.Angle(gameObject.transform.rotation, Q_RotationObjetive) <= ShootWindow)
               Instantiate(Bullets[0], Pointer.transform.position, Pointer.transform.rotation, gameObject.transform);
     }

     public void Fire_2()
     {
          if (Quaternion.Angle(gameObject.transform.rotation, Q_RotationObjetive) <= ShootWindow)
               Instantiate(Bullets[1], Pointer.transform.position, Pointer.transform.rotation, gameObject.transform);
     }
}
