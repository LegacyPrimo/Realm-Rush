using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 5f;
    [SerializeField] private float currentHealth;

    [Tooltip("Adds amount to max HitPoints when Enemy Dies")]
    [SerializeField] private float difficultyRamp = 1f;

    private Enemy enemy;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHitPoints();
    }

    private void ProcessHitPoints() 
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            enemy.RewardCurrency();
            maxHealth += difficultyRamp;
            gameObject.SetActive(false);

        }
    }
}
