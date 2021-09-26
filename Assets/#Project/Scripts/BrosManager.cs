using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]        // prendez le reflex du requirecomponent! 
public class BrosManager : MonoBehaviour
{
    public NavMeshAgent agent;

    public List<TargetPoint> targetPoints = new List<TargetPoint>();
    public int indexNextDestination = 0;
    public Vector3 actualDestination;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = Random.Range(1f, 10f);
        NextDestination();
    }

    // Update is called once per frame
    void Update()
    {

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
        }
    }

    void NextDestination()
    {
        int oldIndex = indexNextDestination;
        while (oldIndex == indexNextDestination && targetPoints.Count > 1)
        {
            indexNextDestination = Random.Range(0, targetPoints.Count);
            //print(indexNextDestination);

        }

        actualDestination = targetPoints[indexNextDestination].GivePoint();
        agent.SetDestination(actualDestination);

        // indexNextDestination++;
        // if (indexNextDestination >= targetPoints.Count) indexNextDestination = 0;
    }

    private void OnDrawGizmos()
    {
        if (agent != null)
        {
            Gizmos.color = new Color(0f, 0f, 1f, 0.5f);
            Gizmos.DrawSphere(transform.position + Vector3.up * 5,
            0.5f + (100 - agent.avoidancePriority) * 0.01f);

        }
    }

}