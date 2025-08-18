using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    Transform destination;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<PlayerController2D>(out var player))
            player.TelePort(destination.position, destination.rotation);
    }
    void OnDrawGizmos()
    {

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(destination.position,0.4f);

        var direction = destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(destination.position, direction);
    }
}