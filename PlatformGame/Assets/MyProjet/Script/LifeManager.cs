using System.Collections;
using UnityEngine;
//reandentation
public class LifeManager : MonoBehaviour
{
    [SerializeField]
    public int startLife = 4;
    public int currentLife;

    IDamagable iDamageable;

    public float lifeRate
    {
        get
        {
            return (float)currentLife / (float)startLife;
        }
    }

    void Start()
    {
        currentLife = startLife;
        iDamageable = GetComponent<IDamagable>();
    }

    public void SetDamage(int damage)
    {
        StartCoroutine(DegatPause(damage));


        if (currentLife <= 0)
        {
            currentLife = 0;
            iDamageable.OnDead();

        }
        else
        {
            iDamageable.OnDamaged(damage);
        }

    }

    IEnumerator DegatPause(int damage)
    {
        currentLife -= damage;
        Debug.Log("Touché");
        yield return new WaitForSeconds(2);

    }


}
