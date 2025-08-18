using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public int levelKey;
    public int level;
    public int levelTime;
    public Material materialCloseLevel;
    public Material materialOpenLevel;
    public Material materialFinishLevel;
    
    
}
