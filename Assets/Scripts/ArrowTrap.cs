using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Rockets;
    private float cooldownTimer;

    private void Attack()
    {
        cooldownTimer = 0;

        Rockets[FindRockets()].transform.position = firePoint.position;
        Rockets[FindRockets()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindRockets()
    {
        for (int i = 0; i < Rockets.Length; i++)
        {
            if (!Rockets[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
            Attack();
    }
}
