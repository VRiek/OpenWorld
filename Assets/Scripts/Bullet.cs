using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Fire(Vector3 direction)
    {
        rigidbody.linearVelocity = direction * speed;
        Destroy(gameObject, 2f);
    }
}
