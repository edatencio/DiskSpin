using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Over_Controller : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     [SerializeField] private SceneAsset game;
     [SerializeField] private SceneAsset mainMenu;
     public Text ScoreText;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          if (PlayerPrefs.HasKey("Score"))
               ScoreText.text = string.Concat("Your Score: ", PlayerPrefs.GetInt("Score").ToString());
          else
               ScoreText.text = "";
     }

     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     private void Update()
     {
     }

     /*************************************************************************************************
     *** OnDestroy
     *************************************************************************************************/
     private void OnDestroy()
     {
          if (PlayerPrefs.HasKey("Score"))
               PlayerPrefs.DeleteKey("Score");
     }

     /*************************************************************************************************
     *** Buttons
     *************************************************************************************************/
     public void Retry()
     {
          SceneManager.LoadScene(game.name);
     }

     public void MainMenu()
     {
          SceneManager.LoadScene(mainMenu.name);
     }
}
