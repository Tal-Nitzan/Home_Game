using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{

    private CharacterController controller;
    private float speed = 0.08f;
    private float angularSpeed = 1f;
    private float rx = 0f, ry;
    public GameObject playerCamera; // Public allows to init this object FROM UNITY

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Simple Motion
        //transform.Translate(new Vector3(0, 0, 0.01f));
        float dx, dz;

        // mouse input
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        playerCamera.transform.localEulerAngles = new Vector3(rx,0,0); // runs on playerCamera
        // ry is horizontal rotation
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed;
        transform.localEulerAngles = new Vector3(0, ry, 0);


        // keyboard input
        dx = Input.GetAxis("Horizontal")*speed;
        dz = Input.GetAxis("Vertical")*speed;
        Vector3 motion = new Vector3(dx,0,dz);
        motion = transform.TransformDirection(motion); // Now in global coordinates.
        controller.Move(motion);



    }
}
