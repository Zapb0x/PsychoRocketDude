using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Rockets;
    [SerializeField] private AudioClip gunshotSound;

    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(gunshotSound);
        cooldownTimer = 0;

        Rockets[FindRocket()].transform.position = firePoint.position;
        Rockets[FindRocket()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindRocket()
    {
        for (int i = 0; i < Rockets.Length; i++)
        {
            if (!Rockets[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
