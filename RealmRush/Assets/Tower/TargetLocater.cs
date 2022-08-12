using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticle;

    Transform target;

    

    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

   

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {

            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance<maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
            
        }

        target = closestTarget;

    }
    void AimWeapon()
    {

        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

        weapon.LookAt(target);


    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;       
    }

}
