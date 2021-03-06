﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shelter : Choice
{
	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			Game.instance.Wood -= 5;
			AddUpgrade();
			Debug.Log("resolve shelter");
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && Game.instance.Wood >= 5;
	}

	public override string GetDescription()
	{
		return "Build a shelter to protect you from the elements.\nCost: 5 wood.";
	}
}
