using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour{

	public string title;
	public int resolved = 0;
	public int priority; //0 Resources, 1 oportunity, 2 Ideas, 3 Bad
	public int showChance;
	public bool available;
	public bool limited;
	public RectTransform upgradesPanel;
	public Text upgradeTextPrefab;

	public Text upgradeText = null;

	public AudioSource [] onShowSound;

	public Color _color = Color.white;
	public virtual bool Resolve(bool selected)
	{
		resolved--;
		if (resolved < 0)
		{
			Debug.LogError("Resoved should not go below 0.");
			resolved = 0;
		}
		return true;
	}

	public virtual bool IsAvailable()
	{
		return available;
	}

	public bool IsResolved()
	{
		return resolved <= 0;
	}

	public virtual string GetDescription()
	{
		return "";
	}

	public void AddUpgrade ()
	{
		upgradeText = Instantiate<Text>(upgradeTextPrefab, Vector2.zero, Quaternion.identity);
		upgradeText.transform.SetParent(upgradesPanel);
		available = false;
		upgradeText.text = title;
	}

	public void LoseUpgrade()
	{
		available = true;
		if (upgradeText != null)
		{
			Destroy(upgradeText.gameObject);
			upgradeText = null;
		}
	}

	public void PlayOnShowSound()
	{
		if (onShowSound != null && onShowSound.Length > 0)
		{
			onShowSound[Random.Range(0,onShowSound.Length)].Play();
		}
	}
}
