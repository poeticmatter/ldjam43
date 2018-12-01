using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public enum GameState {Menu, Setup, Input, Resolution};
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
		set { _food = value; SetText(foodText, value); }
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
	}

	private void Setup()
	{
		Choices.instance.GenerateChoices(Actions + 1);
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
		List<Choice> actions = Choices.instance.GetSelectedChoices();
		bool allResolved = true;
		for (int i = 0; i < actions.Count; i++)
		{
			actions[i].Resolve();
			if (!actions[i].resolved)
			{
				allResolved = false;
				break;
			}
		}
		if (allResolved)
		{
			Debug.Log("Resolution -> Setup");
			currnetState = GameState.Setup;
		}

	}

	private void SetText(Text text, int value)
	{
		text.text = value.ToString();
	}
	
}
