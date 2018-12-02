using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillWater : Choice {
	public Waterskin waterskin;
	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			waterskin.Water = 3;
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && !waterskin.available && waterskin.Water < 3;
	}

	public override string GetDescription()
	{
		return "Refill your waterskin.";
	}
}
