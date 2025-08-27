using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IAbeahviour : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    TriggerRelay triggerRelay;
    [SerializeField]
    NavMeshAgent agent;
      [SerializeField]
    PatrolTrack patrolTrack;
    public enum PatrolType
    {

        FollowPoint, RandomPoint
    }

    public PatrolType patrolType;
    delegate IEnumerator PatrolCoroutDel();

    PatrolCoroutDel patrolCoroutDel;

    Coroutine activeCorout;

    void Start()
    {
        triggerRelay.onTriggerEnterDel += OnTriggerEnter;
        StartPatrol();
    }

   public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        StopCoroutine(activeCorout);
        activeCorout = StartCoroutine(ChaseCorout(other.transform.root.gameObject));    
    }

	public void OnTriggerExit(Collider other)
	{
		if (!other.CompareTag("Player")) return;

		if (activeCorout != null)StopCoroutine(activeCorout);
        StartPatrol();
	}

	void StartPatrol()
    {
        switch (patrolType)
        {
            case PatrolType.FollowPoint:
                patrolCoroutDel = FollowPointCorout;
                break;

            case PatrolType.RandomPoint:
                patrolCoroutDel = PatrolRandomCorout;
                break;
        }
        activeCorout = StartCoroutine(patrolCoroutDel());
    }

    IEnumerator PatrolRandomCorout()
    {
        int index = 0;

        while (true)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Attack", false);
            index = UnityEngine.Random.Range(0, patrolTrack.pointCount);

            agent.SetDestination(patrolTrack.patrolPoints[index].position);
            while (agent.pathPending) yield return null;
            while (agent.remainingDistance > agent.stoppingDistance)
            {
                yield return null;
            }
            yield return null;
        }


    }

    IEnumerator FollowPointCorout()
    {
        while (true)
        {
           
            anim.SetBool("Walk", true);
            anim.SetBool("Attack", false);
            for (int i = 0; i < patrolTrack.pointCount; i++)
            {
                agent.SetDestination(patrolTrack.patrolPoints[i].position);
                while (agent.pathPending) yield return null;
                while (agent.remainingDistance > agent.stoppingDistance)
                {
                    yield return null;
                }
                //  if (i == patrolTrack.patrolPoints.Count - 1)

            }
            yield return null;
        }


    }

    IEnumerator ChaseCorout(GameObject target)
    {

        while (true)
        {
            agent.SetDestination(target.transform.position);

            if (agent.remainingDistance < agent.stoppingDistance + 0.2f)
            {
                anim.SetBool("Attack", true);
                anim.SetBool("Walk", false);
                LifeManager lifeManager = target.GetComponent<LifeManager>();

                if (lifeManager != null)
                    lifeManager.SetDamage(1);
                yield return new WaitForSeconds(3);
                 anim.SetBool("Walk", true);
                anim.SetBool("Attack", false);

            }

            yield return null;
        }
    }

}
