using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int scareDistance = 3;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Image scareImage;
    [SerializeField] private int initialViewDistance = 10;
    [SerializeField] private int patrolRange = 5;

    private NavMeshAgent agent;
    private Vector3 patrolDestination;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetRandomPatrolDestination();
        InvokeRepeating(nameof(SetRandomPatrolDestination), 3f, 3f);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

        if (distanceToPlayer <= initialViewDistance)
        {
            agent.SetDestination(playerTarget.position);
        }
        else
        {
            agent.SetDestination(patrolDestination);
        }

        if (distanceToPlayer <= scareDistance)
        {
            TriggerScare();
        }
    }

    private void SetRandomPatrolDestination()
    {
        patrolDestination = transform.position + new Vector3(
            Random.Range(-1f, 1f) * patrolRange,
            0,
            Random.Range(-1f, 1f) * patrolRange
        );
    }

    private void TriggerScare()
    {
        scareImage.gameObject.SetActive(true);
        this.enabled = false;
    }

    public void AdjustDifficulty(int pagesCollected)
    {
        int distanceIncrement = 10;
        float speedIncrement = 0.5f;

        initialViewDistance = 10 + (pagesCollected * distanceIncrement);
        patrolRange += pagesCollected * 5;

        agent.speed += speedIncrement * pagesCollected;
    }
}
