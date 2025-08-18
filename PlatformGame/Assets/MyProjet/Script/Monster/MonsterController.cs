using UnityEngine;
using UnityEngine.Animations;

public class MonsterController : MonoBehaviour, IDamagable
{
    [SerializeField]
    LifeManager lifeManager;
    public GameObject deathEffect;
    PlayerController playerController;

    public bool isAlive
    {
        get
        {
            return lifeManager.currentLife > 0;
        }
    }

    public void OnDamaged(int damage)
    {

        Debug.Log("Damaged" + gameObject);
        Debug.Log(lifeManager.currentLife +"/ "+ gameObject.name);
    }

    public void OnDied()
    {
        Destroy(transform.parent.gameObject);

        if (gameObject.CompareTag("Enemy"))
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            PlayerController.Instance.Bounce();
        }


    }
}
