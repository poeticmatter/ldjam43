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
				return "Keep and eye on the shelter, or be about your day and you may need to spend wood on repairs (25% chance -1 wood if not chosen).";
			}
			return "Keep and eye on the shelter, or be about your day and you may need to spend wood on repairs (25% chance to lose shelter).";
		}
		return "Find a cave to hide in (10% chance of -1 Health if chosen), or brave the weather (50% chance of -1 Health if not chosen).";
	}

}
