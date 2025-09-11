using UnityEngine;
using UnityEngine.AI;   

public class slimecontroller : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;

    public float stopDistance = 1.0f;   
    public float detectionRange = 10.0f;

    Animator anim;
    bool isPlayerInRange = false;
    bool hasReachedPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        isPlayerInRange = distance <= detectionRange;
        if (isPlayerInRange)
        {
            if (distance <= stopDistance)
            {
                StopMoving();
                hasReachedPlayer = true;
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
        UpdateAnimation();
    }
    void MoveToPlayer()
    {
        if (isActiveAndEnabled) 
        {
            agent.SetDestination(player.transform.position);
            hasReachedPlayer = false;
        }
            
    }

    void StopMoving()
    {
            if (agent.isActiveAndEnabled)
            {
                agent.ResetPath();
                hasReachedPlayer = true;
            }
    }
    void UpdateAnimation()
    {
        anim.SetBool("isRunning", true); 
    }
}