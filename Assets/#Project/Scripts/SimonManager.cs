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
    //public Transform Edgar;
    private int rando;

    //public Transform Edgar;


    void Start()
    {
        Simon = GetComponent<NavMeshAgent>();
        Simon.speed = Random.Range(1f, 6f);


    }

    // Update is called once per frame
    void Update()
    {
        Simon.SetDestination(Toby.position);


    }





}