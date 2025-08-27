using UnityEngine;

public class RefreshLevel : MonoBehaviour
{
    DataPrecistentManager dataPrecistent;


    void Awake()
    {
        dataPrecistent = GameObject.Find("DataPrecistent").GetComponent<DataPrecistentManager>();

    }
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        var lvl = GameManager.Instance.level;
        for (int i = 0; i < lvl.Length; i++)
        {
            var lvlKey = GameManager.Instance.level[i];

            if (dataPrecistent.Key == lvlKey.GetComponent<LevelSelector>().needKeyLevel)
            {
                lvlKey.GetComponent<LevelSelector>().StartLevelActivatorBc.SetActive(true);
                lvlKey.GetComponent<LevelSelector>().door.GetComponent<Animator>().SetBool("Bool",true);
                Debug.Log("Open");
            }
            else
            {
                 lvlKey.GetComponent<LevelSelector>().StartLevelActivatorBc.SetActive(false);
                lvlKey.GetComponent<LevelSelector>().door.GetComponent<Animator>().SetBool("Bool",false);
            }       
        }
        GameManager.Instance.uiRefresh.Invoke();
    }
}
