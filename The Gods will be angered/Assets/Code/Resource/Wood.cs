using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Choice {

	public override bool Resolve(bool selected)
	{
		if (selected)
		{
			Game.instance.Wood += 1;
		}
		return base.Resolve(selected);
	}
}
