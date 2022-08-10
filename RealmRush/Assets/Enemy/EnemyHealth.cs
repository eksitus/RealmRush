using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;

    [SerializeField] int currentHitPoint = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoint = maxHitPoint;
    }

    private void OnParticleCollision(GameObject other)
    {

        ProcessHit();
        
    }

    void ProcessHit()
    {
        currentHitPoint--;
        if (currentHitPoint<=0)
        {
            Destroy(gameObject);
        }
    }
}
