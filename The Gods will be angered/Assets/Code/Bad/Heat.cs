using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : Choice {

	public override bool Resolve(bool selected)
	{
		bool hasWater = false;
		if (selected)
		{
			//Nothing, rests.
		}
		else if (hasWater)
		{
			//water--;
		}
		else
		{
			if (Random.value < 0.75f)
			{
				Game.instance.Health--;
			}
		}
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		return "A harsh sun forces you to go to the lake to cool, or risk suffering a heat stroke (%75 chance -1 Health if not chosen)";
	}
}
