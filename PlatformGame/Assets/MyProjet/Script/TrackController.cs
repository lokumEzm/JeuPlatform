using System.Collections;
using System.Threading;
using UnityEngine;

public class TrackController : MonoBehaviour
{
	public GameObject cam;
	public Transform directionCamera;
	public GameObject player
	{
		get
		{
			return GameManager.Instance.player;
		}
	}
	public Vector3 cameraOffset;
	public PlayerController2DNew playerController2D
	{
		get
		{
			return player.GetComponent<PlayerController2DNew>();

		}
	}


	public Transform trackStart;
	public Transform respawnPoint;
	public FlagController flag;
	LevelSelector levelSelector;
	public LevelData levelData
	{
		get
		{
			return levelSelector.levelData;
		}
	}
	[SerializeField] DoorController doorController;

	public TrackTimerUICtrl.TimerInfo timerInfo;

	public bool playerAssigned = false;

	private void OnEnable()
	{
		GameManager.Instance.tracks.Add(this);
	}

	void Start()
	{
		levelSelector = GetComponent<LevelSelector>();
		cam.SetActive(false);
		flag.Init(this);
		GameManager.Instance.onKeyCollectedDel.AddListener(CheckIfOpen);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameManager.Instance._activeLevel = levelSelector.levelStat;
			MusicManager.Instance.PlayMusic("PlayMusic");

			if (!playerAssigned) AssignPlayer(true);
			trackStart.gameObject.SetActive(true);

		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameManager.Instance._activeLevel = null;

			MusicManager.Instance.PlayMusic("MapMusic");
			if (playerAssigned) AssignPlayer(false);
			trackStart.gameObject.SetActive(false);

			TrackTimerUICtrl.instance.StopTimer();
		}

	}
	void AssignPlayer(bool value)
	{
		Debug.Log("Assign player" + value);
		playerAssigned = value;

		playerController2D.moveDirectionContraints = directionCamera.right;


		player.GetComponent<PlayerController3D>().enabled = !value;
		player.GetComponent<PlayerController2DNew>().enabled = value;

		cam.SetActive(value);

		timerInfo = TrackTimerUICtrl.instance.StartTimer(levelSelector.levelData.levelTime);

		//if (!value) player.GetComponent<PlayerController3D>().SetPos(respawnPoint.position);
	}

	public void QuitLvl()
	{
		Debug.Log("SpawnPlayer");
	
		StartCoroutine(QuitLvlCorout());
	}
	IEnumerator QuitLvlCorout()
	{
		player.gameObject.SetActive(false);
		AssignPlayer(false);
		yield return null;
		player.transform.position = GameManager.Instance.currentGame.spawnZone.transform.position;
		yield return null;
		player.gameObject.SetActive(true);

	}

	public void LateUpdate()
	{
		cam.transform.position = player.transform.position + cameraOffset;

	}


	public void CheckIfOpen()
	{
		if (GameManager.Instance.currentGame.currentKey < levelSelector.levelStat.refLevelData.levelKey) return;
		doorController.OpenDoor(true);

	}

	public void OnTrackFinished()
	{
		levelSelector.levelStat.levelSatus = LevelSatus.Complete;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		GameManager.Instance.stopMove = true;

		FinishLevel.Instance.DisplayStats(levelSelector.levelStat, QuitLvl);
	}


}
