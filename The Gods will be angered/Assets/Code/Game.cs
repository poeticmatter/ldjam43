﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public enum GameState {Menu, Setup, Input, Resolution, GameOver};
	public GameState currnetState;

	public static Game instance;

	// Resources
	public int _wood;
	public Text woodText;
	public int Wood
	{
		get { return _wood; }
		set { _wood = value; SetText(woodText, value); }
	}

	public int _health;
	public Text healthText;
	public int Health
	{
		get { return _health; }
		set { _health = value; SetText(healthText, value); }
	}

	public int _food;
	public Text foodText;
	public int Food
	{
		get { return _food; }
		set { _food = value; SetText(foodText, value); Debug.Log("foodchange"); }
	}

	public int _clay;
	public Text clayText;
	public int Clay
	{
		get { return _clay; }
		set { _clay = value; SetText(clayText, value); }
	}

	public int _actions;
	public Text actionsText;
	public int Actions
	{
		get { return _actions; }
		set { _actions = value; SetText(actionsText, value); ; }
	}

	public int _dailyFoodCost;
	public Text dailyFoodCostText;
	public int DailyFoodCost
	{
		get { return _dailyFoodCost; }
		set { _dailyFoodCost = value; SetText(dailyFoodCostText, value); ; }
	}

	void Awake () {
		if (instance!=null)
		{
			Debug.LogError("Game already exists");
		}
		instance = this;
		currnetState = GameState.Setup;
		SetText(woodText, Wood);
		SetText(foodText, Food);
		SetText(clayText, Clay);
		SetText(actionsText, Actions);
		SetText(healthText, Health);
		restartButton.onClick.AddListener(Restart);
	}

	void Update ()
	{
		if (currnetState == GameState.Menu)
		{

		}
		else if (currnetState == GameState.Setup)
		{
			Setup();
		}
		else if (currnetState == GameState.Input)
		{
			//Display instructions/story
		}
		else if (currnetState == GameState.Resolution)
		{
			Resolution();
		}
		else if (currnetState == GameState.GameOver)
		{
			GameOver();
		}
	}

	private void Setup()
	{
		Choices.instance.GenerateChoices(Actions + 3);
		Debug.Log("Setup -> Input");
		currnetState = GameState.Input;
	}

	public void NextTurn()
	{
		if (currnetState == GameState.Input)
		{
			Debug.Log("Input -> Resolution");
			currnetState = GameState.Resolution;
		}
	}

	private void Resolution()
	{
		List<Choice> actions = Choices.instance.availableChoices;
		bool allResolved = false;
		int currentPriority = 0;
		while (!allResolved && currentPriority < 4)
		{
			Debug.Log(currentPriority);
			allResolved = true;
			for (int i = 0; i < actions.Count; i++)
			{
				Debug.Log(actions[i].name +" " + actions[i].priority);
				if (actions[i].priority > currentPriority)
				{
					allResolved = false;
					continue;
				}
				if (!actions[i].IsResolved())
				{
					if (!actions[i].Resolve(Choices.instance.IsChoiceSelected(i)))
					{
						allResolved = false;
					}
				}
			}
			currentPriority++;
		}
		if (allResolved)
		{
			Food -= DailyFoodCost;
			if (Food < 0)
			{
				Health += Food;
				Food = 0;
			}

			if (Health <= 0)
			{
				Debug.Log("Resolution -> GameOver");
				currnetState = GameState.GameOver;
			}
			else
			{
				while (Health < DailyFoodCost)
				{
					DailyFoodCost--;
					Actions--;
				}
				Choices.instance.badChance += 2;
				Choices.instance.opportunityChance += 1;
				Choices.instance.ideaChance += 2;
				Choices.instance.resourceChance += 1;
				Debug.Log("Resolution -> Setup");
				currnetState = GameState.Setup;
			}
		}

	}

	private void SetText(Text text, int value)
	{
		text.text = value.ToString();
	}


	public GameObject modalWindow;
	public GameObject gameOverPanel;
	public Button restartButton;

	private void GameOver()
	{
		modalWindow.SetActive(true);
		gameOverPanel.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
	}
	
}
