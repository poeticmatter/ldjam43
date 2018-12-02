using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Choice {

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			AddUpgrade();
		}
		return base.Resolve(selected);
	}

	public override string GetDescription()
	{
		return "Fashion a knife out of stone, a very useful tool.";
	}
}
