using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.velocity = transform.forward * speed;
    }
}
