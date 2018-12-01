using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sacrifice : Choice {
	public GameObject modalWindow;
	public GameObject sacrificePanel;
	public Button sacrificeFoodButton;

	private void Awake()
	{
		sacrificeFoodButton.onClick.AddListener(SacrificeFood);
	}

	public override void Resolve(bool selected)
	{
		if (selected)
		{
			if (!resolved)
			{
				ShowModalWindow(true);
			}
		}
		else
		{
			//The Gods are angered.
			resolved = true;
		}
	}

	public void SacrificeFood()
	{
		Game.instance.Food -= 1;
		SetResolved();
	}

	private void SetResolved()
	{
		resolved = true;
		ShowModalWindow(false);
	}

	private void ShowModalWindow(bool show)
	{
		modalWindow.gameObject.SetActive(show);
		sacrificePanel.gameObject.SetActive(show);
		if (show)
		{
			sacrificeFoodButton.interactable = Game.instance.Food > 0;
		}
	}
}
