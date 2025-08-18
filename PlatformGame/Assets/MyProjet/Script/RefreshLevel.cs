using UnityEngine;

public class RefreshLevel : MonoBehaviour
{
 CurrentGame currentGame
    {
        get
        {
            return GameManager.Instance.currentGame;
        }
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
            Debug.Log(currentGame.key + " -> " + "->" + i);


            if (currentGame.key == lvlKey.GetComponent<LevelSelector>().levelKey)
            {
                Debug.Log(currentGame.key);
                Debug.Log(currentGame.key + " -> " + lvlKey + "->" + i + " Level Debloqué");
                lvlKey.GetComponent<LevelSelector>().activatorBc.SetActive(true);
                lvlKey.GetComponent<MeshRenderer>().material = lvlKey.GetComponent<LevelSelector>().materialOpenLevel;
                lvlKey.GetComponent<LevelSelector>().door.GetComponent<Animator>().SetTrigger("Open");
                lvlKey.GetComponent<LevelSelector>().cam.SetActive(true);
                Debug.Log("Open");
            }
            else
            {
                lvlKey.GetComponent<LevelSelector>().activatorBc.SetActive(false);
                lvlKey.GetComponent<MeshRenderer>().material = lvlKey.GetComponent<LevelSelector>().materialCloseLevel;
                lvlKey.GetComponent<LevelSelector>().cam.SetActive(false);
                Debug.Log("Close");
            }

            if (currentGame.key > lvlKey.GetComponent<LevelSelector>().levelKey)
            {
                lvlKey.GetComponent<MeshRenderer>().material = lvlKey.GetComponent<LevelSelector>().materialFinishLevel;
                lvlKey.GetComponent<LevelSelector>().door.GetComponent<Animator>().SetTrigger("Open");
                Debug.Log("Close");
            }
        }
        GameManager.Instance.uiRefresh.Invoke();
    }
}
