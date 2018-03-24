using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class Button_MouseDown : MonoBehaviour, IPointerDownHandler
{
    [Serializable]
    public class ButtonPressEvent : UnityEvent { }

    public ButtonPressEvent OnPress = new ButtonPressEvent();

    public void OnPointerDown (PointerEventData eventData)
    {
	   OnPress.Invoke();

    }//public void OnPointerDown


}//public class Button_MouseDown