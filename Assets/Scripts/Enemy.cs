using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    LayerMask whatIsPlayer;

    [SerializeField]
    float atackRange;
    [SerializeField]
    float atackRate;
    [SerializeField]
    GameObject enemyBullet;
    [SerializeField]
    Transform bulletOrigin;

    bool playerInAtackRange;
    float atackContdown = 0f;

    private void Update()
    {
        playerInAtackRange = Physics.CheckSphere(transform.position, atackRange, whatIsPlayer);
        atackContdown -= Time.deltaTime;

        if (playerInAtackRange) AtackPLayer();
    }

    private void AtackPLayer()
    {
        FaceTarget();
        shoot();
    }

    private void shoot()
    {
        if (atackContdown <= 0f)
        {
            atackContdown = 1f / atackRate;

            GameObject newBullet = Instantiate(enemyBullet, bulletOrigin.position, Quaternion.identity);
            newBullet.transform.forward = transform.forward.normalized;
            /*audioSource.clip = audioClip;
            audioSource.pitch = Random.Range(0.6f, 1.1f);
            audioSource.Play();*/
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atackRange);
    }
}
