using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] SkeletonAnimationController animationController;
    public SkeletonAnimationController AnimationController => animationController;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform myTransform;
    public Transform MyTransform => myTransform;
    [SerializeField] Transform[] patrolPoints;

    bool isPatrolling;
    Vector3 previousDestination;
    Vector3 destination;
    Vector3 direction;
    Vector3[] patrolPositions;
    List<Vector3> nextPatrolPositions = new();

    private void OnValidate()
    {
        if (myTransform == null)
        {
            myTransform = transform;
        }
    }

    private void Start()
    {
        patrolPositions = new Vector3[patrolPoints.Length];

        for (int i = 0; i < patrolPoints.Length; i++)
        {
            patrolPositions[i] = patrolPoints[i].position;
        }

        StartPatrol();
    }

    private void Update()
    {
        if (isPatrolling)
        {
            Patrolling();
        }
    }

    void Patrolling()
    {
        if (ReachDestination())
        {
            destination = nextPatrolPositions.Random();
            nextPatrolPositions.Remove(destination);
            nextPatrolPositions.Add(previousDestination);
            previousDestination = destination;
            direction = (destination - myTransform.position).normalized;
            ChangeDirection(direction.x);
        }
        else
        {
            myTransform.position += moveSpeed * Time.deltaTime * direction;
        }
    }

    bool ReachDestination()
    {
        return Vector3.Distance(myTransform.position, destination) < 0.1f;
    }

    void ChangeDirection(float x)
    {
        float sign = Mathf.Sign(x);
        myTransform.localScale = new Vector3(sign, 1, 1);
    }

    public void StartPatrol()
    {
        nextPatrolPositions.Clear();

        for (int i = 0; i < patrolPositions.Length; i++)
        {
            nextPatrolPositions.Add(patrolPositions[i]);
        }

        destination = patrolPositions.Random();
        previousDestination = destination;
        nextPatrolPositions.Remove(destination);
        direction = (destination - myTransform.position).normalized;
        ChangeDirection(direction.x);
        isPatrolling = true;

        animationController.SetAnimation(0, "Walk_01", true);
    }

    public void StopPatrol()
    {
        isPatrolling = false;
    }
}
