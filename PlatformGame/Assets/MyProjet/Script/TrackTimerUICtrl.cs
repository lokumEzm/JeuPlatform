using System.Collections;
using TMPro;
using UnityEngine;

public class TrackTimerUICtrl : MonoBehaviour
{
	public static TrackTimerUICtrl instance;

	[SerializeField]
	TextMeshProUGUI timerText;

	[SerializeField] Transform UiParent;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		UiParent.gameObject.SetActive(false);
	}

	public TimerInfo StartTimer(float duration)
	{
		TimerInfo infos  = new TimerInfo(duration);
		StartCoroutine(ChronoCorout(infos));
		return infos;

	}

	IEnumerator ChronoCorout(TimerInfo infos)
	{
		UiParent.gameObject.SetActive(true);

		timerText.color = Color.white;

		while (infos.remainingTime > 0)
		{
			if (infos.remainingTime > 0)
			{
				infos.remainingTime -= Time.deltaTime;
			}
			else if (infos.remainingTime < 0)
			{
				infos.remainingTime = 0;
				timerText.color = Color.red;
			}

			int minutes = Mathf.FloorToInt(infos.remainingTime / 60);
			int seconds = Mathf.FloorToInt(infos.remainingTime % 60);
			timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

			yield return null;
		}

		UiParent.gameObject.SetActive(false);
	}

	public void StopTimer()
	{
		StopAllCoroutines();
		UiParent.gameObject.SetActive(false);

	}

	public class TimerInfo
	{
		public TimerInfo(float startDuration)
		{
			duration = startDuration;
			remainingTime = duration;
		}

		public float duration;
		public float remainingTime;

		public float elapsedTime
		{
			get { return duration - remainingTime; }
		}
	}
}
