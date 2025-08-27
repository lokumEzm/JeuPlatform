using UnityEngine;

public class SunDoor : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.night = false;
            GameManager.Instance.day = true;
        }
    }
}
