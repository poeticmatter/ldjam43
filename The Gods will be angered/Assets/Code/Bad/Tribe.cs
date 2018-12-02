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
			return "A neighboring tribe has learned of your clay.\n\nChosen: Show them your Idol, your Gods are their Gods.\n\nNot Chosen: Let them ransack your camp (lose 1-4 clay)";
		}
		if (!spear.available)
		{
			return "A neighboring tribe has learned of your clay.\n\nChosen: Fight off the tribe with your Spear (20% chance of -1 health).\n\nNot Chosen: Let them ransack your camp (lose 1-4 clay)";
		}
		return "A neighboring tribe has learned of your clay.\n\nChosen: Beg for mercy (%50 chance to lose 1-4 clay).\n\nNot Chosen: Let them ransack your camp (lose 1-4 clay)";
	}
}
