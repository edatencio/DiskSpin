using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     [SerializeField] private SceneAsset gameScene;
     [SerializeField] private GameObject aboutPanel;
     [SerializeField] private GameObject exitButtonEnabled;
     [SerializeField] private GameObject exitButtonDisabled;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          Time.timeScale = 1f;

#if UNITY_WEBGL
          exitButtonEnabled.SetActive(false);
          exitButtonDisabled.SetActive(true);
#else
          exitButtonEnabled.SetActive(true);
          exitButtonDisabled.SetActive(false);
#endif

     }

     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     private void Update()
     {
          if (Input.GetButtonDown("Submit"))
               Start_Game();

          if (Input.GetButtonDown("Cancel"))
               Exit_Game();

     }

     /*************************************************************************************************
     *** Methods
     *************************************************************************************************/
     public void Start_Game()
     {
          SceneManager.LoadScene(gameScene.name);
     }

     public void Exit_Game()
     {
          Application.Quit();
     }

     public void About_Panel_Open()
     {
          aboutPanel.SetActive(true);
     }

     public void About_Panel_Close()
     {
          aboutPanel.SetActive(false);
     }

}
