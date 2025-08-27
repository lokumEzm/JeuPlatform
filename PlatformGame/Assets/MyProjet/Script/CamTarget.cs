using UnityEngine;

[ExecuteAlways]
public class CamTarget : MonoBehaviour
{
    [SerializeField]
    GameObject focusPoint;

    void Update()
    {
        if (focusPoint != null)
            transform.LookAt(focusPoint.transform.position);
    }
}
