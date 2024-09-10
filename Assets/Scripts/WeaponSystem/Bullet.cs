using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public virtual void Launch(Vector3 direction, float speed)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().TakeDamage(Player.Instance.CalculateDamage());
        }
        Destroy(gameObject);
    }
}
