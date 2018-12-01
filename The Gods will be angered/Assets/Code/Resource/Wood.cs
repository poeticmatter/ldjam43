using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Choice {

	public override void Resolve(bool selected)
	{
		base.Resolve(selected);
		Game.instance.Wood += 1;
	}
}
