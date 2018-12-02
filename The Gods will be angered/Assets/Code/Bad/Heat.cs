using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : Choice {
	public Waterskin waterskin;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			//Nothing, rests.
		}
		else if (!waterskin.available && waterskin.Water > 1)
		{
			waterskin.Water--;
			waterskin.Water--;
		}
		else if (!waterskin.available && waterskin.Water > 0)
		{
			waterskin.Water--;
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
		if (!waterskin.available && waterskin.Water > 1)
		{
			return "Your Waterskin keeps you refreshed throughout the day (-2 water if not chosen) or spend the day resting.";
		}
		if (!waterskin.available && waterskin.Water > 0)
		{
			return "Your Waterskin keeps you refreshed some of the day (15% chance -1 Health if not chosen) or spend the day resting.";
		}
		return "A harsh sun forces you lay down and rest, or risk suffering a heat stroke (%75 chance -1 Health if not chosen)";
	}
}
