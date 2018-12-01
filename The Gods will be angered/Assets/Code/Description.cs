using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Description : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Text textObject;
	public string description;

	
	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		textObject.text = description;
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
		textObject.text = "";
	}
}
