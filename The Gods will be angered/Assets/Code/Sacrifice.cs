using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sacrifice : Choice {
	bool showDialog = false;
	bool inputRecieved = false;
	public override void Resolve()
	{
		if (inputRecieved)
		{
			resolved = true;
			inputRecieved = false;
			showDialog = false;
		}
		else
		{
			showDialog = true;
		}
	}

	public Rect windowRect = new Rect(20, 20, 120, 50);
	private void OnGUI()
	{
		if (showDialog)
		{
			windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
		}
	}

	void DoMyWindow(int windowID)
	{
		if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
		{
			print("Got a click");
		}
	}
}
