using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Choice {

	public override void Resolve()
	{
		base.Resolve();
		Game.instance.Wood += 1;
	}
}
