using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform weaponHead;
    [SerializeField] private ParticleSystem projectileParticles;
    [SerializeField] private float range = 15f;

    private Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
        FindTarget();
        AimWeapon();
    }

    private void FindTarget() 
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies) 
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance) 
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    private void AimWeapon() 
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weaponHead.LookAt(target);

        if (targetDistance < range)
        {
            EnableAttack(true);
        }
        else 
        {
            EnableAttack(false);
        }
    }

    private void EnableAttack(bool isActive) 
    {
        var emissionModule = projectileParticles.emission;

        emissionModule.enabled = isActive;
    }
}
