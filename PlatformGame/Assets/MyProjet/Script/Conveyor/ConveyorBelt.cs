using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public Vector3 direction;
    public List<GameObject> onBelt;
    public float speed;
    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i <= onBelt.Count - 1; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().linearVelocity = speed * direction * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        {
            onBelt.Add(collision.gameObject);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        {
            onBelt.Remove(collision.gameObject);
        }

    }

    public void StopConvoyer()
    {
        speed = 0;
    }

    // Update is called once per frame

}
