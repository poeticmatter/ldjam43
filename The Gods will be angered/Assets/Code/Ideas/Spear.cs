using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spear : Choice
{
	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			Game.instance.Wood -= 2;
			AddUpgrade();
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && Game.instance.Wood >= 2;
	}

	public override string GetDescription()
	{
		return "Build a Spear to hunt better (-15% chance of Health loss from hunting).\nCost: 2 wood.";
	}
}
