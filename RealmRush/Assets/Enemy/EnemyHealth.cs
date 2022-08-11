using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;

    [SerializeField] int currentHitPoint = 0;

    

    // Start is called before the first frame update
    void OnEnable()
    {
        /* Use OnEnable instead of Start in order to reset the object
        * and spawn with maxHitPoint again.
        */
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
            gameObject.SetActive(false); // if we destroy, gameobject won't return to pool
        }
    }
}
