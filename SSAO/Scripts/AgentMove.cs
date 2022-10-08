﻿ 
using UnityEngine;
using System.Collections;
 
public class AgentMove : MonoBehaviour
{

    float h;
    float v;
    public float speed = 2;
    public float turnSpeed = 4;
    public Transform camTransform;
    Vector3 movement;
    Vector3 camForward;

    void Start()
    {
        Application.targetFrameRate=60;
    }

    void Update()
    {
        Move();
        
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        
        transform.Translate(camTransform.right * h * speed * Time.deltaTime + camForward * v * speed * Time.deltaTime, Space.World);
        if (h != 0 || v != 0)
        {
            Rotating(h, v);
        }
    }

    void Rotating(float hh, float vv)
    {
        camForward = Vector3.Cross(camTransform.right, Vector3.up);  
        Vector3 targetDir = camTransform.right * hh + camForward * vv;  
        Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up); 
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}