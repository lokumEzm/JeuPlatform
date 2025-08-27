using UnityEngine;

public class FlagController : MonoBehaviour, ICollectable
{
	LevelData levelData
	{
		get
		{
			return refTrack.levelData;
		}
	}
	TrackController refTrack;
	public int flagValue = 1;

	public GameObject cameraPos;

	public void Init(TrackController refTrack)
	{
		this.refTrack = refTrack;
	}
	public void OnCollect()
	{
		LevelStat levelStats = GameManager.Instance.currentGame.GetLevelStat(levelData.level);


		GameManager.Instance.stopMove = true;
		LevelStat levelStat = GameManager.Instance.currentGame.GetLevelStat(levelData.level);
		float newTime = refTrack.timerInfo.elapsedTime;


		if (newTime < levelStat.playerTime)
		{
			levelStat.playerTime = newTime;
			GameManager.Instance.stopMove = true;
			GameManager.Instance.newRecord.Invoke();
			Debug.Log("New Record !!!");
		}
		else
		{
			GameManager.Instance.stopMove = true;
			GameManager.Instance.noRcord.Invoke();
			Debug.Log("Pas de Record");
		}
		SoundManager.Instance.PlaySound3D("Flag", cameraPos.transform.position);
		GameManager.Instance.currentGame.flagCount++;
		GameManager.Instance.Refresh.Invoke();
		refTrack.OnTrackFinished();
		Destroy(gameObject);
	}
}
