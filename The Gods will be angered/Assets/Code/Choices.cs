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
			Sacrifice.resolved = false;
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
			}
			else
			{
				scoped.gameObject.SetActive(false);
				scoped.onValueChanged.RemoveAllListeners();
			}
		}
	}

	private void CreateAvailableChoices(int count)
	{
		int chanceTotal = resourceChance + badChance + opportunityChance + ideaChance;
		for (int i = 0; i < count; i++)
		{
			int random = Random.Range(1, chanceTotal);
			if (random <= resourceChance)
			{
				availableChoices.Add(GetChoice(resourceActions));
			}
			else if (random <= resourceChance + badChance)
			{
				availableChoices.Add(GetChoice(badEvents));
			}
			else if (random <= resourceChance + badChance + opportunityChance)
			{
				availableChoices.Add(GetChoice(opportunities));
			}
			else if (random <= resourceChance + badChance + opportunityChance + ideaChance)
			{
				availableChoices.Add(CreateIdea());
			}
		}
	}


	public Choice[] resourceActions;
	public Choice[] badEvents;
	public Choice[] opportunities;

	private Choice GetChoice(Choice [] fromChoices)
	{
		Choice ret = fromChoices[Random.Range(0, fromChoices.Length)];
		ret.resolved = false;
		return ret;
	}


	public Choice[] ideaPrefabs;

	private Choice CreateIdea()
	{
		return null;
	}

	public List<Toggle> toggleQueue;

	public void ToggleValueChanged(Toggle change)
	{
		Debug.Log(change + " " + change.isOn);
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
