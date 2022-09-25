using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyLOS : MonoBehaviour
{
    [SerializeField] float idleDist = 10f;
    [SerializeField] float followDist = 5f;
    [SerializeField] float attackDist = 0.6f;

    private EnemyStates state;
    private AIPath pathing;
    private AIDestinationSetter destination;

    private float distFromTar;

    // Start is called before the first frame update
    void Start()
    {
        pathing = GetComponent<AIPath>();
        destination = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
        ChangeBehavior();
    }

    private void CheckForPlayer()
    {
        distFromTar = Vector2.Distance(transform.position, destination.target.position);

        if (distFromTar > idleDist)
        {
            state = EnemyStates.idle;
        }
        else if (distFromTar <= followDist)
        {
            state = EnemyStates.following;
        }

        if (distFromTar <= attackDist)
        {
            state = EnemyStates.attacking;
        }
    }

    private void ChangeBehavior()
    {
        switch (state)
        {
            case EnemyStates.idle:
                pathing.canMove = false;
                break;

            case EnemyStates.following:
                pathing.canMove = true;
                break;

            case EnemyStates.attacking:
                pathing.canMove = false;
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, idleDist);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followDist);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDist);
    }
}