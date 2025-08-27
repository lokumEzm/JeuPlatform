using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.transform.parent.GetComponent<LifeManager>().SetDamage(1);

        }
    }
}
