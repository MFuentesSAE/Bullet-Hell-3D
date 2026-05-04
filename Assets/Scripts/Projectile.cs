using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;
    public Rigidbody rb;
    private Coroutine lifetimeRoutine;
    private float damage;

    public void SetDamage(float amount)
    {
        damage = amount;
    }

    private void OnEnable()
    {
        rb.linearVelocity = Vector3.zero;

        if (lifetimeRoutine != null)
            StopCoroutine(lifetimeRoutine);

        lifetimeRoutine = StartCoroutine(LifetimeRoutine());
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy == null)
            enemy = collision.gameObject.GetComponentInParent<EnemyHealth>();

        enemy?.TakeDamage(damage);

        gameObject.SetActive(false);// Desactivar el objeto en lugar de destruirlo, para que "regresen" a su pool
    }

    IEnumerator LifetimeRoutine()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }
}
