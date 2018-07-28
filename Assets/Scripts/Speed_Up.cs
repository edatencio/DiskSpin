using UnityEngine;
using System.Collections;

public class Speed_Up : MonoBehaviour
{
     /*************************************************************************************************
     *** Variables
     *************************************************************************************************/
     [SerializeField] private float ThirdAnimState;
     [SerializeField] private float DisableDelay = 3f;

     private Icon_Spawn iconSpawn;
     private Animation Anim;
     private AnimationState ThirdAnimationState;
     private bool animsPlayed;

     /*************************************************************************************************
     *** Start
     *************************************************************************************************/
     private void OnEnable()
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
     private void Update()
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
