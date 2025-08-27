using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI chronoText;

    float elapsedTime;


    void Update()
    {

        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
		chronoText.text = string.Format("{0:00} : {1:00}", minutes, seconds);


    }

}
