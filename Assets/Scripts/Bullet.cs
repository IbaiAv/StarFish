using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float bulletSpeed;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Kendu bizitza playerari
            GameManager.Instance.GetComponent<HealthManager>().LoseHealth(10);

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
