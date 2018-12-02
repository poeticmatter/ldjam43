using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Art : Choice {

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			Game.instance.Clay--;
			AddUpgrade();
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && Game.instance.Clay > 0;
	}

	public override string GetDescription()
	{
		return "An idol in the Gods' image will surely sooth their anger.";
	}
}
