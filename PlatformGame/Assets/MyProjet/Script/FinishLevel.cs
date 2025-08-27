using System.Collections;
using TMPro;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    DataPrecistentManager dataPrecistent;

    public TextMeshProUGUI coinsValue;
    public TextMeshProUGUI keyValue;
    public TextMeshProUGUI timerValue;
    public GameObject player;


    void Start()
    {
        dataPrecistent = GameObject.Find("DataPrecistent").GetComponent<DataPrecistentManager>();
        Statistics();
    }


    void Statistics()
    {
        coinsValue.text = GameManager.Instance.currentGame.currentCoins.ToString();
        keyValue.text = GameManager.Instance.currentGame.currentKey.ToString();
        timerValue.text = GameManager.Instance.currentGame.currentTime.ToString();

        StartCoroutine(WaitTimer());
    }

    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(1.5f);
        SpawnPlayer();
    }


    public void SpawnPlayer()
    {
        GameManager.Instance.currentGame.currentCoins = 0;
        GameManager.Instance.currentGame.currentKey = 0;
        GameManager.Instance.currentGame.currentTime = 0;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.55f;
        GameManager.Instance.Refresh.Invoke();

        player.transform.position = GameManager.Instance.currentGame.spawnZone.transform.position;





    }

    public void ContinueButton()
    {

        //   if (Input.GetKeyDown(KeyCode.Space))
        Time.timeScale = 1f;
        GameManager.Instance.stopMove = false;
        player.transform.position = GameManager.Instance.currentGame.spawnZone.transform.position;
        GameManager.Instance.Refresh.Invoke();
        gameObject.SetActive(false);

    }
}
