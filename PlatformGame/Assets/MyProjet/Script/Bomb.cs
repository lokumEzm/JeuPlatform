using UnityEngine;

public class Bomb : MonoBehaviour
{
   public Transform handL;
    public GameObject bombPrefab;
   public Camera cam;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(bombPrefab, handL.transform);
            SoundManager.Instance.PlaySound3D("Key", cam.transform.position);

            Destroy(gameObject);
        }
    }
}