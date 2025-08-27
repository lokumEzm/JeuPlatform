using System.Collections;
using TMPro;
using UnityEngine;

public class SignCameraController : MonoBehaviour
{
    public LevelData levelData;
    public GameObject camerasign;

    public TextMeshPro levelName;
    public TextMeshPro level;
    public TextMeshPro timer;
    public TextMeshPro key;

    DataPrecistentManager dataPrecistent;

    void Start()
    {
        dataPrecistent = GameObject.Find("DataPrecistent").GetComponent<DataPrecistentManager>();
        levelName.text = levelData.levelName;
        level.text = levelData.level.ToString();
        key.text = levelData.levelKey.ToString();

        timer.text = levelData.levelTime.ToString();

    }
    void OnTriggerEnter(Collider other)
    {
        if (dataPrecistent.LevelDataNeedKey > dataPrecistent.Key)
        {
            StartCoroutine(ExecuteTimer());
        }
           

    }
    IEnumerator ExecuteTimer()
    {
        camerasign.SetActive(true);
        yield return new WaitForSeconds(3);
                camerasign.SetActive(false);
    }


    void Update()
    {

    }
}
