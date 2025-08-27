
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get => instance; set => instance = value; }

    public CurrentGame currentGame;

    [Header("Life")]
    public GameObject lifes;
    public Transform positionIntantiate;

    public bool power;
    public int currentLevel;
    public GameObject player;

    [Header("Level")]
    public GameObject[] level;

    public List<TrackController> tracks;

    [Header("Respawn")]
    public Vector3 respawnPosition;

    public LevelStat _activeLevel;

    [Header("Event")]
    public UnityEvent uiRefresh;
    public UnityEvent Refresh;
    public UnityEvent newRecord;
    public UnityEvent noRcord;
    public UnityEvent finishLevel;
	public UnityEvent onCoinCollected;
    public UnityEvent onKeyCollectedDel;
	

	public bool stopMove = false;
    public bool night = false;
    public bool day = true;


    public bool inLevel
    {
        get
        {
            return _activeLevel != null;
        }
    }


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Start()
    {

        Refresh.Invoke();
        respawnPosition = player.transform.position;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }



    public void PauseUnpause()
    {
        //On arrete la pause
        if (UIManager.instance.pauseScreen.activeInHierarchy)
        {
            UIManager.instance.pauseScreen.SetActive(false);
            Time.timeScale = 1f;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //on demarre la pause
            UIManager.instance.pauseScreen.SetActive(true);
            UIManager.instance.CloseOptions();
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


    public void SwitshPower(bool value) => power = value;



}
