using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f; 
    public Vector3 Velocity;
    public Transform groundcheck;
    public float groundarea = 0.4f;
    public LayerMask groundmask;
    private bool isground;
    public float jh = 3f;
    public float r = 2f;


    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        isground = Physics.CheckSphere(groundcheck.position,groundarea,groundmask);
        if(isground && Velocity.y <0)
        {
            Velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump") && isground)
        {
            Velocity.y = Mathf.Sqrt(jh * -2f * gravity);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed *Time.deltaTime);
        Velocity.y += gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.R))
        {
            speed = speed*r;
        }
        if(Input.GetKeyUp(KeyCode.R))
        {
            speed = speed/r;
        }
    }
}
