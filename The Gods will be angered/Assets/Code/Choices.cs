using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour {
	public int goodChance = 50;
	public int badChance = 0;

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

	public void GenerateChoices(int count, int turn)
	{
		availableChoices.Clear();

		bad.AddRange(chosenBad);
		chosenBad.Clear();
		good.AddRange(chosenGood);
		chosenGood.Clear();

		int badCount = (int) Mathf.Log(turn);
		CreateAvailableChoices(badCount, bad, chosenBad);
		CreateAvailableChoices(count - badCount, good, chosenGood);
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

	private void CreateAvailableChoices(int count, List<Choice> fromChoices, List<Choice> chosen)
	{
		for (int i = 0; i < count; i++)
		{
			availableChoices.Add(GetChoice(fromChoices, chosen));
		}
	}


	public List<Choice> good;
	public List<Choice> bad;
	public List<Choice> chosenGood;
	public List<Choice> chosenBad;

	private Choice GetChoice(List<Choice> fromChoices, List<Choice> chosen)
	{
		int chanceTotal = 0;
		for (int i = 0; i < fromChoices.Count; i++)
		{
			if (fromChoices[i].IsAvailable())
			{
				chanceTotal += fromChoices[i].showChance;
			}
		}
		if (chanceTotal <=0)
		{
			Debug.Log("Falling back to good");
			return GetChoice(good, chosenGood);
		}
		int randomSelect = Random.Range(0, chanceTotal);
		int selectIncrement = 0;
		for (int i = 0; i < fromChoices.Count; i++)
		{
			Choice temp = fromChoices[i];
			if (temp.IsAvailable())
			{
				selectIncrement += temp.showChance;
				if (randomSelect < selectIncrement)
				{
					temp.resolved++;
					if (temp.limited)
					{
						chosen.Add(temp);
						fromChoices.RemoveAt(i);
					}
					return temp;
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
