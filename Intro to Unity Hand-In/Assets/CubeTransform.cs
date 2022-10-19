using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTransform : MonoBehaviour
{
    float velocity;
    Vector3 Vector;
    
    void Start()
    {
       
    }

    void Update()
    {
        Vector = transform.localPosition;  
        Vector.y += Input.GetAxis("Jump") * Time.deltaTime * 20;  
        Vector.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;  
        Vector.z += Input.GetAxis("Vertical") * Time.deltaTime * 20;  
        transform.localPosition = Vector;     

    }
}
