using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public int Score;
     public int GaintToSpeedUp = 100;
     public Text ScoreLabel;
     private int ScoreToSpeedUp;
     private Difficulty_Manager difficultyManager;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          Score = 0;
          ScoreToSpeedUp = GaintToSpeedUp;
          difficultyManager = FindObjectOfType<Difficulty_Manager>();
     }

     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     private void Update()
     {
          ScoreLabel.text = "Score: " + Score.ToString();
     }

     /*************************************************************************************************
     *** OnDestroy
     *************************************************************************************************/
     private void OnDestroy()
     {
          PlayerPrefs.SetInt("Score", Score);
     }

     /*************************************************************************************************
     *** Functions
     *************************************************************************************************/
     public void AddPoints(int HowMuch)
     {
          Score += HowMuch;

          if (Score >= ScoreToSpeedUp)
          {
               ScoreToSpeedUp += GaintToSpeedUp;
               difficultyManager.HarderPls();
          }
     }

     public void TakePoints(int HowMuch)
     {
          Score -= HowMuch;

          if (Score < 0)
               Score = 0;
     }
}
