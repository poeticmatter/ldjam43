﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sacrifice : Choice {
	public GameObject modalWindow;
	public GameObject sacrificePanel;
	public Button sacrificeFoodButton;
	public Button sacrificeHealthButton;
	public Button sacrificeArtButton;

	public AudioSource[] godsAngeredSound;

	public Art art;
	public GodsWillBeAngered gods;
	
	private void Awake()
	{
		sacrificeFoodButton.onClick.AddListener(SacrificeFood);
		sacrificeHealthButton.onClick.AddListener(SacrificeHealth);
		sacrificeArtButton.onClick.AddListener(SacrificeArt);
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
			PlayGodsAngered();
			gods.ShowGodsMessage();
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

	public void PlayGodsAngered()
	{
		if (godsAngeredSound != null && godsAngeredSound.Length > 0)
		{
			godsAngeredSound[Random.Range(0, godsAngeredSound.Length)].Play();
		}
	}
}
