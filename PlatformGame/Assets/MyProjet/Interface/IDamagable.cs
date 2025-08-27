using UnityEngine;

public interface IDamagable
{
    void OnDamaged(int damage);

    bool isAlive { get; }

    void OnDead();
    
    
}
