using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookRotate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    void Start()
    {
        target = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = -35;
        eulerAngles.z = 0;
        transform.rotation = Quaternion.Euler(eulerAngles);
    }
}
