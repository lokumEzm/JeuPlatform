using UnityEngine;

public class PlayerCollectSystem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        ICollectable icollectable = other.gameObject.GetComponent<ICollectable>();
        if (icollectable == null)
            return;
        icollectable.OnCollect();
    }
}