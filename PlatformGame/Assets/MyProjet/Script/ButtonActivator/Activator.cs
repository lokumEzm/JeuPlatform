using UnityEngine;
using UnityEngine.Events;



public class Activator : MonoBehaviour
{
    public UnityEvent Actions;
   


    void OnTriggerEnter(Collider other)
    {
        Actions.Invoke();
    }
   
}

