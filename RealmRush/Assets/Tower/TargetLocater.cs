using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;

    Transform target;

    private void Start()
    {

        target = FindObjectOfType<EnemyMover>().transform;
    }

    private void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        weapon.transform.LookAt(target);
    }
}
