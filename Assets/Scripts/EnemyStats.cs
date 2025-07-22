using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health = 3f;
    private Renderer enemyRenderer;
    private bool isFlashing = false;
    private Color originalColor;
    private float flashDuration = 0.1f;
    public Logic logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Enemy"))
            {
                enemyRenderer = child.GetComponent<Renderer>();
                if (enemyRenderer != null )
                {
                    originalColor = enemyRenderer.material.color;
                }
                break;
            }
            
        }

        if (enemyRenderer == null)
        {
            Debug.LogError("No child with 'Enemy' tag found");
        }
    }

    public void TakeDamage(float damage)
    {
        if (enemyRenderer != null && !isFlashing)
        {
            StartCoroutine(FlashRed());
        }

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator FlashRed()
    {
        isFlashing = true;
        enemyRenderer.material.color = Color.red;

        yield return new WaitForSeconds(flashDuration);

        enemyRenderer.material.color = originalColor;
        isFlashing = false;
    }

    private void Die()
    {
        Destroy(gameObject);

        //Score updated by 1 when killing an enemy.
        logic.setScoreText(1);
    }
}
