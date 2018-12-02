using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : Choice {

	public override bool Resolve(bool selected)
	{
		bool hasShelter = false;
		if (selected)
		{
			//Nothing, hide from rain.
		}
		else if (hasShelter) 
		{
			Game.instance.Wood--; //For repairs
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
		return "Hide from the rain or brave the weather (50% chance of -1 Health)";
	}

}
