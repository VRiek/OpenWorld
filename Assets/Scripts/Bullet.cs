using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    private int bulletDamage = 1;
    private new Rigidbody rigidbody;
    public GameObject enemy;

    private void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Fire(Vector3 direction)
    {
        rigidbody.linearVelocity = direction * speed;
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == enemy)
        {
            EnemyStats enemyStats = collision.transform.parent.GetComponent<EnemyStats>();

            if (enemyStats != null)
            {
                enemyStats.TakeDamage(bulletDamage);
                Debug.Log($"Enemy hit! Health: {enemyStats.health}");
            }
            else
            {
                Debug.LogWarning("Bullet.cs: EnemyStats component not found on the parent.");
            }
        }

        Destroy(gameObject);
    }
}
