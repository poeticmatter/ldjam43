using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : Choice
{
	public Knife knife;
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
		return base.IsAvailable() && Game.instance.Wood >= 2 && !knife.available;
	}

	public override string GetDescription()
	{
		return "Weave a Basket using a Knife and twine to help gather food (50% chance of +1 food when gathering).\nCost: 2 wood.";
	}
}