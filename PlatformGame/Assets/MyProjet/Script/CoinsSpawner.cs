using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{

    [SerializeField]
    List<CoinInfo> coinsInfo;

    [SerializeField]
    GameObject coinPrefab;



    void Start()
    {
        SpawnRandomCoin();
    }

    void SpawnRandomCoin()
    {
        int index = Random.Range(0, coinsInfo.Count);
        GameObject instance = Instantiate(coinPrefab, this.transform);

        instance.transform.localPosition = Vector3.zero;
        var coinCotroller = instance.GetComponent<CoinsController>();
        coinCotroller.Init(coinsInfo[index]);

    }

    [System.Serializable]
    public class CoinInfo
    {
        public string name;
        public int value;
        public Material material;
    }
}


