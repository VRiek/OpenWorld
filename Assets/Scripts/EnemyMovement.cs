using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    public enum StateMachine
    {
        Idle,
        Engage
    }

    public StateMachine currentState;
    public float speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("EnemyMovement.cs: Player not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case StateMachine.Idle:
                Idle();
                break;
            case StateMachine.Engage:
                Engage();
                break;
        }

        bool playerSeen = Vector3.Distance(transform.position, player.position) < 50f;

        if (!playerSeen && currentState != StateMachine.Idle)
        {
            currentState = StateMachine.Idle;
        }
        else if (playerSeen && currentState != StateMachine.Engage)
        {
            currentState = StateMachine.Engage;
        }
    }

    void Idle()
    {
        //Debug.Log("Enemy is idling.");
        return;
    }

    void Engage()
    {
        //Debug.Log("Enemy is engaging.");
        navMeshAgent.SetDestination(player.position);
    }
}
