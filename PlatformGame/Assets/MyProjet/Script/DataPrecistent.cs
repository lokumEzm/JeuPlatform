using UnityEngine;

public class DataPrecistentManager : MonoBehaviour
{
    public static DataPrecistentManager instance;

    

    [Header("-- CurrentGame --")]

    public int Key;
    public string LevelName;
    public int currentLevel;
    public int flag;
    public float timer;
    public int coins;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        MusicManager.Instance.PlayMusic("MapMusic");
    }
}
