using UnityEngine;
using System.Collections;


public class Speed_Up : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     [SerializeField] float ThirdAnimState;
     [SerializeField] float DisableDelay = 3f;

     Icon_Spawn iconSpawn;
     Animation Anim;
     AnimationState ThirdAnimationState;
     bool animsPlayed;


     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     void OnEnable()
     {
          //Get references
          iconSpawn = FindObjectOfType<Icon_Spawn>();
          Anim = gameObject.GetComponent<Animation>();

          //Set flags
          iconSpawn.enabled = false;
          animsPlayed = false;

          Anim.Rewind();

     }


     /*************************************************************************************************
     *** Update
     *************************************************************************************************/
     void Update()
     {
          if (FindObjectOfType<Icon_Controller>() == null && animsPlayed == false)
          {
               Anim.PlayQueued("SpeedUp_Background_FadeIn");
               Anim.PlayQueued("SpeedUp_Background_Text");
               Anim.PlayQueued("SpeedUp_Background_FadeOut");

               StartCoroutine(WaitAndDisable(DisableDelay));
               animsPlayed = true;

          }

     }


     private IEnumerator WaitAndDisable(float HowLong)
     {
          yield return new WaitForSeconds(HowLong);
          iconSpawn.enabled = true;
          gameObject.SetActive(false);

     }


}
