using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     [SerializeField] private SceneAsset mainMenu;
     [SerializeField] private GameObject pauseMenu;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          isPaused = false;
          pauseMenu.SetActive(false);
     }

     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     private void Update()
     {
          if (Input.GetButtonDown(Constants.Submit))
               Pause_Resume_Game();
     }

     /*************************************************************************************************
     *** Properties
     *************************************************************************************************/
     public bool isPaused { get; set; }

     /*************************************************************************************************
     *** Methods
     *************************************************************************************************/
     public void Pause_Resume_Game()
     {
          isPaused = !isPaused;
          pauseMenu.SetActive(isPaused);

          if (isPaused)
               Time.timeScale = 0f;
          else if (!isPaused)
               Time.timeScale = 1f;
     }

     public void Quit_Game()
     {
          Time.timeScale = 1f;
          SceneManager.LoadScene(mainMenu.name);
     }
}
