using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease : Choice {

	public Medicine medicine;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			//nothing

		}
		else if (!medicine.available)
		{
			if (Random.value <0.5f)
			{
				Game.instance.Health--;
			}
		}
		else
		{
			Game.instance.Health--;
			Game.instance.Health--;
		}
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		if (!medicine.available)
		{
			return "You're sick, but the medicine helps.\n\nChosen: Rest, or risk making it worse. \n\n Not Chosen: You go about your day, hoping the medicine is enough. (%50 chance lose 1 health).";
		}
		return "You're sick, you must rest.\n\nChosen: Rest. \n\nNot Chosen: You do your best to work (or lose 2 health).";
	}
}
