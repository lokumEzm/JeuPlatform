using UnityEngine;

public class Rock : MonoBehaviour
{
   public Transform positionBomb;
    public GameObject rockPrefab;
   public Camera cam;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb" ))
        {
          //  Instantiate(rockPrefab, positionBomb.transform);
            SoundManager.Instance.PlaySound3D("Key", cam.transform.position);
            Debug.Log("Explosed");
            Destroy(gameObject);
        }
    }
}