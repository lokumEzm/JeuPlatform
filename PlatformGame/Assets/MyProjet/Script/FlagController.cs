using UnityEngine;

public class FlagController : MonoBehaviour, ICollectable
{
  DataPrecistentManager dataPrecistent;
  [SerializeField]
  LevelData levelData;
  public int flagValue = 1;

  public GameObject cameraPos;

  void Start()
  {
  }
  public void OnCollect()
  {
    LevelStat levelStats = GameManager.Instance.currentGame.GetLevelStat(levelData.level);

    
    GameManager.Instance.stopMove = true;
    dataPrecistent.hSlevel1Timer = levelData.levelTime - dataPrecistent.timer;
    GameManager.Instance.currentGame.currentTime = dataPrecistent.LevelDataTimer - dataPrecistent.timer;

    float tim = PlayerPrefs.GetFloat("LevelRecord" + dataPrecistent.LevelDatalevel);

    if (dataPrecistent.hSlevel1Timer < tim)
    {
      GameManager.Instance.stopMove = true;
      PlayerPrefs.SetFloat("LevelRecord" + dataPrecistent.LevelDatalevel, dataPrecistent.hSlevel1Timer);
      GameManager.Instance.newRecord.Invoke();
      Debug.Log("New Record !!!");
    }
    else
    {
       GameManager.Instance.stopMove = true;
      GameManager.Instance.noRcord.Invoke();
      Debug.Log("Pas de Record");
    }
    SoundManager.Instance.PlaySound3D("Flag", cameraPos.transform.position);
    dataPrecistent.flag ++;
    GameManager.Instance.Refresh.Invoke();
    Destroy(gameObject);
  }
}
