using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class IHM : MonoBehaviour
{
    DataPrecistentManager dataPrecistent;
    public static IHM instance;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI timerText;

    List<GameObject> lifesGo;

    CurrentGame currentGame
    {
        get
        {
            return GameManager.Instance.currentGame;
        }
    }

	private void Awake()
	{
		instance = this;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {

        dataPrecistent = GameObject.Find("DataPrecistent").GetComponent<DataPrecistentManager>();

        currentGame.playerLifeManager.currentLife = currentGame.playerLifeManager.startLife;
        InitLife();
        RefreshUI();

    }

    public void RefreshUI()
    {
        DisplayLife();
        DisplayCoin();

    }

    public void DisplayLife()
    {
        foreach (GameObject life in lifesGo)
            life.SetActive(false);

        for (int i = 0; i < currentGame.playerLifeManager.currentLife; i++)
        {
            lifesGo[i].SetActive(true);
        }
    }

    public void DisplayCoin()
    {
        coinsText.text = currentGame.coinsCount.ToString();
        keyText.text = dataPrecistent.Key.ToString();
    }

    public void InitLife()
    {
        lifesGo = new List<GameObject>();

        for (int i = 0; i < currentGame.playerLifeManager.startLife; i++)
        {
            lifesGo.Add(Instantiate(GameManager.Instance.lifes, GameManager.Instance.positionIntantiate));
        }

        Debug.Log("Refreched :)");
    }
}
