using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    public GameObject cam;

    public enum Behaviour
    {
        freeze, unfreeze
    }

    public Behaviour behaviour;



    public void SetBehaviour(Collider other)
    {
        switch (behaviour)
        {
            case Behaviour.freeze:
                Freeze(other);
                break;

            case Behaviour.unfreeze:
                UnFreeze(other);
                break;

        }
    }

    void Freeze(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            Debug.Log("Collision");
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        }
    }

    void UnFreeze(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            rb.constraints = rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            Debug.Log("Collision");
        }
    }




    void OnTriggerEnter(Collider other)
    {
        SetBehaviour(other);
    }


}