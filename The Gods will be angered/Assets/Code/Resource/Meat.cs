using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Choice {

	public override void Resolve()
	{
		base.Resolve();
		Game.instance.Food += 1;
	}
}
