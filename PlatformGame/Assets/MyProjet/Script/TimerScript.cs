using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timerText;

    [SerializeField]
    TextMeshProUGUI chronoText;

    float elapsedTime;

    [SerializeField]
    float remainingTime;


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
    }
}
