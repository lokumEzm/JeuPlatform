using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    Transform destination;
    Animation anim;
    public GameObject player;

    public Camera cameraPos;

    void Awake()
    {
        cameraPos = GameObject.Find("Main Camera").GetComponent<Camera>();
        anim = GameObject.Find("SK_Knockout_Character").GetComponent<Animation>();
    }


    void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Player") && other.TryGetComponent<PlayerController2DNew>(out var player))

        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalIn());
        }

        {


           // player.TelePort(destination.position, destination.rotation);

        }
    }

    IEnumerator PortalIn()
    {
        anim.Play("PortalIn");
        SoundManager.Instance.PlaySound3D("Teleport", cameraPos.transform.position);
        yield return new WaitForSeconds(2);
        player.transform.position = destination.position;
        anim.Play("PortalOut");
    }

    
    void OnDrawGizmos()
    {

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(destination.position, 0.4f);

        var direction = destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(destination.position, direction);
    }
}