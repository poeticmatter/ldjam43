using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spouse : Choice {

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			Game.instance.Actions++;
			Game.instance.DailyFoodCost++;
			Game.instance.Health += 3;
			available = false;
		}
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		return "You've met someone... (+1 action, +1 mouth to feed).";
	}
}
