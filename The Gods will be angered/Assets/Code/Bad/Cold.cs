using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : Choice
{
	public Shelter shelter;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			if (!shelter.available)
			{
				if (Game.instance.Wood > 0)
				{
					Game.instance.Wood--;
				}
				else if(Random.value < 0.25f)
				{
					Game.instance.Health--;
				}
			}
			else
			{
				if (Game.instance.Wood > 0)
				{
					Game.instance.Wood--;
					if (Random.value < 0.10f)
					{
						Game.instance.Health--;
					}
				}
				else if (Random.value < 0.40f)
				{
					Game.instance.Health--;
				}
			}
		}
		else
		{
			if (Random.value < 0.5f)
			{
				Game.instance.Food--;
			}
		}
	
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		string notChosen = "\n\nNot chosen: brave the weather (%50 chance of -1 health).";
		if (!shelter.available)
		{
			if (Game.instance.Wood > 0)
			{
				return "Freezing night.\n\nChosen: Build a fire and stay in your shelter (-1 Wood for fire)." + notChosen;
			}
			return "Freezing night.\n\nChosen: Stay in your shelter (%25 chance of -1 Health)." + notChosen;
		}
		if (Game.instance.Wood > 0)
		{
			return "Freezing night.\n\nChosen: Find a Cave and build a fire (-1 Wood for fire. 10% chance of -1 Health)." + notChosen;
		}
		return "Freezing night.\n\nChosen: Find a cave to hide in (%40 chance of -1 Health)." + notChosen;
	}

}