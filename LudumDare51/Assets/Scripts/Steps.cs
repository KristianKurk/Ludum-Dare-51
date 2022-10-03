using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    public AudioSource step;
    float oldposition_X;
    float oldposition_Z;
    void Start()
    {
        step.enabled = true;
        oldposition_X = 0;
        oldposition_Z = 0;
    }
    

    void Update()
    {
        
        if (transform.position.x != oldposition_X || transform.position.z != oldposition_Z)
        {
            step.enabled = true;
        }
        else
        {
            step.enabled = false;
        }
        oldposition_Z = transform.position.z;
        oldposition_X = transform.position.x;
    }
}
