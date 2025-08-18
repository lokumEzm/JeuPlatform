using System.Collections;
using UnityEngine;

public class SpikeRollerController : MonoBehaviour
{
    public Transform positionIntantiate;
    public GameObject prefab;

    void Start()
    {
        InstantiateObject();
    }

    public void InstantiateObject()
    {

        StartCoroutine(InstantiateObject1());
    }

    IEnumerator InstantiateObject1()
    {
        yield return new WaitForSeconds(6);
        Instantiate(prefab, positionIntantiate);

        StartCoroutine(InstantiateObject2());
    }
    
     IEnumerator InstantiateObject2()
    {
        yield return new WaitForSeconds(6);
        Instantiate(prefab, positionIntantiate);
         
          StartCoroutine(InstantiateObject1());  
    }

}

