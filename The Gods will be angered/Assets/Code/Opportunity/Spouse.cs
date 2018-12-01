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
		}
		return base.Resolve(selected);
	}
}
