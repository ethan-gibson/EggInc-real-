using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	[SerializeField] private float eggValue = 1.25f;
	[SerializeField] TextMeshProUGUI moniesAmount;
	private float monies;

	private int chickenCount;
	private float cashModifier = 1;
	void Start()
	{
		if (Instance != this && Instance != null)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
        StartCoroutine(updateCashAmount());
    }

    public void AddToChickenCount()
	{
		chickenCount++;
	}
	private IEnumerator updateCashAmount()
	{
		monies += chickenCount * eggValue * cashModifier;
		Debug.Log(monies);
		moniesAmount.text = monies.ToString();
		yield return new WaitForSeconds(1);
		StartCoroutine(updateCashAmount());
	}
}
