using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;

    int currentHitPoint = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoint = maxHitPoint;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Before hit: " + currentHitPoint);
        currentHitPoint--;
        Debug.Log("After hit: " + currentHitPoint);
    }
}
