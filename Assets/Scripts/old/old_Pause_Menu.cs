using UnityEngine;
using UnityEngine.SceneManagement;


public class old_Pause_Menu : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public bool isPaused;
     public GameObject pauseMenu;
     public string MainMenuSceneName = "Main Menu";


     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     void Start()
     {
          isPaused = false;
          pauseMenu.SetActive(false);

     }//void Start


     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     void Update()
     {
          if (isPaused)
          {
               pauseMenu.SetActive(true);
               Time.timeScale = 0f;

          }
          else
          {
               pauseMenu.SetActive(false);
               Time.timeScale = 1f;

          }//if else

#if UNITY_STANDALONE || UNITY_WEBGL
          if (Input.GetButtonDown("Submit"))
               isPaused = !isPaused;
#endif

     }//void Update


     /*************************************************************************************************
     *** Buttons Functions
     *************************************************************************************************/
     public void Button_Resume()
     {
          isPaused = false;

     }//public void Button_Resume


     public void Button_Quit()
     {
          SceneManager.LoadScene(MainMenuSceneName);

     }//public void Button_Quit


}//public class Pause_Menu