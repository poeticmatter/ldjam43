using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour{

	public string title;
	public bool resolved = false;

	public virtual void Resolve()
	{
		resolved = true;
	}

}
