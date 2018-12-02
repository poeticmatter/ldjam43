using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodsWillBeAngered : MonoBehaviour {

	public string[] messages = new string[] { "The Gods will unleash their wrath.", "The Gods will be furious.", "The Gods will punsish the greedy.", "The Gods have been angered", "The Gods must be appeased" };

	public Text textOb;

	void Update()
	{
		Color newColor = textOb.color;
		newColor.a = newColor.a - 0.005f;
		textOb.color = newColor;
	}

	public void ShowGodsMessage()
	{
		textOb.text = messages[Random.Range(0, messages.Length)];
		Color newColor = textOb.color;
		newColor.a = 1f;
		textOb.color = newColor;
	}
}
