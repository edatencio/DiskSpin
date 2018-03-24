using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;


public class old_Main_Menu : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public string TwitterURL = "https://twitter.com/ed_atencio";
     public string GameJoltURL = "https://gamejolt.com/@ed-atencio";
     public string ItchIoURL = "https://ed-atencio.itch.io/";
     public string GameSceneName = "Game";
     public GameObject ExitButtonCrossLine;
     
	
     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     void Start ()
     {
          #if UNITY_WEBGL
               ExitButtonCrossLine.SetActive(true);
          #endif
          
     }//void Start
     
     
	/*************************************************************************************************
     *** Update
     *************************************************************************************************/
     void Update ()
     {
          
          
     }//void Update
     
     
     /*************************************************************************************************
     *** Buttons
     *************************************************************************************************/
     public void Button_StartGame ()
     {
          SceneManager.LoadScene(GameSceneName);
          
     }//StartGame
     
     
     public void Button_ExitGame ()
     {
          Application.Quit();
          
     }//QuitGame
     
     
     public void Button_Twitter ()
     {
          #if UNITY_WEBGL
               openWindow(TwitterURL);
               #else
               Application.OpenURL(TwitterURL);
          #endif
          
     }//public void Button_Twitter
     
     
     public void Button_GameJolt ()
     {
          #if UNITY_WEBGL
               openWindow(GameJoltURL);
               #else
               Application.OpenURL(GameJoltURL);
          #endif
          
     }//public void Button_GameJolt
     
     
     public void Button_ItchIO ()
     {
          #if UNITY_WEBGL
               openWindow(ItchIoURL);
               #else
               Application.OpenURL(ItchIoURL);
          #endif
          
     }//public void Button_ItchIO
     
     
     /*************************************************************************************************
     *** Es necesario para abrir paginas en una pestaña nueva desde el web player
     *************************************************************************************************/
     #if UNITY_WEBGL
          [DllImport("__Internal")]
          private static extern void openWindow(string url);
     #endif
     
     
}//public class Main_Menu_Controller
          