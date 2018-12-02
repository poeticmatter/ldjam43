using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Axe : Choice {

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			Game.instance.Wood -= 2;
			available = false;
			Text upgradeText = AddUpgradeText();
			upgradeText.text = title;
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && Game.instance.Wood >= 2;
	}

	public override string GetDescription()
	{
		return "Build an Axe (+1 wood when gathering).\nCost: 2 wood.";
	}
}
