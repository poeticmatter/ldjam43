using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clay : Choice
{

	public Waterskin waterskin;
	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			waterskin.Water--;
			Game.instance.Clay++;
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && !waterskin.available && waterskin.Water > 0;
	}

	public override string GetDescription()
	{
		return "Make clay using water from your Watersking (+1 Clay. -1 Water.)";
	}
}