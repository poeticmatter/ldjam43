using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Choice {

	public Spear spear;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{	
			Game.instance.Food += 2;
			if (spear.available && Random.value <0.25f)
			{
				Game.instance.Health--;
			}
			if (!spear.available && Random.value < 0.10f)
			{
				Game.instance.Health--;
			}
			if (!spear.available && Random.value < 0.05f)
			{
				spear.LoseUpgrade();
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
		if (!spear.available)
		{
			return "Go hunting with a stone tipped spear (+2 food 10% chance of -1 Health. 5% chance to lose spear).";
		}
		return "Go hunting with a makeshift wooden spear (+2 Food. %25 chance -1 Health.";
	}
}
