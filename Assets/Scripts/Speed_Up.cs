using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Speed_Up : MonoBehaviour
{
    /*************************************************************************************************
    *** Variables
    *************************************************************************************************/
    private Transform text;
    private Icon_Spawn iconSpawn;
    private Animation Anim;
    private AnimationState ThirdAnimationState;
    private bool animsPlayed;
    public float ThirdAnimState;
    public float DisableDelay = 3f;


    /*************************************************************************************************
    *** Start
    *************************************************************************************************/
    void OnEnable ()
    {
	   text = gameObject.transform.GetChild(0);
	   iconSpawn = FindObjectOfType<Icon_Spawn>();
	   iconSpawn.enabled = false;

	   animsPlayed = false;
	   Anim = gameObject.GetComponent<Animation>();
	   Anim.Rewind();

    }//void Start
    
    
	/*************************************************************************************************
    *** Update
    *************************************************************************************************/
    void Update ()
    {
	   if (FindObjectOfType<Icon_Controller>() == null)
	   {
		  if (animsPlayed == false)
		  {
			 Anim.PlayQueued("SpeedUp_Background_FadeIn");
			 Anim.PlayQueued("SpeedUp_Background_Text");
			 Anim.PlayQueued("SpeedUp_Background_FadeOut");

			 StartCoroutine(WaitAndDisable(DisableDelay));
			 animsPlayed = true;

		  }//if

	   }//if

    }//void Update


    private IEnumerator WaitAndDisable(float HowLong)
    {
	   yield return new WaitForSeconds(HowLong);
	   iconSpawn.enabled = true;
	   gameObject.SetActive(false);

    }//WaitAndDisable


}//public class Speed_Up