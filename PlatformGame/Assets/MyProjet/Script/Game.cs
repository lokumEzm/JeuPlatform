using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Game
{
    public int remainingLife = 4;
    public float maxLife = 4;
    public int currentLevel =0;
    public int key = 0;
    public int time;
    public int coins;

    [Header("Life")]
    public GameObject lifes;
    public Transform positionIntantiate;

    public float lifeRate
    {
        get
        {
            return remainingLife / maxLife;
        }
    }
}
