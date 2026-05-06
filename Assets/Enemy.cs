using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] private float turnSpeed = 10;
    [SerializeField] private Transform[] Endpoints;
    private int EndpointIndex; 

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.avoidancePriority = Mathf.RoundToInt(agent.speed * 10);
    }

    private void Start()
    {
        Endpoints = FindFirstObjectByType<EndPointManage>().GetEndPoints();
    }

    private void Update()
    {

        FaceTarget(agent.steeringTarget);

        // Check if the agent has reached its destination
        if(agent.remainingDistance < 0.5f)
        {
            // sets the next destination for the agent
            agent.SetDestination(GetNextEndpoint());
        }
    }

    private void FaceTarget(Vector3 newTarget)
    {
        // Gets the calculaion for direction to the next target, from the current postion.
       Vector3 directionToTarget = newTarget - transform.position;
       directionToTarget.y = 0;

        //
       Quaternion newRotation = Quaternion.LookRotation(directionToTarget);

       transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, turnSpeed * Time.deltaTime);
    }

    private Vector3 GetNextEndpoint()
    {
        if (EndpointIndex >= Endpoints.Length)
        {   
            EndpointIndex = 0;
            //return transform.position;
        }

       Vector3 targetPoint = Endpoints[EndpointIndex].position;
       EndpointIndex = EndpointIndex + 1;

       return targetPoint;
        
    }

} 