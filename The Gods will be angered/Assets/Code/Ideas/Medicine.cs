using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : Choice {

	public Knife knife;

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
		return "You spot a plant you can harvest for medicine.";
	}
}
