using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour, IDamagable
{
    [SerializeField]
    LifeManager lifeManager;
     public GameObject deathEffect;
    public UnityEvent onDamage;


    public bool isAlive
    {
        get
        {
            return lifeManager.currentLife > 0;
        }
    }

    public void OnDamaged(int damage)
    {

        onDamage.Invoke();
            }

    public void OnDied()
    {
       Destroy(gameObject);

        if (gameObject.CompareTag("Player"))
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }
}
