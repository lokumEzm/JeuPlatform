using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public string levelName;
    public int level;
    public int levelKey;
    public int levelTime;
    public LevelData levelData;
    public GameObject activatorBc;
    public GameObject door;
    public GameObject cam;

     public Material materialCloseLevel;
    public Material materialOpenLevel;
    public Material materialFinishLevel;
    public Camera cameraLevelSelector;



    public void Start()
    {
        if (levelData != null)
        {
            LoadLevelData(levelData);
        }
    }

    public void LoadLevelData(LevelData data)
    {
        levelName = levelData.levelName;
        level = levelData.level;
        levelKey = levelData.levelKey;
        levelTime = levelData.levelTime;
        materialCloseLevel = levelData.materialCloseLevel;
        materialOpenLevel = levelData.materialOpenLevel;  
         materialFinishLevel= levelData.materialFinishLevel;  
    }
}
