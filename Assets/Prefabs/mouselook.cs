using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mousesens =100f;
    public Transform playerb;
    float xrotation = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesens * Time.deltaTime;
        
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xrotation,0f,0f);
        playerb.Rotate(Vector3.up * mouseX);
    }
}
