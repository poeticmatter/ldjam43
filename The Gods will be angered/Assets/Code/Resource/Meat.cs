using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Choice {

	public override bool Resolve(bool selected)
	{
		if (selected)
		{	
			Game.instance.Food += 2;
			if (Random.value <0.25f)
			{
				Game.instance.Health--;
			}
		}
		return base.Resolve(selected);
	}
}
