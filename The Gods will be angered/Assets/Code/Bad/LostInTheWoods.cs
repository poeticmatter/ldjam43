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
			showChance -= 3;
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
		return "You're lost in the woods.\n\nChosen: Spend the day looking for your camp and learn the area better to not repeat the mistake (Less chance to get lost again).\n\nNot Chosen: Set up a new camp. (lose your shelter)";
	}
}