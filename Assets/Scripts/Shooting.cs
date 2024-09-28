using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Bullet shooting")]
    [Space]
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletOrigin;

    [Header("Missile shooting")]
    [Space]
    public float sphereRadius;
    public float maxDistance;
    private float currentDistance;

    public LayerMask targetMask;
    public GameObject missile;
    public Transform missileOrigin;
    public List<GameObject> targetList = new List<GameObject>();

    [Header("Audio stuff")]
    [Space]
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (targetList.Any())
            {
                FireHomingMissiles();
            }
        }
        LockInTargets();
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, bulletOrigin.position, Quaternion.identity);
        newBullet.transform.forward = transform.forward.normalized;
        audioSource.clip = audioClip;
        audioSource.pitch = Random.Range(.6f, 1.1f);
        audioSource.Play();
    }

    void LockInTargets()
    {
        if (Physics.SphereCast(transform.position, sphereRadius, transform.forward, out RaycastHit hit, maxDistance, targetMask))
        {
            currentDistance = hit.distance;
            GameObject hitObject = hit.transform.gameObject;
            if (!targetList.Contains(hitObject))
            {
                targetList.Add(hitObject);

                if (hitObject.GetComponent<TargetedAnimation>())
                {
                    hit.transform.gameObject.GetComponent<TargetedAnimation>().Targeted(true);
                }
            }
        }
        else
        {
            currentDistance = maxDistance;
        }
    }

    void FireHomingMissiles()
    {
        for (int i = 0; i < targetList.Count; i++)
        {
            if (targetList[i] != null)
            {
                GameObject newMissile = Instantiate(missile, missileOrigin.position, Quaternion.identity);
                newMissile.GetComponent<HomingMissile>().Target = targetList[i].transform;
            }
        }
        targetList.Clear();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * currentDistance);
        Gizmos.DrawWireSphere(transform.position + transform.forward * currentDistance, sphereRadius);
    }
}
