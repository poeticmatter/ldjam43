using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : Choice {
	public Shelter shelter;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			if (shelter.available && Random.value < 0.1f)
			{
				Game.instance.Health--;
			}
			//Nothing, hide from rain.
		}
		else if (!shelter.available) 
		{
			if (Random.value < 0.25f)
			{
				if (Game.instance.Wood > 0)
				{
					Game.instance.Wood--; //For repairs
				} else
				{
					shelter.LoseUpgrade(); //Cannot repair
				}
			}
		}
		else
		{
			if (Random.value < 0.5f)
			{
				Game.instance.Health--;
			}
		}
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		if (!shelter.available)
		{
			if (Game.instance.Wood > 0)
			{
				return "You have a shelter to sleep in at night, but the rain is heavy during the day too.\n\nChosen: Make sure your shelter remains intact.\n\nNot Chosen: You leave the shelter while you go about your day, you may need to repair it when back (25% chance -1 wood).";
			}
			return "You have a shelter to sleep in at night, but the rain is heavy during the day too.\n\nChosen: Make sure your shelter remains intact.\n\nNot Chosen: You leave the shelter while you go about your day, it may fall apart, and you have no wood, so you'll have to rebuild from scratch (25% to lose shelter).";
		}
		return "A rainy night and no shelter.\n\nChosen: Find a cave to slee in, there is a sleight chance of a flood (10% chance of -1 health).\n\nNot Chosen: Sleep outdoors (50% chance of -1 health).";
	}

}
