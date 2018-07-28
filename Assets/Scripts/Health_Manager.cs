using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_Manager : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public int Health;
     public int MaxHealth = 10;
     [SerializeField] private Slider HealthSlider;
     [SerializeField] private SceneAsset gameOver;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          Health = MaxHealth;
          HealthSlider.maxValue = MaxHealth;
     }

     /*************************************************************************************************
    *** Update
    *************************************************************************************************/
     private void Update()
     {
          HealthSlider.value = Health;
     }

     /*************************************************************************************************
     *** Add and Take Health
     *************************************************************************************************/
     public void AddHealth(int HowMuch)
     {
          Health += HowMuch;

          if (Health > MaxHealth)
               Health = MaxHealth;
     }

     public void TakeHealth(int HowMuch)
     {
          Health -= HowMuch;

          if (Health <= 0)
               SceneManager.LoadScene(gameOver.name);
     }
}
