using UnityEngine;

public class CoinsController : MonoBehaviour, ICollectable
{
    DataPrecistentManager dataPrecistent;

    public CoinsSpawner.CoinInfo coinInfo;
    public MeshRenderer meshRenderer;
    public Camera cameraPos;

    void Awake()
    {
        dataPrecistent = GameObject.Find("DataPrecistent").GetComponent<DataPrecistentManager>();

        cameraPos = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void Init(CoinsSpawner.CoinInfo coinInfo)
    {
        this.coinInfo = coinInfo;
        meshRenderer.material = coinInfo.material;
    }

    public void OnCollect()
    {
        dataPrecistent.coins += coinInfo.value; // on Ajoute la valeur du Coin dans l'inventaire.

        var inlvl = GameManager.Instance.inLevel;

        if(inlvl)
        GameManager.Instance.currentGame.currentCoins += coinInfo.value;
        
        GameManager.Instance.Refresh.Invoke();  // Refresh 
        SoundManager.Instance.PlaySound3D("CoinsCollect", cameraPos.transform.position); // On joue un son quand on touche la piece
        Destroy(gameObject);  // on detruit l 'objext
    }
}