using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]        // prenez le reflex du requirecomponent! 
public class SimonManager : MonoBehaviour
{
    private NavMeshAgent Simon;
    private Vector3 actualDestination;
    public Transform Toby;
    public Transform Edgar;
    private int rando;

    //public Transform Edgar;


    void Start()
    {
        Simon = GetComponent<NavMeshAgent>();
        Simon.speed = Random.Range(1f, 6f);
        NextDestination();

    }

    // Update is called once per frame
    void Update()
    {
        if (Simon.remainingDistance <= Simon.stoppingDistance)
        {
            NextDestination();
        }

    }

    private void NextDestination()
    {
        rando = Random.Range(1, 3);
        
        if (rando == 1){

        actualDestination = Toby.position;
        Simon.SetDestination(actualDestination);
        }
        else {
            actualDestination = Edgar.position;
            Simon.SetDestination(actualDestination);
        }
        Debug.Log(rando);


    }



}