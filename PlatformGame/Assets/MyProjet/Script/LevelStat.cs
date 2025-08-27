using UnityEngine;
[System.Serializable]
public class LevelStat
{

	public string levelName { get { return refLevelData.levelName; } }
	public LevelSatus levelSatus;
	public int level { get { return refLevelData.level; } }
	public float playerTime = 100000;
	public int collectedCoinsCount;

	public LevelData refLevelData;

	public LevelStat(LevelData refLevelData)
	{
		this.refLevelData = refLevelData;
	}
}

public enum LevelSatus
{
	Complete,
	Uncomplete
}
