using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    public float missileSpeed;

    private Transform target;

    public Transform Target { get => target; set => target = value; }

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * missileSpeed;
    }

    private void LateUpdate()
    {
        gameObject.transform.LookAt(Target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
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
