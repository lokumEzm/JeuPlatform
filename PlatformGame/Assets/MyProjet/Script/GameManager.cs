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
    public GameObject player;

    [Header("Level")]
    public GameObject[] level;

    [Header("Respawn")]
    public Vector3 respawnPosition;



    [Header("Event")]
    public UnityEvent uiRefresh;
    public UnityEvent Refresh;


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
    }

    public void SwitshPower(bool value) => power = value;


   
}
