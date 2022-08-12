using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;

    [Tooltip("Adds amount to Max Hit Point when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;


    int currentHitPoint = 0;
    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        /* Use OnEnable instead of Start in order to reset the object
        * and spawn with maxHitPoint again.
        */
        currentHitPoint = maxHitPoint;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
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
            maxHitPoint += difficultyRamp;
            enemy.RewardGold();
        }
    }



}
