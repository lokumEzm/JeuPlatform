using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "/" + other.tag);
        if (other.CompareTag("Enemy"))
        {
            other.transform.parent.GetComponent<LifeManager>().SetDamage(1);

        }
    }
}
