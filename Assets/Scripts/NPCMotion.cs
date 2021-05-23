using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMotion : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject destination;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("updating..");
        if (agent.enabled)
        {
            agent.SetDestination(destination.transform.position); // The path has been computed
        }

        if (Vector3.Distance(agent.destination, transform.position) <= agent.stoppingDistance)
        {
            animator.SetBool("isWalking", false);
            agent.isStopped = true;
            Debug.Log("Got the door");
            // other.GetComponent<OpenDoor>().OnTriggerEnter();
        }
    }

    private void SetDestination(Vector3 target)
    {
        animator.SetBool("isWalking", true);
        agent.SetDestination(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Im here");
            animator.SetBool("isWalking", false);
            agent.isStopped = true;
            // other.GetComponent<OpenDoor>().TrigDoor();
        }
    }
}
