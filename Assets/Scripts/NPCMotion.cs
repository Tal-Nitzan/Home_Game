using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class NPCMotion : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Animator animator;
    private LineRenderer lr;
    public NPCMotion npcRef;
    bool wait_flag = true;
    private float time = float.MaxValue;


    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        npcRef = GetComponent<NPCMotion>();
        animator.SetBool("isWalking", true);
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;
        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
        if (destPoint == 3)
        {
            wait_flag = true;
        }
    }


    void Update () {
        if (Time.time - time >= 2f)
        {
            agent.isStopped = false;
            animator.SetBool("inPlace", false);
        }
        // Choose the next destination point when the agent gets
        // close to the current one.
        lr.positionCount = agent.path.corners.Length;
        for (int i=0; i<agent.path.corners.Length; i++)
        {
            lr.SetPosition(i, agent.path.corners[i]);
        }
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (destPoint == 2 && wait_flag == true)
            {
                wait_flag = false;
                time = Time.time;
                agent.isStopped = true;
                animator.SetBool("inPlace", true);

            }
            GotoNextPoint();
        }
    }
}