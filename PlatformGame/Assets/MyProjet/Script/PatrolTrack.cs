using System.Collections.Generic;
using UnityEngine;

public class PatrolTrack : MonoBehaviour
{
    public List<Transform> patrolPoints;

 public int pointCount
    {
        get
        {
            return patrolPoints.Count;
         }
 }

    void Awake()
    {
        foreach (Transform point in transform)  // pour chaque enfants de ce transform je l'ajoute dans la liste  

        {
            patrolPoints.Add(point);
        }
    }
}
