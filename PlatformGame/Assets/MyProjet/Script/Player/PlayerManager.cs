using System.Collections;
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
        Debug.Log("Player -1");
    }

    public void OnDead()
    {


        if (gameObject.CompareTag("Player"))
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            StartCoroutine(WaitTime());
        }

        IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(2);
                        gameObject.transform.position = GameManager.Instance.currentGame.spawnZone.transform.position;


        }
    }
}
