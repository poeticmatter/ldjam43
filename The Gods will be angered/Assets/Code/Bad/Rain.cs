using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : Choice {

	public override bool Resolve(bool selected)
	{
		bool hasShelter = false;
		Debug.Log("resolving Rain");
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
			Debug.Log("No shelter");
			Game.instance.Health--;
		}
		return base.Resolve(selected);
	}

}
