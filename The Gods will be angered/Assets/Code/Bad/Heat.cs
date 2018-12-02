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
			return "A harsh sun, but your Waterskin may keep you refreshed throughout the day.\n\nChosen: You rest.\n\nNot Chosen: Take your watersking with you(-2 water).";
		}
		if (!waterskin.available && waterskin.Water > 0)
		{
			return "A harsh sun, but your Waterskin may keep you refreshed some of the day.\n\nChosen: Take your watersking with you (15% chance -1 health).\n\nNot Chosen: spend the day resting.";
		}
		return "A harsh sun forces you lay down and rest, or risk suffering a heat stroke.\n\nChosen: Rest in the shade.\n\nNot Chosen: You go about your day, risking dehydration (%75 chance -1 Health if not chosen).";
	}
}
