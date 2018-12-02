using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildAnimal : Choice
{
	public Spear spear;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			if (spear.available && Random.value < 0.1f)
			{
				Game.instance.Health--;
			}
			else if (Random.value < 0.25f)
			{
				Game.instance.Health--;
			}
			
		}
		else
		{
			Game.instance.Food -= Random.Range(1, 5);
			if (Game.instance.Food <= 0)
			{
				Game.instance.Food = 0;
			}
		}
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		if (!spear.available)
		{
			return "Fight off the animal with your Spear (10% chance of -1 Health if chosen), or let it into your cqamp (lose 1-4 food).";
		}
		return "Fight off the animal with a makeshift spear (25% chance of -1 Health if chosen), or let it into your cqamp (lose 1-4 food).";
	}

}
