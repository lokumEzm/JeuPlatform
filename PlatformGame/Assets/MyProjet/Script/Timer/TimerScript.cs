using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
      DataPrecistentManager dataPrecistent;

    [SerializeField]
    TextMeshProUGUI timerText;

    [SerializeField]
    TextMeshProUGUI chronoText;

    public GameObject ChronoImage;

    float elapsedTime;

    [SerializeField]
    float remainingTime;

    void Start()
    {
            dataPrecistent = GameObject.Find("DataPrecistent").GetComponent<DataPrecistentManager>();

    }

    public void StartTimer()
    {
        remainingTime = GetComponent<LevelSelector>().levelTimer;
    }


    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            chronoText.color = Color.red;
        }

        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);


        int chMinutes = Mathf.FloorToInt(remainingTime / 60);
        int chSeconds = Mathf.FloorToInt(remainingTime % 60);
        chronoText.text = string.Format("{0:00} : {1:00}", chMinutes, chSeconds);

        dataPrecistent.timer = remainingTime;
    }
}
