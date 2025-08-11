using UnityEngine;

public class PlayerCollectSystem : MonoBehaviour
{
    void Start()
    {

    }

    void OTriggerEnter(Collider other)
    {
        ICollectable icollectable = other.gameObject.GetComponent<ICollectable>();
        Debug.Log(icollectable);
        if (icollectable == null)
            return;

        icollectable.OnCollect();
    }

}
