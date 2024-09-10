using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPscript : MonoBehaviour
{
    Transform target;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, 20 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Player.Instance.IncreaseXP(5);
            Destroy(gameObject);
        }
    }
}
