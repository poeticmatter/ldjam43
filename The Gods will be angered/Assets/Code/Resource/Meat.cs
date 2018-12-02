using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Choice {

	public override bool Resolve(bool selected)
	{
		if (selected)
		{	
			Game.instance.Food += 2;
			if (Random.value <0.25f)
			{
				Game.instance.Health--;
			}
			if (Random.value < 0.25f)
			{
				Game.instance.Wood--;
				if (Game.instance.Wood <0)
				{
					Debug.LogError("Negative wood");
					Game.instance.Wood = 0; //Dirty, but will prevent awkwardness
				}
			}
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && Game.instance.Wood >= 1;
	}

	public override string GetDescription()
	{
		return "Go hunting with a makeshift wooden spear (+2 Food. %25 chance -1 Health. %25 chance -1 Wood.";
	}
}
