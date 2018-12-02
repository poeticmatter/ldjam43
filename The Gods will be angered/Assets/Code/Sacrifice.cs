using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sacrifice : Choice {
	public GameObject modalWindow;
	public GameObject sacrificePanel;
	public Button sacrificeFoodButton;
	public Button sacrificeHealthButton;
	public Button sacrificeArtButton;

	public Art art;
	
	private void Awake()
	{
		sacrificeFoodButton.onClick.AddListener(SacrificeFood);
	}

	public override bool Resolve(bool selected)
	{
		if (selected && !IsResolved())
		{
			ShowModalWindow(true);
			return false;
		}
		else
		{
			//The Gods are angered.
			return base.Resolve(selected);
		}
	}

	public void SacrificeFood()
	{
		Game.instance.Food -= 2;
		SetResolved();
	}

	public void SacrificeHealth()
	{
		Game.instance.Health -= 1;
		SetResolved();
	}

	public void SacrificeArt()
	{
		art.LoseUpgrade();
		SetResolved();
	}

	private void SetResolved()
	{
		ShowModalWindow(false);
		base.Resolve(true);
	}

	private void ShowModalWindow(bool show)
	{
		modalWindow.gameObject.SetActive(show);
		sacrificePanel.gameObject.SetActive(show);
		if (show)
		{
			sacrificeFoodButton.interactable = Game.instance.Food >= 2;
			sacrificeArtButton.interactable = !art.available;
		}
	}

	public override string GetDescription()
	{
		return "Or the Gods will be angered.";
	}
}
