using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FinishLevel : MonoBehaviour
{
	public static FinishLevel Instance;
	public TextMeshProUGUI coinsValue;
	public TextMeshProUGUI keyValue;
	public TextMeshProUGUI timerValue;
	public Transform UiParent;

	System.Action callback;


	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		UiParent.gameObject.SetActive(false);

	}
	public void DisplayStats(LevelStat levelStat, System.Action callback)
	{
		this.callback = callback;	
		UiParent.gameObject.SetActive(true);
		coinsValue.text = levelStat.collectedCoinsCount.ToString();
		keyValue.text = GameManager.Instance.currentGame.currentKey.ToString();


		int minutes = Mathf.FloorToInt(levelStat.playerTime / 60);
		int seconds = Mathf.FloorToInt(levelStat.playerTime % 60);
		timerValue.text = string.Format("{0:00} : {1:00}", minutes, seconds);

	}



	public void ContinueButton()
	{
		callback();
		//   if (Input.GetKeyDown(KeyCode.Space))
		Time.timeScale = 1f;
		GameManager.Instance.stopMove = false;
		//player.transform.position = GameManager.Instance.currentGame.spawnZone.transform.position;
		GameManager.Instance.Refresh.Invoke();
		UiParent.gameObject.SetActive(false);



	}
}
