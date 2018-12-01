using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Choice {

	public override void Resolve(bool selected)
	{
		base.Resolve(selected);
		Game.instance.Food += 1;
	}
}
