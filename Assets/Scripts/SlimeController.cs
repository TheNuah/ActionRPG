using UnityEngine;
using UnityEngine.AI;   

public class SlimeController : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;

    public float stopDistance = 1f;
    public float detectionRange = 10f;

    Animator anim;
    bool isPlayerInRange = false;
    bool isPlayerClose = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        isPlayerInRange = distance <= detectionRange;
        isPlayerClose = distance <= stopDistance;

        if (isPlayerInRange)
        {
            if (isPlayerClose)
            {
                StopMoving();
            }
            else
            {
                MoveToPlayer();
            }
        }
        else
        {
            StopMoving();
        }

        UpdateAnimation(distance);
    }

    void MoveToPlayer()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    void StopMoving()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.ResetPath();
        }
    }

    void UpdateAnimation(float distance)
    {
        anim.SetBool("Attack", isPlayerClose);
        bool shouldWalk = isPlayerInRange && !isPlayerClose;
        anim.SetBool("Walk", shouldWalk);

        // Log for debugging
        Debug.Log($"Slime Animation: Walk={shouldWalk}, Attack={isPlayerClose}, Distance={distance}");
    }
}
