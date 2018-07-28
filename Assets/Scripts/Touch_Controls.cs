using UnityEngine;

public class Touch_Controls : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public GameObject TouchControls;
     private Pause_Menu pauseMenu;
     private Disk_Controller Disk;

     private bool RotateRight;
     private bool RotateLeft;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          Disk = FindObjectOfType<Disk_Controller>();
          pauseMenu = FindObjectOfType<Pause_Menu>();

#if UNITY_ANDROID
          TouchControls.SetActive(true);
#endif

#if UNITY_STANDALONE || UNITY_WEBGL
          TouchControls.SetActive(false);
#endif
     }

     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     private void Update()
     {
          if (RotateRight)
               Disk.RotateRight();

          if (RotateLeft)
               Disk.RotateLeft();
     }

     /*************************************************************************************************
     *** Buttons Functions
     *************************************************************************************************/
     public void Arrow_Right_Down()
     {
          RotateRight = true;
     }

     public void Arrow_Right_Up()
     {
          RotateRight = false;
     }

     public void Arrow_Left_Down()
     {
          RotateLeft = true;
     }

     public void Arrow_Left_Up()
     {
          RotateLeft = false;
     }

     public void Fire_1()
     {
          Disk.Fire_1();
     }

     public void Fire_2()
     {
          Disk.Fire_2();
     }

     public void Pause()
     {
          pauseMenu.isPaused = !pauseMenu.isPaused;
     }
}
