using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]        // prenez le reflex du requirecomponent! 
public class EdgarManager : MonoBehaviour
{
    private NavMeshAgent Edgar;

    public List<Transform> targetPoints = new List<Transform>();
    private int indexNextDestination = 0;
    private Vector3 actualDestination;



    void Start()
    {
        Edgar = GetComponent<NavMeshAgent>();
        Edgar.speed = Random.Range(5f, 10f);
        NextDestination();
    }

    // Update is called once per frame
    void Update()
    {

        if (Edgar.remainingDistance <= Edgar.stoppingDistance)
        {
            NextDestination();
        }
    }

    private void NextDestination()
    {
        int oldIndex = indexNextDestination;
        while (oldIndex == indexNextDestination && targetPoints.Count > 1)
        {
            indexNextDestination = Random.Range(0, targetPoints.Count);
            //print(indexNextDestination);

        }

        actualDestination = targetPoints[indexNextDestination].position;
        Edgar.SetDestination(actualDestination);

    }



}