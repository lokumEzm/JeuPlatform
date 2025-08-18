using System.Linq;
using TMPro;
using UnityEngine;

public class IHM : MonoBehaviour
{

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI timerText;

    Game currentGame
    {
        get
        {
            return GameManager.Instance.currentGame;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Refresh()
    {

        DisplayLife();
        DisplayCoin();

    }

    public void DisplayLife()
    {

    }

    public void DisplayCoin()
    {
        coinsText.text = currentGame.coins.ToString();
        keyText.text = currentGame.key.ToString();
    }   
}
