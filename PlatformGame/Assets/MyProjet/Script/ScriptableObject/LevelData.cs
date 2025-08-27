using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public int levelKey;
    public int level;
    public int levelTime;
    public int levelFlag;
    public Material materialOpenLevel;
    public Material materialFinishLevel;
    public GameObject spawnData; 
}
