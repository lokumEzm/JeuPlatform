using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CurrentGame
{
        public LifeManager playerLifeManager;
        public int currentCoins;
        public int currentKey;
        public float currentTime;
        public float currentLevel;
        public GameObject spawnZone;

        public Dictionary<int, LevelStat> playerLevelStats;

        public void InitLevelStat(LevelData levelData)
        {
                if (playerLevelStats == null)
                        playerLevelStats = new Dictionary<int, LevelStat>();
                LevelStat levelStat = new LevelStat(levelData);
                playerLevelStats.Add(levelStat.level, levelStat);
        }

        public LevelStat GetLevelStat(int levelIndex)
        {
                LevelStat result = null;
                playerLevelStats.TryGetValue(levelIndex, out result);
                return result;
        }
}
