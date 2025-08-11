using UnityEngine;

public class CoinsController : MonoBehaviour,ICollectable
{
    public int coinValue = 1;

    public void OnCollect()
    {
        Debug.Log("Piece collecté");
    }

    void Start()
    {
        
    }

}
