using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private CinemachineDollyCart dollyCart;
    [SerializeField]
    private float enemySpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SetSpeed(enemySpeed);
        }
    }

    private void SetSpeed(float Speed)
    {
        dollyCart.m_Speed = Speed;
    }
}
