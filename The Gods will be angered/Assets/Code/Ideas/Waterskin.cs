using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterskin : Choice {

	public Knife knife;

	public int _water;
	public int Water
	{
		get { return _water; }
		set { _water = value; if (_water > 3) _water = 3;  upgradeText.text = title + " ("+_water+")"; }
	}

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			AddUpgrade();
		}
		return base.Resolve(selected);
	}

	public override bool IsAvailable()
	{
		return base.IsAvailable() && !knife.available;
	}

	public override string GetDescription()
	{
		return "Make a Waterskin out of discarded hides using your Knife.";
	}
}
