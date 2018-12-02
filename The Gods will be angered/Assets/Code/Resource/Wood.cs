using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Choice {
	public Axe axe;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			Game.instance.Wood += 1;
			if (!axe.available)
			{
				Game.instance.Wood += 1;
			}
		}
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		if (!axe.available) // purchased
		{
			return "Gather 2 wood with your Axe.";
		}
		return "Gather 1 wood.";
	}
}
