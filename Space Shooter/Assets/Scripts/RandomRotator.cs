using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
