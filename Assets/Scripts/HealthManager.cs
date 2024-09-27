using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health;

    [SerializeField]
    Image healthBar;

    private void Start()
    {
        healthBar.fillAmount = health/100;
    }
    public void GainHealth(float healthAmount)
    { 
        health += healthAmount;
        if (health > 100)
        { 
            health = 100;
        }
        healthBar.fillAmount = health / 100;
    }

    public void LoseHealth(float healthAmount)
    {
        health -= healthAmount;
        if (health < 0)
        {
            health = 0;
        }
        healthBar.fillAmount = health / 100;
        
    }
}
