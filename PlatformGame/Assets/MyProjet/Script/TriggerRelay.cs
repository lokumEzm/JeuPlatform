using UnityEngine;
using UnityEngine.Events;

public class TriggerRelay : MonoBehaviour
{
    public delegate void TriggerDel(Collider other);

    public TriggerDel onTriggerEnterDel;
    public TriggerDel onTriggerStayDel;
    public TriggerDel onTriggerExitDel;

	public UnityEvent onTriggerEnterEvent;
	public UnityEvent onTriggerExitEvent;
	public UnityEvent onTriggerStayEvent;




	void OnTriggerEnter(Collider other)
    {
        if (onTriggerEnterDel != null)
            onTriggerEnterDel(other);

		onTriggerEnterEvent.Invoke();

	}


    void OnTriggerStay(Collider other)
    {
        if (onTriggerStayDel != null)
            onTriggerStayDel(other);

		onTriggerStayEvent.Invoke();

	}


    void OnTriggerExit(Collider other)
    {
        if (onTriggerExitDel != null)
            onTriggerExitDel(other);

		onTriggerExitEvent.Invoke();

	}
}
