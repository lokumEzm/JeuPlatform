using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public LevelData levelData;

    public GameObject StartLevelActivatorBc;
    public GameObject levelLoaderBc;
    public bool levelLoader;
    public GameObject door;

    public Material materialOpenLevel;
    public Material materialFinishLevel;
    public Camera cameraLevelSelector;
    public Transform spawnZone;

 DataPrecistentManager dataPrecistent;


    public void Start()
    {
        dataPrecistent = GameObject.Find("DataPrecistent").GetComponent<DataPrecistentManager>();
        GameManager.Instance.currentGame.InitLevelStat(levelData);
       
    }   

    public void Update()
    {
        if (levelLoader)
            LoadLevelData(levelData);

    }

    public void LoadLevelData(LevelData data)
    {
        materialOpenLevel = levelData.materialOpenLevel;
        materialFinishLevel = levelData.materialFinishLevel;

        dataPrecistent.LevelDataNeedKey = levelData.levelKey;
        dataPrecistent.LevelDatalevel = levelData.level;
        dataPrecistent.LevelDataFlag = levelData.levelFlag;
        dataPrecistent.LevelDataTimer = levelData.levelTime;
       // levelData.spawnData.transform.position = spawnZone.transform.position;
        GameManager.Instance.currentGame.spawnZone = spawnZone.gameObject;
        GameManager.Instance.currentGame.spawnZone.transform.position = spawnZone.transform.position;
    }
}
