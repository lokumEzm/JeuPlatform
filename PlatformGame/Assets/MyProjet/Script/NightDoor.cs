using System.Collections;
using UnityEngine;

public class NightDoor : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.night = true;
            GameManager.Instance.day = false;
        }
    }
}