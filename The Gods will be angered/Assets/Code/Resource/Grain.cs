using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grain : Choice {

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			Game.instance.Food += 1;
		}
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		return "Forage for Food (+1 Food).";
	}
}
