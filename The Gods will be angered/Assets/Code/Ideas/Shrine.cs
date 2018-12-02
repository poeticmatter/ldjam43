using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : Choice {

	public Sacrifice sacrifice;

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			AddUpgrade();
			sacrifice.showChance -= sacrifice.showChance/2;
			Game.instance.Clay -= 10;
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && Game.instance.Clay >= 10;
	}

	public override string GetDescription()
	{
		return "Build a shrine for the Gods. This will please them (Less sacrifices required).";
	}
}
