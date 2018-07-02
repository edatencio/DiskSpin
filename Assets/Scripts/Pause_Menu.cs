using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause_Menu : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     [SerializeField] SceneAsset mainMenu;
     [SerializeField] GameObject pauseMenu;


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
          if (Input.GetButtonDown(Constants.Submit))
               Pause_Resume_Game();

     }//void Update


     /*************************************************************************************************
     *** Properties
     *************************************************************************************************/
     public bool isPaused
     {
          get; set;

     }//public bool IsPaused


     /*************************************************************************************************
     *** Methods
     *************************************************************************************************/
     public void Pause_Resume_Game()
     {
          isPaused = !isPaused;
          pauseMenu.SetActive(isPaused);

          if (isPaused) Time.timeScale = 0f;
          else if (!isPaused) Time.timeScale = 1f;

     }//public void Pause_Game


     public void Quit_Game()
     {
          Time.timeScale = 1f;
          SceneManager.LoadScene(mainMenu.name);

     }//public void Quit_Game


}//public class Pause_Menu
