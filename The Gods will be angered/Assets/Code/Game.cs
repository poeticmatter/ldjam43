using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public enum GameState {Menu, Setup, Input, Resolution, GameOver};
	public GameState currnetState;

	public static Game instance;
	public int turn;

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
		set { _health = value; SetText(healthText, value); if (_health <= 0) { currnetState = GameState.GameOver; }; }
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

	public int _dailyFoodCost;
	public Text dailyFoodCostText;
	public int DailyFoodCost
	{
		get { return _dailyFoodCost; }
		set { _dailyFoodCost = value; SetText(dailyFoodCostText, value); }
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
		SetText(dailyFoodCostText, DailyFoodCost);
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
		Choices.instance.GenerateChoices(Actions + 2, turn);
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
			allResolved = true;
			for (int i = 0; i < actions.Count; i++)
			{
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

			if (Health > 0)
			{
				while (Health < DailyFoodCost)
				{
					DailyFoodCost--;
					Actions--;
				}
				Choices.instance.badChance += 1;
				turn++;
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
	public Text gameOverText;
	public Button restartButton;

	private void GameOver()
	{
		modalWindow.SetActive(true);
		gameOverPanel.SetActive(true);
		gameOverText.text = "You survived " + turn + " turns.";
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
	}
	
}
