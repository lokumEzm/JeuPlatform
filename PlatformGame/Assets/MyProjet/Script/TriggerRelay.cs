using UnityEngine;
using UnityEngine.Events;

public class TriggerRelay : MonoBehaviour
{
    public delegate void TriggerDel(Collider other);

    public TriggerDel onTriggerEnterEvent;
    public TriggerDel onTriggerStayEvent;
    public TriggerDel onTriggerExitEvent;


    void OnTriggerEnter(Collider other)
    {
        if (onTriggerEnterEvent != null)
            onTriggerEnterEvent(other);
    }


    void OnTriggerStay(Collider other)
    {
        if (onTriggerStayEvent != null)
            onTriggerStayEvent(other);
    }


    void OnTriggerExit(Collider other)
    {
        if (onTriggerExitEvent != null)
            onTriggerExitEvent(other);
    }
}
