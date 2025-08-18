using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class IHM : MonoBehaviour
{

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        coinsText.text = currentGame.coins.ToString();
        keyText.text = currentGame.key.ToString();
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
