using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpenDoor : MonoBehaviour
{

    // public float animationDuration;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // public void TrigDoor()
    // {
    //     Debug.Log("openning the door");
    //     // this.animator.SetBool("open", true);
    //     this.animator.SetTrigger("OpenDoor");
    // }


    public void OnTriggerEnter(Collider other)
    {
        animator.SetBool("open", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
