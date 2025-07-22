using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public Logic logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            AudioManager.Instance.PlaySFX("Collect");
            Destroy(other.gameObject);
            logic.setScoreText(1);
        }
        else
        {
            Debug.Log("Joku muu tag");
        }
    }
}
