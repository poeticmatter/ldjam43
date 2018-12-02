using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour {
	public bool addSacrifice;
	public int resourceChance = 50;
	public int badChance = 0;
	public int opportunityChance = 0;
	public int ideaChance = 0;

	public Choice Sacrifice;

	public List<Choice> availableChoices;
	public Toggle[] toggles;

	public static Choices instance;

	private void Awake()
	{
		if (instance!=null)
		{
			Debug.LogError("Choices already exists");
		}
		instance = this;
		for (int i = 0; i < toggles.Length; i++)
		{
			Toggle scoped = toggles[i];
			scoped.onValueChanged.AddListener(delegate {
				ToggleValueChanged(scoped);
			});
		}
	}

	public void GenerateChoices(int count)
	{
		availableChoices.Clear();
		if (addSacrifice)
		{
			availableChoices.Add(Sacrifice);
			Sacrifice.resolved++;
		}
		CreateAvailableChoices(count - availableChoices.Count);
		AttachChoicesToUI();
		
	}

	private void AttachChoicesToUI()
	{
		for (int i = 0; i < toggles.Length; i++)
		{
			Toggle scoped = toggles[i];
			if (i < availableChoices.Count)
			{
				scoped.gameObject.SetActive(true);
				scoped.isOn = false;
				scoped.GetComponentInChildren<Text>().text = availableChoices[i].title;
				scoped.GetComponent<Description>().description = availableChoices[i].GetDescription();
			}
			else
			{
				scoped.gameObject.SetActive(false);
			}
		}
	}

	private void CreateAvailableChoices(int count)
	{
		int chanceTotal = badChance + opportunityChance + ideaChance + resourceChance;
		badEventCreated = opportunityCreated = ideaCreated = false;
		for (int i = 0; i < count; i++)
		{
			int random = Random.Range(1, chanceTotal);
			if (random <= badChance && !badEventCreated)
			{
				availableChoices.Add(GetChoice(badEvents));
				badEventCreated = true;
			}
			else if (random <= badChance + opportunityChance && !opportunityCreated)
			{
				availableChoices.Add(GetChoice(opportunities));
				opportunityCreated = true;
			}
			else if (random <= badChance + opportunityChance + ideaChance && !ideaCreated)
			{
				availableChoices.Add(GetChoice(ideas));
				ideaCreated = true;
			}
			else
			{
				availableChoices.Add(GetChoice(resourceActions));
			}
		}
	}


	public Choice[] resourceActions;
	public Choice[] badEvents;
	public Choice[] opportunities;
	public Choice[] ideas;
	private bool badEventCreated = false;
	private bool opportunityCreated = false;
	private bool ideaCreated = false;

	private Choice GetChoice(Choice [] fromChoices)
	{
		int chanceTotal = 0;
		for (int i = 0; i < fromChoices.Length; i++)
		{
			if (fromChoices[i].isAvailable())
			{
				chanceTotal += fromChoices[i].showChance;
			}
		}
		if (chanceTotal <=0)
		{
			Debug.Log("Falling back to resources");
			return GetChoice(resourceActions);
		}
		int randomSelect = Random.Range(0, chanceTotal);
		int selectIncrement = 0;
		for (int i = 0; i < fromChoices.Length; i++)
		{
			if (fromChoices[i].isAvailable())
			{
				selectIncrement += fromChoices[i].showChance;
				if (randomSelect < selectIncrement)
				{
					fromChoices[i].resolved++;
					return fromChoices[i];
				}
			}
		}
		Debug.LogError("Could not create choice, this should not happen.");
		return null;
	}


	public List<Toggle> toggleQueue;

	public void ToggleValueChanged(Toggle change)
	{
		if (change.isOn)
		{
			toggleQueue.Add(change);
		}
		else
		{
			toggleQueue.Remove(change);
		}
		if (toggleQueue.Count > Game.instance.Actions)
		{
			toggleQueue[0].isOn = false; //Triggers this method and will be removed by it.
		}
	}

	public bool IsChoiceSelected(int choiceIndex)
	{
		return toggles[choiceIndex].isOn;
	}

}
