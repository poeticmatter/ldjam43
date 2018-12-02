using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostInTheWoods : Choice
{

	public Shelter shelter;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			//nothing

		}
		else
		{
			shelter.LoseUpgrade();
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && !shelter.available;
	}

	public override string GetDescription()
	{
		return "You're lost, set up a new camp (not chosen, lose your shelter) or look for your camp (chosen)";
	}
}