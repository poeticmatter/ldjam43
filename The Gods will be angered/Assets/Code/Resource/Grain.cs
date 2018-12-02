using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grain : Choice {

	public Basket basket;
	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			Game.instance.Food += 1;
			if (!basket.available && Random.value < 0.50f)
			{
				Game.instance.Food += 1;
			}
		}
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		if (!basket.available)
		{
			return "Forage for Food using your Basket (+1 Food. %50 chance of additonal +1 Food).";
		}
		return "Forage for Food (+1 Food).";
	}
}
