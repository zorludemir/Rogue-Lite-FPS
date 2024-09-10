using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float attackRange = 2f;
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;
    public GameObject xpObject;
    private bool canAttack;
    private Transform target;

    private Renderer enemyRenderer;
    private Color originalColor;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        enemyRenderer = GetComponent<Renderer>();
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    public virtual void FollowPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }

    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        StopAllCoroutines();
        StartCoroutine(BlinkOnDamage());

        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator BlinkOnDamage()
    {
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = Color.white;
        }

        yield return new WaitForSeconds(0.05f);

        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = originalColor;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
        if (canAttack)
        {
            StartCoroutine(attackenum());
        }
    }

    public virtual IEnumerator attackenum()
    {
        canAttack = false;
        Player.Instance.TakeDamage(damage);
        yield return new WaitForSeconds(1);
        canAttack = true;
    }

    protected virtual void Die()
    {
        Debug.Log("Enemy has died.");
        Instantiate(xpObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
