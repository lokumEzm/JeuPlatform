using UnityEngine;

public class Lamp : MonoBehaviour
{
   public Transform handL;
    public GameObject lampPrefab;
   public Camera cam;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(lampPrefab, handL.transform);
            SoundManager.Instance.PlaySound3D("Key", cam.transform.position);

            Destroy(gameObject);
        }
    }
}