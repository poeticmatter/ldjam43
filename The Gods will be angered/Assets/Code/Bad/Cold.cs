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
		if (!shelter.available)
		{
			if (Game.instance.Wood > 0)
			{
				return "Freezing night.\nBuild a fire and stay in your shelter (-1 Wood for fire) or brave the weather (%50 chance of -1 health).";
			}
			return "Freezing night.\nStay in your shelter (%25 chance of -1 Health) or brave the weather (%50 chance of -1 health).";
		}
		if (Game.instance.Wood > 0)
		{
			return "Freezing night.\nFind a Cave and build a fire (-1 Wood for fire. 10% chance of -1 Health) or brave the weather (%50 chance of -1 health).";
		}
		return "Freezing night.\nFind a cave to hide in (%40 chance of -1 Health) or brave the weather (%50 chance of -1 health).";
	}

}