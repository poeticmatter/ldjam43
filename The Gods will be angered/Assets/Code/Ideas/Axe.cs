using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Choice {

	public override bool Resolve(bool selected)
	{
		return base.Resolve(selected);
	}

	public override bool isAvailable()
	{
		return false;
	}
}
