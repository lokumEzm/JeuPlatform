using UnityEngine;

public class CoinsController : MonoBehaviour, ICollectable
{
    public int coinValue = 1;

    public void OnCollect()
    {
        Debug.Log("Piece collecté");
        GameManager.Instance.currentGame.coins++;
        GameManager.Instance.uiRefresh.Invoke();
        Destroy(gameObject);
    }

    void Start()
    {

    }

}
