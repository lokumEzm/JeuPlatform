using UnityEngine;
using UnityEngine.Events;



public class Activator : MonoBehaviour
{
    public UnityEvent Actions;
   


    void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlaySound3D("Interrupt", transform.position);
        Actions.Invoke();
    }
   
}

