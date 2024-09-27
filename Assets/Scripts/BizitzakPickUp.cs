using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float speed;
    private bool isActivated;

    public float healtAmount;
    private void Update()
    {
        if (!isActivated)
        { 
            transform.eulerAngles += new Vector3(0, speed, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GetComponent<HealthManager>().GainHealth(healtAmount);
            isActivated = true;
            transform.parent = other.transform.parent;

            Sequence s = DOTween.Sequence();

            s.Append(transform.DORotate(new Vector3(0,0, -900), 3f, RotateMode.LocalAxisAdd));
            s.Append(transform.DOScale(0, 0.5f).SetDelay(1f));
            s.AppendCallback(() => Destroy(gameObject));
        }
    }
}
