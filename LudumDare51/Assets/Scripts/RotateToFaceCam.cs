using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToFaceCam : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        target = Camera.main.transform;
    }

    void Update()
    {
        Quaternion newRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = new Quaternion(transform.rotation.x, newRotation.y, transform.rotation.z, transform.rotation.w);
    }
}
