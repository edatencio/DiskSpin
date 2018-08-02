using UnityEngine;

public class Icon_Spawn : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     public ObjectPool[] iconPools;
     private int SelectedIcon;
     private Transform Disk;
     private float Counter;
     private Difficulty_Manager difficultyManager;
     public bool ShieldsOn = false;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void Start()
     {
          Disk = FindObjectOfType<Disk_Controller>().transform;
          Counter = 0;

          difficultyManager = FindObjectOfType<Difficulty_Manager>();
     }

     /*************************************************************************************************
    *** Update
    *************************************************************************************************/
     private void Update()
     {
          if (Counter <= 0)
          {
               //Stablecer la probabilidad en que se elije cada Icon
               SelectedIcon = Mathf.RoundToInt(Random.Range(1, 10));

               if (ShieldsOn == false && SelectedIcon == 1)
                    SelectedIcon++;

               switch (SelectedIcon)
               {
                    case 1: //Shields
                         SelectedIcon = 2;
                         break;

                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6: //Plus
                         SelectedIcon = 1;
                         break;

                    default: //Cross
                         SelectedIcon = 0;
                         break;
               }
               GameObject IconClone = iconPools[SelectedIcon].Spawn(Disk, Disk.position, Disk.rotation);
               IconClone.GetComponent<Icon_Controller>().moveSpeed = difficultyManager.IconsMoveSpeed;

               Counter = difficultyManager.SpawnDelay;
          }

          Counter -= Time.deltaTime;
     }
}
