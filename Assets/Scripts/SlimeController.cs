using UnityEditor.XR;
using UnityEngine;
using UnityEngine.AI;

public class SlimeController : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;

    public float stopDistane = 1f;
    public float detectionRange = 10f;

    Animator anim;
    bool isPlayerInRange = false;
    bool hasReachePlayer = false;

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
            if (distance < stopDistane)
            {
                StopMoveing();
                hasReachePlayer = true;
            }
            else
            {
                MoveToPlayer();
                hasReachePlayer= false;
            }
        }
        else
        {
            StopMoveing();
        }
        UpdateAnimation();
    }

    void MoveToPlayer()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.SetDestination(player.transform.position);
            hasReachePlayer = false;
        }
    }

    void StopMoveing()
    {
        if (agent.isActiveAndEnabled)
        {
            agent.ResetPath();
            hasReachePlayer = true;
        }
    }

    void UpdateAnimation()
    {
        anim.SetBool("Attack", hasReachePlayer);
    }
}