using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; set => instance = value; }
    public Game currentGame;

    public bool power;
    public GameObject player;

    [Header("Level")]
    public GameObject[] level;

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
        StartGame();
    }

    public void SwitshPower(bool value) => power = value;


    public void StartGame()
    {
        for (int i = 0; i < currentGame.remainingLife; i++)
        {
            Instantiate(currentGame.lifes, currentGame.positionIntantiate);
        }
        uiRefresh.Invoke();
        Refresh.Invoke();
        Debug.Log("Refreched :)");
    }
}
