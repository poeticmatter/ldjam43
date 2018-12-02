﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour{

	public string title;
	public int resolved = 1;
	public int priority; //0 Resources, 1 oportunity, 2 Ideas, 3 Bad
	public int showChance;
	public bool available;
	public virtual bool Resolve(bool selected)
	{
		resolved--;
		if (resolved < 0)
		{
			Debug.LogError("Resoved should not go below 0.");
			resolved = 0;
		}
		return true;
	}

	public virtual bool isAvailable()
	{
		return available;
	}

	public bool IsResolved()
	{
		return resolved <= 0;
	}

	public virtual string GetDescription()
	{
		return "";
	}

}
