using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour{

	public string title;
	public string description;
	public int resolved = 1;
	public int priority; //0 Resources, 1 oportunity, 2 Ideas, 3 Bad
	public int showChance;
	public virtual bool Resolve(bool selected)
	{
		resolved--;
		if (resolved < 0)
		{
			Debug.LogError("Resoved should not go below 0.");
			resolved = 0;
		}
		return true;
	}

	public virtual bool isAvailable()
	{
		return true;
	}

	public bool IsResolved()
	{
		return resolved <= 0;
	}

}
