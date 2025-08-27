using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public LevelData levelData;
    public LevelStat levelStat
    {
        get
        {
            return GameManager.Instance.currentGame.GetLevelStat(levelData.level);
        }
    }

    public GameObject StartLevelActivatorBc;
    public GameObject levelLoaderBc;
    public bool levelLoader;
    public GameObject door;

    public Material materialOpenLevel;
    public Material materialFinishLevel;
    public Camera cameraLevelSelector;
    public Transform spawnZone;

 DataPrecistentManager dataPrecistent;


    public void Awake()
    {
        dataPrecistent = GameObject.Find("DataPrecistent").GetComponent<DataPrecistentManager>();
        GameManager.Instance.currentGame.InitLevelStat(levelData);
		LoadLevelData(levelData);
	}   


    public void LoadLevelData(LevelData data)
    {
        materialOpenLevel = levelData.materialOpenLevel;
        materialFinishLevel = levelData.materialFinishLevel;

       // levelData.spawnData.transform.position = spawnZone.transform.position;
        GameManager.Instance.currentGame.spawnZone = spawnZone.gameObject;
        GameManager.Instance.currentGame.spawnZone.transform.position = spawnZone.transform.position;
    }
}
