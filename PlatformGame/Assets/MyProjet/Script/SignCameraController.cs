using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class SignCameraController : MonoBehaviour
{
    public LevelData levelData;
    LevelStat levelStat;
    public GameObject camerasign;

    public TextMeshPro levelName;
    public TextMeshPro level;
    public TextMeshPro timer;
    public TextMeshPro key;


    void Start()
    {
        levelName.text = levelData.levelName;
        level.text = levelData.level.ToString();
        key.text = levelData.levelKey.ToString();

        timer.text = levelData.levelTime.ToString();

        levelStat = GameManager.Instance.currentGame.GetLevelStat(levelData.level);


	}
    void OnTriggerEnter(Collider other)
    {
        /*
        if (!other.CompareTag("Player")) return;
        if (GameManager.Instance.currentGame.currentKey < levelData.levelKey)
        {
            StartCoroutine(ExecuteTimer());
        }*/

    }

    public void ShowSign()
    {
		StartCoroutine(ExecuteTimer());

	}
	IEnumerator ExecuteTimer()
    {
        camerasign.SetActive(true);
        yield return new WaitForSeconds(3);
                camerasign.SetActive(false);
    }


}
