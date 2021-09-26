using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]        // prenez le reflex du requirecomponent! 
public class TobyManager : MonoBehaviour
{
    private NavMeshAgent Toby;

    public List<TargetPoint> targetPoints = new List<TargetPoint>();
    private int indexNextDestination = 0;
    private Vector3 actualDestination;



    void Start()
    {
        Toby = GetComponent<NavMeshAgent>();
        Toby.speed = Random.Range(5f, 7f);
        NextDestination();
    }

    // Update is called once per frame
    void Update()
    {

        if (Toby.remainingDistance <= Toby.stoppingDistance)
        {
            NextDestination();
        }
    }

    private void NextDestination()
    {
        actualDestination = targetPoints[indexNextDestination].GivePoint();
        Toby.SetDestination(actualDestination);

        indexNextDestination++;
        if (indexNextDestination >= targetPoints.Count) indexNextDestination = 0;

    }



}