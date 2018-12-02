using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tribe : Choice {

	public Spear spear;
	public Art art;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			if (!art.available)
			{
				//nothing
			}
			else if (spear.available && Random.value < 0.2f)
			{
				Game.instance.Health--;
			}
			else if (Random.value < 0.5f)
			{
				Game.instance.Clay -= Random.Range(1, 5);
				if (Game.instance.Clay <= 0)
				{
					Game.instance.Clay = 0;
				}
			}

		}
		else
		{
			Game.instance.Clay -= Random.Range(1, 5);
			if (Game.instance.Clay <= 0)
			{
				Game.instance.Clay = 0;
			}
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && Game.instance.Clay > 0;
	}

	public override string GetDescription()
	{
		if (!art.available)
		{
			return "Show them your Idol is the same as theirs (chosen) or let them ransack your camp (lose 1-4 clay)";
		}
		if (!spear.available)
		{
			return "Fight off the tribe with your Spear (20% chance of -1 Health if chosen), or let them ransack your camp (lose 1-4 clay).";
		}
		return "Beg for mercy (%50 chance to lose 1-4 clay), or let them ransack your camp (lose 1-4 clay).";
	}
}
