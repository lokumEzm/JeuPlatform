using UnityEngine;
using UnityEngine.Animations;

public class MonsterManager : MonoBehaviour, IDamagable
{
    [SerializeField]
    LifeManager lifeManager;
    public GameObject deathEffect;

    public bool isAlive
    {
        get
        {
            return lifeManager.currentLife > 0;
        }
    }

    public void OnDamaged(int damage)
    {

        Debug.Log("Enemy-1" + gameObject);
        Debug.Log(lifeManager.currentLife + "/ " + gameObject.name);
    }

    public void OnDead()
    {
        Debug.Log("Enemy_Dead" + gameObject);
       
             
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
             PlayerController3D.Instance.Bounce();
        
    }
}
