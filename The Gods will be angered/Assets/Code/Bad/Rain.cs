using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : Choice {

	public override void Resolve(bool selected)
	{
		base.Resolve(selected);
		bool hasShelter = false;
		if (selected)
		{
			//Nothing, hide from rain.
		}
		else if (hasShelter) 
		{
			Game.instance.Wood--; //For repairs
		}
		else
		{
			Game.instance.Health--;
		}
	}

}
