using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour{

	public string title;
	public bool resolved = false;
	public int priority; //0 Resources, 1 oportunity, 2 Ideas, 3 Bad

	public virtual void Resolve(bool selected)
	{
		resolved = true;
	}

}
